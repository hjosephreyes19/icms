using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ICMS.Entities.Main;

namespace ICMS.Repositories.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        // Add DbSet main tables here
        public DbSet<Module> Module { get; set; }
        //public DbSet<Document> Document { get; set; }
        //public DbSet<DocumentField> DocumentField { get; set; }
        //public DbSet<Field> Field { get; set; }
        //public DbSet<FieldItem> FieldItem { get; set; }
        //public DbSet<Module> Module { get; set; }
        //public DbSet<SubModule> SubModule { get; set; }
        //public DbSet<SubModuleField> ModuleField { get; set; }
        //public DbSet<Template> Template { get; set; }
        //public DbSet<TemplateField> TemplateField { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<IdentityRole<int>>().ToTable("Roles");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");

            //// Register OpenIddict
            modelBuilder.UseOpenIddict();

            //// TODO: Configure limit, constraints, table index field
            //// Register main entities
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
            });
            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("Module").HasKey(c => c.id);
                entity.Property(c => c.id).HasColumnName("id").ValueGeneratedOnAdd();
                entity.Property(c => c.rowVersion).HasColumnName("rowVersion").IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
                entity.Property(c => c.createdDate).HasColumnName("createdDate").HasColumnType("date").IsRequired();
                entity.Property(c => c.createdBy).HasColumnName("createdBy").IsRequired();
                entity.Property(c => c.modifiedDate).HasColumnName("modifiedDate").HasColumnType("date");
                entity.Property(c => c.modifiedBy).HasColumnName("modifiedBy");

                entity.Property(c => c.name).HasColumnName("name").IsRequired();
                entity.Property(c => c.description).HasColumnName("description").IsRequired();
                entity.Property(c => c.isEnabled).HasColumnName("isEnabled").HasDefaultValue(1);
                entity.Property(c => c.url).HasColumnName("url").IsRequired();
                entity.Property(c => c.order).HasColumnName("order").IsRequired();
                entity.Property(c => c.roles).HasColumnName("role").IsRequired();
            });
            //modelBuilder.Entity<Document>(entity =>
            //{
            //    entity.ToTable("Document").HasKey(c => new
            //    {
            //        c.Id
            //    });

            //    entity.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
            //    entity.Property(c => c.RowVersion).HasColumnName("rowVersion").IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
            //    entity.Property(c => c.CreatedDate).HasColumnName("createdDate").HasColumnType("date").IsRequired();
            //    entity.Property(c => c.CreatedBy).HasColumnName("createdBy").IsRequired();
            //    entity.Property(c => c.ModifiedDate).HasColumnName("modifiedDate").HasColumnType("date");
            //    entity.Property(c => c.ModifiedBy).HasColumnName("modifiedBy");

            //    entity.Property(c => c.DataNumber).HasColumnName("datanumber");
            //    entity.Property(c => c.DueDate).HasColumnName("duedate");
            //    entity.Property(c => c.Status).HasColumnName("status");
            //    entity.Property(c => c.TemplateId).HasColumnName("templateid");
            //    entity.Property(c => c.DataSubject).HasColumnName("datasubject");
            //});

            //modelBuilder.Entity<DocumentField>(entity =>
            //{
            //    entity.ToTable("DocumentFields").HasKey(c => c.Id);
            //    entity.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
            //    entity.Property(c => c.RowVersion).HasColumnName("rowVersion").IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();

            //    entity.Property(c => c.DocumentId).HasColumnName("docid").IsRequired();
            //    entity.Property(c => c.FieldId).HasColumnName("fieldId").IsRequired();
            //    entity.Property(c => c.SubModuleId).HasColumnName("submoduleid").IsRequired();
            //    entity.Property(c => c.Value).HasColumnName("value");
            //    entity.Property(c => c.FilePath).HasColumnName("filepath");

            //    entity.HasOne(e => e.Document).WithMany(e => e.DocumentField).HasForeignKey(cc => cc.DocumentId).IsRequired();
            //});

            //modelBuilder.Entity<DocumentTemplateField>(entity =>
            //{
            //    entity.ToTable("DocumentTemplateFields").HasKey(c => c.Id);
            //    entity.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
            //    entity.Property(c => c.RowVersion).HasColumnName("rowVersion").IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();

            //    entity.Property(c => c.DocumentId).HasColumnName("docid").IsRequired();
            //    entity.Property(c => c.FieldId).HasColumnName("fieldId").IsRequired();
            //    entity.Property(c => c.TemplateId).HasColumnName("templateid").IsRequired();
            //    entity.Property(c => c.Value).HasColumnName("value");
            //    entity.Property(c => c.FilePath).HasColumnName("filepath");

            //    entity.HasOne(e => e.Document).WithMany(e => e.DocumentTemplateField).HasForeignKey(cc => cc.DocumentId).IsRequired();
            //});

            //modelBuilder.Entity<Field>(entity =>
            //{
            //    entity.ToTable("Field").HasKey(c => c.Id);
            //    entity.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
            //    entity.Property(c => c.RowVersion).HasColumnName("rowVersion").IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
            //    entity.Property(c => c.CreatedDate).HasColumnName("createdDate").HasColumnType("date").IsRequired();
            //    entity.Property(c => c.CreatedBy).HasColumnName("createdBy").IsRequired();
            //    entity.Property(c => c.ModifiedDate).HasColumnName("modifiedDate").HasColumnType("date");
            //    entity.Property(c => c.ModifiedBy).HasColumnName("modifiedBy");

            //    entity.Property(c => c.Name).HasColumnName("name").IsRequired();
            //    entity.Property(c => c.IsDefault).HasColumnName("isdefault");
            //    entity.Property(c => c.IsRequired).HasColumnName("isrequired");
            //    entity.Property(c => c.Type).HasColumnName("type");
            //});

            //modelBuilder.Entity<FieldItem>(entity =>
            //{
            //    entity.ToTable("FieldItems").HasKey(c => c.Id);
            //    entity.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
            //    entity.Property(c => c.RowVersion).HasColumnName("rowVersion").IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();

            //    entity.Property(c => c.Name).HasColumnName("name").IsRequired();
            //    entity.Property(c => c.Description).HasColumnName("description");
            //    entity.Property(c => c.FieldId).HasColumnName("fieldId").IsRequired();
            //    entity.HasOne(e => e.Field).WithMany(e => e.FieldItem).HasForeignKey(cc => cc.FieldId).IsRequired();
            //});

            //modelBuilder.Entity<Module>(entity =>
            //{
            //    entity.ToTable("Module").HasKey(c => c.Id);
            //    entity.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
            //    entity.Property(c => c.RowVersion).HasColumnName("rowVersion").IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
            //    entity.Property(c => c.CreatedDate).HasColumnName("createdDate").HasColumnType("date").IsRequired();
            //    entity.Property(c => c.CreatedBy).HasColumnName("createdBy").IsRequired();
            //    entity.Property(c => c.ModifiedDate).HasColumnName("modifiedDate").HasColumnType("date");
            //    entity.Property(c => c.ModifiedBy).HasColumnName("modifiedBy");

            //    entity.Property(c => c.Name).HasColumnName("name").IsRequired();
            //    entity.Property(c => c.isEnabled).HasColumnName("isenabled");
            //    entity.Property(c => c.Description).HasColumnName("description");
            //    entity.Property(c => c.Url).HasColumnName("url");
            //});

            //modelBuilder.Entity<SubModule>(entity =>
            //{
            //    entity.ToTable("SubModule").HasKey(c => c.Id);
            //    entity.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
            //    entity.Property(c => c.RowVersion).HasColumnName("rowVersion").IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();

            //    entity.Property(c => c.ModuleId).HasColumnName("moduleid").IsRequired();
            //    entity.Property(c => c.Name).HasColumnName("name").IsRequired();
            //    entity.Property(c => c.isEnabled).HasColumnName("isenabled");
            //    entity.Property(c => c.Description).HasColumnName("description");
            //    entity.Property(c => c.Url).HasColumnName("url");

            //    entity.HasOne(e => e.Module).WithMany(e => e.SubModule).HasForeignKey(cc => cc.ModuleId).IsRequired();
            //});

            //modelBuilder.Entity<SubModuleField>(entity =>
            //{
            //    entity.ToTable("SubModuleField").HasKey(c => c.Id);
            //    entity.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
            //    entity.Property(c => c.RowVersion).HasColumnName("rowVersion").IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();

            //    entity.Property(c => c.SubModuleId).HasColumnName("submoduleid");
            //    entity.Property(c => c.FieldId).HasColumnName("fieldid").IsRequired();
            //    entity.Property(c => c.Order).HasColumnName("order").IsRequired();
            //    entity.HasOne(e => e.SubModule).WithMany(e => e.SubModuleField).HasForeignKey(cc => cc.SubModuleId).IsRequired();
            //    entity.HasOne(e => e.Field).WithMany(e => e.SubModuleField).HasForeignKey(cc => cc.FieldId).IsRequired();
            //});

            //modelBuilder.Entity<Template>(entity =>
            //{
            //    entity.ToTable("Template").HasKey(c => c.Id);
            //    entity.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
            //    entity.Property(c => c.RowVersion).HasColumnName("rowVersion").IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
            //    entity.Property(c => c.CreatedDate).HasColumnName("createdDate").HasColumnType("date").IsRequired();
            //    entity.Property(c => c.CreatedBy).HasColumnName("createdBy").IsRequired();
            //    entity.Property(c => c.ModifiedDate).HasColumnName("modifiedDate").HasColumnType("date");
            //    entity.Property(c => c.ModifiedBy).HasColumnName("modifiedBy");

            //    entity.Property(c => c.Name).HasColumnName("name").IsRequired();
            //    entity.Property(c => c.Description).HasColumnName("description");
            //});

            //modelBuilder.Entity<TemplateField>(entity =>
            //{
            //    entity.ToTable("TemplateField").HasKey(c => c.Id);
            //    entity.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
            //    entity.Property(c => c.RowVersion).HasColumnName("rowVersion").IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();

            //    entity.Property(c => c.TemplateId).HasColumnName("templateid");
            //    entity.Property(c => c.FieldId).HasColumnName("fieldid").IsRequired();
            //    entity.Property(c => c.Order).HasColumnName("order").IsRequired();
            //    entity.HasOne(e => e.Template).WithMany(e => e.TemplateField).HasForeignKey(cc => cc.TemplateId).IsRequired();
            //    entity.ToTable("TemplateField");
            //    entity.HasOne(e => e.Field).WithMany(e => e.TemplateField).HasForeignKey(cc => cc.FieldId).IsRequired();
            //});
        }
    }
}