using System;
using Microsoft.EntityFrameworkCore;

namespace FileSharingandStorageSystem
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<FileMetaData> FileMetaData { get; set; }
    }
}
 