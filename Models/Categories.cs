
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pharma_Ky.Models
    {
        public class Categories
        {
            [Required]
            [DisplayName("Title")]
            public string Title { get; set; }
            public string Breef { get; set; }
            [Required]
            [DisplayName("Image")]
            public string ImageUrl { get; set; }
        }
    }


