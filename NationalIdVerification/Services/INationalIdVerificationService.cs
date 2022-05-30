using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalIdVerification.Services
{
    public interface INationalIdVerificationService
    {
        Task<bool> IsNationalIdVerified(long id, string firstName, string lastName, int yearOfBirth);
    }
}
