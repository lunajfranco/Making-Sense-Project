﻿using Making_Sense_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_Sense_Project.Logic
{
    public class CarCRUD
    {
        public List<Car> Create()
        {
            List<Car> car = new List<Car> {
            new Car
                {
                IdCar = 2,
                Marca = new Marca { IdMarca = 1, NombreMarca = "volskwagen" },
                Color = "negro",
                Year = 2015,
                CantidadPuertas = 3,
                Transimision = "Manual"
                }
            };
            return car;
        }
        public Car GetCar(int idCar)
        {
            ReadWriteJson json = new ReadWriteJson();
            var datos = json.ReadJsonFile();
            var listCar = json.DesrealizedJson(datos);
            for (int i = 0; i < listCar.Count; i++)
            {
                if (listCar[i].IdCar == idCar)
                {
                    return listCar[i];
                }
            }
            return null;
        }
    }
}
