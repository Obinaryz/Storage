using System;
namespace Storage.BL.Model
{
    [Serializable]
    public class Work
    {
        public string Name { get; }

        public double Kpi { get; }

        public Work(string name,double kpi)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя работы не может быть пустым", nameof(name));
            }
            if (kpi <= 0)
            {
                throw new ArgumentException("KPI не может быть меньше или равно нулю", nameof(kpi));
            }

            Name = name;
            Kpi = kpi;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
