﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Project_ABP.Entities;
using Project_ABP.Filter;
using Volo.Abp.DependencyInjection;

namespace Project_ABP.IRepositories
{
    public interface ITinhRepository : ITransientDependency
    {
        Task<List<Tinh>> GetAllTinhs();
        Task<List<Tinh>> GetListAsync(int skipCount, int maxResultCount, string sorting = "", TinhFilter filter = null);
        Task<int> GetTotalCountAsync(TinhFilter filter);
    }
}
