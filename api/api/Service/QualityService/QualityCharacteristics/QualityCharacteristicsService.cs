using api.DataContext;
using api.Models;
using api.Models.Material;
using api.Models.Quality;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace api.Service.QualityService.QualityCharacteristics
{
    public class QualityCharacteristicsService : IQualityCharacteristicsInterface
    {
        private readonly ApplicationDbContext _context;

        public QualityCharacteristicsService(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public async Task<ServiceResponse<List<QualityCharacteristicsModel>>> GetCharacteristics(int id)
        {
            ServiceResponse<List<QualityCharacteristicsModel>> serviceResponse = new ServiceResponse<List<QualityCharacteristicsModel>>();

            try
            {
                MaterialModel material = await _context.Materials
                .Include(m => m.MaterialQualityCharacteristics)
                .FirstOrDefaultAsync(x => x.Id == id);

                if (material == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Material não encontrado";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                serviceResponse.Data = material.MaterialQualityCharacteristics;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;

        }
        public async Task<ServiceResponse<List<QualityCharacteristicsModel>>> CreateCharacteristics(QualityCharacteristicsModel newCharacteristic, int materialId)
        {
            ServiceResponse<List<QualityCharacteristicsModel>> serviceResponse = new ServiceResponse<List<QualityCharacteristicsModel>>();

            try
            {
                MaterialModel material = await _context.Materials
                .Include(m => m.MaterialQualityCharacteristics)
                .FirstOrDefaultAsync(x => x.Id == materialId);


                if (newCharacteristic == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar Dados!";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                newCharacteristic.MaterialModelId = materialId;

                _context.Add(newCharacteristic);
                await _context.SaveChangesAsync();
                serviceResponse.Data = material.MaterialQualityCharacteristics;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<QualityCharacteristicsModel>> GetCharacteristicById(int materialId, int characteristicId)
        {
            ServiceResponse<QualityCharacteristicsModel> serviceResponse = new ServiceResponse<QualityCharacteristicsModel>();

            try
            {
                MaterialModel material = await _context.Materials
                .Include(m => m.MaterialQualityCharacteristics)
                .FirstOrDefaultAsync(x => x.Id == materialId);

                QualityCharacteristicsModel characteristic = material.MaterialQualityCharacteristics.FirstOrDefault(x => x.Id == characteristicId);


                if (material == null || characteristic == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Material não encontrado";
                    return serviceResponse;
                }

                await _context.SaveChangesAsync();
                serviceResponse.Data = characteristic;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
        public Task<ServiceResponse<List<QualityCharacteristicsModel>>> UpdateCharacteristic(QualityCharacteristicsModel editedCharacteristic)
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<List<QualityCharacteristicsModel>>> DeleteCharacteristic(int materialId, int characteristicId)
        {
            ServiceResponse<List<QualityCharacteristicsModel>> serviceResponse = new ServiceResponse<List<QualityCharacteristicsModel>>();

            try
            {
                MaterialModel material = await _context.Materials
                .Include(m => m.MaterialQualityCharacteristics)
                .FirstOrDefaultAsync(x => x.Id == materialId);

                QualityCharacteristicsModel characteristic = material.MaterialQualityCharacteristics.FirstOrDefault(x => x.Id == characteristicId);


                if (material == null || characteristic == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Material não encontrado";
                    return serviceResponse;
                }
                
                _context.Remove(characteristic);

                await _context.SaveChangesAsync();
                serviceResponse.Data = material.MaterialQualityCharacteristics;

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
