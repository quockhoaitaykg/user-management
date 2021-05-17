using System;
using System.Collections.Generic;

namespace UserManagement.Models
{
    public partial class Information
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public bool? Active { get; set; }
    }
}
