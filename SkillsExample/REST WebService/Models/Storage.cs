using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using REST_WebService.Models;

namespace REST_WebService.Models
{
    public class Storage
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must type name of the wardrobe")]
        [StringLength(50, ErrorMessage = "Maximum Name length is 50 characters")]
        public string Name { get; set; } = "unknown WARDROBE";
        [Required(ErrorMessage = "Its required to define width"), Range(1, 100000, ErrorMessage = "Width must be in range between 1 and 10000 (centimeters)")]
        public int Width { get; set; }
        [Required(ErrorMessage = "Its required to define height"), Range(1, 100000, ErrorMessage = "Height must be in range between 1 and 10000 (centimeters)")]
        public int Height { get; set; }
        [Required(ErrorMessage = "Its required to define length"), Range(1, 100000, ErrorMessage = "Length must be in range between 1 and 10000 (centimeters)")]
        public int Length { get; set; }
        public List<Drawer> DrawerList { get; set; } = new List<Drawer>();
    }
}
