using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace HomeWork14_03_19
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            int bookCount = SetCount();
            List<Book> books = new List<Book>();

            for(int i = 0; i < bookCount; i++)
            {
                Book newBook = new Book
                {
                    Name = SetName(),
                    Price = SetPrice(), 
                    Author = SetAuthor(), 
                    PressYear = SetPressYear()
                };

                books.Add(newBook);
            }

            using (FileStream fs = new FileStream("books", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, books);
            }

            List<Book> deserializedBooks;

            using (FileStream fs = new FileStream("books", FileMode.OpenOrCreate))
            {
                deserializedBooks = formatter.Deserialize(fs) as List<Book>;
            }
        }
        static string SetName()
        {
            try
            {
                Console.WriteLine("Введите имя книги:");

                string name = Console.ReadLine().Trim();

                foreach (char letter in name)
                {
                    if (!((letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z') ||
                        (letter >= '0' && letter <= '9') || letter == ' '))
                    {
                        throw new ArgumentException("Имя книги введено неверно");
                    }
                }

                return name;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetName();
            }
        }
        static double SetPrice()
        {
            try
            {
                Console.WriteLine("Введите цену книги:");

                double price;

                if (double.TryParse(Console.ReadLine().Trim(), out price))
                {
                    return price;
                }

                throw new ArgumentException("Цена была введена неверно");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetPrice();
            }
        }
        static string SetAuthor()
        {
            try
            {
                Console.WriteLine("Введите автора книги:");

                string author = Console.ReadLine().Trim();

                foreach (char letter in author)
                {
                    if (!((letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z') ||
                        (letter >= '0' && letter <= '9') || letter == ' '))
                    {
                        throw new ArgumentException("Автор книги введен неверно");
                    }
                }

                return author;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetAuthor();
            }
        }
        static int SetPressYear()
        {
            try
            {
                Console.WriteLine("Введите год выпуска книги:");

                int pressYear;

                if (int.TryParse(Console.ReadLine().Trim(), out pressYear))
                {
                    return pressYear;
                }

                throw new ArgumentException("Год выпуска был введен неверно");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetPressYear();
            }
        }
        static int SetCount()
        {
            try
            {
                Console.WriteLine("Введите кол книг:");

                int bookCount;

                if (int.TryParse(Console.ReadLine().Trim(), out bookCount))
                {
                    return bookCount;
                }

                throw new ArgumentException("Кол было введено неверно");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetCount();
            }
        }
    }
}
