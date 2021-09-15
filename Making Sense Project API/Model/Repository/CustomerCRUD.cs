using Making_Sense_Project_API.Logic;
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
        private readonly ReadWriteJsonCustomer _readWriteJsoncustomer;

        public CustomerCRUD(ReadWriteJsonCustomer readWriteJsoncustomer)
        {
            _readWriteJsoncustomer = readWriteJsoncustomer;
        }
        public void Create(Customer customer)
        {
            string dataJson = _readWriteJsoncustomer.ReadJsonFile();
            List<Customer> listCustomer = _readWriteJsoncustomer.DesrealizedJson(dataJson);
            var result = listCustomer.SingleOrDefault(x => x.DNI == customer.DNI);
            if (result != null)
            {
                throw new Exception($"Ya existe usuario con ese DNI {result.DNI}");   
            }
            listCustomer.Add(customer);
            string SerializedJson = _readWriteJsoncustomer.SerializeJson(listCustomer);
            _readWriteJsoncustomer.WriteJsonFile(SerializedJson);
        }

        public void DeleteById(int dni)
        {
            string dataJson = _readWriteJsoncustomer.ReadJsonFile();
            List<Customer> listCustomer = _readWriteJsoncustomer.DesrealizedJson(dataJson);
            var result = listCustomer.SingleOrDefault(x => x.DNI == dni);
            if (result == null)
            {
                throw new Exception($"No se encuentra Cliente con DNI:{dni} para eliminar");
            }
            listCustomer.Remove(listCustomer.SingleOrDefault(x => x.DNI == dni));
            string SerializedJson = _readWriteJsoncustomer.SerializeJson(listCustomer);
            _readWriteJsoncustomer.WriteJsonFile(SerializedJson);
        }

        public IList<Customer> GetAll()
        {
            string dataJson = _readWriteJsoncustomer.ReadJsonFile();
            List<Customer> listCustomer = _readWriteJsoncustomer.DesrealizedJson(dataJson);
            return listCustomer;
        }

        public Customer GetById(int dni)
        {
            string dataJson = _readWriteJsoncustomer.ReadJsonFile();
            List<Customer> listCustomer = _readWriteJsoncustomer.DesrealizedJson(dataJson);
            Customer customer = listCustomer.SingleOrDefault(x => x.DNI == dni);
            if (customer == null)
            {
                throw new Exception($"No se encuentra Cliente con DNI:{dni} para visualizar");
            }
            return customer;
        }

        public void Update(Customer customer)
        {
            string dataJson = _readWriteJsoncustomer.ReadJsonFile();
            List<Customer> listCustomer = _readWriteJsoncustomer.DesrealizedJson(dataJson);
            var result = listCustomer.SingleOrDefault(x => x.DNI == customer.DNI);
            if (result == null)
            {
                throw new Exception("No se encuentra Cliente con ese dni para actualizar");
            }
            listCustomer.Remove(listCustomer.SingleOrDefault(x => x.DNI == customer.DNI));
            listCustomer.Add(customer);
            string SerializedJson = _readWriteJsoncustomer.SerializeJson(listCustomer);
            _readWriteJsoncustomer.WriteJsonFile(SerializedJson);
        }
    }
}
