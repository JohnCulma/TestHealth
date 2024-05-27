using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.UserDTO
{
    public class UpdateDto
    {
        public int Id { get; set; }
        public int PatientID { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(1)]
        public string Gender { get; set; } = null!;

        [StringLength(200)]
        public string? Address { get; set; }
        [StringLength(15)]
        public string? ContactNumber { get; set; }
    }
}
