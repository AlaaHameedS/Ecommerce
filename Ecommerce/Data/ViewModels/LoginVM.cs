using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "This Field is Reqired!")]
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }
        [Required(ErrorMessage = "This Field is Reqired!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
