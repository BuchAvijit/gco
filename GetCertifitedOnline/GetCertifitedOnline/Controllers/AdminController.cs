using GetCertifitedOnline.DTO;
using GetCertifitedOnline.Entities;
using GetCertifitedOnline.Models;
using GetCertifitedOnline.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetCertifitedOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize (Roles = "ADMIN")]
    public class AdminController : ControllerBase
    {
        private IAdminRepository repo;
        //Constructor
        public AdminController(IAdminRepository repo)
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
        [Route("ViewAdmin/{AdminId}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult ViewAdmin(int AdminId)
        {
            AdminDTO adminDTO = repo.ViewAdminById(AdminId);
            if (adminDTO != null)
            {
                return Ok(adminDTO);
            }
            else
            {
                return NotFound("Invalid Admin ID");
            }
        }
        [HttpGet]
        [Route("GetCandidaterById")]
        public IActionResult GetCustomerById(int candidateId)
        {
            try
            {
                Candidate candidate = repo.GetCandidaterById(candidateId);
                if (candidate != null)
                {
                    return Ok(candidate);
                }
                else
                {
                    return NotFound("No such candidate Available!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("GetAllCandidates")]
        public IActionResult GetAllCandidates()
        {
            try
            {
                List<Candidate> candidates = repo.GetAllCandidates();
                if (candidates != null) { return Ok(candidates); }
                else { return NotFound("No candidates Data Available!"); }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        [Route("DeleteCandidate")]
        public IActionResult DeleteCandidate(int candidateId)
        {
            if (candidateId != 0)
            {
                Feedback feedback = repo.DeleteCandidate(candidateId);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("Candidate not entered");
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
