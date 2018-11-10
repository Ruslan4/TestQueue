using System.Collections.Generic;
using MyQueue;
using System;

namespace MyTestQueueOfT
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<Car> myCar = new MyQueue<Car>();

            myCar.ClearEvent += Show_FromCar_Clear;
            myCar.DequeueEvent += Show_FromCar;
            myCar.EnqueueEvent += Show_FromCar;

            Console.WriteLine(new string('-', 50));

            myCar.Enqueue(new Car("Tesla X", 3000000));
            myCar.Enqueue(new Car("Tesla Model 3", 2500000));
            myCar.Enqueue(new Car("BMW", 3000000));
            myCar.Enqueue(new Car("Roadster", 10000000));

            

            Console.Write("--foreach");
            Console.WriteLine(new string('-', 50));

            foreach (var item in myCar)
            {
                Console.WriteLine(item.Name + "  " + item.Price);
            }

            Console.Write("--Peek");
            Console.WriteLine(new string('-', 50));

            Console.WriteLine(myCar.Peek().Name);

            Console.Write("--Dequeue");
            Console.WriteLine(new string('-', 50));

            Console.WriteLine(myCar.Dequeue().Name);
            Console.WriteLine(myCar.Dequeue().Name);

            Console.Write("--Clear");
            Console.WriteLine(new string('-', 50));

            myCar.Clear();

            Console.WriteLine(new string('-', 50));

            #region MyQueue<int> Проверка на совместимость с int
            MyQueue<int> my = new MyQueue<int>();

            my.ClearEvent += Show_Message;
            my.DequeueEvent += Show_Message;
            my.EnqueueEvent += Show_Message;

            my.Enqueue(1);
            my.Enqueue(2);
            my.Enqueue(3);
            my.Enqueue(4);
            my.Enqueue(5);

            int a = my.Dequeue();
            Console.WriteLine(a);

            int a1 = my.Dequeue();
            Console.WriteLine(a1);

            Console.WriteLine(new string('-', 100));

            foreach (var item in my)
            {
                Console.WriteLine(item);
            }

            my.Enqueue(1);
            my.Enqueue(2);
            my.Clear();

            foreach (var item in my)
            {
                Console.WriteLine(item);
            }


            my.ClearEvent -= Show_Message;
            my.DequeueEvent -= Show_Message;
            my.EnqueueEvent -= Show_Message;

        }
        #endregion


        private static void Show_Message(object sender, MyQueueEventArgs<int> e)
        {
            Console.WriteLine($"Event:{e.Message}, Item: {e.Item.ToString()}");
        }

        private static void Show_FromCar(object sender, MyQueueEventArgs<Car> e)
        {
            Console.WriteLine($"Event:{e.Message}, Name: {e.Item.Name}, Price: {e.Item.Price}");
        }

        private static void Show_FromCar_Clear(object sender, MyQueueEventArgs<Car> e)
        {
            Console.WriteLine($"Event:{e.Message}");
        }
    }
}
