using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetCertifitedOnline.DTO
{
    public class CandidateDTO
    {
        public int CandidateId { get; set; }  //Primary Key
        public string Role { get; set; }   //Role of the User
        public string CandidateName { get; set; }   //Name of the Customer
        public string CandidateEmail { get; set; }   //EmailId of the Customer Used for LogIn purpose
        public string CandidateContanctNo { get; set; } //Contanct number of the Customer
        public string CandidateAddress { get; set; }  //Address of the Customer
    }
}
