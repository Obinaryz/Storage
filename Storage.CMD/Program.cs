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

            Console.WriteLine(resourceManager.GetString("WhatWant",culture));
            Console.WriteLine(resourceManager.GetString("EnterrSell",culture));
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.E)
            {
                var items = EnterSellItem();
                sellController.Add(items,items.Price);
                foreach(var product in sellController.Sells.Items)
                {
                    Console.WriteLine($"\t{product.Key} - {product.Value}");
                }
            }

            Console.ReadLine();
        }

        private static Item EnterSellItem()
        {
            Console.WriteLine("Введите имя товара: ");//TODO: localization
            var item = Console.ReadLine();
            var price = ParseDouble("цену");
            var weight = ParseDouble("массу");
            var shelfLife = ParseDateTime("окончания срока годности товара");
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
                Console.WriteLine($"Введите дату {name} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateFormat))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты.");
                    Console.WriteLine($"Введите дату {name} еще раз: ");
                }
            }

            return DateFormat;
        }
        /// <summary>
        /// проверка формата даты
        /// </summary>
        /// <returns>дата в формате DateTime</returns>
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
