using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Moq;
using StudentBlazor.Context;
using StudentBlazor.IServices;
using StudentBlazor.Models;
using System;
using Xunit;

namespace StudentBlazorTests
{
    public class CountryTest
    {
        [Fact]
        public void EnterCountry_Values_SavedOrUpdated()
        {
            Countries country = new Countries();
            var mockRepo = new Mock<ICountryService>();
            country.Id = 0;
            country.Name= Faker.Country.Name();
            mockRepo.Setup(x => x.EnterCountry(country)).Returns($"Country {country.Name} is added");
        }
    }
}
