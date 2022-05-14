using System;
using System.Collections.Generic;
using System.Linq;

namespace Storage.BL.Model
{
    [Serializable]
    /// <summary>
    /// продажа товара
    /// </summary>
    public class Sell
    {   /// <summary>
        /// Время продажи
        /// </summary>
        public DateTime SellMoment { get; }
        /// <summary>
        /// Товар и вес
        /// </summary>
        public Dictionary<Item,double> Items { get; }
        /// <summary>
        /// Продавец
        /// </summary>
        public User Seller { get; }
        /// <summary>
        /// Продажа товара
        /// </summary>
        /// <param name="seller">продавец</param>
        public Sell(User seller)
        {
            Seller = seller ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(seller));
            SellMoment = DateTime.UtcNow;
            Items = new Dictionary<Item, double>();
        }
        /// <summary>
        /// добавление товара
        /// </summary>
        /// <param name="item">Имя товара</param>
        /// <param name="weight">Вес или количество товара</param>
        public void Add(Item item,double weight)
        {
            var newitem = Items.Keys.FirstOrDefault(c => c.Name.Equals(item.Name));

            if(newitem == null)
            {
                Items.Add(item, weight);
            }
            else
            {
                Items[newitem] += weight; 
            }
        }
    }
}
