using api.Enums;
using System.ComponentModel.DataAnnotations;

namespace api.Models.Batch
{
    public class BatchModel
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public BatchStatusEnum Status { get; set; }
        public int MaterialId { get; set; }

    }
}
