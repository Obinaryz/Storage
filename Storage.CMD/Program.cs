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
            if (userController.IsNewUser == true)
            {
                Console.WriteLine("Введите id Работника: ");
                var idWorker = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите Страну Работника: ");
                var countryWorker = Console.ReadLine();
                Console.WriteLine("Введите дату окончания контракта работника (dd.MM.yyyy): ");
                DateTime contractDate = ParseDateTime();

                userController.SetNewWorkerData(idWorker, contractDate, countryWorker);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }
        /// <summary>
        /// проверка формата даты
        /// </summary>
        /// <returns>дата в формате DateTime</returns>
        private static DateTime ParseDateTime()
        {
            DateTime DateFormat;
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateFormat))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты.");
                    Console.WriteLine("Введите дату еще раз: ");
                }
            }

            return DateFormat;
        }
    }
}
