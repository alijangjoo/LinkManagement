namespace Dotin.URLManagement.Infra.DAL.DatabaseContexts
{
    using Dotin.URLManagement.Infra.DAL.URLShortener.Entities;
    using Dotin.URLManagement.Infra.DAL.URLViewer.Entities;
    using Microsoft.EntityFrameworkCore;
    public class URLManagementDbContext : DbContext
    {
        public URLManagementDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<ShrotenerURL> ShrotenerURLs { get; set; }
        public DbSet<URLViewerInfo> URLViewerInfo { get; set; }
    }
}
