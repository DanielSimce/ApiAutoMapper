using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerApi.Dto
{
    public class PlayerDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string NameSimo { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Club { get; set; }
    }
}
