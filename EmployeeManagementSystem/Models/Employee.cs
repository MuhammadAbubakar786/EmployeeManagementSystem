using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Models
{
    public partial class Employee
    {
        public int EId { get; set; }
        public string EFirstName { get; set; }
        public string ELastName { get; set; }
        public string EEmail { get; set; }
        public string JobTitle { get; set; }
        public string EPhoneNumber { get; set; }
        public string EAddress { get; set; }
        public string EGender { get; set; }
        public string ECity { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
