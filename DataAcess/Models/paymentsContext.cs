using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAcess.Models
{
    /// <summary>
    /// The payment context 
    /// </summary>
    public partial class paymentsContext : DbContext
    {
        private string _connectionString = null;
        public paymentsContext()
        {
        }
       
        /// <summary>
        /// The get conection string 
        /// </summary>
        /// <param name="connectionString"></param>
        public paymentsContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public paymentsContext(DbContextOptions<paymentsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CardPayment> CardPayment { get; set; }
        public virtual DbSet<NetBanking> NetBanking { get; set; }
        public virtual DbSet<OperaterTable> OperaterTable { get; set; }
        public virtual DbSet<PostPaid> PostPaid { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(_connectionString == null)
            {
                base.OnConfiguring(optionsBuilder);
            }
            else if(!optionsBuilder.IsConfigured)
            {
                //"PaymentConnection"
                //"Server=DESKTOP-89M5D8J\\SQLEXPRESS01;Database=payments;Trusted_Connection=True;"
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<CardPayment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.CardHolderName).HasMaxLength(50);

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cvvnumber)
                    .HasColumnName("CVVNumber")
                    .HasMaxLength(10);

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.ExpiryDate)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NetBanking>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.DateModified).HasColumnType("datetime");
            });

            modelBuilder.Entity<OperaterTable>(entity =>
            {
                entity.Property(e => e.Mrp)
                    .HasColumnName("MRP")
                    .HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Operater).IsRequired();

                entity.Property(e => e.Sms).HasColumnName("SMS");
            });

            modelBuilder.Entity<PostPaid>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.BillType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ConsumerNo).HasMaxLength(50);

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Id).IsRequired();

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
