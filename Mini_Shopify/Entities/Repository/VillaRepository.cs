using Mini_Shopify.Entities.Data;
using Mini_Shopify.Entities.Models;
using Mini_Shopify.Entities.Repository.IRepository;

namespace Mini_Shopify.Entities.Repository
{
    public class VillaRepository : RepositoryBase<Villa>, IVillaRepository
    {
        public VillaRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        
    }
}
