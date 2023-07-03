using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Курсовая__Магазин_компьютерных_комплектующих_.Model;

public partial class ShopcoumpcomplectContext : DbContext
{
    public ShopcoumpcomplectContext()
    {
    }

    public ShopcoumpcomplectContext(DbContextOptions<ShopcoumpcomplectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Manufacture> Manufactures { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderproduct> Orderproducts { get; set; }

    public virtual DbSet<PickapPoint> PickapPoints { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Suppler> Supplers { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseMySql("server=127.0.0.1;port=3306;user=root;database=shopcoumpcomplect;password=1488", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Manufacture>(entity =>
        {
            entity.HasKey(e => e.IdManufacture).HasName("PRIMARY");

            entity.ToTable("manufacture");

            entity.Property(e => e.IdManufacture).HasColumnName("id_manufacture");
            entity.Property(e => e.NameManufacture)
                .HasMaxLength(45)
                .HasColumnName("name_manufacture");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PRIMARY");

            entity.ToTable("order");

            entity.HasIndex(e => e.PickapPointOrder, "Order_Pickap_Point_FK_idx");

            entity.HasIndex(e => e.UserOrder, "Orser_User_FK_idx");

            entity.Property(e => e.IdOrder).HasColumnName("id_Order");
            entity.Property(e => e.CodeToGet).HasColumnName("codeToGet");
            entity.Property(e => e.DateOrder).HasColumnName("Date_Order");
            entity.Property(e => e.PickapPointOrder).HasColumnName("Pickap_Point_Order");
            entity.Property(e => e.UserOrder).HasColumnName("User_Order");

            entity.HasOne(d => d.PickapPointOrderNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PickapPointOrder)
                .HasConstraintName("Order_Pickap_Point_FK");

            entity.HasOne(d => d.UserOrderNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserOrder)
                .HasConstraintName("Orser_User_FK");
        });

        modelBuilder.Entity<Orderproduct>(entity =>
        {
            entity.HasKey(e => new { e.IdOrder, e.IdProduct })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("orderproduct");

            entity.HasIndex(e => e.IdProduct, "product_idx");

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdProduct).HasColumnName("Id_product");
            entity.Property(e => e.Count).HasColumnName("count");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Orderproducts)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Orderproducts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product");
        });

        modelBuilder.Entity<PickapPoint>(entity =>
        {
            entity.HasKey(e => e.IdPickapPoint).HasName("PRIMARY");

            entity.ToTable("pickap_point");

            entity.Property(e => e.IdPickapPoint)
                .ValueGeneratedNever()
                .HasColumnName("id_Pickap_Point");
            entity.Property(e => e.HousePickapPoint).HasColumnName("House_Pickap_Point");
            entity.Property(e => e.IndexPickapPoint).HasColumnName("index_Pickap_Point");
            entity.Property(e => e.SityPickapPoint)
                .HasMaxLength(45)
                .HasColumnName("Sity_Pickap_Point");
            entity.Property(e => e.StreetPickapPoint)
                .HasMaxLength(45)
                .HasColumnName("Street_Pickap_Point");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.ManufactureProduct, "manufacture_FK_idx");

            entity.HasIndex(e => e.SupplProduct, "suppl_FK_idx");

            entity.HasIndex(e => e.TypeProduct, "type_FK_idx");

            entity.Property(e => e.IdProduct).HasColumnName("id_Product");
            entity.Property(e => e.CostProduct)
                .HasPrecision(19, 2)
                .HasColumnName("Cost_product");
            entity.Property(e => e.CountInStockProduct).HasColumnName("Count_in_stock_Product");
            entity.Property(e => e.DiscriptionProduct)
                .HasMaxLength(500)
                .HasColumnName("Discription_Product");
            entity.Property(e => e.ManufactureProduct).HasColumnName("Manufacture_Product");
            entity.Property(e => e.NameProduct)
                .HasMaxLength(45)
                .HasColumnName("name_Product");
            entity.Property(e => e.PhotoProduct)
                .HasMaxLength(500)
                .HasColumnName("Photo_Product");
            entity.Property(e => e.SupplProduct).HasColumnName("Suppl_Product");
            entity.Property(e => e.TypeProduct).HasColumnName("Type_Product");

            entity.HasOne(d => d.ManufactureProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufactureProduct)
                .HasConstraintName("manufacture_FK");

            entity.HasOne(d => d.SupplProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplProduct)
                .HasConstraintName("suppl_FK");

            entity.HasOne(d => d.TypeProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeProduct)
                .HasConstraintName("type_FK");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PRIMARY");

            entity.ToTable("role");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.NameRole)
                .HasMaxLength(45)
                .HasColumnName("name_role");
        });

        modelBuilder.Entity<Suppler>(entity =>
        {
            entity.HasKey(e => e.IdSupplers).HasName("PRIMARY");

            entity.ToTable("supplers");

            entity.Property(e => e.IdSupplers).HasColumnName("id_supplers");
            entity.Property(e => e.NameSupplers)
                .HasMaxLength(45)
                .HasColumnName("name_supplers");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.IdType).HasName("PRIMARY");

            entity.ToTable("type");

            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.NameType)
                .HasMaxLength(45)
                .HasColumnName("name_type");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.LoginUser, "Login_User_UNIQUE").IsUnique();

            entity.HasIndex(e => e.NumTelefonUser, "NumTelefon_user_UNIQUE").IsUnique();

            entity.HasIndex(e => e.RoleUser, "role_FK_idx");

            entity.Property(e => e.IdUser).HasColumnName("id_User");
            entity.Property(e => e.LoginUser)
                .HasMaxLength(45)
                .HasColumnName("Login_User");
            entity.Property(e => e.NameUser)
                .HasMaxLength(45)
                .HasColumnName("Name_user");
            entity.Property(e => e.NumTelefonUser)
                .HasMaxLength(45)
                .HasColumnName("NumTelefon_user");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(45)
                .HasColumnName("Password_User");
            entity.Property(e => e.PatronymicUser)
                .HasMaxLength(45)
                .HasColumnName("Patronymic_user");
            entity.Property(e => e.RoleUser).HasColumnName("Role_user");
            entity.Property(e => e.SurNameUser)
                .HasMaxLength(45)
                .HasColumnName("SurName_user");

            entity.HasOne(d => d.RoleUserNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("role_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
