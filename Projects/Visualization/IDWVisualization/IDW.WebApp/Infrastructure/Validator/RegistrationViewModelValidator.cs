using FluentValidation;
using IDW.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDW.WebApp.Infrastructure.Validator
{
    public class RegistrationViewModelValidator:AbstractValidator<RegistrationViewModel>
    {
        public RegistrationViewModelValidator()
        {
            RuleFor(r => r.Email).NotEmpty().EmailAddress().WithMessage("Invalid email address");
            RuleFor(r => r.Username).NotEmpty().WithMessage("Invalid username");
            RuleFor(r => r.Password).NotEmpty().WithMessage("Invalid password");
        }
    }
}