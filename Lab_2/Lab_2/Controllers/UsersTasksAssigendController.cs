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
using Microsoft.AspNetCore.Authorization;
using Polly;

using (var db = new Context())
{
    db.Categories.Add(new Category
    {
        Id = 5,
        Name = "test"
    });

    db.Database.OpenConnection();
    try
    {
        db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Categories ON;");
        db.SaveChanges();
        db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Categories OFF;");
    }
    finally
    {
        db.Database.CloseConnection();
    }
}

namespace Lab_2.Controllers
{
    [Authorize(AuthenticationSchemes ="Identity.Application,Bearer")]
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
        public async Task<ActionResult> AssignTask(NewAssignTaskRequest newAssignTaskRequest)
        {
            var a = User.Identity.IsAuthenticated;
            var b = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);
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
                Id = newAssignTaskRequest.ID,
                ApplicationUser = user,
                DateAssigned = newAssignTaskRequest.TaskAssignDateTime.GetValueOrDefault(),
                Tasks = tasksAssigned
            };

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
