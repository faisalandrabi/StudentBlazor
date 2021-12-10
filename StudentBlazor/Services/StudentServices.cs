using StudentBlazor.Context;
using StudentBlazor.IServices;
using StudentBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentBlazor.Services
{
    public class StudentServices : IStudentService
    {
        private readonly DataBaseContext _studentContext;
        public StudentServices(DataBaseContext studentContext)
        {
            _studentContext = studentContext;
        }
        public string Delete(int studentId)
        {
            string res = "Deletion Failed";
            var student = _studentContext.Student.FirstOrDefault(x => x.Id == studentId);
            if (student!=null)
            {
                _studentContext.Student.Remove(student);
                _studentContext.SaveChanges();
                res = "Deletion Sucess";
            }
            return res;
        }

        public Students GetById(int studentId)
        {
            return _studentContext.Student.SingleOrDefault(x => x.Id == studentId);
        }

        public HashSet<Students> GetStudents()
        {
            return _studentContext.Student.ToHashSet();
        }

        public string Save(Students students)
        {
            string res = "A new Student is added";
            if (students.Id == 0)
            {
                _studentContext.Student.Add(students);
            }
            else
            {
                _studentContext.Student.Update(students);
                res = "Student Updated";
            }
            _studentContext.SaveChanges();
            return res;
        }
    }

   
}
