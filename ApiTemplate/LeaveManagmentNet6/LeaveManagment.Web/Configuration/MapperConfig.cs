using AutoMapper;
using LeaveManagment.Web.Data;
using LeaveManagment.Web.Models;

namespace LeaveManagment.Web.Configuration
{
    public class MapperConfig: Profile 
    {
        public MapperConfig()
        {

            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();

        }
    }
}
