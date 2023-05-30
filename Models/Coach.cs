using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UpFit__main.Models
{
    public class Coach
    {
        [Key]
        public int CoachID { get; set; }

        [Required(ErrorMessage = "Username Required")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
    }
}