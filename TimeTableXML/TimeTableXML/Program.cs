using System;
using System.Xml.Serialization;

public class Program
{
    public class Lesson
    {
        public String stSubjectName;
        public String stTutorInit;
        public String stClassroom;
        public String stLessonType;
        public String dtLessonStart;
        public String dtLessonEnd;



        public Lesson() { }

        public Lesson(string stSubjectName, string stTutorInit, string stClassroom, string stLessonType, String dtLessonStart, String dtLessonEnd)
        {
            this.stSubjectName = stSubjectName;
            this.stTutorInit = stTutorInit;
            this.stClassroom = stClassroom;
            this.stLessonType = stLessonType;
            this.dtLessonStart = dtLessonStart;
            this.dtLessonEnd = dtLessonEnd;
        }   
    }

    public class WeekTable
    {
        public List<Lesson> llMonday;
        public List<Lesson> llTuesday;
        public List<Lesson> llWednesday;
        public List<Lesson> llThursday;
        public List<Lesson> llFriday;
            
        public List<Lesson> llSaturday;
        public List<Lesson> llSunday;

        public WeekTable() { }
        public WeekTable(List<Lesson> llMonday, List<Lesson> llTuesday, List<Lesson> llWednesday, List<Lesson> llThursday, List<Lesson> llFriday, List<Lesson> llSaturday, List<Lesson> llSunday)
        {
            this.llMonday = llMonday;
            this.llTuesday = llTuesday;
            this.llWednesday = llWednesday;
            this.llThursday = llThursday;
            this.llFriday = llFriday;
            this.llSaturday = llSaturday;
            this.llSunday = llSunday;
        }
    }

    static void Main(string[] args)
    {
        List<Lesson> llMonday = new List<Lesson>()
        {
            new Lesson
            (
                "Web-программирование",
                "Чумаков Р.В.",
                "125/5 (22)",
                "Лекция",
                "8:00",
                 "9:35"),
            new Lesson
            (
                "Web-программирование",
                "Чумаков Р.В.",
                "242/2 (239)",
                "Лабораторная",
                "9:45",
                 "11:20"),
            new Lesson
            (
                "Моделирование информационных систем",
                "Дацун Н.Н.",
                "241/2 (237)",
                "Лабораторная",
                "13:30",
                 "15:05")
        };

        List<Lesson> llTuesday = new List<Lesson>()
        {
            new Lesson
            (
                "Технологии разработки распределенных приложений",
                "Постаногов И.С.",
                "426/2 (427)",
                "Лабораторная",
                "8:00",
                 "9:35"),
            new Lesson
            (
                "Комбинаторные алгоритмы",
                "Городилов А.Ю.",
                "130/5 (27)",
                "Лекция",
                "11:30",
                 "13:05")

        };
        List<Lesson> llWednesday = new List<Lesson>()
        {
            new Lesson
            (
                "Моделирование информационных систем",
                "Дацун Н.Н.",
                "425/5 (424)",
                "Лекция",
                "8:00",
                 "9:35"),
            new Lesson
            (
                "Моделирование информационных систем",
                "Дацун Н.Н.",
                "425/5 (424)",
                "Практика",
                "9:45",
                 "11:20"),
            new Lesson
            (
                "Операциянная система UNIX",
                "Замятина Е.Б.",
                "425/5 (424)",
                "Практика",
                "11:30",
                 "13:05")
        };
        List<Lesson> llThursday = new List<Lesson>()
        {
            new Lesson
            (
                "Технологии разработки распределенных приложений",
                "Постаногов И.С.",
                "242/2 (239)",
                "Практика",
                "8:00",
                 "9:35")
        };

        List<Lesson> llFriday = new List<Lesson>()
        {
            new Lesson
            (
                "Операциянная система UNIX",
                "Анисимов А.О.",
                "241/2 (237)",
                "Лабораторная",
                "8:00",
                 "9:35"),
            new Lesson
            (
                "Семантические технологии обработки текстовых документов",
                "Ланин В.В.",
                "241/2 (237)",
                "Лабораторная",
                "9:45",
                 "11:20")
        };

        List<Lesson> llSatudray = new List<Lesson>()
        {
            new Lesson
            (
                "Комбинаторные алгоритмы",
                "Дураков А.В.",
                "241/2 (237)",
                "Лабораторная",
                "13:30",
                 "15:05")
        };

        List<Lesson> llSunday = new List<Lesson>();

        WeekTable weektable = new WeekTable();
        weektable.llMonday = llMonday;
        weektable.llTuesday = llTuesday;
        weektable.llWednesday  = llWednesday;
        weektable.llThursday = llThursday;
        weektable.llFriday = llFriday;
        weektable.llSaturday = llSatudray;
        weektable.llSunday = llSunday;

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(WeekTable));

        using (FileStream fs = new FileStream("WeekTable.xml", FileMode.OpenOrCreate))
        {
            xmlSerializer.Serialize(fs, weektable);
        }
    }
}