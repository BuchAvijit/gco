using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GetCertifitedOnline.Entities
{
    [Table("admins")]
    public class Admin
    {
        [Key]
        public long adminId { get; set; } //Primary key

        [Required]
        public string role { get; set; } //Role of the person

        [Required]
        public string adminQuestion { get; set; } //Security Question Of Admin

        [Required]
        public string adminAnswer { get; set; } //Security Answer Of Admin

        [Required(ErrorMessage = "Please Enter your name")]
        public string adminName { get; set; } //Name of the Admin

        [Required(ErrorMessage = "Please Enter an Email address")]
        [EmailAddress(ErrorMessage = "Enter a valid Email Address")]
        public string adminEmail { get; set; }  //EmailId of the Admin which will be used for LogIn purpose

        [Required(ErrorMessage = "Please create a password")]
        public string password { get; set; } //Password of the Admin which will be used for LogIn purpose

        [Required(ErrorMessage = "Please Enter your Contanct Number")]
        [Phone(ErrorMessage = "Contanct no format not Correct")]
        public string adminContanctNo { get; set; } //Contanct number of the Admin
    }
}
