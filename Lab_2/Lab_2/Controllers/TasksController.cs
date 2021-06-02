using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab_2.Data;
using Lab_2.Models;
using Lab_2.ViewModel;
using AutoMapper;
using Newtonsoft.Json;
using Carbon.Json;
using Newtonsoft.Json.Converters;

namespace Lab_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
   

        public TasksController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Tasks
        [HttpGet("{from}/{to}")]
        public ActionResult<IEnumerable<TaskViewModel>> GetTasks(DateTime DateFrom, DateTime DateTo)
        {
          
            var tasks = _context.Tasks.Where(task => task.AddedTime >= DateFrom && task.AddedTime <= DateTo);
            var tasksViewModel = _mapper.Map<IEnumerable<Models.Task>, IEnumerable<TaskViewModel>>(tasks);
            return tasksViewModel.ToList();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetTasks()
        {

            return await _context.Tasks.ToListAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskViewModel>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            var taskViewModel = _mapper.Map<TaskViewModel>(task);
        
            if (task == null)
            {
                return NotFound();
            }

            return taskViewModel;
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, Models.Task task)
        {
            if (id != task.ID)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
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
        public async Task<ActionResult<Models.Task>> PostTask(Models.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = task.ID }, task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.ID == id);
        }
    }
}
