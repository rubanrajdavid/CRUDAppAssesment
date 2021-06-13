using System.ComponentModel.DataAnnotations;

namespace CRUDAppAssesment.Models
{
    public class ProductAsBodyDto
    {
        //Validation rule to limit the Name Sting by 50 characters
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
