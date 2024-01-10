using api.Enums;
using api.Models.Material;
using System.ComponentModel.DataAnnotations;

namespace api.Models.Quality
{
    public class QualityVisionModel
    {
        [Key]
        public int Id {  get; set; }
        public string Name { get; set; }
        public int MinimumQuantity { get; set; }
        public TypeOfCalculationEnum TypeOfCalculation { get; set; }
        public int MaterialModelId { get; set; }
    }
}
