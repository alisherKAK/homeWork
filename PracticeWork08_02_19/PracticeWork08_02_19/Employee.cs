using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWork08_02_19
{
    public struct Employee
    {
        public string Name { get; set; }
        public Vacancies Vacancy { get; set; }
        public int Salary { get; set; }
        public int[] RecepitDate { get; set; }

        public Employee(string name, Vacancies vacancy, int salary, int[] recepitDate)
        {
            Name = name;
            Vacancy = vacancy;
            Salary = salary;
            RecepitDate = new int[Constants.DATE_COUNT];
            if(recepitDate.Length == Constants.DATE_COUNT)
            {
                for(int i = 0; i < RecepitDate.Length; i++)
                {
                    RecepitDate[i] = recepitDate[i];
                }
            }
            else
            {
                throw new OverflowException("Дата дана неверно!");
            }
        }
        public Employee(string name, Vacancies vacancy, int salary, int recepitDateYear, int recepitDateMonth, int recepitDateDay)
        {
            Name = name;
            Vacancy = vacancy;
            Salary = salary;
            RecepitDate = new int[Constants.DATE_COUNT];
            RecepitDate[Constants.DATE_YEAR] = recepitDateYear;
            RecepitDate[Constants.DATE_MONTH] = recepitDateMonth;
            RecepitDate[Constants.DATE_DAY] = recepitDateDay;
        }
        public Employee(string name, Vacancies vacancy, int salary, int recepitDateYear, Month recepitDateMonth, int recepitDateDay)
        {
            Name = name;
            Vacancy = vacancy;
            Salary = salary;
            RecepitDate = new int[Constants.DATE_COUNT];
            RecepitDate[Constants.DATE_YEAR] = recepitDateYear;
            RecepitDate[Constants.DATE_MONTH] = (int)recepitDateMonth;
            RecepitDate[Constants.DATE_DAY] = recepitDateDay;
        }

        public string GetFullInormation()
        {
            return $"Name: {Name}\n" +
                   $"Vacancy: {Vacancy.ToString()}\n" +
                   $"Salary: {Salary}\n" +
                   $"RecepitDate: {RecepitDate[Constants.DATE_DAY]}:{RecepitDate[Constants.DATE_MONTH]}:{RecepitDate[Constants.DATE_YEAR]}";
        }
    }
}
