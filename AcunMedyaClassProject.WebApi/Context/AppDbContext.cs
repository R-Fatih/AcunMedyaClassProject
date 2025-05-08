using AcunMedyaClassProject.WebApi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaClassProject.WebApi.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<LectureExam> LectureExams { get; set; }
        public DbSet<StudentLecture> StudentLectures { get; set; }

        

    }
}
