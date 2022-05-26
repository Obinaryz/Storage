using System;
using System.Globalization;
using Storage.BL.Controller;
using Storage.BL.Model;
using System.Resources;
namespace Storage.CMD
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("Storage.CMD.Languages.Messages",typeof(MainClass).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello",culture));

            Console.WriteLine(resourceManager.GetString("EnterName",culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var sellController = new SellController(userController.CurrentUser);
            var workTimeController = new WorkTimeController(userController.CurrentUser);

            if (userController.IsNewUser == true)
            {
                Console.WriteLine(resourceManager.GetString("WorkerId",culture)) ;
                var idWorker = int.Parse(Console.ReadLine());
                Console.WriteLine(resourceManager.GetString("WorkerCountry",culture));
                var countryWorker = Console.ReadLine();
                DateTime contractDate = ParseDateTime(resourceManager.GetString("ContractData",culture));

                userController.SetNewWorkerData(idWorker, contractDate, countryWorker);
            }
            Console.WriteLine(userController.CurrentUser);

            while (true) { 
                Console.WriteLine(resourceManager.GetString("WhatWant",culture));
                Console.WriteLine(resourceManager.GetString("EnterrSell",culture));
                Console.WriteLine("W - ввести работу");
                Console.WriteLine("Q - выход");
            
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                    var items = EnterSellItem();
                    sellController.Add(items,items.Price);
                    foreach(var product in sellController.Sells.Items)
                    {
                        Console.WriteLine($"\t{product.Key} - {product.Value}");
                    }
                        break;

                    case ConsoleKey.W:
                        var workedTime = EnterWorkTime();
                        var workTime = new WorkTime(workedTime.Start,workedTime.Finish,workedTime.Work,userController.CurrentUser);
                        workTimeController.Add(workTime.Work, workTime.Start, workTime.Finish);

                        foreach(var job in workTimeController.WorkTimes)
                        {
                            Console.WriteLine($"{job.Work} с {job.Start.ToShortTimeString()} по {job.Finish.ToShortTimeString()}");
                        }
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;

                }
            }
        }

        private static WorkTime EnterWorkTime()
        {
            Console.WriteLine("Введите название работы");
            var name = Console.ReadLine();
            var kpi = ParseDouble("KPI работы");
            var begin = ParseDateTime("время начала работы");
            var end = ParseDateTime("время окончания работы");
            var work = new Work(name,kpi);
            var workTime = new WorkTime(begin, end, work,new User("1"));

            return workTime;
        }

        private static Item EnterSellItem()
        {
            Console.WriteLine("Введите имя товара: ");//TODO: localization
            var item = Console.ReadLine();
            var price = ParseDouble("цену");
            var weight = ParseDouble("массу");
            var shelfLife = ParseDateTime("дату окончания срока годности товара");
            Console.WriteLine("Введите Страну импортера: ");
            var country = Console.ReadLine();
            var import = new Country(country);
            var product = new Item(item,weight,price,shelfLife, import);

            return product;
        }

        /// <summary>
        /// проверка формата даты
        /// </summary>
        /// <returns>дата в формате DateTime</returns>
        private static DateTime ParseDateTime(string name)
        {
            DateTime DateFormat;
            while (true)
            {
                Console.WriteLine($"Введите {name}: ");
                if (DateTime.TryParse(Console.ReadLine(), out DateFormat))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный форм.");
                    Console.WriteLine($"Введите {name} еще раз: ");
                }
            }

            return DateFormat;
        }
        /// <summary>
        /// проверка формата числа с плавающей запятой
        /// </summary>
        /// <returns>число в формате Double</returns>
        private static double ParseDouble(string name)
        {
            double DoubleFormat;
            while (true)
            {
                Console.WriteLine($"Введите {name}");
                if (double.TryParse(Console.ReadLine(), out DoubleFormat))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат числа.");
                    Console.WriteLine($"Введите {name} еще раз: ");
                }
            }

            return DoubleFormat;
        }
    }
}
