using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car {BrandId=1, CarId=1, ColorId=1, DailyPrice=100, Description="Civic", ModelYear=2010},
                new Car {BrandId=3, CarId=2, ColorId=2, DailyPrice=175, Description="Qashqai", ModelYear=2015},
                new Car {BrandId=2, CarId=3, ColorId=3, DailyPrice=250, Description="Corolla", ModelYear=2016},
                new Car {BrandId=2, CarId=4, ColorId=1, DailyPrice=300, Description="Hilux", ModelYear=2020},
                new Car {BrandId=1, CarId=5, ColorId=2, DailyPrice=130, Description="CR-V", ModelYear=2012},
            };
        }
        public void Add(Car car)
        {
           _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=> c.CarId == car.CarId);
            
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetAllByColor(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=> c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
