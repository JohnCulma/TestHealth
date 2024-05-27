using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.UserDTO
{
    public class GetUserDto
    {
        [Required]
        public int Id { get; set; }
    }
}
