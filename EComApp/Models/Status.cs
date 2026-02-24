using System.ComponentModel.DataAnnotations;

namespace EComApp.Models
{
    public class Status
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
