namespace Mini_Shopify.Entities.Repository.IRepository
{
    public interface IRepositoryWrapper
    {
        IVillaRepository Villa { get; }
        IVillaNumberRepository VillaNumber { get; }
        IUserRepository User { get; }
        void Save();
    }
}
