using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Firstname { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Lastname { get; set; }

        [Required]
        [MinLength(9)]
        [MaxLength(18)]
        public string Phone { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Brand { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(10)]
        public string Registration { get; set; }

        [Required]
        [MaxLength(100)]
        public string Maintenance { get; set; }


        [Required]
        public DateTime Checkdate { get; set; }

        [MaxLength(250)]
        public string Information { get; set; }
    }
}
