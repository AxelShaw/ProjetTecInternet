using Application.UseCases.Movies.Dtos;
using AutoMapper;
using Domain;
using Infrastructure.Ef.DbEntities;

namespace Application;

public class Mapper
{
    private static AutoMapper.Mapper _instance;

    public static AutoMapper.Mapper GetInstance()
    {
        return _instance ??= CreateMapper();
    }

    private static AutoMapper.Mapper CreateMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            // Source, Destination
            // User
            cfg.CreateMap<Movie, DtoOutputMovie>();
            cfg.CreateMap<DbMovie, DtoOutputMovie>();
            cfg.CreateMap<DbMovie, Movie>();
            
        });
        return new AutoMapper.Mapper(config);
    }
}