using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.Utils;

public interface IUseCaseParameterizedQueryUpCommentMovie<out TOutput, in TParam>
{
    bool Execute(DbCommentMovie param );

}