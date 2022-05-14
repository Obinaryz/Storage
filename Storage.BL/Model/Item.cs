using System;
namespace Storage.BL.Model
{
    public class Item
    {
        public string Name { get; }
        /// <summary>
        /// Количество товара
        /// </summary>
        public double WeightOrCount { get; }
        /// <summary>
        /// Цена Товара за штуку или килограмм
        /// </summary>
        public double Price { get; }
        /// <summary>
        /// Срок годности
        /// </summary>
        public DateTime ShelfLife { get; }
        /// <summary>
        /// Страна производитель
        /// </summary>
        public Country Country { get; }
        public Item(string name) : this(name,0,0,DateTime.Now,new Country("Self")) { }
        /// <summary>
        /// Добавление товара на склад товара на склад
        /// </summary>
        /// <param name="name">Имя Товара</param>
        /// <param name="weightOrCount">Вес или количество товара</param>
        /// <param name="price">Цена Товара</param>
        /// <param name="shelfLife">Срок годности товара</param>
        /// <param name="country">Страна производитель товара</param>

        public Item(string name,double weightOrCount,double price, DateTime shelfLife, Country country)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя товара не может быть пустым", nameof(name));
            }
            if (weightOrCount < 0)
            {
                throw new ArgumentException("Количество товара не может быть меньше нуля",nameof(weightOrCount));
            }
            if (price < 0)
            {
                throw new ArgumentException("Цена товара не может быть меньше нуля", nameof(price));
            }
            if (shelfLife < DateTime.Now)
            {
                throw new ArgumentException("Срок годности не может быть просрочен", nameof(shelfLife));
            }
            if (country == null)
            {
                throw new ArgumentNullException("Имя страны не может быть пустым", nameof(country));
            }
            Name = name;
            WeightOrCount = weightOrCount;
            Price = price;
            ShelfLife = shelfLife;
            Country = country;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
