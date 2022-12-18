using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.Utils;

public interface IUseCaseParameterizedQueryUpActu<out TOutput, in TParam>
{
    bool Execute(DbActu param );

}