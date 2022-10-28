using AutoMapper;
using upd8.MVC.ViewModels;
using upd8.Business.Models;

namespace upd8.MVC.Configurations;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<ClienteViewModel, Cliente>().ReverseMap();




    }
}