using System;
namespace Storage.BL.Model
{
    [Serializable]
    public class WorkTime
    {
        public DateTime Start { get; }
        public DateTime Finish { get; }
        public Work Work { get; }
        public User User { get; }

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
