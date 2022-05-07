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
                DateTime contractDate;
                contractDate = ParseDateTime();

                userController.SetNewWorkerData(idWorker, contractDate, countryWorker);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }
        /// <summary>
        /// Ввод и проверка формата даты окончания контракта
        /// </summary>
        /// <returns>дата окончания контракта в формате DateTime</returns>
        private static DateTime ParseDateTime()
        {
            DateTime contractDate;
            while (true)
            {
                Console.WriteLine("Введите дату окончания контракта работника (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out contractDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты");
                }
            }

            return contractDate;
        }
    }
}
