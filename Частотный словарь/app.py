import collections
import string

import pymorphy2
import nltk
from langdetect import detect
from nltk.corpus import stopwords


def save(output, tag):
    output.write('{0} {1}\n'.format(tag[0], tag[1]))


if __name__ == '__main__':
    # Read text
    f = open('./data/input.txt', 'r')
    source = f.read()
    stop_words = set(stopwords.words('english') + stopwords.words('russian'))

    # Tokenize text
    tokens = nltk.wordpunct_tokenize(source)
    tokens = [i for i in tokens if (i not in string.punctuation and i.lower() not in stop_words)]

    # Analyze each word
    morph = pymorphy2.MorphAnalyzer()
    tags = [morph.parse(i) for i in tokens]
    # Calculate frequencies of words
    ordered = collections.OrderedDict(
        sorted(
            collections.Counter([t[0].normal_form for t in tags]).items(),
            key=lambda t2: t2[1],
            reverse=True
        )
    )

    # Save result
    out = open('./data/output.txt', 'w')
    for v in ordered:
        save(out, (v, ordered[v]))
    out.close()

    stemmer_en = nltk.SnowballStemmer('english')
    stemmer_ru = nltk.SnowballStemmer('russian')

    singles = [stemmer_ru.stem(plural_ru) for plural_ru in tokens if detect(plural_ru) == 'ru'] +\
              [stemmer_en.stem(plural_en) for plural_en in tokens if detect(plural_en) == 'en']
    ordered_stem = collections.OrderedDict(
        sorted(
            collections.Counter([t for t in singles]).items(),
            key=lambda t2: t2[1],
            reverse=True
        )
    )
    out = open('./data/output_stem.txt', 'w')
    for v in ordered_stem:
        save(out, (v, ordered_stem[v]))
    out.close()
    f.close()

