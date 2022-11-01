using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.Utils;

public interface IUseCaseParameterizedQueryUpUser<out TOutput, in TParam>
{
    bool Execute(DbUser param );
    
}