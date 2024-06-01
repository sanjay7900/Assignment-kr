namespace Assignment.Models.ViewModels
{
    public class ProductViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IFormFile ImageFile { get; set; }
        public bool? Selected { get; set; }
        public string? ImagePath { get; set; }
    }
}
