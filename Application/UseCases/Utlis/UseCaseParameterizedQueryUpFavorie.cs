using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.Utils;

public interface IUseCaseParameterizedQueryUpFavorie<out TOutput, in TParam>
{
    bool Execute(DbFavorie param );

}