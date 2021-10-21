using Making_Sense_Project_API.Data;
using Making_Sense_Project_API.Model.Class;
using Making_Sense_Project_API.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Making_Sense_Project_API.Model.Repository
{
    public interface ICustomerCRUD<T> : ICRUD<T>
    {

    }
    public class CustomerCRUD<T> : ICustomerCRUD<Customer>
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerCRUD(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            return Save();
        }

        public bool Delete(Customer customer)
        {
            _dbContext.Customers.Remove(customer);
            return Save();
        }
        public bool Update(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            return Save();
        }

        public ICollection<Customer> GetAll()
        {
            return _dbContext.Customers.OrderBy(c => c.DNI).ToList();
        }

        public Customer GetById(int dni)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.DNI == dni);
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }
    }
}
