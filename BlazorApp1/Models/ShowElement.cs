using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    public class ShowElement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = 0;
        [Required]
        public string Name { get; set; } = String.Empty;
        public string ShowSection { get; set; } = String.Empty;
        public bool Status { get; set; } = false;
    }
}