using System;
namespace Storage.BL.Model
{
    [Serializable]
    public class WorkTime
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public int WorkId { get; set; }

        public Work Work { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public WorkTime() { }

        public WorkTime(DateTime start,DateTime finish,Work work,User user)
        {
            if (start < DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата начала работы", nameof(start));
            }
            if (finish <= start)
            {
                throw new ArgumentException("Невозможная дата окончания работы", nameof(finish));
            }
            Start = start;
            Finish = finish;
            Work = work ?? throw new ArgumentNullException("Название работы не может быть пустым", nameof(work));
            User = user ?? throw new ArgumentNullException("Имя работника не может быть пустым", nameof(user));

        }
    }
}
