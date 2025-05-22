using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcunMedyaClassProject.Dtos.LectureDtos
{
    public class ResultLectureDto
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
    }
}
