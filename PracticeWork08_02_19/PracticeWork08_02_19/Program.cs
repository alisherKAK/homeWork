using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWork08_02_19
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 HomeWork
            Employee[] employees = new Employee[SetEmployeesCount()];

            for(int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine($"Заполнение данных о {i+Constants.LENTH_TO_INDEX} работнике");
                string name = SetEmploeeName();
                int receptiYear = SetRecepitDateYear();
                Month receptiMonth = SetRecepitDateMonth();
                int receptiDay = SetRecepitDateDay(receptiMonth, receptiYear);
                Vacancies vacancies = SetEmploeeVacanci();
                int salary = SetEmploeeSalary();
                employees[i] = new Employee(name, vacancies, salary, receptiYear, receptiMonth, receptiDay);
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");

            //a
            for(int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine($"Информация про {i+Constants.LENTH_TO_INDEX} сотрудника");
                Console.WriteLine(employees[i].GetFullInormation());
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");

            //b
            int clercCout = Constants.NULL;
            int allClerSalary = Constants.NULL;

            for(int i = 0; i < employees.Length; i++)
            {
                if(employees[i].Vacancy == Vacancies.Clerk)
                {
                    ++clercCout;
                    allClerSalary += employees[i].Salary;
                }
            }

            if (clercCout != Constants.NULL)
            {
                double averageClercSalary = allClerSalary / clercCout;

                for (int i = 0; i < employees.Length; i++)
                {
                    if (employees[i].Vacancy == Vacancies.Manager && employees[i].Salary >= averageClercSalary)
                    {
                        Console.WriteLine(employees[i].GetFullInormation());
                    }
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------------");
            }

            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < employees.Length - Constants.LENTH_TO_INDEX; ++i)
                    if (employees[i].Name.CompareTo(employees[i + Constants.LENTH_TO_INDEX].Name) > 0)
                    {
                        string name = employees[i].Name;
                        Vacancies vacancies = employees[i].Vacancy;
                        int salary = employees[i].Salary;
                        int recepitYear = employees[i].RecepitDate[Constants.DATE_YEAR];
                        int recepitMonth = employees[i].RecepitDate[Constants.DATE_MONTH];
                        int recepitDay = employees[i].RecepitDate[Constants.DATE_DAY];

                        employees[i].Name = employees[i + Constants.LENTH_TO_INDEX].Name;
                        employees[i].Vacancy = employees[i + Constants.LENTH_TO_INDEX].Vacancy;
                        employees[i].Salary = employees[i + Constants.LENTH_TO_INDEX].Salary;
                        employees[i].RecepitDate[Constants.DATE_YEAR] = employees[i + Constants.LENTH_TO_INDEX].RecepitDate[Constants.DATE_YEAR];
                        employees[i].RecepitDate[Constants.DATE_MONTH] = employees[i + Constants.LENTH_TO_INDEX].RecepitDate[Constants.DATE_MONTH];
                        employees[i].RecepitDate[Constants.DATE_DAY] = employees[i + Constants.LENTH_TO_INDEX].RecepitDate[Constants.DATE_DAY];

                        employees[i + Constants.LENTH_TO_INDEX].Name = name;
                        employees[i + Constants.LENTH_TO_INDEX].Vacancy = vacancies;
                        employees[i + Constants.LENTH_TO_INDEX].Salary = salary;
                        employees[i + Constants.LENTH_TO_INDEX].RecepitDate[Constants.DATE_YEAR] = recepitYear;
                        employees[i + Constants.LENTH_TO_INDEX].RecepitDate[Constants.DATE_MONTH] = recepitMonth;
                        employees[i + Constants.LENTH_TO_INDEX].RecepitDate[Constants.DATE_DAY] = recepitDay;
                        flag = true;
                    }
            }

            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].Vacancy == Vacancies.Manager)
                {
                    Console.WriteLine(employees[i].GetFullInormation());
                }
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");

            //c
            int bossRecepitYear = Constants.NULL;
            int bossRecepitMonth = Constants.NULL;
            int bossRecepitDay = Constants.NULL;

            for (int i = 0; i < employees.Length; i++)
            {
                if(employees[i].Vacancy == Vacancies.Boss)
                {
                    bossRecepitDay = employees[i].RecepitDate[Constants.DATE_DAY];
                    bossRecepitMonth = employees[i].RecepitDate[Constants.DATE_MONTH];
                    bossRecepitYear = employees[i].RecepitDate[Constants.DATE_YEAR];
                    break;
                }
            }

            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].Vacancy == Vacancies.Manager)
                {
                    if(employees[i].RecepitDate[Constants.DATE_YEAR] > bossRecepitYear)
                    {
                        Console.WriteLine(employees[i].GetFullInormation());
                    }
                    else if(employees[i].RecepitDate[Constants.DATE_YEAR] == bossRecepitYear)
                    {
                        if(employees[i].RecepitDate[Constants.DATE_MONTH] > bossRecepitMonth)
                        {
                            Console.WriteLine(employees[i].GetFullInormation());
                        }
                        else if(employees[i].RecepitDate[Constants.DATE_MONTH] == bossRecepitMonth)
                        {
                            if(employees[i].RecepitDate[Constants.DATE_DAY] > bossRecepitDay)
                            {
                                Console.WriteLine(employees[i].GetFullInormation());
                            }
                        }
                    }
                }
            }
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //2 HomeWork
            Student[] students = new Student[SetStudentCount()];

            for(int i = 0; i < students.Length; i++)
            {
                string name = SetStudentName();
                string group = SetStudentGroup();
                double averageMark = SetStudentAverageMark();
                double familyMemberIncome = SetStudentFamilyMemberIncome();
                Gender gender = SetStudentGender();
                StudyForm studyForm = SetStudentStudyForm();

                students[i] = new Student(name, group, averageMark, familyMemberIncome, gender, studyForm);
            }

            bool flag_ = true;
            while (flag_)
            {
                flag_ = false;
                for (int i = 0; i < students.Length - Constants.LENTH_TO_INDEX; ++i)
                    if (students[i].FamilyMemberIncome.CompareTo(students[i + Constants.LENTH_TO_INDEX].FamilyMemberIncome) < 0)
                    {
                        string name = students[i].Name;
                        string group = students[i].Group;
                        double familyMemberIncome = students[i].FamilyMemberIncome;
                        double averageMark = students[i].AverageMark;
                        Gender gender = students[i].Gender;
                        StudyForm studyForm  = students[i].StudyForm;

                        students[i].Name = students[i + Constants.LENTH_TO_INDEX].Name;
                        students[i].Group = students[i + Constants.LENTH_TO_INDEX].Group;
                        students[i].FamilyMemberIncome = students[i + Constants.LENTH_TO_INDEX].FamilyMemberIncome;
                        students[i].AverageMark = students[i + Constants.LENTH_TO_INDEX].AverageMark;
                        students[i].Gender = students[i + Constants.LENTH_TO_INDEX].Gender;
                        students[i].StudyForm = students[i + Constants.LENTH_TO_INDEX].StudyForm;

                        students[i + Constants.LENTH_TO_INDEX].Name = name;
                        students[i + Constants.LENTH_TO_INDEX].Group = group;
                        students[i + Constants.LENTH_TO_INDEX].FamilyMemberIncome = familyMemberIncome;
                        students[i + Constants.LENTH_TO_INDEX].AverageMark = averageMark;
                        students[i + Constants.LENTH_TO_INDEX].Gender = gender;
                        students[i + Constants.LENTH_TO_INDEX].StudyForm = studyForm;
                        flag_ = true;
                    }
            }

            for(int i = 0; i < students.Length; ++i)
            {
                if(students[i].FamilyMemberIncome <= Constants.MINIMAl_SALARY * Constants.DOUBLE)
                {
                    Console.WriteLine(students[i].GetFullInfomation());
                }
            }

            for(int i = 0; i < students.Length; ++i)
            {
                if (students[i].FamilyMemberIncome > Constants.MINIMAl_SALARY * Constants.DOUBLE)
                {
                    Console.WriteLine(students[i].GetFullInfomation());
                }
            }
        }
        static int SetEmployeesCount()
        {
            Console.Write("Введите количество работников: ");

            string result = Console.ReadLine().Trim();
            int employeesCount;
            if(int.TryParse(result, out employeesCount))
            {
                return employeesCount;
            }
            else
            {
                Console.WriteLine("Ввели неправильное кол работников!");
                return SetEmployeesCount();
            }
        }
        static void SetEmploeeInformation(Employee employee)
        {

        }
        static string SetEmploeeName()
        {
            try
            {
                Console.Write("Введите имя рабтника: ");

                string name = Console.ReadLine().Trim();

                for(int i = 0; i < name.Length; i++)
                {
                    if(!((name[i] >= 'a' && name[i] <= 'z') || (name[i] >= 'A' && name[i] <= 'Z')) )
                    {
                        throw new ArgumentException("Имя введено неверно!");
                    }
                }
                return name;

            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetEmploeeName();
            }
        }
        static int SetEmploeeSalary()
        {
            try
            {
                Console.Write("Введите зартплату: ");

                int salary;

                if(int.TryParse(Console.ReadLine().Trim(), out salary))
                {
                    return salary;
                }
                else
                {
                    throw new ArgumentException("Зартплата введина неверно!");
                }
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetEmploeeSalary();
            }
        }
        static int SetRecepitDateYear()
        {
            try
            {
                Console.Write("Введите год поступления на работу: ");

                int year;

                if(int.TryParse(Console.ReadLine().Trim(), out year))
                {
                    return year;
                }
                else
                {
                    throw new ArgumentException("Год был введен неверно!");
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetRecepitDateYear();
            }
        }
        static Month SetRecepitDateMonth()
        {
            try
            {
                Console.Write("Введите месяц поступления на работу(номер): ");

                int month;

                if(int.TryParse(Console.ReadLine().Trim(), out month))
                {
                    switch (month)
                    {
                        case (int)Month.January:
                        case (int)Month.February:
                        case (int)Month.March:
                        case (int)Month.April:
                        case (int)Month.May:
                        case (int)Month.June:
                        case (int)Month.July:
                        case (int)Month.August:
                        case (int)Month.September:
                        case (int)Month.October:
                        case (int)Month.November:
                        case (int)Month.December:
                            return (Month)month;
                        default:
                            throw new ArgumentException("Такого месяца нет!");
                    }
                }
                else
                {
                    throw new ArgumentException("Месяц был введен неверно!");
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetRecepitDateMonth(); 
            }
        }
        static int SetRecepitDateDay(Month month, int year)
        {
            try
            {
                Console.Write("Введите день поступления на работу: ");

                int day;

                if (int.TryParse(Console.ReadLine().Trim(), out day))
                {
                    switch (month)
                    {
                        case Month.January:
                            if(day <= (int)Month_sDay.JanuaryDay)
                            {
                                return day;
                            }
                            else
                            {
                                throw new ArgumentException($"Такого дня нет в {month.ToString()}");
                            }
                        case Month.February:
                            if (year % Constants.LEAP_YEAR == Constants.NULL)
                            {
                                if (day <= (int)Month_sDay.FebruaryDay + Constants.LEAP_YEAR_PLUS_DAY)
                                {
                                    return day;
                                }
                                else
                                {
                                    throw new ArgumentException($"Такого дня нет в {month.ToString()}");
                                }
                            }
                            else

                            {
                                if (day <= (int)Month_sDay.FebruaryDay + Constants.LEAP_YEAR_PLUS_DAY)
                                {
                                    return day;
                                }
                                else
                                {
                                    throw new ArgumentException($"Такого дня нет в {month.ToString()}");
                                }
                            }
                        case Month.March:
                            if (day <= (int)Month_sDay.MarchDay)
                            {
                                return day;
                            }
                            else
                            {
                                throw new ArgumentException($"Такого дня нет в {month.ToString()}");
                            }
                        case Month.April:
                            if (day <= (int)Month_sDay.AprilDay)
                            {
                                return day;
                            }
                            else
                            {
                                throw new ArgumentException($"Такого дня нет в {month.ToString()}");
                            }
                        case Month.May:
                            if (day <= (int)Month_sDay.MayDay)
                            {
                                return day;
                            }
                            else
                            {
                                throw new ArgumentException($"Такого дня нет в {month.ToString()}");
                            }
                        case Month.June:
                            if (day <= (int)Month_sDay.JuneDay)
                            {
                                return day;
                            }
                            else
                            {
                                throw new ArgumentException($"Такого дня нет в {month.ToString()}");
                            }
                        case Month.July:
                            if (day <= (int)Month_sDay.JulyDay)
                            {
                                return day;
                            }
                            else
                            {
                                throw new ArgumentException($"Такого дня нет в {month.ToString()}");
                            }
                        case Month.August:
                            if (day <= (int)Month_sDay.AugustDay)
                            {
                                return day;
                            }
                            else
                            {
                                throw new ArgumentException($"Такого дня нет в {month.ToString()}");
                            }
                        case Month.September:
                            if (day <= (int)Month_sDay.SeptemberDay)
                            {
                                return day;
                            }
                            else
                            {
                                throw new ArgumentException($"Такого дня нет в {month.ToString()}");
                            }
                        case Month.October:
                            if(day <= (int)Month_sDay.OctoberDay)
                            {
                                return day;
                            }
                            else
                            {
                                throw new ArgumentException($"Такого дня нет в {month.ToString()}");
                            }
                        case Month.November:
                            if (day <= (int)Month_sDay.NovemberDay)
                            {
                                return day;
                            }
                            else
                            {
                                throw new ArgumentException($"Такого дня нет в {month.ToString()}");
                            }
                        case Month.December:
                            if (day <= (int)Month_sDay.DecemberDay)
                            {
                                return day;
                            }
                            else
                            {
                                throw new ArgumentException($"Такого дня нет в {month.ToString()}");
                            }
                        default:
                            throw new ArgumentException("Такого дня нет в этом месяце");
                            break;
                    }
                }
                else
                {
                    throw new ArgumentException("Такого дня нет в этом месяце");
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetRecepitDateDay(month, year);
            }
        }
        static Vacancies SetEmploeeVacanci()
        {
            try
            {
                Console.Write("Введите должность сотрудника\n" +
                              "1) Manager\n" +
                              "2) Boss\n" +
                              "3) Clerk\n" +
                              "4) Salesman\n");

                int vacanci;

                if(int.TryParse(Console.ReadLine().Trim(), out vacanci))
                {
                    if(vacanci >= (int)Vacancies.Manager && vacanci <= (int)Vacancies.Salesman)
                    {
                        return (Vacancies)vacanci;
                    }
                    else
                    {
                        throw new ArgumentException("Нет такой должности!");
                    }
                }
                else
                {
                    throw new ArgumentException("Нет такой должности!");
                }
            }
            catch (ArgumentException exception)
            {
                Console.Write(exception.Message);
                return SetEmploeeVacanci();
            }
        }

        static int SetStudentCount()
        {
            try
            {
                Console.Write("Введите кол студентов: ");

                int studentCount;

                if(int.TryParse(Console.ReadLine().Trim(), out studentCount))
                {
                    return studentCount;
                }
                else
                {
                    throw new ArgumentException("Кол студентов введено неверно!");
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetStudentCount();
            }
        }
        static string SetStudentName()
        {
            try
            {
                Console.Write("Введите имя студента: ");

                string name = Console.ReadLine().Trim();

                for(int i = 0; i < name.Length; i++)
                {
                    if(!((name[i] >= 'a' && name[i] <= 'z') || (name[i] >= 'A' && name[i] <= 'Z')))
                    {
                        throw new ArgumentException("Имя студента был введен неверно!");
                    }
                }
                return name;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetStudentName();
            }
        }
        static string SetStudentGroup()
        {
            try
            {
                Console.Write("Введите группу студента: ");

                string group = Console.ReadLine().Trim();

                for (int i = 0; i < group.Length; i++)
                {
                    if (group[i] == ' ')
                    {
                        throw new ArgumentException("Группа студента был введен неверно!");
                    }
                }
                return group;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetStudentGroup();
            }
        }
        static double SetStudentAverageMark()
        {
            try
            {
                Console.Write("Введите средую оценку студента: ");

                double studentAverageMark;

                if (double.TryParse(Console.ReadLine().Trim(), out studentAverageMark))
                {
                    return studentAverageMark;
                }
                else
                {
                    throw new ArgumentException("Средняя оценка студента введено неверно!");
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetStudentAverageMark();
            }
        }
        static double SetStudentFamilyMemberIncome()
        {
            try
            {
                Console.Write("Введите доход на члена семьи студента: ");

                double studentFamilyMemberIncome;

                if (double.TryParse(Console.ReadLine().Trim(), out studentFamilyMemberIncome))
                {
                    return studentFamilyMemberIncome;
                }
                else
                {
                    throw new ArgumentException("Доход на члена семьи студента введено неверно!");
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetStudentFamilyMemberIncome();
            }
        }
        static Gender SetStudentGender()
        {
            try
            {
                Console.Write("Введите пол студента: ");

                int studentGender;

                if (int.TryParse(Console.ReadLine().Trim(), out studentGender))
                {
                    switch (studentGender)
                    {
                        case (int)Gender.Male:
                            return Gender.Male;
                        case (int)Gender.Female:
                            return Gender.Female;
                        default:
                            throw new ArgumentException("Пол студента введено неверно!");
                    }
                }
                else
                {
                    throw new ArgumentException("Пол студента введено неверно!");
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetStudentGender();
            }
        }
        static StudyForm SetStudentStudyForm()
        {
            try
            {
                Console.Write("Введите тип обучение студента: ");

                int studentGender;

                if (int.TryParse(Console.ReadLine().Trim(), out studentGender))
                {
                    switch (studentGender)
                    {
                        case (int)StudyForm.Stationary:
                            return StudyForm.Stationary;
                        case (int)StudyForm.Halfstationary:
                            return StudyForm.Halfstationary;
                        default:
                            throw new ArgumentException("Тип обучение студента введено неверно!");
                    }
                }
                else
                {
                    throw new ArgumentException("Тип обучение студента введено неверно!");
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetStudentStudyForm();
            }
        }
    }
}
