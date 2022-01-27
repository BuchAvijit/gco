using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetCertifitedOnline.Entities
{
    [Table("courses")]
    public class Course
    {
        [Key]
        public long courseId { get; set; }

        [Required(ErrorMessage ="enter course name")]
        public string courseName { get; set; }

        [Required]
        public string couseFee { get; set; }
        [Required]
        public string courseDuration { get; set; }

    }
}
