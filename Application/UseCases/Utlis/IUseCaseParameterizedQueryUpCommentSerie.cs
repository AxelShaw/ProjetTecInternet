using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.Utils;

public interface IUseCaseParameterizedQueryUpCommentSerie<out TOutput, in TParam>
{
    bool Execute(DbCommentSerie param );
}