using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetCertifitedOnline.Entities;
using GetCertifitedOnline.Models;
using GetCertifitedOnline.Repository;

namespace GetCertifitedOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountSignUpController : ControllerBase
    {
        private ICandidateRepository candidateRepository;
        
        public AccountSignUpController(ICandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }
        [HttpPost]
        [Route("candidateSignUp")]
        public IActionResult candidateSignUp(Candidate candidate, Role role)
        {
            Feedback feedback = candidateRepository.addCandidate(candidate, role);
            if (feedback.Result == true) { return Ok(feedback.Message); }
            else { return BadRequest(feedback.Message); }
        }

    }
}
