using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWork08_02_19
{
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public double AverageMark { get; set; }
        public double FamilyMemberIncome { get; set; }
        public Gender Gender { get; set; }
        public StudyForm StudyForm { get; set; }

        public Student(){}
        public Student(string name, string group, double averageMark, double familyMemberIncome, Gender gender, StudyForm studyForm)
        {
            Name = name;
            Group = group;
            AverageMark = averageMark;
            FamilyMemberIncome = familyMemberIncome;
            Gender = gender;
            StudyForm = studyForm;
        }

        public string GetFullInfomation()
        {
            return $"Name: {Name}\n" +
                   $"Group: {Group}\n" +
                   $"Average mark: {AverageMark}\n" +
                   $"Family member income: {FamilyMemberIncome}\n" +
                   $"Gender: {Gender.ToString()}\n" +
                   $"Study form: {StudyForm.ToString()}";
        }
    }
}
