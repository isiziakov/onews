using System;
using System.Collections.Generic;

#nullable disable

namespace OnewsApi
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
