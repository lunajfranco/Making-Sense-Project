using Making_Sense_Project_API.Data;
using Making_Sense_Project_API.Model.Class;
using Making_Sense_Project_API.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Making_Sense_Project_API.Model.Repository
{
    public interface IRentalsCRUD<T> : ICRUD<T>
    {

    }
    public class RentalsCRUD<T> : IRentalsCRUD<Rentals>
    {
        private readonly ApplicationDbContext _dbContext;

        public RentalsCRUD(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(Rentals rentals)
        {
            _dbContext.Rentals.Add(rentals);
            return Save();
        }

        public bool Delete(Rentals rentals)
        {
            _dbContext.Rentals.Remove(rentals);
            return Save();
        }

        public bool Update(Rentals rentals)
        {
            _dbContext.Rentals.Update(rentals);
            return Save();
        }

        public ICollection<Rentals> GetAll()
        {
            return _dbContext.Rentals.OrderBy(r => r.IdRentals).ToList();
        }

        public Rentals GetById(int id)
        {
            return _dbContext.Rentals.FirstOrDefault(r => r.IdRentals == id);
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }
    }
}
