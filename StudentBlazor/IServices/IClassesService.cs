

using StudentBlazor.Models;
using System.Collections.Generic;

namespace StudentBlazor.IServices
{
   public interface IClassesService
    {
        HashSet<Classes> GetClasses();
        Classes GetClass(int ClassId);
        string SaveClasses(Classes ClassObj);
    }
}
