using Lab_2.ViewModel;
using Lab_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Lab_2
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Task, TaskViewModel>().ReverseMap();
            CreateMap<UserTaskAssigned, AssignUserTasksForUserResponse>().ReverseMap();
        }
    }
}
