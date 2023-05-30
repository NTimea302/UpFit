using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UpFit__main.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Subscription Type is required.")]
        [DisplayName("Subscription Type")]
        public int SubscriptionTypeFK { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name can only contain letters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name can only contain letters.")]
        public string LastName { get; set; }

        [RegularExpression("^[FM]$", ErrorMessage = "Gender must be 'F' or 'M'.")]
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Range(1, 150, ErrorMessage = "Age must be between 1 and 150.")]
        public int Age { get; set; }

        [Range(50, 300, ErrorMessage = "Height must be between 50 and 300.")]
        public int Height { get; set; }

        [Range(10, 300, ErrorMessage = "Weight must be between 10 and 300.")]
        public int Weight { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Kcal Daily must be a positive value.")]
        public int KcalDaily { get; set; }
 
        public double Lifestyle { get; set; }
    }
}