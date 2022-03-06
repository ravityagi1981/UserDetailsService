using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UserDetailsService.Models
{
    public partial class UserType
    {
        public int UserTypeId { get; set; }
        public int? UserId { get; set; }
        public string UserType1 { get; set; }
        public string Createdby { get; set; }
        public DateTime? Createddt { get; set; }
    }
}
