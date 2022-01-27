using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetCertifitedOnline.Repository;
using GetCertifitedOnline.DTO;
using GetCertifitedOnline.Entities;
using GetCertifitedOnline.Models;


namespace GetCertifitedOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="CADIDATE")]
    public class CandidateController : ControllerBase
    {
        private ICandidateRepository repo;
        //constructor
        public CandidateController(ICandidateRepository repo)
        {
            this.repo = repo;
        }
        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult ChangePassword(string Email, ChagePasswordDTO changePasswordDTO)
        {
            Feedback feedback = repo.ChangePassword(Email, changePasswordDTO);
            if (feedback.Result == true) { return Ok(feedback.Message); }
            else { return NotFound(feedback.Message); }

        }
        [HttpGet]
        [Route("ViewCandidate/{CandidateId}")]
        public IActionResult ViewCanidate(int CandidateId)
        {
            CandidateDTO candidateDTO = repo.ViewCandidateById(CandidateId);
            if (candidateDTO == null)
            {
                return NotFound("Invalid Candidate ID");

            }
            return Ok(candidateDTO);
        }
        [HttpPut]
        [Route("UpdateProfile")]
        public IActionResult UpdateProfile(int candidateId, string candidateName, string cnadidateContactNo)
        {
            try
            {
                Feedback feedback = repo.UpdateProfile(candidateId, candidateName, cnadidateContactNo);
                return Ok(feedback.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetAllCourses")]
        public IActionResult GetAllCourses()
        {
            try
            {
                List<Course> courses = repo.GetAllCourses();
                if (courses != null) { return Ok(courses); }
                else { return NotFound("No course Data Available!"); }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}