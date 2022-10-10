using Microsoft.EntityFrameworkCore;
using NeuRecipe.Infrastructure.Repositories.Interfaces;

namespace NeuRecipe.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly RecipeDBContext dBContext;
        private readonly DbSet<T> entities;
        public GenericRepository(RecipeDBContext dBContext)
        {
            this.dBContext = dBContext;
            entities = dBContext.Set<T>();
        }
        public async Task Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            await dBContext.SaveChangesAsync();
        }
        public IQueryable<T> GetQuery()
        {
            return entities;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await dBContext.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> Delete(int id)
        {
            T existing = entities.Find(id);
            if (existing != null)
            {
                entities.Remove(existing);
                await dBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
