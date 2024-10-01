namespace KindergarderCRUD.Models
{
	public class Kindergarten
	{
		public int Id { get; set; }
		public string Groupname { get; set; }
		public int ChildrenCount { get; set; }
		public string KindergartenName { get; set; }
		public string Teacher {  get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

	}
}
