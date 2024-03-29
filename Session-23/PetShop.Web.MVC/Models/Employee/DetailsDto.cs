﻿using PetShop.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Web.MVC.Models.Employee
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Type less than 50 characters")]
        public string Name { get; set; } = null!;
        [MaxLength(100, ErrorMessage = "Type less than 100 characters")]
        public string Surname { get; set; } = null!;
        [Display(Name = "Employee Type")]
        public EmployeeType EmployeeType { get; set; }
        [Display(Name = "Salary Per Month")]
        public int SalaryPerMonth { get; set; }
    }
}
