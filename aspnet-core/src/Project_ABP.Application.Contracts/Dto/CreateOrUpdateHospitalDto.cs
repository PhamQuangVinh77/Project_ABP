using System.ComponentModel.DataAnnotations;

namespace Project_ABP.Dto
{
    public class CreateOrUpdateHospitalDto
    {
        [Required]
        public string Ma { get; set; }
        [Required]
        public string Ten { get; set; }
        [Required]
        public int MaTinh { get; set; }
        [Required]
        public int MaHuyen { get; set; }
        [Required]
        public int MaXa { get; set; }
        public string DiaChi { get; set; }
    }
}
