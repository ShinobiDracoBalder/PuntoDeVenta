using PuntoDeVenta.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoDeVenta.Web.DataBase.Repositories
{
    public interface IcStateService
    {
        public Task<List<cState>> GetAllcStates();
        public Task<cState> GetcStateById(int id);
        public Task<int> CreatecStateAsync(cState model);
        public Task<int> UpdatecStateAsync(cState model);
        public Task<int> DeletecStateAsync(cState model);
    }
}
