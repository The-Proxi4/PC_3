using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoticiasEnriquecidas.Data;
using NoticiasEnriquecidas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace NoticiasEnriquecidas.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FeedbackController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/feedback
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var feedbacks = await _context.Feedbacks.ToListAsync();
            return Ok(feedbacks);
        }

        // POST: api/feedback
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Feedback feedback)
        {
            if (feedback == null)
                return BadRequest("Feedback no puede ser nulo");

            // Validación simple: un postId solo puede tener un feedback
            var exists = await _context.Feedbacks.AnyAsync(f => f.PostId == feedback.PostId);
            if (exists)
                return Conflict("Ya existe feedback para este post");

            feedback.Fecha = DateTime.UtcNow;

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = feedback.PostId }, feedback);
        }
    }
}