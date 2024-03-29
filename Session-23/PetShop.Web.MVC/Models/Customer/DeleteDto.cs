﻿using System.ComponentModel.DataAnnotations;

namespace PetShop.Web.MVC.Models.Customer
{
    public class CustomerDeleteDto
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Type less than 50 characters")]
        public string Name { get; set; } = null!;
        [MaxLength(100, ErrorMessage = "Type less than 100 characters")]
        public string Surname { get; set; } = null!;
        [MaxLength(15, ErrorMessage = "Type less than 15 characters")]
        public string Phone { get; set; } = null!;
        [MaxLength(15, ErrorMessage = "Type less than 15 characters")]
        public string Tin { get; set; } = null!;
    }
}
