namespace dmitriyVanchinKt_42_21.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; }
        public string DisciplineName { get; set; }
        public int LecturerId { get; set; }  // Преподаватель, который ведет дисциплину
        public Lecturer Lecturer { get; set; }  // Связь с моделью Преподаватель
    }
}