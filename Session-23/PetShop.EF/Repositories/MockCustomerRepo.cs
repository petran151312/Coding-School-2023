﻿using PetShop.EF.Context;
using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.EF.Repositories
{
    public class MockCustomerRepo : IEntityRepo<Customer>
    {
        private readonly List<Customer> _customers;

        public MockCustomerRepo()
        {
            _customers = new List<Customer>
            {
                new Customer("Petran","Ras",693999999,"1234567890")
            };
        }

        public void Add(Customer entity)
        {
            using var context = new PetShopDbContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            using var context = new PetShopDbContext();
            var dbPetShop = context.Customers.Where(customer => customer.Id == id).SingleOrDefault();
            if (dbPetShop is null)
                return;
            context.Remove(dbPetShop);
            context.SaveChanges();
        }

        public IList<Customer> GetAll()
        {
            using var context = new PetShopDbContext();
            return _customers;
        }

        public Customer GetById(int id)
        {
            using var context = new PetShopDbContext();
            return context.Customers.Where(customer => customer.Id == id).SingleOrDefault();
        }

        public void Update(int id, Customer entity)
        {
            using var context = new PetShopDbContext();
            var dbPetshop = context.Customers.Where(customer => customer.Id == id).SingleOrDefault();
            if (dbPetshop is null)
                return;
            dbPetshop.Name = entity.Name;
            dbPetshop.Surname = entity.Surname;
            dbPetshop.Phone = entity.Phone;
            dbPetshop.Tin = entity.Tin;
            context.SaveChanges();
        }
    }
}
