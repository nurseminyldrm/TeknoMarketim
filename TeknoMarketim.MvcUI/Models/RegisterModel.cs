using System.ComponentModel.DataAnnotations;

namespace TeknoMarketim.MvcUI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Full name is required")]

        public string FullName { get; set; }
        [Required(ErrorMessage = "Username is required")]

        public string UserName {  get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [Required(ErrorMessage = "RePassword is required")]
        [DataType(DataType.Password)]

        public string RePassword { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        
        public string PhoneNumber { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
