using Inlog.Desafio.Backend.Domain.Interfaces;
using Inlog.Desafio.Backend.Domain.Models;
using Inlog.Desafio.Backend.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Inlog.Desafio.Backend.Infra.Database.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        public DbInlogContext context;

        public VeiculoRepository(DbInlogContext context)
        {
            this.context = context;
        }

        public async Task<Veiculo> CreateAsync(Veiculo veiculo)
        {
            await context.Veiculos.AddAsync(veiculo);
            await context.SaveChangesAsync();
            return veiculo;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var veiculo = await GetVeiculoAsync(id);
            context.Veiculos.Remove(veiculo);
            return await context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<IList<Veiculo>> GetAll(double? latitude, double? longitude)            
        {
            if(latitude is not null && longitude is not null)
            {
                return await context.Veiculos.OrderBy(x =>
                        Math.Acos(
                            Math.Sin(x.Latitude * Math.PI / 180) * Math.Sin(latitude.Value * Math.PI / 180) +
                            Math.Cos(x.Latitude * Math.PI / 180) * Math.Cos(latitude.Value * Math.PI / 180) *
                            Math.Cos((longitude.Value - x.Longitude) * Math.PI / 180)
                        ) * 6371
                    ).ToListAsync();
            }

            return await context.Veiculos.ToListAsync();

        }

        public async Task<Veiculo> GetVeiculoAsync(int id)
        {
            return await context.Veiculos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Veiculo> UpdateAsync(Veiculo veiculo)
        {
            context.Update(veiculo);
            await context.SaveChangesAsync();
            return veiculo;
        }
    }
}
