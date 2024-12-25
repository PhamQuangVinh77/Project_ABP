using System.ComponentModel.DataAnnotations;

namespace Project_ABP.Dto.HuyenDtos
{
    public class CreateOrUpdateHuyenDto
    {
        [Required]
        public int MaHuyen { get; set; }
        [Required]
        public string TenHuyen { get; set; }
        [Required]
        public string Cap { get; set; }
        [Required]
        public int MaTinh { get; set; }
    }
}
