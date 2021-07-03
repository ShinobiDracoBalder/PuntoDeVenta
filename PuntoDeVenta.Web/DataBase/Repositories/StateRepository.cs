using Dapper;
using Microsoft.Extensions.Configuration;
using PuntoDeVenta.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoDeVenta.Web.DataBase.Repositories
{
    public class StateRepository : BaseRepository, IStateRepository
    {
        public StateRepository(IConfiguration configuration)
            : base(configuration)
        {}

        public async Task<int> CreateAsync(cState entity)
        {
            try
            {
                var query = "INSERT INTO cState (nombre) VALUES (@nombre)";

                var parameters = new DynamicParameters();
                parameters.Add("nombre", entity.nombre, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> DeleteAsync(cState entity)
        {
            try
            {
                var query = "DELETE FROM cState WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", entity.id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<cState>> GetAllsAsync()
        {
            try
            {
                var query = "SELECT * FROM cState";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<cState>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<cState>> GetAllAsync()
        {
            try
            {
                var procedure = "spGetAllStates";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<cState>(procedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<cState> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM cState WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<cState>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(cState entity)
        {
            try
            {
                var query = "UPDATE cState SET nombre = @Name WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("nombre", entity.nombre, DbType.String);
                parameters.Add("Id", entity.id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
