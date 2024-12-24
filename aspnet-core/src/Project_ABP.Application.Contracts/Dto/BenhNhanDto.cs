using Volo.Abp.Application.Dtos;

namespace Project_ABP.Dto
{
    public class BenhNhanDto : FullAuditedEntityDto<int>
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public int MaTinh { get; set; }
        public int MaHuyen { get; set; }
        public int MaXa { get; set; }
        public string DiaChi { get; set; }
        public int HospitalId { get; set; }
    }
}
