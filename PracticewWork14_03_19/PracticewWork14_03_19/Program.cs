using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using Newtonsoft.Json;

namespace PracticewWork14_03_19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до файла:");

            string path = Console.ReadLine().Trim();
            List<Person> people = new List<Person>();

            using (StreamReader reader = new StreamReader(path))
            {
                string[] result = reader.ReadToEnd().Split('\n');
                List<string> persons = result.ToList();

                foreach (string person in persons)
                {
                    Person newPerson = new Person();

                    string[] data = person.Split(';');

                    for (int i = 0; i < data.Length; i++)
                    {
                        data[i] = data[i].Trim();
                    }

                    newPerson.Name = data[Constants.PERSONS_NAME];
                    newPerson.Surname = data[Constants.PERSONS_SURNAME];
                    newPerson.PhoneNumber = data[Constants.PERSONS_PHONENUMBER];

                    int birthYear;

                    if(int.TryParse(data[Constants.PERSONS_BIRTHYEAR], out birthYear))
                    {
                        newPerson.BirthYear = birthYear;
                    }
                    else
                    {
                        Console.WriteLine("Неправильно переданы данны");
                    }

                    people.Add(newPerson); 
                }
            }

            SoapFormatter formatter = new SoapFormatter();

            using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, people.ToArray());
            }

            string json = JsonConvert.SerializeObject(people);

            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(json);

                fs.Write(buffer, Constants.NULL, buffer.Length);
            }
        }
    }
}
