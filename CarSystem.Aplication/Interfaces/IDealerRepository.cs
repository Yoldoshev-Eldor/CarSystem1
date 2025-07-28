using CarSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Aplication.Interfaces;

public interface IDealerRepository
{
    Task<int> AddDealerAsync(Dealer dealer);
    Task UpdateDealerAsync(Dealer dealer);
    Task DeleteDealerAsync(int id);
    Task<Dealer?> GetDealerByIdAsync(int id);
    Task<IEnumerable<Dealer>> GetPagedDealers(int pageNumber, int pageSize);
    Task<IEnumerable<Dealer>> GetDealersByCityIdAsync(int cityId);

}
