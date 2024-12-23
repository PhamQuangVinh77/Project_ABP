using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Entities;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Project_ABP.DataSeeding
{
    public class DataSeeding : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Tinh, Guid> _tinhRepository;
        private readonly IRepository<Huyen, Guid> _huyenRepository;
        private readonly IRepository<Xa, Guid> _xaRepository;
        private List<Tinh> _listTinh;
        private List<Huyen> _listHuyen;
        private List<Xa> _listXa;

        public DataSeeding(IRepository<Tinh, Guid> tinhRepository, IRepository<Huyen, Guid> huyenRepository, IRepository<Xa, Guid> xaRepository)
        {
            _tinhRepository = tinhRepository;
            _huyenRepository = huyenRepository;
            _xaRepository = xaRepository;
            _listTinh = new List<Tinh>
            {
                new Tinh {MaTinh=30, TenTinh="Hà Nội", Cap="Thành phố trung ương"},
                new Tinh {MaTinh=34, TenTinh="Hải Dương", Cap="Tỉnh"},
                new Tinh {MaTinh=89, TenTinh="Hưng Yên", Cap="Tỉnh"},
                new Tinh {MaTinh=15, TenTinh="Hải Phòng", Cap="Thành phố trung ương"},
            };
            _listHuyen = new List<Huyen>
            {
                new Huyen {MaHuyen=001, TenHuyen="Ba Đình", Cap="Quận", MaTinh=30},
                new Huyen {MaHuyen=002, TenHuyen="Hoàn Kiếm", Cap="Quận", MaTinh=30},
                new Huyen {MaHuyen=018, TenHuyen="Gia Lâm", Cap="Huyện", MaTinh=30},
                new Huyen {MaHuyen=269, TenHuyen="Sơn Tây", Cap="Thị xã", MaTinh=30},
                new Huyen {MaHuyen=288, TenHuyen="TP Hải Dương", Cap="Thành phố", MaTinh=34},
                new Huyen {MaHuyen=290, TenHuyen="TP Chí Linh", Cap="Thành phố", MaTinh=34},
                new Huyen {MaHuyen=292, TenHuyen="Kinh Môn", Cap="Thị xã", MaTinh=34},
                new Huyen {MaHuyen=300, TenHuyen="Thanh Miện", Cap="Huyện", MaTinh=34},
                new Huyen {MaHuyen=308, TenHuyen="Đồ Sơn", Cap="Quận", MaTinh=15},
                new Huyen {MaHuyen=316, TenHuyen="Vĩnh Bảo", Cap="Huyện", MaTinh=15},
                new Huyen {MaHuyen=323, TenHuyen="TP Hưng Yên", Cap="Thành phố", MaTinh=89},
                new Huyen {MaHuyen=328, TenHuyen="Mỹ Hào", Cap="Thị xã", MaTinh=89},
                new Huyen {MaHuyen=332, TenHuyen="Tiên Lữ", Cap="Huyện", MaTinh=89},
            };
            _listXa = new List<Xa>
            {
                new Xa{ MaXa= 00004, TenXa="Trúc Bạch", Cap="Phường", MaTinh=30, MaHuyen=001},
                new Xa{ MaXa= 00008, TenXa="Liễu Giai", Cap="Phường", MaTinh=30, MaHuyen=001},
                new Xa{ MaXa= 00043, TenXa="Hàng Mã", Cap="Phường", MaTinh=30, MaHuyen=002},
                new Xa{ MaXa= 00046, TenXa="Hàng Buồm", Cap="Phường", MaTinh=30, MaHuyen=002},
                new Xa{ MaXa= 00079, TenXa="Tràng Tiền", Cap="Phường", MaTinh=30, MaHuyen=002},
                new Xa{ MaXa= 00526, TenXa="Yên Viên", Cap="Thị trấn", MaTinh=30, MaHuyen=018},
                new Xa{ MaXa= 00544, TenXa="Phù Đổng", Cap="Xã", MaTinh=30, MaHuyen=018},
                new Xa{ MaXa= 09574, TenXa="Lê Lợi", Cap="Phường", MaTinh=30, MaHuyen=269},
                new Xa{ MaXa= 09592, TenXa="Đường Lâm", Cap="Xã", MaTinh=30, MaHuyen=269},
                new Xa{ MaXa= 10519, TenXa="Nguyễn Trãi", Cap="Phường", MaTinh=34, MaHuyen=288},
                new Xa{ MaXa= 10822, TenXa="Quyết Thắng", Cap="Xã", MaTinh=34, MaHuyen=288},
                new Xa{ MaXa= 11011, TenXa="Tân Hưng", Cap="Phường", MaTinh=34, MaHuyen=288},
                new Xa{ MaXa= 10549, TenXa="Sao Đỏ", Cap="Phường", MaTinh=34, MaHuyen=290},
                new Xa{ MaXa= 10561, TenXa="Hưng Đạo", Cap="Xã", MaTinh=34, MaHuyen=290},
                new Xa{ MaXa= 10678, TenXa="Bạch Đằng", Cap="Xã", MaTinh=34, MaHuyen=292},
                new Xa{ MaXa= 11239, TenXa="TT Thanh Miện", Cap="Thị trấn", MaTinh=34, MaHuyen=300},
                new Xa{ MaXa= 11275, TenXa="Ngũ Hùng", Cap="Xã", MaTinh=34, MaHuyen=300},
                new Xa{ MaXa= 11269, TenXa="Tứ Cường", Cap="Xã", MaTinh=34, MaHuyen=300},
                new Xa{ MaXa= 11458, TenXa="Hải Sơn", Cap="Phường", MaTinh=15, MaHuyen=308},
                new Xa{ MaXa= 11824, TenXa="TT Vĩnh Bảo", Cap="Thị trấn", MaTinh=15, MaHuyen=316},
                new Xa{ MaXa= 11845, TenXa="Vĩnh Long", Cap="Xã", MaTinh=15, MaHuyen=316},
                new Xa{ MaXa= 11950, TenXa="Lam Sơn", Cap="Phường", MaTinh=89, MaHuyen=323},
                new Xa{ MaXa= 11956, TenXa="An Tảo", Cap="Phường", MaTinh=89, MaHuyen=323},
                new Xa{ MaXa= 11971, TenXa="Trung Nghĩa", Cap="Xã", MaTinh=89, MaHuyen=323},
                new Xa{ MaXa= 12103, TenXa="Bần Yên Nhân", Cap="Phường", MaTinh=89, MaHuyen=328},
                new Xa{ MaXa= 12112, TenXa="Dương Quang", Cap="Xã", MaTinh=89, MaHuyen=328},
                new Xa{ MaXa= 12337, TenXa="TT Vương", Cap="Thị trấn", MaTinh=89, MaHuyen=332},
                new Xa{ MaXa= 12346, TenXa="Nhật Tân", Cap="Xã", MaTinh=89, MaHuyen=332},
            };
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            try
            {
                if (await _tinhRepository.GetCountAsync() <= 0)
                {
                    await _tinhRepository.InsertManyAsync(_listTinh, autoSave: true);
                    if (await _huyenRepository.GetCountAsync() > 0) return;
                    await _huyenRepository.InsertManyAsync(_listHuyen, autoSave: true);
                    if(await _xaRepository.GetCountAsync() > 0) return;
                    await _xaRepository.InsertManyAsync(_listXa, autoSave: true);
                }
            }
            catch (Exception ex) 
            {
                throw;
            }
        }
    }
}
