using Application.UseCases.Actu.Dtos;
using Application.UseCases.CommentMovies.Dtos;
using Application.UseCases.Favorie.Dtos;
using Application.UseCases.Movies.Dtos;
using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.Users.Dtos;
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
    
    //map for use case
    private static AutoMapper.Mapper CreateMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            // Source, Destination
            cfg.CreateMap<Movie, DtoOutputMovie>();
            cfg.CreateMap<DbMovie, DtoOutputMovie>();
            cfg.CreateMap<DbMovie, Movie>();
            cfg.CreateMap<Boolean, DtoOutputMovie>();
            cfg.CreateMap<DtoOutputMovie, Movie>();
            cfg.CreateMap<Int32 , DtoOutputMovie>();
            
            cfg.CreateMap<User, DtoOutputUser>();
            cfg.CreateMap<DbUser, DtoOutputUser>();
            cfg.CreateMap<DbUser, User>();
            cfg.CreateMap<Boolean, DtoOutputUser>();
            
            cfg.CreateMap<RatingMovie, DtoOutputRatingMovie>();
            cfg.CreateMap<DbRatingMovie, DtoOutputRatingMovie>();
            cfg.CreateMap<DbRatingMovie, RatingMovie>();
            cfg.CreateMap<Boolean, DtoOutputRatingMovie>();
            cfg.CreateMap<DtoOutputRatingMovie, RatingMovie>();
            
            cfg.CreateMap<CommentMovie, DtoOutputCommentMovie>();
            cfg.CreateMap<DbCommentMovie, DtoOutputCommentMovie>();
            cfg.CreateMap<DbCommentMovie, CommentMovie>();
            cfg.CreateMap<Boolean, DtoOutputCommentMovie>();
            cfg.CreateMap<DtoOutputCommentMovie, CommentMovie>();
            
            cfg.CreateMap<Favorie, DtoOutputFavorie>();
            cfg.CreateMap<DbFavorie, DtoOutputFavorie>();
            cfg.CreateMap<DbFavorie, Favorie>();
            cfg.CreateMap<Boolean, DtoOutputFavorie>();
            cfg.CreateMap<DtoOutputFavorie, Favorie>();
            
            cfg.CreateMap<Actu, DtoOutputActu>();
            cfg.CreateMap<DbActu, DtoOutputActu>();
            cfg.CreateMap<DbActu, Actu>();
            cfg.CreateMap<Boolean, DtoOutputActu>();
            cfg.CreateMap<DtoOutputActu, Actu>();

        });
        return new AutoMapper.Mapper(config);
    }
}