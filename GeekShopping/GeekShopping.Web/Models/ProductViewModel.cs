using System.ComponentModel.DataAnnotations;

namespace GeekShopping.Web.Models
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }

        [Range(1, 100)]
        public int Count { get; set; } = 1;

        public string SubstringName()
        {
            return Name.Length < 24 ? Name : $"{ Name[..21] } ...";
        }

        public string SubstringDescription()
        {
            return Description.Length < 355 ? Description : $"{ Description[..352] } ...";
        }
    }
}
