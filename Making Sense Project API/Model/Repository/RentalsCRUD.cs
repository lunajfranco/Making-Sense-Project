using Making_Sense_Project_API.Logic;
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
        private readonly ReadWriteJsonRentals _readWriteJsonRentals;

        public RentalsCRUD(ReadWriteJsonRentals readWriteJsonRentals)
        {
            _readWriteJsonRentals = readWriteJsonRentals;
        }
        public void Create(Rentals rentals)
        {
            string dataJson = _readWriteJsonRentals.ReadJsonFile();
            List<Rentals> listRentals = _readWriteJsonRentals.DesrealizedJson(dataJson);
            listRentals.Add(rentals);
            string serializedJson = _readWriteJsonRentals.SerializeJson(listRentals);
            _readWriteJsonRentals.WriteJsonFile(serializedJson);
        }

        public void DeleteById(int id)
        {
            string dataJson = _readWriteJsonRentals.ReadJsonFile();
            List<Rentals> listRentals = _readWriteJsonRentals.DesrealizedJson(dataJson);
            listRentals.Remove(listRentals.SingleOrDefault(x => x.IdRentals == id));
            string serializedJson = _readWriteJsonRentals.SerializeJson(listRentals);
            _readWriteJsonRentals.WriteJsonFile(serializedJson);
        }

        public IList<Rentals> GetAll()
        {
            string dataJson = _readWriteJsonRentals.ReadJsonFile();
            IList<Rentals> listRentals = _readWriteJsonRentals.DesrealizedJson(dataJson);
            return listRentals;
        }

        public Rentals GetById(int id)
        {
            string dataJson = _readWriteJsonRentals.ReadJsonFile();
            List<Rentals> listRentals = _readWriteJsonRentals.DesrealizedJson(dataJson);
            Rentals rentals = listRentals.SingleOrDefault(x => x.IdRentals == id);
            return rentals;
        }

        public void Update(Rentals rentals)
        {
            string dataJson = _readWriteJsonRentals.ReadJsonFile();
            List<Rentals> listRentals = _readWriteJsonRentals.DesrealizedJson(dataJson);
            listRentals.Remove(listRentals.SingleOrDefault(x => x.IdRentals == rentals.IdRentals));
            listRentals.Add(rentals);
            string serializedJson = _readWriteJsonRentals.SerializeJson(listRentals);
            _readWriteJsonRentals.WriteJsonFile(serializedJson);
        }
    }
}
