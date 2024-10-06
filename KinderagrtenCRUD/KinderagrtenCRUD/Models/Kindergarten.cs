using System;
using System.ComponentModel.DataAnnotations;

namespace KindergartenCRUD.Models
{
    public class Kindergarten
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string GroupName { get; set; }

        [Range(0, 100)]
        public int ChildrenCount { get; set; }

        [Required]
        [StringLength(100)]
        public string KindergartenName { get; set; }

        [Required]
        [StringLength(100)]
        public string Teacher { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdatedAt { get; set; }
    }
}