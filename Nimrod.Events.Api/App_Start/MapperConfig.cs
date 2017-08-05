using AutoMapper;
using Nimrod.Events.Api.Models;
using Nimrod.Events.DomainModel;

namespace Nimrod.Events.Api
{
    public static class MapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateDualMap<Contact, ContactResource>();
                cfg.CreateDualMap<Session, SessionResource>();
            });
        }
    }

    public static partial class MapperExtensions
    {
        public static IMappingExpression<T2, T1> CreateDualMap<T1, T2>(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<T1, T2>();
            return cfg.CreateMap<T2, T1>();
        }
    }
}
