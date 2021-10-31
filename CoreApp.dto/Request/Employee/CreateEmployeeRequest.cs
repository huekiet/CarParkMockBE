﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.dto.Request.Employee
{
    public class CreateEmployeeRequest : BaseRequest
    {
        public string Account { get; set; }

        public string Department { get; set; }

        public string EmployeeAddress { get; set; }

        public DateTime? EmployeeBirthdate { get; set; }

        public string EmployeeEmail { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeePhone { get; set; }

        public string Sex { get; set; }

        public string Password { get; set; }
    }
}
