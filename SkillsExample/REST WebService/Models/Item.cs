using System.Collections.Generic;
using System.Runtime.Serialization;
using REST_WebService.Models;

namespace REST_WebService.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = "unknown item";
        public ICollection<Tag> TagList { get; set; } = new List<Tag>();
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public string LinkToSite { get; set; }
        public decimal UnitCost { get; set; }
    }
}
