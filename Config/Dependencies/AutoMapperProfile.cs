using AutoMapper;
using Common.Models;
using MongoDB.Bson;
using Repository.Entities;

namespace Config.Dependencies
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<InsurancePolicy, InsurancePolicyDTO>().ReverseMap();

            //Mapeo para ObjectId en MongoDB
            CreateMap<List<ObjectId>, List<string>>().ConvertUsing(o => o.Select(os => os.ToString()).ToList());
            CreateMap<List<string>, List<ObjectId>>().ConvertUsing(o => o.Select(os => !string.IsNullOrEmpty(os) ? ObjectId.Parse(os) : ObjectId.Empty).ToList());
            CreateMap<ObjectId, string>().ConvertUsing(o => o.ToString());
            CreateMap<string, ObjectId>().ConvertUsing(s => !string.IsNullOrEmpty(s) ? ObjectId.Parse(s) : ObjectId.Empty);
        }
    }
}
