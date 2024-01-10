using api.Models.Material;
using api.Models;
using api.Service.MaterialService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Models.Quality;
using api.Service.QualityService.QualityCharacteristics;

namespace api.Controllers.QualityController.QualityCharacteristics
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualityCharacteristicsController : ControllerBase
    {
        private readonly IQualityCharacteristicsInterface _qualityCharacteristicsInterface;

        public QualityCharacteristicsController(IQualityCharacteristicsInterface qualityCharacteristicsInterface)
        {
            _qualityCharacteristicsInterface = qualityCharacteristicsInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<QualityCharacteristicsModel>>>> GetCharacteristics(int id)
        {
            return Ok(await _qualityCharacteristicsInterface.GetCharacteristics(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<QualityCharacteristicsModel>>>> CreateCharacteristic(QualityCharacteristicsModel newCharacteristic, int materialId)
        {
            return Ok(await _qualityCharacteristicsInterface.CreateCharacteristics(newCharacteristic, materialId));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<QualityCharacteristicsModel>>>> DeleteMaterial(int materialId, int characteristicId)
        {
            return Ok(await _qualityCharacteristicsInterface.DeleteCharacteristic(materialId, characteristicId));
        }

        [HttpGet("Characteristic")]
        public async Task<ActionResult<ServiceResponse<QualityCharacteristicsModel>>> GetCharacteristicById(int materialId, int characteristicId)
        {       
            return Ok(await _qualityCharacteristicsInterface.GetCharacteristicById(materialId, characteristicId));
        }

    }
}
