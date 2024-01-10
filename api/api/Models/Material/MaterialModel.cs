using api.Models.Quality;
using System.ComponentModel.DataAnnotations;

namespace api.Models.Material
{
    public class MaterialModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public List<QualityCharacteristicsModel>? MaterialQualityCharacteristics { get; set; }
        public QualityVisionModel? MaterialQualityVision { get; set; }

    }
}
