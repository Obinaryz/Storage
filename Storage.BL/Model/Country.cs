using System;
using System.Collections.Generic;

namespace Storage.BL.Model
{/// <summary>
/// Страна
/// </summary>
    [Serializable]
    public class Country
    {
        public int Id { get; set; }
        /// <summary>
        /// Название страны
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Добавить новую страну
        /// </summary>
        /// <param name="name">Название страны </param>
        public Country(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя страны не может быть пустым или null", nameof(name));
            }

            Name = name;
        }

        public Country() { }
        public override string ToString()
        {
            return  Name;
        }
    }
}
