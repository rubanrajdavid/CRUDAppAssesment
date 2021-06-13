using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDAppAssesment.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID{ get; set; }

        // Declaring Size to be 50 Characters for the Name Coloumn
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
