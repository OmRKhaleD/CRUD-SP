using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUD_SP.Models
{
    public class TrainingProduct
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Product Name must be filled in")]
        [Display(Description ="Product Name")]
        [StringLength(150,MinimumLength =4,ErrorMessage ="Product Name must be greater than {2} characters and less than {1} charachters")]
        public string ProductName { get; set; }
        [Range(typeof(DateTime),"1/1/2000","12/31/2025",ErrorMessage ="Introduction Date must be in {1} and {2}")]
        public DateTime IntroductionDate { get; set; }
        [Required(ErrorMessage = "Url must be filled in")]
        [Display(Description = "URL")]
        [StringLength(2000, MinimumLength = 5, ErrorMessage = "Url must be greater than {2} characters and less than {1} charachters")]
        public string Url { get; set; }
        [Range(1,999,ErrorMessage ="{0} must be between {1} and {2}")]

        public decimal Price { get; set; }
    }
}