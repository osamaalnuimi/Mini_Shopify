using Mini_Shopify.Entities.Data;
using Mini_Shopify.Entities.Models;
using Mini_Shopify.Entities.Repository.IRepository;

namespace Mini_Shopify.Entities.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _dbContext;
        private IVillaRepository _villaRepository;
        private IVillaNumberRepository _villaNumberRepository;
        private IUserRepository _userRepository;

        public IVillaRepository Villa
        {
            get
            {
                if (_villaRepository == null)
                {
                    _villaRepository = new VillaRepository(_dbContext);
                }
                return _villaRepository;
            }
        }
        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dbContext);
                }
                return _userRepository;
            }
        }
        public IVillaNumberRepository VillaNumber
        {
            get
            {
                if (_villaNumberRepository == null)
                {
                    _villaNumberRepository = new VillaNumberRepository(_dbContext);
                }
                return _villaNumberRepository;
            }
        }
        public RepositoryWrapper(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public void Save()
        {
            _dbContext.SaveChangesAsync();
        }

    }
}
