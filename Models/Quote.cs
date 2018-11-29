// allows for validation error messages
using System.ComponentModel.DataAnnotations;

// using the namespace + models
namespace QuotingDojo.Models
{
    // creates a model for comments in order to sanatize data
    public class Quote
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Quote is required!")]
        public string QuoteText { get; set; }
    }
}