using System;
namespace Storage.BL.Model
{/// <summary>
/// Страна производитель
/// </summary>
    public class Country
    {/// <summary>
    /// Название страны
    /// </summary>
        public string Name { get; }
        /// <summary>
        /// Добавить новую страну
        /// </summary>
        /// <param name="name">Название страны производителя</param>
        public Country(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя страны не может быть пустым или null", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return  Name;
        }
    }
}
