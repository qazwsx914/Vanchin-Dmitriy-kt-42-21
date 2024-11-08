namespace DmitriyVanchinKt_42_21.Models
{
    public class Load
    {
        public int LoadId { get; set; }
        public int LecturerId { get; set; }
        public int DisciplineId { get; set; }
        public int OpeningHours { get; set; }
        public Discipline Discipline { get; set; }
        public Lecturer Lecturer { get; set; }
    }
}
