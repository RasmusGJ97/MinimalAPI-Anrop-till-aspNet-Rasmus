using System.ComponentModel.DataAnnotations;

namespace MinimalAPI_Anrop_till_aspNet_Rasmus.Models
{
    public class Books
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string Author { get; set; }
        [Required]
        [StringLength(4, MinimumLength = 4)]
        public int Publiced { get; set; }
        [Required]
        [MaxLength(25)]
        public string Genre { get; set; }
        public string? Description { get; set; }
        [Required]
        public bool Available { get; set; }
    }
}
