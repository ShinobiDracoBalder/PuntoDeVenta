using PuntoDeVenta.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoDeVenta.Web.DataBase.Repositories
{
    public class cStateService: IcStateService
    {
        private readonly IStateRepository _stateRepository;

        public cStateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<int> CreatecStateAsync(cState model)
        {
            return await _stateRepository.CreateAsync(model);
        }

        public async Task<int> DeletecStateAsync(cState model)
        {
            return await _stateRepository.DeleteAsync(model);
        }

        public async Task<List<cState>> GetAllcStates()
        {
            return await _stateRepository.GetAllAsync();
        }

        public async Task<cState> GetcStateById(int id)
        {
            return await _stateRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdatecStateAsync(cState model)
        {
            return await _stateRepository.UpdateAsync(model);
        }
    }
}
