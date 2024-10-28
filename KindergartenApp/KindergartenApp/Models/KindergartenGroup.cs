using System;
using System.ComponentModel.DataAnnotations;

namespace KindergartenApp.Models
{
    public class KindergartenGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int ChildrenCount { get; set; }
        public string KindergartenName { get; set; }
        public string Teacher { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public string? PicturePath { get; set; } 
        public List<Picture> Pictures { get; set; }
    }
}
