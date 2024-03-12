using Microsoft.EntityFrameworkCore;
using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Contexts;

public partial class SaleCoreContext : DbContext
{
    public SaleCoreContext()
    {
    }

    public SaleCoreContext(DbContextOptions<SaleCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductStock> ProductStocks { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Purcharse> Purcharses { get; set; }

    public virtual DbSet<PurcharseDetail> PurcharseDetails { get; set; }

    public virtual DbSet<Quote> Quotes { get; set; }

    public virtual DbSet<QuoteDetail> QuoteDetails { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VoucherDocumentType> VoucherDocumentTypes { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=172.174.251.150;database=SaleCore;user=sa;password=S0port3.;Connect Timeout=60;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Purcharse>(entity =>
        {
            entity.HasKey(e => e.PurcharseId).HasName("PK__Purchars__A98C674BDE295F6F");

            entity.ToTable("Purcharse");

            entity.Property(e => e.Iva).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Provider).WithMany(p => p.Purcharses)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Purcharse__Provi__70DDC3D8");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Purcharses)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Purcharse__Wareh__71D1E811");
        });

        modelBuilder.Entity<PurcharseDetail>(entity =>
        {
            entity.HasKey(e => new { e.PurcharseId, e.ProductId }).HasName("PK__Purchars__62CCAB2760589CAC");

            entity.ToTable("PurcharseDetail");

            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitPurcharsePrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.PurcharseDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Purcharse__Produ__73BA3083");

            entity.HasOne(d => d.Purcharse).WithMany(p => p.PurcharseDetails)
                .HasForeignKey(d => d.PurcharseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Purcharse__Purch__72C60C4A");
        });

        modelBuilder.Entity<Quote>(entity =>
        {
            entity.HasKey(e => e.QuoteId).HasName("PK__Quote__AF9688C159F0D61A");

            entity.ToTable("Quote");

            entity.Property(e => e.Discount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Iva).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Client).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quote__ClientId__74AE54BC");

            entity.HasOne(d => d.VoucherDocumentType).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.VoucherDocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quote__VoucherDo__75A278F5");
        });

        modelBuilder.Entity<QuoteDetail>(entity =>
        {
            entity.HasKey(e => new { e.QuoteId, e.ProductId }).HasName("PK__QuoteDet__64D644AD740DF2BA");

            entity.ToTable("QuoteDetail");

            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitSalePrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.QuoteDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__QuoteDeta__Produ__76969D2E");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__Sale__1EE3C3FF970ED72A");

            entity.ToTable("Sale");

            entity.Property(e => e.Iva).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Client).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sale__ClientId__778AC167");

            entity.HasOne(d => d.Quote).WithMany(p => p.Sales)
                .HasForeignKey(d => d.QuoteId)
                .HasConstraintName("FK__Sale__QuoteId__787EE5A0");

            entity.HasOne(d => d.VoucherDocumentType).WithMany(p => p.Sales)
                .HasForeignKey(d => d.VoucherDocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sale__VoucherDoc__797309D9");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Sales)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sale__WarehouseI__7A672E12");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.HasKey(e => new { e.SaleId, e.ProductId }).HasName("PK__SaleDeta__D5A30F93D1015521");

            entity.ToTable("SaleDetail");

            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitSalePrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SaleDetai__Produ__7D439ABD");

            entity.HasOne(d => d.Quote).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.QuoteId)
                .HasConstraintName("FK__SaleDetai__Quote__7C4F7684");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SaleDetai__SaleI__7B5B524B");
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.HasKey(e => e.SubCategoryId).HasName("PK__SubCateg__26BE5B192DC75A8B");

            entity.ToTable("SubCategory");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubCatego__Categ__6A30C649");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C280696F8");

            entity.ToTable("User");

            entity.Property(e => e.AuthType)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VoucherDocumentType>(entity =>
        {
            entity.HasKey(e => e.VoucherDocumentTypeId).HasName("PK__VoucherD__CD0B68F2E39021AF");

            entity.ToTable("VoucherDocumentType");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseId).HasName("PK__Warehous__2608AFF9564CAD78");

            entity.ToTable("Warehouse");

            entity.Property(e => e.Name).HasMaxLength(25);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}