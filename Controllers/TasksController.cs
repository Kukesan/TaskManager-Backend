using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskManagerContext _context;

        public TasksController(TaskManagerContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDetail>>> GetTaskDetailEntity()
        {
          if (_context.TaskDetailEntity == null)
          {
              return NotFound();
          }
            return await _context.TaskDetailEntity.ToListAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDetail>> GetTaskDetail(int id)
        {
          if (_context.TaskDetailEntity == null)
          {
              return NotFound();
          }
            var taskDetail = await _context.TaskDetailEntity.FindAsync(id);

            if (taskDetail == null)
            {
                return NotFound();
            }

            return taskDetail;
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskDetail(int id, TaskDetail taskDetail)
        {
            if (id != taskDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskDetail>> PostTaskDetail(TaskDetail taskDetail)
        {
          if (_context.TaskDetailEntity == null)
          {
              return Problem("Entity set 'TaskManagerContext.TaskDetailEntity'  is null.");
          }
            _context.TaskDetailEntity.Add(taskDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskDetail", new { id = taskDetail.Id }, taskDetail);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskDetail(int id)
        {
            if (_context.TaskDetailEntity == null)
            {
                return NotFound();
            }
            var taskDetail = await _context.TaskDetailEntity.FindAsync(id);
            if (taskDetail == null)
            {
                return NotFound();
            }

            _context.TaskDetailEntity.Remove(taskDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskDetailExists(int id)
        {
            return (_context.TaskDetailEntity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
