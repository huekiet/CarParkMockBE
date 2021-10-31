using CoreApp.Dto.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreApp.dto.Request.Authentication
{
    public class LoginRequest: BaseRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

        //public override bool IsValid()
        //{
        //    ValidationResult = new LoginRequestValidation().Validate(this);
        //    return ValidationResult.IsValid;
        //}
    }
}
