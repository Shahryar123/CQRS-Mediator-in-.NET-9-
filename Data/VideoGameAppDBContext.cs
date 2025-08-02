using CQRS_and_Mediator.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS_and_Mediator.Data
{
    public class VideoGameAppDBContext : DbContext
    {
        public VideoGameAppDBContext(DbContextOptions<VideoGameAppDBContext> options)
            : base(options)
        {
        }
        public DbSet<Player> Players { get; set; }


    }
}
