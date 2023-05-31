using Mini_Shopify.Entities.Data;
using Mini_Shopify.Entities.Models;
using Mini_Shopify.Entities.Repository.IRepository;

namespace Mini_Shopify.Entities.Repository
{
    public class VillaNumberRepository : RepositoryBase<VillaNumber>, IVillaNumberRepository
    {
        public VillaNumberRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        
    }
}
