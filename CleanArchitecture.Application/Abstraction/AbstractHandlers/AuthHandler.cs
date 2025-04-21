using CleanArchitecture.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Abstraction.AbstractHandlers
{
    public abstract class AuthHandler
    {
        public IAuthService _authService;

        protected AuthHandler(IAuthService authService)
        {
            _authService = authService;
        }
    }
}
