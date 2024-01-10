using api.Enums;
using api.Models.Material;
using System.ComponentModel.DataAnnotations;

namespace api.Models.Quality
{
    public class QualityCharacteristicsModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public QualityCharacteristicsTypeEnum Type { get; set; }
        public bool Justify { get; set; }
        public double DecimalPlaces { get; set; }
        public double InferiorLimit { get; set; }
        public double SuperiorLimit { get; set; }
        public int MaterialModelId { get; set; }
    }
}
