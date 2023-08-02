using AutoMapper;
using DashboardApi.Models;
using MongoDB.Bson;

namespace DashboardApi.Automapper;

public class MappingProfile : Profile   
{
    public MappingProfile() {
        CreateMap<Revenue, RevenueDTO>()
            .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>src.Id.ToString()));
        CreateMap<RevenueDTO, Revenue>()
            .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>ObjectId.Parse(src.Id)));
        CreateMap<TaskModel, TaskDTO>()
            .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>src.Id.ToString()));
        CreateMap<TaskDTO, TaskModel>()
            .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>ObjectId.Parse(src.Id)));
       
        CreateMap<Project, ProjectDTO>()
            .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>src.Id.ToString()));
        CreateMap<ProjectDTO, Project>()
            .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>ObjectId.Parse(src.Id)));
        CreateMap<ProjectMember, ProjectMemberDTO>()
            .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>src.Id.ToString()));
        CreateMap<ProjectMemberDTO, ProjectMember>()
            .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>ObjectId.Parse(src.Id)));
        
        CreateMap<User, UserDTO>()
            .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>src.Id.ToString()));
        CreateMap<UserDTO, User>()
            .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>ObjectId.Parse(src.Id)));
    }}