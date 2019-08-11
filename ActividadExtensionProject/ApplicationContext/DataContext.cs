using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Core.Constants;

namespace ApplicationContext
{
    public class DataContext : DbContext, IAppContext, IDesignTimeDbContextFactory<DataContext>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfigurationRoot _configuration;


        public DataContext()
        {

        }

        public DataContext(DbContextOptions options, IHttpContextAccessor contextAccessor, IConfigurationRoot configuration) : base(options)
        {
            //Uncomment this lines if youd like to debbug the migration scripts
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            _contextAccessor = contextAccessor;
            _configuration = configuration;


        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<ActaEU> ActasEU { get; set; }
        public DbSet<ActaEUDetalle> ActasEUDetalles { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
            modelBuilder.Entity<Categoria>()
                .HasMany(x => x.SubCategorias)
                .WithOne(x => x.Categoria)
                .HasForeignKey(x => x.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ActaEU>()
                .HasMany(x => x.ActaEUDetalle)
                .WithOne(x => x.Acta)
                .HasForeignKey(x => x.ActaEUId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Estudiante>()
               .HasMany(x => x.Actas)
               .WithOne(x => x.Estudiante)
               .HasForeignKey(x => x.EstudianteId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Carrera>()
              .HasMany(x => x.Actas)
              .WithOne(x => x.Carrera)
              .HasForeignKey(x => x.CarreraId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SubCategoria>()
              .HasMany(x => x.ActaEUDetalle)
              .WithOne(x => x.SubCategoria)
              .HasForeignKey(x => x.SubCategoriaId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Carrera>()
              .HasMany(x => x.Estudiantes)
              .WithOne(x => x.Carrera)
              .HasForeignKey(x => x.CarreraId)
              .OnDelete(DeleteBehavior.Restrict);
        }

        public override int SaveChanges()
        {
            var now = DateTime.UtcNow;
            var userId = GetUserId();

            //Populate Created/ Modified By fields
            var castedList = ChangeTracker.Entries<BaseEntity>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();
            foreach (var x in castedList)
            {
                if (x.State == EntityState.Added)
                {
                    x.Entity.DateCreated = now;
                    x.Entity.UserCreatedId = userId;
                }
                else if (x.State == EntityState.Modified)
                {
                    x.Entity.DateModified = now;
                    x.Entity.UserModifiedId = userId;
                }
            }
            return base.SaveChanges();
        }

        public DataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=ActividadesExtensionDBDev;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new DataContext(builder.Options, _contextAccessor, _configuration);
        }

        private int GetUserId()
        {
            return _contextAccessor == null ? 0 : Convert.ToInt32(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.UserId)?.Value ?? "0");
        }
    }
}
