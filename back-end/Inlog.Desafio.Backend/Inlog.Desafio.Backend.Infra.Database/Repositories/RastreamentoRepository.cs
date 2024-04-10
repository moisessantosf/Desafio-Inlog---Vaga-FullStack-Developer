using Inlog.Desafio.Backend.Domain.Interfaces;
using Inlog.Desafio.Backend.Domain.Models;
using Inlog.Desafio.Backend.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Inlog.Desafio.Backend.Infra.Database.Repositories
{
    public class RastreamentoRepository : IRastreamentoRepository
    {
        public DbInlogContext context;

        public RastreamentoRepository(DbInlogContext context)
        {
            this.context = context;
        }

        public async Task<Rastreamento> CreateAsync(Rastreamento rastreamento)
        {
            await context.Rastreamentos.AddAsync(rastreamento);
            await context.SaveChangesAsync();
            return rastreamento;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rastreamento = await GetRastreamentoAsync(id);
            context.Rastreamentos.Remove(rastreamento);
            return await context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<IList<Rastreamento>> GetAll()
        {
            return await context.Rastreamentos.ToListAsync();
        }

        public async Task<Rastreamento> GetRastreamentoAsync(int id)
        {
            return await context.Rastreamentos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Rastreamento> UpdateAsync(Rastreamento rastreamento)
        {
            context.Update(rastreamento);
            await context.SaveChangesAsync();
            return rastreamento;
        }
    }
}
