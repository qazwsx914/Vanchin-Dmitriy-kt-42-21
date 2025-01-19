namespace DmitriyVanchinKt_42_21.Models
{
    public class Cathedra
    {
        public int  CathedraId { get; set; }
        public string CathedraName { get; set; }
        public string TypeDirection { get; set; } // Тип кафедры
        public int HeadLecturerId { get; set; }  // Заведующий кафедрой
        public Lecturer HeadLecturer { get; set; }  // Связь с моделью Преподаватель
    }
}
