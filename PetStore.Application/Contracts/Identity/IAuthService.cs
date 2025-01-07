using PetStore.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login (AuthRequest request);
        Task<Registrationresponse> Register (RegistrationRequest request);
    }
}
