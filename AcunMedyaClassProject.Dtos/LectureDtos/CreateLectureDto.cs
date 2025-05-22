using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcunMedyaClassProject.Dtos.LectureDtos
{
    public class CreateLectureDto
    {
        public string Name { get; set; }
        public int Credit { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Limit { get; set; }
        public string LecturerId { get; set; }
    }
}
