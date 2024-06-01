using System.ComponentModel.DataAnnotations;

namespace Assignment.Models.DataModels
{
    public class ProductDataModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, RegularExpression(@"^\d{10}$")]
        
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Modifieddate { get; set; }  
        public int CreatedBy {  get; set; } 
        public int ModifiedBy { get; set; } 
        public bool IsDelete { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}
