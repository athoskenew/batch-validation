using api.DataContext;
using api.Models;
using api.Models.Material;
using api.Models.Quality;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace api.Service.QualityService.QualityVision
{
    public class QualityVisionService : IQualityVisionInterface
    {

        private readonly ApplicationDbContext _context;

        public QualityVisionService(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<ServiceResponse<QualityVisionModel>> GetVision(int id)
        {
            ServiceResponse<QualityVisionModel> serviceResponse = new ServiceResponse<QualityVisionModel>();

            try
            {
                MaterialModel material = await _context.Materials
                .Include(material => material.MaterialQualityVision)
                .FirstOrDefaultAsync(x => x.Id == id);

                if (material == null || material.MaterialQualityVision == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Material não encontrado";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                serviceResponse.Data = material.MaterialQualityVision; 

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<QualityVisionModel>> CreateVision(QualityVisionModel newVision, int materialId)
        {
            ServiceResponse<QualityVisionModel> serviceResponse = new ServiceResponse<QualityVisionModel>();

            try
            {
                MaterialModel material = await _context.Materials
                .Include(material => material.MaterialQualityVision)
                .FirstOrDefaultAsync(x => x.Id == materialId);


                if (newVision == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar Dados!";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                newVision.MaterialModelId = materialId;

                _context.Add(newVision);
                await _context.SaveChangesAsync();
                serviceResponse.Data = material.MaterialQualityVision;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<QualityVisionModel>> GetVisionById(int materialId, int visionId)
        {
            ServiceResponse<QualityVisionModel> serviceResponse = new ServiceResponse<QualityVisionModel>();

            try
            {
                MaterialModel material = await _context.Materials
                .Include(material => material.MaterialQualityVision)
                .FirstOrDefaultAsync(x => x.Id == materialId);

                QualityVisionModel vision = material.MaterialQualityVision;


                if (material == null || vision == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Material não encontrado";
                    return serviceResponse;
                }

                await _context.SaveChangesAsync();
                serviceResponse.Data = vision;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<QualityVisionModel>>> UpdateVision(QualityVisionModel editedVision)
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<QualityVisionModel>> DeleteVision(int materialId)
        {
            ServiceResponse<QualityVisionModel> serviceResponse = new ServiceResponse<QualityVisionModel>();

            try
            {
                MaterialModel material = await _context.Materials
                .Include(material => material.MaterialQualityVision)
                .FirstOrDefaultAsync(x => x.Id == materialId);

                QualityVisionModel vision = material.MaterialQualityVision;


                if (material == null || vision == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Material não encontrado";
                    return serviceResponse;
                }

                _context.Remove(vision);

                await _context.SaveChangesAsync();
                serviceResponse.Data = vision;

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
