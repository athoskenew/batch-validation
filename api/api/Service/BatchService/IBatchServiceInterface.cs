using api.Models;
using api.Models.Batch;
using api.Models.Quality;

namespace api.Service.BatchService
{
    public interface IBatchServiceInterface
    {

        Task<ServiceResponse<List<BatchModel>>> GetBatches();
        Task<ServiceResponse<BatchModel>> CreateBatch(BatchModel newBatch, int materialId);
        Task<ServiceResponse<BatchModel>> GetBatchById(int id);
        Task<ServiceResponse<List<BatchModel>>> UpdateBatch(BatchModel editedBatch);
        Task<ServiceResponse<BatchModel>> DeleteBatch(int id);
        Task<ServiceResponse<BatchModel>> TestLaunch(List<QualityCharacteristicsModel> qualityCharacteristics);

    }
}
