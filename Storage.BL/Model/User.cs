using System;
namespace Storage.BL.Model
{/// <summary>
/// Товар
/// </summary>
[Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// ID сотрудника
        /// </summary>
        public int WorkerId { get; set; }
        /// <summary>
        /// Страна 
        /// </summary>
        public Country Country { get; set; }
        /// <summary>
        /// Дата окончания контракта
        /// </summary>
        public DateTime ContractDate { get; set; }
        #endregion


        /// <summary>
        /// Сколько еще лет будет действовать контракт
        /// </summary>
        public int ContractTerm { get { return ContractDate.Year - DateTime.Now.Year; } }


        /// <summary>
        /// Добавить нового пользователя
        /// </summary>
        /// <param name="name">Имя </param>
        /// <param name="workerid">ID работника</param>
        /// <param name="shelflife">Дата окончания контракта</param>
        /// <param name="country">Страна</param>
        public User (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя товара не может быть пустым", nameof(name));
            }

            Name = name;
        }
        public User(string name, int workerid,DateTime contractDate,Country country)
        {
            #region Проверка входных условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя товара не может быть пустым",nameof(name));
            }
            if (contractDate < DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата истечения контракта", nameof(contractDate));
            }
            if (workerid <= 0)
            {
                throw new ArgumentException("ID не может быть меньше или равно нулю", nameof(workerid));
            }
            if (country == null)
            {
                throw new ArgumentNullException("Имя страны не может быть пустым",nameof(country));
            }
            #endregion
            Name = name;
            WorkerId = workerid;
            ContractDate = contractDate;
            Country = country;
        }

        public override string ToString()
        {
            return Name+ " " + ContractTerm;
        }

    }
}
