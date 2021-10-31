using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.dto.Request.Employee
{
    public class UpdateEmployeeRequest: CreateEmployeeRequest
    {
        public long Id { get; set; }

    }
}
