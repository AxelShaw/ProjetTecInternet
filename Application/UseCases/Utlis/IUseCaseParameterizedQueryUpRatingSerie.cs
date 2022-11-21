using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.Utils;

public interface IUseCaseParameterizedQueryUpRatingSerie<out TOutput, in TParam>
{
    bool Execute(DbRatingSerie param );

}