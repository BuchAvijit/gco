using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetCertifitedOnline.Entities;
using GetCertifitedOnline.Models;
using GetCertifitedOnline.DTO;

namespace GetCertifitedOnline.Repository
{
    public interface IAdminRepository
    {
        AdminDTO ViewAdminById(long AdminId);
        Feedback ChangePassword(string Email, ChagePasswordDTO changePasswordDTO);
        Feedback ForgetPassword(string Email, ForgotPasswordDTO forgetPasswordDTO);
        Admin ValidateAdmin(LoginModel login);
        Feedback UpdateProfile(int adminId, string adminName, string adminContactNo);
        Candidate GetCandidaterById(int candidateId);
        Feedback DeleteCandidate(int candidateId);
        List<Candidate> GetAllCandidates();
        List<Course> GetAllCourses();

    }
}
