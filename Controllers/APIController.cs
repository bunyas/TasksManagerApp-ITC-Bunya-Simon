using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagerApp_Bunya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private static List<Tasks> tasks = new List<Tasks>();
        // GET: api/<APIController>
        [HttpGet]
        public ActionResult<IEnumerable<Tasks>> GetTasks()
        {
            return tasks;
        }

        // GET api/<APIController>/1
        [HttpGet("{id}")]
        public ActionResult<Tasks> GetTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        // POST api/<APIController>
        [HttpPost]
        public ActionResult<Tasks> CreateTask(Tasks task)
        {
            task.Id = Convert.ToInt32(Guid.NewGuid().ToString());
            task.CreatedAt = DateTime.UtcNow;
            task.UpdatedAt = DateTime.UtcNow;
            tasks.Add(task);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        // PUT api/<APIController>/1
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, Tasks updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.Status = updatedTask.Status;
            task.DueDate = updatedTask.DueDate;
            task.Priority = updatedTask.Priority;
            task.UpdatedAt = DateTime.UtcNow;
            return NoContent();
        }

        // DELETE api/<APIController>/1
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            tasks.Remove(task);
            return NoContent();
        }
    }

    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public DateTime DueDate { get; set; }
        public int? Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
