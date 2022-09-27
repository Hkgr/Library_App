using System.ComponentModel.DataAnnotations;

namespace Library_Domin
{
    public class Book
    {
        public int id{ get; set; }

        [MaxLength(50)]
        [Required]
        public string name { get; set; }
        [MaxLength(50)]
        [Required]
        public string auther { get; set; }
        [MaxLength(50)]
        [Required]
        public double price { get; set; }
        [MaxLength(50)]
        [Required]
        public int copies { get; set; }

        public bool isDeleted { get; set; } = false;
    }
}