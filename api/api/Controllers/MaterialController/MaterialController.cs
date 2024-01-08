using api.Models;
using api.Models.Material;
using api.Service.MaterialService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.MaterialController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialInterface _materialInterface;
        public MaterialController(IMaterialInterface materialInterface)
        {
            _materialInterface = materialInterface;            
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<MaterialModel>>>> GetMaterials() {
            return Ok(await _materialInterface.GetMaterials());
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<ServiceResponse<MaterialModel>>> GetMaterialById(int id)
        {
            return Ok(await _materialInterface.GetMaterialById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<MaterialModel>>>> CreateMaterial(MaterialModel newMaterial)
        {
            return Ok(await _materialInterface.CreateMaterial(newMaterial));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<MaterialModel>>>> UpdateMaterial(MaterialModel editedMaterial)
        {
            return Ok(await _materialInterface.UpdateMaterial(editedMaterial));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<MaterialModel>>>> DeleteMaterial(int id)
        {
            return Ok(await _materialInterface.DeleteMaterial(id));
        }

    }
}
