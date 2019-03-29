using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Student : IStudent
    {
        public string Fio { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public double AverageMark { get; set; }

        string IStudent.GetFullInformation()
        {
            return $"{Fio}; {Age}; {Grade}; {AverageMark}";
        }
        void IStudent.GetMark(int mark)
        {
            if(mark >= Constants.LOWER_MARK && mark <= Constants.HIGHEST_MARK)
            {
                AverageMark = (AverageMark + mark) / Constants.HALF;
            }
            else
            {
                throw new ArgumentException("Введите нормальную оценку!");
            }
        }
    }
}
