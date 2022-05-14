using System;
using Storage.BL.Controller;
using Storage.BL.Model;

namespace Storage.CMD
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Привет!");

            Console.WriteLine("Введите имя пользователя: ");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var sellController = new SellController(userController.CurrentUser);
            if (userController.IsNewUser == true)
            {
                Console.WriteLine("Введите id Работника: ");
                var idWorker = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите Страну Работника: ");
                var countryWorker = Console.ReadLine();
                DateTime contractDate = ParseDateTime("окончания контракта работника");

                userController.SetNewWorkerData(idWorker, contractDate, countryWorker);
            }
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("Е - ввести прием пищи");
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
            Console.WriteLine("Введите имя товара: ");
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
