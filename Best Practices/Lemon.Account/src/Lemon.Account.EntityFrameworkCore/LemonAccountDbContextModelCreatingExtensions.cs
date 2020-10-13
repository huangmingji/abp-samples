using Lemon.Account.Domain.Role;
using Lemon.Account.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Lemon.Account.EntityFrameworkCore
{
    public static class LemonAccountDbContextModelCreatingExtensions
    {
        public static void ConfigureLemonAccount(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
            builder.ConfigureAccount();
        }
        
        private static void ConfigureAccount(this ModelBuilder builder)
        {
            builder.Entity<RoleData>(b =>
            {
                b.ToTable("RoleData", "account");                
                b.ConfigureAuditedAggregateRoot();
                b.HasKey(o => o.Id);
                b.HasMany(x => x.Permissions)
                    .WithOne()
                    .HasForeignKey(x => x.RoleId);
                b.ConfigureByConvention();
            });
            
            builder.Entity<RolePermissionData>(b =>
            {
                b.ToTable("RolePermissionData", "account");
                b.HasKey(x => new { x.RoleId, x.Permission });
                b.ConfigureByConvention();
            });
            
            builder.Entity<PermissionData>(b =>
            {
                b.ToTable("PermissionData", "account");
                b.HasKey(o => o.Id);
                b.ConfigureByConvention();
            });
            
            builder.Entity<UserData>(b =>
            {
                b.ToTable("UserData", "account");
                b.HasKey(o => o.Id);
                b.HasOne(x=> x.UserLogOn)
                    .WithOne()
                    .HasForeignKey<UserLogOn>(x => x.UserId);
                b.HasMany(x => x.UserRoles)
                    .WithOne()
                    .HasForeignKey(x => x.UserId);
                b.HasIndex(o => o.Account).IsUnique();
                b.HasIndex(x => x.Email).IsUnique();
                b.HasIndex(x => x.Mobile).IsUnique();
                b.ConfigureAuditedAggregateRoot();
                b.ConfigureByConvention();
            });

            builder.Entity<UserLogOn>(b =>
            {
                b.ToTable("UserLogOn", "account");
                b.HasKey(x => x.UserId );
                b.ConfigureByConvention();
            });
            
            builder.Entity<UserRole>(b =>
            {
                b.ToTable("UserRole", "account");
                b.HasKey(o => o.Id);
                b.HasOne(x => x.RoleData)
                    .WithOne()
                    .HasForeignKey<UserRole>(x => x.RoleId);
                b.ConfigureAuditedAggregateRoot();
                b.ConfigureByConvention();
                b.HasIndex(o => o.UserId);
                b.HasIndex(o => new { o.RoleId, o.UserId }).IsUnique();
            });
        }
    }
}