namespace DmitriyVanchinKt_42_21.Models
{
    public class Cathedra
    {
        public int  CathedraId { get; set; }
        public string CathedraName { get; set; }
        public int HeadLecturerId { get; set; }  // Заведующий кафедрой
        public Lecturer HeadLecturer { get; set; }  // Связь с моделью Преподаватель
    }
}
