namespace AcunMedyaClassProject.WebApi.Entities
{
    public class StudentLecture
    {
        public int Id { get; set; }
        public int LectureId { get; set; }
        public string StudentId { get; set; }
        public DateTime RegisterDate { get; set; }
        public Lecture Lecture { get; set; }
        public AppUser Student { get; set; }
    }
}
