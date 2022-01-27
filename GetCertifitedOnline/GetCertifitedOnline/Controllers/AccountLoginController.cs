using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetCertifitedOnline.Entities;
using GetCertifitedOnline.Models;
using GetCertifitedOnline.DTO;
using GetCertifitedOnline.Repository;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;
 

namespace GetCertifitedOnline.Controllers
    
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountLoginController : ControllerBase
    {
        private IAdminRepository adminRepository = null;
        private ICandidateRepository candidateRepository = null;
        //constructor
        public AccountLoginController(IAdminRepository adminRepository , ICandidateRepository candidateRepository)
        {
            this.adminRepository = adminRepository;
            this.candidateRepository = candidateRepository;
        }
        //Logging in Admin
        [Route("AdminLogin")]
        [HttpPost]
        public IActionResult AdminLogin(LoginModel login)
        {
            LoggedUserModel model = new LoggedUserModel();
            //Validating Login credentials
            Admin admin = adminRepository.ValidateAdmin(login);
            if (admin != null)
            {
                string token = getTokenForAdmin(admin);
                model = new LoggedUserModel() { Id = admin.adminId, EmailID = admin.adminEmail, Token = token, Role = admin.role };
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }

            return Ok(model);
        }
        //Logging in User
        [Route("CandidateLogin")]
        [HttpPost]
        public IActionResult CandidateLogin(LoginModel login)
        {
            LoggedUserModel model = new LoggedUserModel();
            //Validating Login credentials
            Candidate candidate = candidateRepository.ValidateCandidate(login);
            if (candidate != null)
            {
                string token = GetTokenForCandidate(candidate);
                model = new LoggedUserModel() { Id = candidate.candidateId, EmailID = candidate.candidateEmail, Token = token, Role = candidate.Role };
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }

            return Ok(model);
        }
        [Route("AdminForgetPassword")]
        [HttpPost]
        public IActionResult AdminForgetPassword(Role role, string Email, ForgotPasswordDTO forgetPassword)
        {
            if (role == Role.ADMIN)
            {
                Feedback feedback = adminRepository.ForgetPassword(Email, forgetPassword);
                if (feedback.Result == true)
                {
                    return Ok(feedback.Message);
                }
                else
                {
                    return BadRequest(feedback.Message);
                }
            }
            else
            {
                return BadRequest("You don't have permission for this Request!");
            }
            //Validating Login credentials

        }
        [Route("CandidateForgetPassword")]
        [HttpPost]
        public IActionResult CandidateForgetPassword(Role role, string Email, ForgotPasswordDTO forgetPassword)
        {
            if (role == Role.CANDIDATE)
            {
                Feedback feedback = candidateRepository.ForgetPassword(Email, forgetPassword);
                if (feedback.Result == true)
                {
                    return Ok(feedback.Message);
                }
                else
                {
                    return BadRequest(feedback.Message);
                }
            }
            else
            {
                return BadRequest("Email has not been registered!");
            }
            //Validating Login credentials

        }

        private string getTokenForAdmin(Admin person)
        {
            var _config = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json").Build();
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(2);
            var securityKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials
        (securityKey, SecurityAlgorithms.HmacSha256);

            //    var token = new JwtSecurityToken(issuer: issuer,
            //audience: audience,

            //expires: DateTime.Now.AddMinutes(120),
            //signingCredentials: credentials);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                   {
                    new Claim(ClaimTypes.NameIdentifier, person.adminId.ToString()),
                    new Claim(ClaimTypes.Name, person.adminEmail.ToString()),
                    new Claim(ClaimTypes.Role, person.role)
                   }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
        private string GetTokenForCandidate(Candidate person)
            {
                var _config = new ConfigurationBuilder()
                                  .SetBasePath(Directory.GetCurrentDirectory())
                                  .AddJsonFile("appsettings.json").Build();
                var issuer = _config["Jwt:Issuer"];
                var audience = _config["Jwt:Audience"];
                var expiry = DateTime.Now.AddMinutes(2);
                var securityKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials
            (securityKey, SecurityAlgorithms.HmacSha256);

                //    var token = new JwtSecurityToken(issuer: issuer,
                //audience: audience,

                //expires: DateTime.Now.AddMinutes(120),
                //signingCredentials: credentials);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                       {
                    new Claim(ClaimTypes.NameIdentifier, person.candidateId.ToString()),
                    new Claim(ClaimTypes.Name, person.candidateEmail.ToString()),
                    new Claim(ClaimTypes.Role, person.Role)
                       }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var stringToken = tokenHandler.WriteToken(token);
                return stringToken;
            }
        }
    }

