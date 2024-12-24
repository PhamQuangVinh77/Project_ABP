using AutoMapper;
using Project_ABP.Dto;
using Project_ABP.Entities;

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
    }
}
