using AutoMapper;
using LiveCasino.DLL;
using LiveCasino.Service;
using LiveCasino.Service.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LiveCasino.Controller.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ClientService, IClientService>();
            CreateMap<AdminService, IAdminService>();
            CreateMap<BonusService, IBonusService>();
            CreateMap<RoleService, IRoleService>();
        }
    }
}
