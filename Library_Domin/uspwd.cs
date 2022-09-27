using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Domin
{
    public class uspwd
    {
        public int id { get; set; }
        [MaxLength(50)]
        [Required]
        public string username { get; set; }
        [MaxLength(50)]
        [Required]
        public string password { get; set; }
    }
}
