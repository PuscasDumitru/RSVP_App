using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFDatabaseAccess.Models
{
    public class GuestResponse
    {
        public int Id { get; set; }

        [MaxLength(15)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }
        
        [MaxLength(15)]
        public string Phone { get; set; }
        public bool Attend { get; set; }
    }
}
