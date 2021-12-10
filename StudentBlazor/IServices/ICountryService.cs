using StudentBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentBlazor.IServices
{
    public interface ICountryService
    {
        HashSet<Countries> GetCountries();
        Countries GetCountry(int CountryId);
        string EnterCountry(Countries Country);
    }
}
