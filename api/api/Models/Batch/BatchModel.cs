using api.Enums;
using api.Models.Material;

namespace api.Models.Batch
{
    public class BatchModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public BatchStatusEnum Status { get; set; }
        public MaterialModel? Material { get; set; }

    }
}
