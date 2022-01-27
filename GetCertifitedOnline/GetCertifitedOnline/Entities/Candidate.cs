using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GetCertifitedOnline.Entities
{
    [Table("candidates")]
    public class Candidate
    {
        [Key]
        public int candidateId { get; set; }  //Primary Key
        public string Role { get; set; }   //Role of the User

        [Required]
        public string candidateQuestion { get; set; }   // Security question of Cadidate

        [Required]
        public string candidateAnswer { get; set; }   //Security answer of Candidate

        [Required(ErrorMessage = "Please Enter your name")]
        public string candidateName { get; set; }   //Name of the Candidate

        [Required(ErrorMessage = "Please Enter an Email address")]
        [EmailAddress(ErrorMessage = "Enter a valid Email Address")]
        public string candidateEmail { get; set; }   //EmailId of the candidate Used for LogIn purpose

        [Required(ErrorMessage = "Please create a password")]
        public string Password { get; set; } //Password of the candidate Used for LogIn purpose

        [Required(ErrorMessage = "Please Enter your Contanct Number")]
        [Phone(ErrorMessage = "Contanct no format not Correct")]
        public string candidateContanctNo { get; set; } //Contanct number of the candidate

        [Required(ErrorMessage = "Please Enter your address")]
        public string CandidateAddress { get; set; }  //Address of the Customer
    }
}
