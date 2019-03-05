using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HomeWork03_03_19
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            string result;

            WebRequest request = WebRequest.Create("https://habr.com/ru/rss/interesting/");
            WebResponse response = request.GetResponse();
            XmlDocument doc = new XmlDocument();
            doc.Load(response.GetResponseStream());
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            response.Close();

            List<Item> items = new List<Item>(); 

            XmlElement rssElem = doc["rss"];
            XmlElement chanElem = rssElem["channel"];
            XmlNodeList itemElements = chanElem.GetElementsByTagName("item");

            foreach(XmlElement item in itemElements)
            {
                Item itemBuf = new Item();
                itemBuf.Title = item["title"].InnerText;
                itemBuf.Link = item["link"].InnerText;
                itemBuf.Description = item["description"].InnerText;
                itemBuf.PubDate = item["pubDate"].InnerText;
                items.Add(itemBuf);
            }

            //2
            XmlDocument document = new XmlDocument();

            var rootElement = document.CreateElement("student");

            var fullNameElement = document.CreateElement("fullName");
            fullNameElement.InnerText = SetFullName();

            rootElement.AppendChild(fullNameElement);

            var ageElement = document.CreateElement("age");
            ageElement.InnerText = SetAge().ToString();

            rootElement.AppendChild(ageElement);

            var facultyElement = document.CreateElement("faculty");
            facultyElement.InnerText = SetFaculty();

            rootElement.AppendChild(facultyElement);

            var courseElement = document.CreateElement("course");
            courseElement.InnerText = SetCourse().ToString();

            rootElement.AppendChild(courseElement);

            document.AppendChild(rootElement);

            document.Save("student.xml");

            Console.ReadLine();
        }
        static string SetFullName()
        {
            try
            {
                Console.WriteLine("Введите Full Name:");

                string fullName = Console.ReadLine().Trim();

                for (int i = 0; i < fullName.Length; i++)
                {
                    if (!((fullName[i] >= 'a' && fullName[i] <= 'z') || (fullName[i] >= 'A' && fullName[i] <= 'Z') || fullName[i] == ' '))
                    {
                        throw new ArgumentException("Full Name был введен неверно");
                    }
                }

                return fullName;
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetFullName();
            }
        }
        static int SetAge()
        {
            try
            {
                int age;

                Console.WriteLine("Введите Age:");

                if (int.TryParse(Console.ReadLine().Trim(), out age))
                {
                    return age;
                }

                throw new ArgumentException("Age был введен неверно");
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetAge();
            }
        }
        static string SetFaculty()
        {
            try
            {
                Console.WriteLine("Введите Faculty:");

                string faculty = Console.ReadLine().Trim();

                for (int i = 0; i < faculty.Length; i++)
                {
                    if (!((faculty[i] >= 'a' && faculty[i] <= 'z') || (faculty[i] >= 'A' && faculty[i] <= 'Z') || faculty[i] == ' '))
                    {
                        throw new ArgumentException("Faculty был введен неверно");
                    }
                }

                return faculty;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetFaculty();
            }
        }
        static int SetCourse()
        {
            try
            {
                int course;

                Console.WriteLine("Введите Course:");

                if (int.TryParse(Console.ReadLine().Trim(), out course))
                {
                    if (course >= Constants.FIRST_COURSE && course <= Constants.LAST_COURSE)
                    {
                        return course;
                    }
                }

                throw new ArgumentException("Course был введен неверно");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetCourse();
            }
        }
    }
}
