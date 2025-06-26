using System.ComponentModel.DataAnnotations;

namespace StorageApi.Dto
{
    public class CreateProductDto
    {
        [Required(ErrorMessage ="Name is obligatory")]
        [StringLength(100)]
        public string Name { get; set; }
        [Range(1,5000)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Category is obligatory")]
        [StringLength(50)]
        public string Category { get; set; }
        [Required(ErrorMessage = "Shelf is obligatory")]
        [StringLength(5)]
        public string Shelf { get; set; }
        [Range(1, 1000)]
        public int Count { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
    }
}
