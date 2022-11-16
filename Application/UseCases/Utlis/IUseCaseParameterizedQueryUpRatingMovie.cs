using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.Utils;

public interface IUseCaseParameterizedQueryUpRatingMovie<out TOutput, in TParam>
{
    bool Execute(DbRatingMovie param );

}