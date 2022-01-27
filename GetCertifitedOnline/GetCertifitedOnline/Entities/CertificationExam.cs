using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GetCertifitedOnline.Entities
{
    [Table("certificationexams")]
    public class CertificationExam
    {
        [Key]
        public long examId { get; set; }
        
        [Required(ErrorMessage ="set the exam name")]
        public string examName { get; set; }

        [Required(ErrorMessage ="set the exam duration")]
        public int examDuration { get; set; }

        [Required(ErrorMessage ="set date and time")]
        public DateTime examDateTime { get; set; }
    }
}
