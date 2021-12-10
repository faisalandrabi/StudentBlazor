using StudentBlazor.Context;
using StudentBlazor.IServices;
using StudentBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentBlazor.Services
{
    public class ClassesServices : IClassesService
    {

        private readonly DataBaseContext _classContext;
        public ClassesServices(DataBaseContext baseContext)
        {
            _classContext = baseContext;
        }
        public HashSet<Classes> GetClasses()
        {
            return _classContext.Classes.ToHashSet();
        }

        public Classes GetClass(int ClassId)
        {
            return _classContext.Classes.SingleOrDefault(x => x.Id == ClassId);
        }

        public string SaveClasses(Classes ClassObj)
        {
            string res = "A new Class is added";
            if (ClassObj.Id == 0)
            {
                _classContext.Classes.Add(ClassObj);
            }
            else
            {
                _classContext.Classes.Update(ClassObj);
                res = "Class Updated";
            }
            _classContext.SaveChanges();
            return res;
        }
    }
}
