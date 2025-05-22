using AcunMedyaClassProject.Dtos.StudentLectureDtos;
using AcunMedyaClassProject.WebApi.Context;
using AcunMedyaClassProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaClassProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentLecturesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentLecturesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateStudentLecture(CreateStudentLectureDto dto)
        {
            var studentLecture = new StudentLecture
            {
                LectureId = dto.LectureId,
                StudentId = dto.StudentId,
                RegisterDate = DateTime.UtcNow
            };
            _context.StudentLectures.Add(studentLecture);
            _context.SaveChanges();
            return Created("", studentLecture);
        }
        [HttpPost("CreateStudentLectureMultiple")]
        public IActionResult CreateStudentLectureMultiple(List<CreateStudentLectureDto> dto)
        {
            var lectures = dto.Select(x => new StudentLecture
            {
                LectureId = x.LectureId,
                StudentId = x.StudentId,
                RegisterDate = DateTime.UtcNow
            });
            _context.StudentLectures.AddRange(lectures);
            _context.SaveChanges();
            return Created("", lectures);
        }
        [HttpGet]
        public IActionResult GetStudentLecturesByStudentId(string studentId)
        {
            var studentLectures = _context.StudentLectures.Where(x => x.StudentId == studentId).Select(y => y.LectureId);
            var lectures=_context.Lectures.Where(x => !studentLectures.Contains(x.Id)).ToList();
            return Ok(lectures);
        }
    }
}
