using System;
namespace Storage.BL.Model
{/// <summary>
/// Товар
/// </summary>
    public class Item
    {
        #region Свойства
        /// <summary>
        /// Имя товара
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Количество товара
        /// </summary>
        public double CountOrWeight { get; set; }
        /// <summary>
        /// Страна Производитель
        /// </summary>
        public Country Country { get; }
        /// <summary>
        /// Дата окончания срока годности
        /// </summary>
        public DateTime ShelfLife { get; }
        #endregion
        /// <summary>
        /// Добавить новый товар
        /// </summary>
        /// <param name="name">Имя товара</param>
        /// <param name="countorweight">Количество товара</param>
        /// <param name="shelflife">Окончание даты срока годности</param>
        /// <param name="country">Страна производитель</param>
        public Item(string name, double countorweight,DateTime shelflife,Country country)
        {
            #region Проверка входных условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя товара не может быть пустым",nameof(name));
            }
            if (shelflife < DateTime.Parse("01.01.1900") || shelflife >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата срока годности", nameof(shelflife));
            }
            if (countorweight <= 0)
            {
                throw new ArgumentException("Количество не может быть меньше или равно нулю", nameof(countorweight));
            }
            if (country == null)
            {
                throw new ArgumentNullException("Имя страны не может быть пустым",nameof(country));
            }
            #endregion
            Name = name;
            CountOrWeight = countorweight;
            ShelfLife = shelflife;
            Country = country;
        }

        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
