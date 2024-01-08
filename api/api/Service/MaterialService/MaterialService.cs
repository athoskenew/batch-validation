using api.DataContext;
using api.Models;
using api.Models.Material;
using Microsoft.EntityFrameworkCore;

namespace api.Service.MaterialService
{
    public class MaterialService : IMaterialInterface
    {
        private readonly ApplicationDbContext _context;
        public MaterialService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<MaterialModel>>> GetMaterials()
        {
            ServiceResponse<List<MaterialModel>> serviceResponse = new ServiceResponse<List<MaterialModel>>();

            try
            {
                serviceResponse.Data = await _context.Materials
                .Include(material => material.MaterialQualityCharacteristics)
                .Include(material => material.MaterialQualityVision)
                .ToListAsync();

            }
            catch(Exception ex) 
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<MaterialModel>> GetMaterialById(int id)
        {
            ServiceResponse<MaterialModel> serviceResponse = new ServiceResponse<MaterialModel>();

            try
            {
                MaterialModel material = await _context.Materials
                .Include(m => m.MaterialQualityCharacteristics)
                .Include(m => m.MaterialQualityVision)
                .FirstOrDefaultAsync(x => x.Id == id);

                if (material == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Material não encontrado";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                serviceResponse.Data = material;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<MaterialModel>>> CreateMaterial(MaterialModel newMaterial)
        {
            ServiceResponse<List<MaterialModel>> serviceResponse = new ServiceResponse<List<MaterialModel>>();

            try
            {
                if (newMaterial == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar Dados!";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                _context.Add(newMaterial);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Materials.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<MaterialModel>>> UpdateMaterial(MaterialModel editedMaterial)
        {
            ServiceResponse<List<MaterialModel>> serviceResponse = new ServiceResponse<List<MaterialModel>>();

            try
            {
                MaterialModel material = await _context.Materials
                    .FirstOrDefaultAsync(x => x.Id == editedMaterial.Id);

                if (material == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Material não encontrado";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                material.Name = editedMaterial.Name;
                material.Description = editedMaterial.Description;

                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Materials
                    .Include(m => m.MaterialQualityCharacteristics)
                    .Include(m => m.MaterialQualityVision)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }


        public async Task<ServiceResponse<List<MaterialModel>>> DeleteMaterial(int id)
        {
            ServiceResponse<List<MaterialModel>> serviceResponse = new ServiceResponse<List<MaterialModel>>();

            try
            {
                var materialToDelete = _context.Materials.FirstOrDefault(x => x.Id == id);
                if (materialToDelete == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Material não encontrado";
                    return serviceResponse;
                }

                _context.Remove(materialToDelete);

                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Materials
                .Include(material => material.MaterialQualityCharacteristics)
                .Include(material => material.MaterialQualityVision)
                .ToListAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
    }
}