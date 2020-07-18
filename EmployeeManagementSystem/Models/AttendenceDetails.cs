using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Models
{
    public partial class AttendenceDetails
    {
        public int Attendence_Detail_ID { get; set; }
        public int EmployeeID { get; set; }
        public string Attendence { get; set; }
        public DateTime Date{ get; set; }
    }
}

