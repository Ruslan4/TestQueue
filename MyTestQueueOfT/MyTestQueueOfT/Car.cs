using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestQueueOfT
{
    class Car : IComparer, IEqualityComparer
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Car(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public int Compare(object obj)
        {
            Car car = obj as Car;
            if (car.Name.Length > this.Name.Length && car.Price > this.Price)
            {
                return 1;
            }
            if (car.Name.Length < this.Name.Length && car.Price < this.Price)
            {
                return -1;
            }
            else return 0;
        }

        public new bool Equals(object x, object y)
        {
            Car car1 = x as Car;
            Car car2 = y as Car;

            if (car1.GetHashCode() == car2.GetHashCode())
            {
                return true;
            }
            else return false;
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }

        public int Compare(object x, object y)
        {

            Car car1 = x as Car;
            Car car2 = y as Car;
            if (car1.Name.Length > car2.Name.Length && car1.Price > car2.Price)
            {
                return 1;
            }
            if (car1.Name.Length < car2.Name.Length && car1.Price < car2.Price)
            {
                return -1;
            }
            else return 0;
        }
    }
}
