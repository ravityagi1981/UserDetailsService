using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UserDetailsService.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public DateTime? Dob { get; set; }
        public string Createdby { get; set; }
        public DateTime? Createddt { get; set; }
    }
}
