using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PracticeWork03_03_19
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("data.xml");

            XmlElement rootElement = xmlDocument.DocumentElement;

            XmlNodeList nodeList = rootElement.ChildNodes;

            Console.Write($"{rootElement.Name}  ");

            for(int i = 0; i < nodeList.Count; i++)
            {
                Console.Write($"{nodeList[i].Name} ");
            }

            Console.ReadLine();
        }
    }
}
