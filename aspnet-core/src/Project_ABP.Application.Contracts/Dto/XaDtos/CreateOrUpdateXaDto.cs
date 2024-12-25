using System.ComponentModel.DataAnnotations;

namespace Project_ABP.Dto.XaDtos
{
    public class CreateOrUpdateXaDto
    {
        [Required]
        public int MaXa { get; set; }
        [Required]
        public string TenXa { get; set; }
        [Required]
        public string Cap { get; set; }
        [Required]
        public int MaTinh { get; set; }
        [Required]
        public int MaHuyen { get; set; }
    }
}
