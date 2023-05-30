using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpFit__main.Models
{
    public class FoodType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Type { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }
    }
}