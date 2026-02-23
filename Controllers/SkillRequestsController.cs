using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SkillRequestsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SkillRequestsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetRequests()
    {
        var requests = await _context.SkillRequests.Include(r => r.User).ToListAsync();
        return Ok(new ApiResponse<List<SkillRequest>>(requests));
    }

    [HttpPost]
    public async Task<IActionResult> CreateRequest(CreateSkillRequestDto dto)
    {
        var request = new SkillRequest
        {
            RequestText = dto.RequestText,
            UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))
        };

        _context.SkillRequests.Add(request);
        await _context.SaveChangesAsync();

        return Ok(new ApiResponse<SkillRequest>(request, "Request created"));
    }
}
