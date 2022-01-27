using GetCertifitedOnline.DTO;
using GetCertifitedOnline.Entities;
using GetCertifitedOnline.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetCertifitedOnline.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private GCOContext context;
        public CandidateRepository(GCOContext context)
        {

            this.context = context;
        }

        public Feedback addCandidate(Candidate candidate, Role role)
        {
            Feedback feedback = null;
            try
            {
                //check if candidate already exists by matching email
                Candidate candidate1 = context.Candidates.SingleOrDefault(s => s.candidateEmail == candidate.candidateEmail);
                if (candidate1 == null)
                {
                    //Add Farmers
                    candidate.Role = role.ToString();
                    context.Candidates.Add(candidate);
                    context.SaveChanges();
                    feedback = new Feedback() { Result = true, Message = "Candidate Added" };
                }
                else
                {
                    feedback = new Feedback() { Result = false, Message = "Candidate with same EmailID already exists" };

                }
            }
            catch(Exception ex)
            {
                feedback = new Feedback() { Result = false, Message = ex.Message };
            }
            return feedback;
        }

        public Feedback ChangePassword(string Email, ChagePasswordDTO changePasswordDTO)
        {
            Candidate candidate1 = context.Candidates.SingleOrDefault(s => s.candidateEmail == Email);
            if (candidate1 != null)
            {
                if (changePasswordDTO.OldPassword == candidate1.Password)
                {
                    candidate1.Password = changePasswordDTO.NewPassword;
                    context.Candidates.Update(candidate1);
                    context.SaveChanges();
                    Feedback feedback = new Feedback { Result = true, Message = "Password Changed" };
                    return feedback;
                }
                else
                {
                    Feedback feedback = new Feedback { Result = false, Message = "Incorrect Password" };
                    return feedback;
                }
            }
            else
            {
                Feedback feedback = new Feedback { Result = false, Message = "Customer Email not registered!" };
                return feedback;
            }
        }

        public Feedback ForgetPassword(string Email, ForgotPasswordDTO forgetPasswordDTO)
        {
            Candidate candidate1 = context.Candidates.SingleOrDefault(s => s.candidateEmail == Email);
            if (candidate1 != null)
            {
                if (forgetPasswordDTO.Answer == candidate1.candidateAnswer)
                {
                    candidate1.Password = forgetPasswordDTO.NewPassword;
                    context.Candidates.Update(candidate1);
                    context.SaveChanges();
                    Feedback feedback = new Feedback { Result = true, Message = "Password has been reset!" };
                    return feedback;
                }
                else
                {
                    Feedback feedback = new Feedback { Result = false, Message = "Incorrect Answer!" };
                    return feedback;
                }
            }
            else
            {
                Feedback feedback = new Feedback { Result = false, Message = "Customer Email not registered!" };
                return feedback;
            }
        }

        public List<Course> GetAllCourses()
        {
            try
            {
                List<Course> courses = context.Courses.FromSqlRaw("sp_GetCourses").ToList(); //implemented stored procedure
                return courses;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Feedback UpdateProfile(int candidateId, string candidateName, string cnadidateContactNo)
        {
            Feedback feedback = null;
            try
            {
                //Check if Customer already exists by matching Email & ElectricityBoardId
                Candidate candidate = context.Candidates.SingleOrDefault(s => s.candidateId == candidateId);
                if (candidate != null)
                {
                    candidate.candidateName = candidateName;
                    candidate.candidateContanctNo = cnadidateContactNo;
                    context.Candidates.Update(candidate);
                    context.SaveChanges();
                    feedback = new Feedback() { Result = true, Message = "Profile Updated!" };
                }
                else
                {
                    feedback = new Feedback() { Result = false, Message = "Invalid Candidate ID!" };

                }

            }
            catch (Exception ex)
            {
                feedback = new Feedback() { Result = false, Message = ex.Message };

            }
            return feedback;
        }

        public Candidate ValidateCandidate(LoginModel login)
        {
            return context.Candidates.SingleOrDefault(u => u.candidateEmail == login.emailId && u.Password == login.password);
        }

        public CandidateDTO ViewCandidateById(int candidateId)
        {
            Candidate candidate = context.Candidates.SingleOrDefault(s => s.candidateId == candidateId); ;
            if (candidate != null)
            {
                CandidateDTO candidateDTO = new CandidateDTO();
                candidateDTO.CandidateId = candidate.candidateId;
                candidateDTO.Role = candidate.Role;
                candidateDTO.CandidateName = candidate.candidateName;
                candidateDTO.CandidateEmail = candidate.candidateEmail;
                candidateDTO.CandidateContanctNo = candidate.candidateContanctNo;
                candidateDTO.CandidateAddress = candidate.CandidateAddress;
                if (candidateDTO != null)
                {
                    return candidateDTO;
                }
                else { return null; }
            }
            else { return null; }
        }
    }
}
