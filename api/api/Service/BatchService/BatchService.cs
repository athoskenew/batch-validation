using api.DataContext;
using api.Models;
using api.Models.Batch;
using api.Models.Material;
using api.Models.Quality;
using Microsoft.EntityFrameworkCore;

namespace api.Service.BatchService
{
    public class BatchService : IBatchServiceInterface
    {
        private readonly ApplicationDbContext _context;
        public BatchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<BatchModel>>> GetBatches()
        {
            ServiceResponse<List<BatchModel>> serviceResponse = new ServiceResponse<List<BatchModel>>();

            try
            {
                serviceResponse.Data = await _context.Batches.ToListAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;


        }
        public async Task<ServiceResponse<BatchModel>> CreateBatch(BatchModel newBatch, int materialId)
        {
            ServiceResponse<BatchModel> serviceResponse = new ServiceResponse<BatchModel>();

            try
            {

                if (newBatch == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar Dados!";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                newBatch.MaterialId = materialId;

                _context.Add(newBatch);
                await _context.SaveChangesAsync();
                serviceResponse.Data =  newBatch;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<BatchModel>> GetBatchById(int id)
        {
            ServiceResponse<BatchModel> serviceResponse = new ServiceResponse<BatchModel>();

            try
            {
                BatchModel batch = await _context.Batches.FirstOrDefaultAsync(x => x.Id == id);
                
                if(batch == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Lote não encontrado";
                    return serviceResponse;
                }
                
                serviceResponse.Data = batch;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;

        }
        public Task<ServiceResponse<List<BatchModel>>> UpdateBatch(BatchModel editedBatch)
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<BatchModel>> DeleteBatch(int id)
        {
            ServiceResponse<BatchModel> serviceResponse = new ServiceResponse<BatchModel>();

            try
            {

                BatchModel batch = await _context.Batches.FirstOrDefaultAsync(x => x.Id == id);


                if (batch == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Lote não encontrado";
                    return serviceResponse;
                }

                _context.Remove(batch);

                await _context.SaveChangesAsync();
                serviceResponse.Data = batch;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
        
        // actions
        public Task<ServiceResponse<BatchModel>> TestLaunch(List<QualityCharacteristicsModel> qualityCharacteristics)
        {
            throw new NotImplementedException();
        }

    }
}
