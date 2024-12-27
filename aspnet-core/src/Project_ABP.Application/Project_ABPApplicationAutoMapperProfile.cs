using AutoMapper;
using Project_ABP.Dto.BenhNhanDtos;
using Project_ABP.Dto.ExcelDtos;
using Project_ABP.Dto.HospitalDtos;
using Project_ABP.Dto.HuyenDtos;
using Project_ABP.Dto.TinhDto;
using Project_ABP.Dto.XaDtos;
using Project_ABP.Entities;
using Project_ABP.Filter;

namespace Project_ABP;

public class Project_ABPApplicationAutoMapperProfile : Profile
{
    public Project_ABPApplicationAutoMapperProfile()
    {
        // AutoMapper for Tinh
        CreateMap<Tinh, TinhDto>();
        CreateMap<CreateOrUpdateTinhDto, Tinh>();

        // AutoMapper for Huyen
        CreateMap<Huyen, HuyenDto>();
        CreateMap<CreateOrUpdateHuyenDto, Huyen>();

        // AutoMapper for Xa
        CreateMap<Xa, XaDto>();
        CreateMap<CreateOrUpdateXaDto, Xa>();

        //AutoMapper for Hospital
        CreateMap<Hospital, HospitalDto>();
        CreateMap<CreateOrUpdateHospitalDto, Hospital>();

        //AutoMapper for BenhNhan
        CreateMap<BenhNhan, BenhNhanDto>();
        CreateMap<CreateOrUpdateBenhNhanDto, BenhNhan>();

        //AutoMapper for Filter
        CreateMap<TinhPagedAndSortedResultRequestDto, TinhFilter>();
        CreateMap<HuyenPagedAndSortedResultRequestDto, HuyenFilter>();
        CreateMap<XaPagedAndSortedResultRequestDto, XaFilter>();
        CreateMap<HospitalPagedAndSortedResultRequestDto, HospitalFilter>();
        CreateMap<BenhNhanPagedAndSortedResultRequestDto, BenhNhanFilter>();

        //AutoMapper for import Excel
        CreateMap<TinhDto, ExcelDto>().ForMember(destination => destination.Ma, options => options.MapFrom(source => source.MaTinh))
                                      .ForMember(destination => destination.Ten, options => options.MapFrom(source => source.TenTinh));

        CreateMap<HuyenDto, ExcelDto>().ForMember(destination => destination.Ma, options => options.MapFrom(source => source.MaHuyen))
                                      .ForMember(destination => destination.Ten, options => options.MapFrom(source => source.TenHuyen));

        CreateMap<XaDto, ExcelDto>().ForMember(destination => destination.Ma, options => options.MapFrom(source => source.MaXa))
                                      .ForMember(destination => destination.Ten, options => options.MapFrom(source => source.TenXa));
    }
}
