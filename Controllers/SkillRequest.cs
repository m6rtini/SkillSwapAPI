using System.ComponentModel.DataAnnotations;

public class SkillRequest
{
    public int Id { get; set; }

    [Required]
    public string RequestText { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int UserId { get; set; }
    public User User { get; set; }
}
