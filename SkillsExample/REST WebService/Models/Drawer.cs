using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using REST_WebService.Models;
namespace REST_WebService.Models
{
    public class Drawer
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public List<Item> Items { get; set; }
    }
}
