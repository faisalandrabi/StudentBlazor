
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using StudentBlazor.Context;
using StudentBlazor.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace StudentBlazor.Logic
{
    public class PopulateDB
    {
        private readonly DataBaseContext _DbContext;
        public PopulateDB(DataBaseContext dataBaseContext)
        {
            _DbContext = dataBaseContext;
        }
        public void FillCountries()
        {
            var CountryCount = _DbContext.Countries.ToHashSet();
            if (CountryCount.Count == 0)
            {
                Dictionary<int, string> CountryList = new Dictionary<int, string>();
                int CountryIndex = 100;
                var CountryObj = new Countries();
                CultureInfo[] getCulture = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                foreach (var item in getCulture)
                {
                    RegionInfo regionInfo = new RegionInfo(item.LCID);
                    if (!(CountryList.Values.Contains(regionInfo.EnglishName)))
                    {
                        CountryList.Add(CountryIndex, regionInfo.EnglishName);
                        CountryObj.Name = regionInfo.EnglishName;
                        CountryObj.Id = CountryIndex;
                        _DbContext.Countries.Add(CountryObj);
                        _DbContext.SaveChanges();
                        CountryIndex++;
                    }
                }

            }
        }
        public void FillClasses()
        {
            var ClassesCount = _DbContext.Classes.ToHashSet();
            
            if (ClassesCount.Count == 0)
            {
                List<Classes> ListClasses = new List<Classes>(){
                    new Classes { Id = 1, class_name = "Pre Primary" },
                    new Classes { Id = 2, class_name = "Primary" },
                    new Classes { Id = 3, class_name = "Secondry" },
                    new Classes { Id = 4, class_name = "Higher Secondry" },
                    new Classes { Id = 5, class_name = "College" },
                    new Classes { Id = 5, class_name = "University" },
                    };
                foreach (var classObj in ListClasses)
                {
                    _DbContext.Classes.Add(classObj);
                    _DbContext.SaveChanges();
                }

            }
        }


    }
}
