import re
import roman
input_file = "num.txt"

# читаем файл
file = open(input_file,'r', encoding='utf-8')
try:
    txt = file.read()
finally:
    file.close()
 
# выбираем слова через регулярные выражения
p = re.compile("^(?=[MDCLXVI])M*(C[MD]|D?C*)(X[CL]|L?X*)(I[XV]|V?I*)$")
res=p.findall(txt)
 
# переводим в число
lsWord = {}
for ln in res:
    for key in ln:
        if not(key == ''):
            key = key.upper()
            if not(key in lsWord):
                lsWord[key]=roman.fromRoman(key)

num=0
for key in lsWord:
    num=num+lsWord[key]
    
print(str("{0}: {1}").format(txt,num))