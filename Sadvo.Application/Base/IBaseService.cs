

using Sadvo.Domain.BaseCommon;

namespace Sadvo.Application.Base
{
    public interface IBaseService<TDSave, TDUpdate, TDDelete>
    {
        Task<OperationResult> GetAll();
        Task<OperationResult> GetById(int id);
        Task<OperationResult> UpdateById(TDUpdate dto);
        Task<OperationResult> DeleteById(TDDelete dto);
        Task<OperationResult> Save(TDSave dto);
    }
}
