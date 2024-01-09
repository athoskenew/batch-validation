using api.Models.Quality;
using api.Models;

namespace api.Service.QualityService.QualityVision
{
    public interface IQualityVisionInterface
    {
        Task<ServiceResponse<QualityVisionModel>> GetVision(int id);
        Task<ServiceResponse<QualityVisionModel>> CreateVision(QualityVisionModel newVision, int materialId);
        Task<ServiceResponse<QualityVisionModel>> GetVisionById(int materialId, int visionId);
        Task<ServiceResponse<List<QualityVisionModel>>> UpdateVision(QualityVisionModel editedVision);
        Task<ServiceResponse<QualityVisionModel>> DeleteVision(int materialId);
    }
}
