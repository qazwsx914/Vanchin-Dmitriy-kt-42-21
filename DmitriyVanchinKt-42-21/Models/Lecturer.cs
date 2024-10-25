namespace dmitriyVanchinKt_42_21.Models
{
    public class Lecturer
    {
        public int LecturerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int CathedraId { get; set; } //ID кафедры
        public Cathedra Cathedra { get; set; } // Связь с моделью Кафедра
        public ICollection<Discipline> Disciplines { get; set; }  // Дисциплины, которые ведет преподаватель
    }
}
