

using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using StudentBlazor.Context;
using StudentBlazor.IServices;
using StudentBlazor.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentBlazor.Logic
{
    public class StudentBase : ComponentBase
    {
        [Inject]
        public IDbContextFactory<DataBaseContext> _contextFactory { get; set; }
        [Inject]
        public IStudentService _studentService { get; set; }      
        [Inject]
        public ICountryService _countryService { get; set; } 
        
        [Inject]
        public IClassesService _classService { get; set; }
        [Inject]
        public  ISnackbar Snackbar { get; set; }

        public HashSet<Students> StudentSet;
        public HashSet<Countries> CountrySet;
        public HashSet<Classes> ClassSet;

        protected bool dense = false;
        protected bool hover = true;
        protected bool striped = false;
        protected bool bordered = false;
        protected bool success = true;
        protected MudForm form;
        protected string searchString1 = "";
        protected Students student = new Students();
        
       
        protected void Reset()
        {
           student = new Students();
        }
        protected override Task OnInitializedAsync()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var pop = new PopulateDB(context);
                pop.FillCountries();
                pop.FillClasses();
            }
            
            StudentSet = GetListOfStudents();
            CountrySet = GetListOfCountries();
            ClassSet = GetListOfClasses();

            return base.OnInitializedAsync();
        }
        private bool FilterFunc(Students element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Id.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        protected void SaveStudents()
        {
            _studentService.Save(student);
            Snackbar.Add("Student has been saved!", Severity.Success);
            GetListOfStudents();
        }

        protected HashSet<Students> GetListOfStudents()
        {
            return _studentService.GetStudents();
        }
        protected HashSet<Classes> GetListOfClasses()
        {
            return _classService.GetClasses();
        }

        protected HashSet<Countries> GetListOfCountries()
        {
            return _countryService.GetCountries();
        }

        protected void Edit(int studentid)
        {
            var tmpStd=_studentService.GetById(studentid);
            
            student = tmpStd;
        }
        protected void ChangePosition(string message, string position)
        {
            Snackbar.Clear();
            Snackbar.Configuration.PositionClass = position;
            Snackbar.Add(message, Severity.Normal);
        }
    }
}
