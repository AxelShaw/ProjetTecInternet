using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.Utils;

public interface IUseCaseParameterizedQueryUp<out TOutput, in TParam>
{
    bool Execute(DbMovie param);
    bool Execute(DbUser param);
}