using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SkillsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SkillsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetSkills()
    {
        var skills = await _context.Skills
            .Include(s => s.Category)
            .ToListAsync();

        return Ok(new ApiResponse<List<Skill>>(skills));
    }

    [HttpPost]
    public async Task<IActionResult> CreateSkill(CreateSkillDto dto)
    {
        var skill = new Skill
        {
            Name = dto.Name,
            Description = dto.Description,
            CategoryId = dto.CategoryId,
            UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))
        };

        _context.Skills.Add(skill);
        await _context.SaveChangesAsync();

        return Ok(new ApiResponse<Skill>(skill, "Skill created"));
    }
}
