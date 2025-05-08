using AcunMedyaClassProject.WebApi.Enums;

namespace AcunMedyaClassProject.WebApi.Entities
{
    public class LectureExam
    {
        public int Id { get; set; }
        public int LectureId { get; set; }
        public string StudentId { get; set; }
        public ExamType ExamType { get; set; }
        public double Grade { get; set; }
        public AppUser Student { get; set; }
        public Lecture Lecture { get; set; }
    }
}
