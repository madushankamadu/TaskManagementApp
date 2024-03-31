using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Data;
using TaskManagementApp.Models;

namespace TaskManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskDBContext _dbContext;
        public TaskController(TaskDBContext taskDBContext)
        {
            _dbContext = taskDBContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskToDo>>> GetTasks() 
        {
            return await _dbContext.Tasks.ToListAsync();    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskToDo>> GetTaskById(int id)
        {
            if (_dbContext.Tasks == null) 
            {
                return NotFound();
            }
            var task = await _dbContext.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        [HttpPost]
        public async Task<ActionResult<TaskToDo>> CreateTask(TaskToDo task)
        {
            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();    
            return CreatedAtAction(nameof(GetTaskById), new {id = task.Id }, task);
        }
    }
}
