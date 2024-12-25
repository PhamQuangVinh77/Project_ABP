using System.ComponentModel.DataAnnotations;

namespace Project_ABP.Dto.TinhDto
{
    public class CreateOrUpdateTinhDto
    {
        [Required]
        public int MaTinh { get; set; }
        [Required]
        public string TenTinh { get; set; }
        [Required]
        public string Cap { get; set; }
    }
}
