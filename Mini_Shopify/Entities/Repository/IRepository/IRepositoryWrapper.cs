namespace Mini_Shopify.Entities.Repository.IRepository
{
    public interface IRepositoryWrapper
    {
        IVillaRepository Villa { get; }
        IVillaNumberRepository VillaNumber { get; }
        void Save();
    }
}
