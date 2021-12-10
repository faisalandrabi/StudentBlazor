using StudentBlazor.Context;
using StudentBlazor.IServices;
using StudentBlazor.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace StudentBlazor.Services
{
    public class CountryServices : ICountryService
    {
        
        private readonly DataBaseContext _countryContext;
        public CountryServices(DataBaseContext countryContext)
        {
            _countryContext=countryContext;
        }

        public string EnterCountry(Countries Country)
        {
            string res = $"Country {Country.Name} is added";
            if (Country.Id == 0)
            {
                _countryContext.Countries.Add(Country);
            }
            else
            {
                _countryContext.Countries.Update(Country);
                res = $"Country {Country.Name} Updated";
            }
            _countryContext.SaveChanges();
            return res;
        }
        public HashSet<Countries> GetCountries()
        {
            return _countryContext.Countries.ToHashSet();
        }

        public Countries GetCountry(int CountryId)
        {
            throw new NotImplementedException();
        }
  
    }
}
