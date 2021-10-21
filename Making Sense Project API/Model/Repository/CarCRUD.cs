
using Making_Sense_Project_API.Data;
using Making_Sense_Project_API.Model.Class;
using Making_Sense_Project_API.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Making_Sense_Project_API.Model.Repository
{
    public interface ICarCRUD<T> : ICRUD<T>
    {

    }
    public class CarCRUD<T> : ICarCRUD<Car>
    {
        private readonly ApplicationDbContext _dbContext;

        public CarCRUD(ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public bool Create(Car car)
        {
            _dbContext.Cars.Add(car);
            return Save();
        }

        public bool Delete(Car car)
        {
            _dbContext.Cars.Remove(car);
            return Save();
        }

        public bool Update(Car car)
        {
            _dbContext.Update(car);
            return Save();
        }

        public ICollection<Car> GetAll()
        {
            return _dbContext.Cars.OrderBy(c => c.IdCar).ToList();
        }

        public Car GetById(int idCar)
        {
            return _dbContext.Cars.FirstOrDefault(c => c.IdCar == idCar);
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }
    }
}
