using StudentBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentBlazor.IServices
{
    public interface IStudentService
    {
        HashSet<Students> GetStudents();
        Students GetById(int studentId);
        string Save(Students students);
        string Delete(int studentId);
    }
}
