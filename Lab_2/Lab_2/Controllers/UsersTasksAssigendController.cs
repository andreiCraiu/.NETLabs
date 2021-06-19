using AutoMapper;
using Lab_2.Data;
using Lab_2.Models;
using Lab_2.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Identity.Core;
using Microsoft.EntityFrameworkCore;


namespace Lab_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersTasksAssigendController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;



        public UsersTasksAssigendController(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> AssignTask(NewAssignTaskRequest newAssignTaskRequest, int userId)
        { 
            //var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.Name).Value);
            List<Models.Task> tasksAssigned = new List<Models.Task>();

            newAssignTaskRequest.TasksAssiged.ForEach(tid =>
            {
                var taskWithId = _context.Tasks.Find(tid);
                if (taskWithId != null)
                {
                    tasksAssigned.Add(taskWithId);
                }
            });

            if (tasksAssigned.Count == 0)
            {
                return BadRequest();
            }

            var userTaskAssign = new UserTaskAssigned
            {
                ApplicationUserId = userId,
                DateAssigned = newAssignTaskRequest.TaskAssignDateTime.GetValueOrDefault(),
                Tasks = tasksAssigned
            };

            var c = userTaskAssign.ApplicationUserId;
            _context.UserTaskAssigneds.Add(userTaskAssign);
            await _context.SaveChangesAsync();
           return Ok();
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
           // var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = _context.UserTaskAssigneds.Include(o => o.Tasks).FirstOrDefault();
            var resultViewModel = _mapper.Map<AssignUserTasksForUserResponse>(result);

            return Ok(resultViewModel);
        }
    }

}
