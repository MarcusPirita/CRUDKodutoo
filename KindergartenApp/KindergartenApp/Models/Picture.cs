using System.ComponentModel.DataAnnotations;

namespace KindergartenApp.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public int KindergartenGroupId { get; set; }
        public KindergartenGroup KindergartenGroup { get; set; }
    }
}
