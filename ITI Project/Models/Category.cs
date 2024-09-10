using System.ComponentModel.DataAnnotations;

namespace ITI_Project.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string? Name { get; set; }

        [StringLength(200, ErrorMessage = "Description cannot be longer than 200 characters")]
        public string? Description { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
