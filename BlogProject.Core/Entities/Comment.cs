namespace BlogProject.Core.Entities;

public class Comment:BaseEntity
{
    public string Text { get; set; }
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public DateTime CreatedTime { get; set; }
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
    public Comment? Parent { get; set; }
    public int? ParentId { get; set; }
    public IEnumerable<Comment>? Children { get; set; }

}
