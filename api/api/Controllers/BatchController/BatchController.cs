using api.Models.Quality;
using api.Models;
using api.Service.BatchService;
using api.Service.QualityService.QualityVision;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Models.Batch;

namespace api.Controllers.BatchController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatchServiceInterface _batchServiceInterface;
        public BatchController(IBatchServiceInterface batchServiceInterface)
        {
            _batchServiceInterface = batchServiceInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<BatchModel>>>> GetBatches()
        {
            return Ok(await _batchServiceInterface.GetBatches());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<BatchModel>>> CreateBatch(BatchModel newBatch, int materialId)
        {
            return Ok(await _batchServiceInterface.CreateBatch(newBatch, materialId));
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<ServiceResponse<BatchModel>>> GetBatchById(int id)
        {
            return Ok(await _batchServiceInterface.GetBatchById(id));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<BatchModel>>> DeleteBatch(int id)
        {
            return Ok(await _batchServiceInterface.DeleteBatch(id));
        }



    }
}
