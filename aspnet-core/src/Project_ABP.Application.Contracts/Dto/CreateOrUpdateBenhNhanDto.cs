using System.ComponentModel.DataAnnotations;

namespace Project_ABP.Dto
{
    public class CreateOrUpdateBenhNhanDto
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
        [Required]
        public int HospitalId { get; set; }
    }
}
