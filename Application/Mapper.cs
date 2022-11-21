using Application.UseCases.CommentMovies.Dtos;
using Application.UseCases.CommentSeries.Dtos;
using Application.UseCases.Movies.Dtos;
using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.Series.Dtos;
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

    private static AutoMapper.Mapper CreateMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            // Source, Destination
            // User
            cfg.CreateMap<Movie, DtoOutputMovie>();
            cfg.CreateMap<DbMovie, DtoOutputMovie>();
            cfg.CreateMap<DbMovie, Movie>();
            cfg.CreateMap<Boolean, DtoOutputMovie>();
            cfg.CreateMap<DtoOutputMovie, Movie>();
            
            cfg.CreateMap<User, DtoOutputUser>();
            cfg.CreateMap<DbUser, DtoOutputUser>();
            cfg.CreateMap<DbUser, User>();
            cfg.CreateMap<Boolean, DtoOutputUser>();
            cfg.CreateMap<DtoOutputSerie, Serie>();
            
            cfg.CreateMap<Serie, DtoOutputSerie>();
            cfg.CreateMap<DbSerie, DtoOutputSerie>();
            cfg.CreateMap<DbSerie, Serie>();
            cfg.CreateMap<Boolean, DtoOutputSerie>();
            cfg.CreateMap<DtoOutputSerie, Serie>();
            
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
            
            cfg.CreateMap<RatingSerie, DtoOutputRatingSerie>();
            cfg.CreateMap<DbRatingSerie, DtoOutputRatingSerie>();
            cfg.CreateMap<DbRatingSerie, RatingSerie>();
            cfg.CreateMap<Boolean, DtoOutputRatingSerie>();
            cfg.CreateMap<DtoOutputRatingSerie, RatingSerie>();
            
            cfg.CreateMap<CommentSerie, DtoOutputCommentSerie>();
            cfg.CreateMap<DbCommentSerie, DtoOutputCommentSerie>();
            cfg.CreateMap<DbCommentSerie, CommentSerie>();
            cfg.CreateMap<Boolean, DtoOutputCommentSerie>();
            cfg.CreateMap<DtoOutputCommentSerie, CommentSerie>();
            
            

        });
        return new AutoMapper.Mapper(config);
    }
}