namespace AcunMedyaClassProject.WebApi.Entities
{
    /// <summary>
    /// Ders sınıfı
    /// </summary>
    public class Lecture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Ders için öğrenci kontenjanı
        /// </summary>
        public int Limit { get; set; }
        public string LecturerId { get; set; }
        public AppUser Lecturer { get; set; }
        public List<StudentLecture> StudentLectures { get; set; }
        public List<LectureExam> LectureExams { get; set; }
    }
}
