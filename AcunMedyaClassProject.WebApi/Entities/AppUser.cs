using Microsoft.AspNetCore.Identity;

namespace AcunMedyaClassProject.WebApi.Entities
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public List<Lecture> Lectures { get; set; }
        public List<StudentLecture> StudentLectures { get; set; }
        public List<LectureExam> LectureExams { get; set; }
    }
}
