using System.Threading.Tasks;

namespace Trendyol.Data.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task Add(T entity);
    }
}