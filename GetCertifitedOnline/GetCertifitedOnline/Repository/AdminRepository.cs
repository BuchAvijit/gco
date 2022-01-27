using GetCertifitedOnline.DTO;
using GetCertifitedOnline.Entities;
using GetCertifitedOnline.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetCertifitedOnline.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private GCOContext context;

        public AdminRepository(GCOContext context)
        {
            this.context = context;
        }
        public Feedback ChangePassword(string Email, ChagePasswordDTO changePasswordDTO)
        {
            Admin admin1 = context.Admin.SingleOrDefault(s => s.adminEmail == Email);
            if (admin1 != null)
            {
                if (changePasswordDTO.OldPassword == admin1.password)
                {
                    admin1.password = changePasswordDTO.NewPassword;
                    context.Admin.Update(admin1);
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
                Feedback feedback = new Feedback { Result = false, Message = "Admin Email not registered!" };
                return feedback;
            }
        }

        public Feedback DeleteCandidate(int candidateId)
        {
            try
            {
                //Check if Customer exists or not
                Candidate candidate = context.Candidates.SingleOrDefault(s => s.candidateId == candidateId);
                if (candidate != null)
                {
                    //Deleted Customer
                    context.Candidates.Remove(candidate);
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "Candidate Removed" };
                    return fb;
                }
                else
                {
                    var fb = new Feedback() { Result = false, Message = "Candidate doesn't exists" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        public Feedback ForgetPassword(string Email, ForgotPasswordDTO forgetPasswordDTO)
        {
            Admin admin1 = context.Admin.SingleOrDefault(s => s.adminEmail == Email);
            if (admin1 != null)
            {
                if (forgetPasswordDTO.Answer == admin1.adminAnswer)
                {
                    admin1.password = forgetPasswordDTO.NewPassword;
                    context.Admin.Update(admin1);
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
                Feedback feedback = new Feedback { Result = false, Message = "Admin Email not registered!" };
                return feedback;
            }
        }

        public List<Candidate> GetAllCandidates()
        {
            try
            {
                List<Candidate> candidate = context.Candidates.FromSqlRaw("sp_GetCandidates").ToList(); //implemented stored procedure
                return candidate;
            }
            catch (Exception)
            {

                return null;
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

        public Candidate GetCandidaterById(int candidateId)
        {
            Candidate candidate = context.Candidates.SingleOrDefault(s => s.candidateId == candidateId);
            if (candidate != null)
            {
                return candidate;
            }
            else
            {
                return null;
            }
        }

        public Feedback UpdateProfile(int adminId, string adminName, string adminContactNo)
        {
            Feedback feedback = null;
            try
            {
                //Check if Customer already exists by matching Email & ElectricityBoardId
                Admin admin = context.Admin.SingleOrDefault(s => s.adminId == adminId);
                if (admin != null)
                {
                    admin.adminName = adminName;
                    admin.adminContanctNo = adminContactNo;
                    context.Admin.Update(admin);
                   context.SaveChanges();
                    feedback = new Feedback() { Result = true, Message = "Profile Updated!" };
                }
                else
                {
                    feedback = new Feedback() { Result = false, Message = "Invalid Admin ID!" };

                }

            }
            catch (Exception ex)
            {
                feedback = new Feedback() { Result = false, Message = ex.Message };

            }
            return feedback;
        }

        public Admin ValidateAdmin(LoginModel login)
        {
            return context.Admin.SingleOrDefault(u => u.adminEmail == login.emailId && u.password == login.password);
        }

        public AdminDTO ViewAdminById(long AdminId)
        {
            Admin admin = context.Admin.SingleOrDefault(s => s.adminId == AdminId);
            if (admin != null)
            {
                AdminDTO adminDTO = new AdminDTO();
                adminDTO.AdminId = admin.adminId;
                adminDTO.Role = admin.role;
                adminDTO.AdminName = admin.adminName;
                adminDTO.AdminEmail = admin.adminEmail;
                adminDTO.AdminContanctNo = admin.adminContanctNo;
                if (adminDTO != null)
                {
                    return adminDTO;
                }
                else { return null; }
            }
            else { return null; }
        }

      /*  public AdminDTO viewAdminById(long AdminId)
        {

            Admin admin = context.Admin.SingleOrDefault(s => s.adminId == AdminId);
            if (admin != null)
            {
                AdminDTO adminDTO = new AdminDTO();
                adminDTO.AdminId = admin.adminId;
                adminDTO.Role = admin.role;
                adminDTO.AdminName = admin.adminName;
                adminDTO.AdminEmail = admin.adminEmail;
                adminDTO.AdminContanctNo = admin.adminContanctNo;
                if (adminDTO != null)
                {
                    return adminDTO;
                }
                else { return null; }
            }
            else { return null; }

        }*/
    }
}
