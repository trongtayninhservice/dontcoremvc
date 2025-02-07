using System.ComponentModel.DataAnnotations;

namespace AdvancedEship.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public string? CategoryDescription { get; set; }
        //Photo of the category
        public string? CategoryPhoto { get; set; }
        //Order of the category
        public int CategoryOrder { get; set; }

    }
}
