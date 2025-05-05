//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Dal.Models
//{
//    internal class dbContext
//    {
//    }
//}
using System;
using System.Collections.Generic;
using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Models;

public partial class dbcontext : DbContext
{
    public dbcontext()
    {
    }

    public dbcontext(DbContextOptions<dbcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Expenditure> Expenditures { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\הפרויקט של איידי & שרי\\Dal\\Server.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__23CAF1D87B77C047");

            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CategoryName)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("categoryName");
        });

        modelBuilder.Entity<Expenditure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07FE275863");

            entity.Property(e => e.AmountPaid)
                .HasColumnType("money")
                .HasColumnName("amountPaid");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.ExpenditureSum)
                .HasColumnType("money")
                .HasColumnName("expenditureSum");
            entity.Property(e => e.InvoiceNum).HasColumnName("invoiceNum");
            entity.Property(e => e.IsAccepted).HasColumnName("isAccepted");
            entity.Property(e => e.OrdererName)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ordererName");
            entity.Property(e => e.SchoolSymbol).HasColumnName("schoolSymbol");
            entity.Property(e => e.SupplierNum).HasColumnName("supplierNum");

            entity.HasOne(d => d.Category).WithMany(p => p.Expenditures)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Expenditures_ToTable_2");

            entity.HasOne(d => d.SchoolSymbolNavigation).WithMany(p => p.Expenditures)
                .HasForeignKey(d => d.SchoolSymbol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Expenditures_ToTable_1");

            entity.HasOne(d => d.SupplierNumNavigation).WithMany(p => p.Expenditures)
                .HasForeignKey(d => d.SupplierNum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Expenditures_ToTable");
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.SchoolSymbol).HasName("PK__Schools__18574C2CD6D4087D");

            entity.Property(e => e.SchoolSymbol)
                .ValueGeneratedNever()
                .HasColumnName("schoolSymbol");
            entity.Property(e => e.Budget)
                .HasColumnType("money")
                .HasColumnName("budget");
            entity.Property(e => e.SchoolName)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("schoolName");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.LicensedNum);

            entity.Property(e => e.LicensedNum).ValueGeneratedNever();
            entity.Property(e => e.BankCode).HasColumnName("bankCode");
            entity.Property(e => e.NameOfOwnerAccount)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("nameOfOwnerAccount");
            entity.Property(e => e.NumOfBankAccount).HasColumnName("numOfBankAccount");
            entity.Property(e => e.NumOfBankBranch).HasColumnName("numOfBankBranch");
            entity.Property(e => e.SupplierName)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("supplierName");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC074670D0EE");

            entity.ToTable("users");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.SchoolSymbol).HasColumnName("schoolSymbol");
            entity.Property(e => e.UserName)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("userName");

            entity.HasOne(d => d.SchoolSymbolNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.SchoolSymbol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_ToTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

