﻿using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.RatingMovies.UseCaseRatingMovie;

public class UseCaseFetchAllRatingMoviesTop : IUseCaseQuery<IEnumerable<DtoOutputRatingMovie>>
{
    private readonly IRatingMovieRepository _ratingMovieRepository;

    public UseCaseFetchAllRatingMoviesTop(IRatingMovieRepository ratingMovieRepository)
    {
        _ratingMovieRepository = ratingMovieRepository;
    }

    public IEnumerable<DtoOutputRatingMovie> Execute()
    {
        var dbUsers = _ratingMovieRepository.FetchAllTop();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputRatingMovie>>(dbUsers);
    }
}