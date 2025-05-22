using AcunMedyaClassProject.Dtos.LectureDtos;
using AcunMedyaClassProject.WebApi.Context;
using AcunMedyaClassProject.WebApi.Dtos;
using AcunMedyaClassProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaClassProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LecturesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddLecture(CreateLectureDto dto)
        {
            var lecture = new Lecture
            {
                Code = dto.Code,
                Credit = dto.Credit,
                Description = dto.Description,
                LecturerId = dto.LecturerId,
                Limit = dto.Limit,
                Name = dto.Name
            };
            _context.Lectures.Add(lecture);
            _context.SaveChanges();
            return Created("", lecture);
        }
        [HttpGet]
        public IActionResult GetAllLectures()
        {
            var lectures = _context.Lectures.ToList();
            return Ok(lectures);
        }
        [HttpGet("GetLectureByLecturer")]
        public IActionResult GetLectureByLecturer(string lecturerId)
        {
            var lectures = _context.Lectures.Where(x => x.LecturerId == lecturerId);
            return Ok(lectures);
        }
    }
}
