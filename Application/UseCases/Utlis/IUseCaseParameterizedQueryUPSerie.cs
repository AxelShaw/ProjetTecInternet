using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.Utils;

public interface IUseCaseParameterizedQueryUpSerie<out TOutput, in TParam>
{
    bool Execute(DbSerie param );
    
}