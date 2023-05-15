using Mini_Shopify.Models.Dto;

namespace Mini_Shopify.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
        {
            new VillaDTO { Id = 1, Name =" Pool View",Occupancy=4,Sqft=1000},
            new VillaDTO { Id = 2,Name = "Beach View",Occupancy=3,Sqft=3000}
        };
    }
}
