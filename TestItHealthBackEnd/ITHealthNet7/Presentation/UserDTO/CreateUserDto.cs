using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.UserDTO
{
    public class CreateUserDto
    {

        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [StringLength(50)]
        public string LastName { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        [StringLength(1)]
        public string Gender { get; set; } = null!;

        [StringLength(200)]
        public string? Address { get; set; }
        [StringLength(15)]
        public string? ContactNumber { get; set; }
    }
}
