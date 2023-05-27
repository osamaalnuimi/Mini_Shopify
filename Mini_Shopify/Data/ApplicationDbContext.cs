using Microsoft.EntityFrameworkCore;
using Mini_Shopify.Models;

namespace Mini_Shopify.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
            {
                Id = 1,
                Name = "Royal Villa",
                Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                ImageUrl ="",
                Occupancy = 5,
                Rate= 200,
                sqft = 550,
                Amenity ="",
                CreatedDate = DateTime.UtcNow,

            },

                new Villa()
                {
                    Id = 2,
                    Name = "Royal Villa 2",
                    Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ImageUrl = "",
                    Occupancy = 4 ,
                    Rate = 200,
                    sqft = 550,
                    Amenity = "",
                    CreatedDate = DateTime.UtcNow,

                },
                  new Villa()
                  {
                      Id =3,
                      Name = "Royal Villa 3",
                      Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                      ImageUrl = "",
                      Occupancy = 1,
                      Rate = 200,
                      sqft = 550,
                      Amenity = "",
                      CreatedDate = DateTime.UtcNow,

                  },
                    new Villa()
                    {
                        Id = 4,
                        Name = "Royal Villa 4",
                        Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        ImageUrl = "",
                        Occupancy =5,
                        Rate = 200,
                        sqft = 550,
                        Amenity = "",
                        CreatedDate = DateTime.UtcNow,

                    },
                      new Villa()
                      {
                          Id = 5,
                          Name = "Royal Villa 5",
                          Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                          ImageUrl = "",
                          Occupancy = 5,
                          Rate = 200,
                          sqft = 550,
                          Amenity = "",
                          CreatedDate = DateTime.UtcNow,

                      }
                );
        }
    }
}
