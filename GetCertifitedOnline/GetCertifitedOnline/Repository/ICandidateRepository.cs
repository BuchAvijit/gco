using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetCertifitedOnline.DTO;
using GetCertifitedOnline.Entities;
using GetCertifitedOnline.Models;

namespace GetCertifitedOnline.Repository
{
    public  interface ICandidateRepository
    {
        CandidateDTO ViewCandidateById(int candidateId);
        Feedback addCandidate(Candidate candidate, Role role);
        Feedback ChangePassword(string Email, ChagePasswordDTO changePasswordDTO);
        Feedback ForgetPassword(string Email, ForgotPasswordDTO forgetPasswordDTO);
        Feedback UpdateProfile(int candidateId, string candidateName, string cnadidateContactNo);
        Candidate ValidateCandidate(LoginModel login);
        List<Course> GetAllCourses();
    }
}
