using api.Models.Quality;
using api.Models;
using api.Service.MaterialService;
using api.Service.QualityService.QualityCharacteristics;
using api.Service.QualityService.QualityVision;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Models.Material;

namespace api.Controllers.QualityController.QualityVision
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualityVisionController : ControllerBase
    {

        private readonly IQualityVisionInterface _qualityVisionInterface;
        public QualityVisionController(IQualityVisionInterface qualityVision)
        {
            _qualityVisionInterface = qualityVision;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<QualityVisionModel>>> GetVision(int id)
        {
            return Ok(await _qualityVisionInterface.GetVision(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<QualityVisionModel>>> CreateVision(QualityVisionModel newVision, int materialId)
        {
            return Ok(await _qualityVisionInterface.CreateVision(newVision, materialId));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<QualityVisionModel>>>> DeleteVision(int materialId)
        {
            return Ok(await _qualityVisionInterface.DeleteVision(materialId));
        }

        [HttpGet("Vision")]
        public async Task<ActionResult<ServiceResponse<QualityVisionModel>>> GetVisionById(int materialId, int visionId)
        {
            return Ok(await _qualityVisionInterface.GetVisionById(materialId, visionId));
        }


    }
}
