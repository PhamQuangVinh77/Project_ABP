using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MimeKit;
using Project_ABP.Dto.BenhNhanDtos;
using Project_ABP.Entities;
using Project_ABP.Filter;
using Project_ABP.IRepositories;
using Project_ABP.IServices;
using Project_ABP.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Project_ABP.Services
{
    public class BenhNhanService : CrudAppService<BenhNhan, BenhNhanDto, int, BenhNhanPagedAndSortedResultRequestDto, CreateOrUpdateBenhNhanDto, CreateOrUpdateBenhNhanDto>, IBenhNhanService
    {
        private readonly IBenhNhanRepository _benhNhanRepository;
        private readonly IUserHospitalRepository _userHospitalRepository;
        private readonly IIdentityUserAppService _identityUserAppService;
        private readonly IRepository<Hospital, int> _hospitalRepository;
        private ILogger<BenhNhanService> _logger;

        private const string EMAIL_SENDER = "quangvinh770808@gmail.com";
        private const string HOST = "smtp.gmail.com";
        private const string PASSWORD = "ixnlzhmqsnoyborm";
        public BenhNhanService(IRepository<BenhNhan, int> repository, IRepository<Hospital, int> hospitalRepository, IIdentityUserAppService identityUserAppService,
            IBenhNhanRepository benhNhanRepository, IUserHospitalRepository userHospitalRepository, ILogger<BenhNhanService> logger) : base(repository)
        {
            CreatePolicyName = Project_ABPPermissions.BenhNhanPermissions.Create;
            UpdatePolicyName = Project_ABPPermissions.BenhNhanPermissions.Edit;
            DeletePolicyName = Project_ABPPermissions.BenhNhanPermissions.Delete;

            _benhNhanRepository = benhNhanRepository;
            _userHospitalRepository = userHospitalRepository;
            _hospitalRepository = hospitalRepository;
            _identityUserAppService = identityUserAppService;
            _logger = logger;
        }

        public async Task<List<BenhNhanDto>> GetAllBenhNhans()
        {
            try
            {
                var hospitalId = await GetHospitalIdByCurrentUser();
                var responses = await _benhNhanRepository.GetAllBenhNhans(hospitalId);
                return ObjectMapper.Map<List<BenhNhan>, List<BenhNhanDto>>(responses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<string> GetHospitalNameByCurrentUser()
        {
            return await _userHospitalRepository.GetHospitalNameByCurrentUser();
        }

        public override async Task<PagedResultDto<BenhNhanDto>> GetListAsync(BenhNhanPagedAndSortedResultRequestDto request)
        {
            try
            {
                var filter = ObjectMapper.Map<BenhNhanPagedAndSortedResultRequestDto, BenhNhanFilter>(request);
                filter.HospitalId = await GetHospitalIdByCurrentUser();
                var sorting = string.IsNullOrEmpty(request.Sorting) ? "ma ASC" : request.Sorting;
                var response = await _benhNhanRepository.GetListAsync(request.SkipCount, request.MaxResultCount, sorting, filter);
                var totalCount = await _benhNhanRepository.GetTotalCountAsync(filter);
                return new PagedResultDto<BenhNhanDto>(totalCount, ObjectMapper.Map<List<BenhNhan>, List<BenhNhanDto>>(response));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public override async Task<BenhNhanDto> CreateAsync(CreateOrUpdateBenhNhanDto input)
        {
            try
            {
                input.Ma = GeneratedCode(6);
                input.HospitalId = await GetHospitalIdByCurrentUser();
                var benhNhan = await base.CreateAsync(input);
                var hospital = await _hospitalRepository.GetAsync(input.HospitalId);
                var listUser = await _identityUserAppService.GetListAsync(new GetIdentityUsersInput());
                var adminEmail = listUser.Items.ToList().FirstOrDefault(x => x.UserName == "admin").Email;
                SendMail(input.Ma, input.Ten, hospital.Ten, adminEmail);
                return benhNhan;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        private async Task<int> GetHospitalIdByCurrentUser()
        {
            return await _userHospitalRepository.GetHospitalIdByCurrentUser();
        }

        private string GeneratedCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                                        .Select(s => s[random.Next(s.Length)])
                                        .ToArray());
        }

        private async Task SendMail(string maBN, string tenBN, string tenBV, string adminEmail)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(tenBV, EMAIL_SENDER);
            email.From.Add(new MailboxAddress(tenBV, EMAIL_SENDER));
            email.To.Add(new MailboxAddress(adminEmail, adminEmail));
            email.Subject = "Thông báo từ " + tenBV;
            var builder = new BodyBuilder();
            builder.HtmlBody = $"Mã số {maBN}: Bệnh nhân {tenBN} vừa nhập viện!";
            email.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                await smtp.ConnectAsync(HOST, 587, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(EMAIL_SENDER, PASSWORD);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                smtp.Disconnect(true);
            }
        }
    }
}
