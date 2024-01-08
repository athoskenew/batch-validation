using api.Models;
using api.Models.Material;

namespace api.Service.MaterialService
{
    public interface IMaterialInterface
    {
        Task<ServiceResponse<List<MaterialModel>>> GetMaterials();
        Task<ServiceResponse<List<MaterialModel>>> CreateMaterial(MaterialModel newMaterial);
        Task<ServiceResponse<MaterialModel>> GetMaterialById(int id);
        Task<ServiceResponse<List<MaterialModel>>> UpdateMaterial(MaterialModel editedMaterial);
        Task<ServiceResponse<List<MaterialModel>>> DeleteMaterial(int id);

    }
}
