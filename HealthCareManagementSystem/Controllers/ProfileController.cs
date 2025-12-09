using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace HealthCareManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        // Simple welcome endpoint for non-admin roles to confirm access.
        [HttpGet("welcome")]
        public IActionResult Welcome()
        {
            var name = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? "User";
            var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "Unknown";
            return Ok(new { message = $"Welcome, {name}! You are signed in as {role}." });
        }
    }
}

