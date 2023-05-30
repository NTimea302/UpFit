using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UpFit__main.Models
{
    public class Video
    {
        [Key]
        public int videoID { get; set; }
        public string Vname { get; set; }
        public string Vpath { get; set; }
    }
}