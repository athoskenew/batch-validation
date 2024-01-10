using api.Models;
using api.Models.Quality;

namespace api.Service.QualityService.QualityCharacteristics
{
    public interface IQualityCharacteristicsInterface
    {

        Task<ServiceResponse<List<QualityCharacteristicsModel>>> GetCharacteristics(int id);
        Task<ServiceResponse<List<QualityCharacteristicsModel>>> CreateCharacteristics(QualityCharacteristicsModel newCharacteristic, int materialId);
        Task<ServiceResponse<QualityCharacteristicsModel>> GetCharacteristicById(int materialId, int characteristicId);
        Task<ServiceResponse<List<QualityCharacteristicsModel>>> UpdateCharacteristic(QualityCharacteristicsModel editedCharacteristic);
        Task<ServiceResponse<List<QualityCharacteristicsModel>>> DeleteCharacteristic(int materialId, int characteristicId);

    }
}
