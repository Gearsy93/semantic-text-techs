using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;

public static class Program
{
    public static bool isValid = true;
    static void Main(string[] args)
    {
        //1.В разработанном формате представить расписание текущей недели
        String filename = "WeekTable.xml";
        String filenameDTD = "WeekTable_DTD.xml";
        String filenameXSD = "WeekTable_XSD.xsd";
        String filenameTXTXSLT = "WeekTable_TXT.xsl";
        String filenameTXT_out = "WeekTable_TXT.txt";
        String filenameHTMLXSLT = "WeekTable_HTML.xsl";
        String filenameHTML_out = "WeekTable_HTML.HTML";

        XDocument weekTable = XDocument.Load(filename);

        //2.a Получить все занятия на данной неделе
        //var lessons = weekTable.XPathSelectElements("//Lesson");
        //foreach (XElement lesson in lessons)
        //{
        //    Console.WriteLine(lesson.Element("stLessonType").Value + " | " + lesson.Element("stSubjectName").Value + " | " + lesson.Element("stTutorInit").Value);
        //}

        //2.b Получить все аудитории, в которых проходят занятия.
        //var audiences = weekTable.XPathSelectElements("//stClassroom").Select(x => x.Value).Distinct();
        //foreach (string auditorium in audiences)
        //{
        //    Console.WriteLine(auditorium);
        //}

        //2.c Получить все практические занятия на неделе
        //var lessons = weekTable.XPathSelectElements("//Lesson").Where(x => x.Element("stLessonType").Value == "Практика");
        //foreach (XElement lesson in lessons)
        //{
        //    Console.WriteLine(lesson.Element("stLessonType").Value + " | " + lesson.Element("stSubjectName").Value + " | " + lesson.Element("stTutorInit").Value);
        //}

        //2.d Получить все лекции, проводимые в указанной аудитории.
        //String audience_num = "425/5 (424)";
        //var lectures = weekTable.XPathSelectElements("//Lesson").Where(x => x.Element("stLessonType").Value == "Лекция" && x.Element("stClassroom").Value == audience_num);
        //foreach (XElement lecture in lectures)
        //{
        //    Console.WriteLine(lecture.Element("stLessonType").Value + " | " + lecture.Element("stSubjectName").Value + " | " + lecture.Element("stTutorInit").Value + " | " + audience_num);
        //}
        //2.e Получить список всех преподавателей, проводящих практики в указанной аудитории !!
        //String audience_num = "425/5 (424)";
        //var Tutors = weekTable.Where(x => x.Element("stLessonType").Value == "Практика" && x.Element("stClassroom").Value == audience_num).Select(x => x.Element("stTutorInit"));
        //foreach (XElement tutor in Tutors)
        //{
        //    Console.WriteLine(tutor.Value);
        //}
        //2.f Получить последнее занятие для каждого дня делели

        //var lessons = weekTable.Elements().Elements();
        //foreach (XElement lesson in lessons)
        //{
        //    if (lesson.HasElements == false) continue;
        //    var lastlesson = lesson.Elements().Last();
        //    Console.WriteLine(lastlesson.Element("stLessonType").Value + " | " + lastlesson.Element("stSubjectName").Value + " | " + lastlesson.Element("stTutorInit").Value + " | " + lastlesson.Element("dtLessonStart").Value);

        //    }
        //2.g Получить общее количество занятий за всю неделю
        //var lessonsCount = weekTable.XPathSelectElements("//Lesson").Count();
        //Console.WriteLine(lessonsCount.ToString());

        //3 Описать DTD схему для разработанного формата. Произвести валидацию xml-документа.

        //XmlReaderSettings settings = new XmlReaderSettings();
        //settings.DtdProcessing = DtdProcessing.Parse;
        //settings.ValidationType = ValidationType.DTD;
        //settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

        //XmlReader reader = XmlReader.Create(filenameDTD, settings);
        //while (reader.Read()) ;
        //reader.Close();

        //if (isValid)
        //    Console.WriteLine("Document is valid");
        //else
        //    Console.WriteLine("Document is invalid");

        // 4 Описать XML Schema для разработанного формата. Произвести валидацию xml-документа.

        isValid = true;
        XmlSchemaSet tableSchema = new XmlSchemaSet();
        tableSchema.Add("", XmlReader.Create(filenameXSD));
        weekTable.Validate(tableSchema, new ValidationEventHandler(ValidationCallBack));
        if (isValid)
            Console.WriteLine("Document is valid");
        else
            Console.WriteLine("Document is invalid");

        // 5 Описать XSLT-преобразование xml-документа в текстовый вид (*.txt).
        //XslCompiledTransform TableToTxt = new XslCompiledTransform();
        //TableToTxt.Load(filenameTXTXSLT);
        //TableToTxt.Transform(XmlReader.Create(filename), XmlWriter.Create(filenameTXT_out, new XmlWriterSettings()
        //{ ConformanceLevel = ConformanceLevel.Auto }));

        //6 Описать XSLT-преобразование xml-документа в html-страницу (расписание должно быть представлено в виде таблицы)
        //XslCompiledTransform TableToTxt = new XslCompiledTransform();
        //TableToTxt.Load(filenameHTMLXSLT);
        //TableToTxt.Transform(XmlReader.Create(filename), XmlWriter.Create(filenameHTML_out, new XmlWriterSettings()
        //{ ConformanceLevel = ConformanceLevel.Auto }));


    }

    private static void ValidationCallBack(object sender, ValidationEventArgs e)
    {
        //On Not Valid
        isValid = false;
        Console.WriteLine("Validation Error: " + e.Message);
    }

    private static void booksSettingsValidationEventHandler(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Warning)
        {
            Console.Write("WARNING: ");
            Console.WriteLine(e.Message);
        }
        else if (e.Severity == XmlSeverityType.Error)
        {
            Console.Write("ERROR: ");
            Console.WriteLine(e.Message);
        }
    }
}