using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ComputerRepairDatabaseImplement.Models;
using System.Text;
using System.IO;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ComputerRepairDatabaseImplement.DatabaseContext
{
    public partial class ComputerRepairDatabase : DbContext
    {
        const string CONFIG_FILE_ADDRESS = "../../../config.txt";
        public ComputerRepairDatabase()
        {
        }

        public ComputerRepairDatabase(DbContextOptions<ComputerRepairDatabase> options)
            : base(options)
        {
        }

        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<CustomerBase> CustomerBase { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Materials> Materials { get; set; }
        public virtual DbSet<MaterialsContract> MaterialsContract { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<ServicesContract> ServicesContract { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(GetConnectionString());
                optionsBuilder.UseNpgsql("Host=192.168.0.103;Database=KamyshovDA;Username=postgres;Password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contract");

                entity.HasComment("Таблица контрактов");

                entity.HasIndex(e => e.DateOfConclusion)
                    .HasName("index_contract_date");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('contract_seq'::regclass)");

                entity.Property(e => e.CustomerBaseid)
                    .HasColumnName("customer_baseid")
                    .HasDefaultValueSql("1")
                    .HasComment("Идентификатор клиента");

                entity.Property(e => e.DateOfConclusion)
                    .HasColumnName("date_of_conclusion")
                    .HasColumnType("date")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата заключения контракта");

                entity.Property(e => e.Employeeid)
                    .HasColumnName("employeeid")
                    .HasDefaultValueSql("1")
                    .HasComment("Идентификатор сотрудника");

                entity.HasOne(d => d.CustomerBase)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.CustomerBaseid)
                    .HasConstraintName("customer_basefk");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.Employeeid)
                    .HasConstraintName("employeefk");
            });

            modelBuilder.Entity<CustomerBase>(entity =>
            {
                entity.ToTable("customer_base");

                entity.HasComment("Таблица клиентов");

                entity.HasIndex(e => e.DateOfBirthday)
                    .HasName("index_customer_base_date");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('customer_base_seq'::regclass)");

                entity.Property(e => e.DateOfBirthday)
                    .HasColumnName("date_of_birthday")
                    .HasColumnType("date")
                    .HasDefaultValueSql("now()")
                    .HasComment("День рождения клиента");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Отчество'::character varying")
                    .HasComment("Отчество клиента");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Имя'::character varying")
                    .HasComment("Имя клиента");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Фамилия'::character varying")
                    .HasComment("Фамилия клиента");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasComment("Таблица сотрудников");

                entity.HasIndex(e => e.Post)
                    .HasName("index_employee_post");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('employee_seq'::regclass)")
                    .HasComment("Идентификатор работника");

                entity.Property(e => e.DateOfBirthday)
                    .HasColumnName("date_of_birthday")
                    .HasColumnType("date")
                    .HasDefaultValueSql("now()")
                    .HasComment("День рождения работника");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Отчество'::character varying")
                    .HasComment("Отчество работника");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Имя'::character varying")
                    .HasComment("Имя работника");

                entity.Property(e => e.Post)
                    .IsRequired()
                    .HasColumnName("post")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Должность'::character varying")
                    .HasComment("Должность работника");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Фамилия'::character varying")
                    .HasComment("Фамилия работника");
            });

            modelBuilder.Entity<Materials>(entity =>
            {
                entity.ToTable("materials");

                entity.HasComment("Таблица материалов");

                entity.HasIndex(e => e.Name)
                    .HasName("index_materials_name");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('materials_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Материал'::character varying")
                    .HasComment("Название материала");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(6,2)")
                    .HasDefaultValueSql("15")
                    .HasComment("Цена материала");
            });

            modelBuilder.Entity<MaterialsContract>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("materials_contract");

                entity.HasComment("Материалы и контракты");

                entity.Property(e => e.Contractid)
                    .HasColumnName("contractid")
                    .HasDefaultValueSql("1")
                    .HasComment("Идентификатор контрактов");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('materials_contract_seq'::regclass)");

                entity.Property(e => e.Materialsid)
                    .HasColumnName("materialsid")
                    .HasDefaultValueSql("1")
                    .HasComment("Идентификатор материалов");

                entity.HasOne(d => d.Contract)
                    .WithMany()
                    .HasForeignKey(d => d.Contractid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contractidfk");

                entity.HasOne(d => d.Materials)
                    .WithMany()
                    .HasForeignKey(d => d.Materialsid)
                    .HasConstraintName("materialsidfk");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.HasComment("Таблица оплаты");

                entity.HasIndex(e => e.DateOfPayment)
                    .HasName("index_payment_date");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('payment_seq'::regclass)");

                entity.Property(e => e.Contractid)
                    .HasColumnName("contractid")
                    .HasDefaultValueSql("1")
                    .HasComment("Идентификатор контракта");

                entity.Property(e => e.DateOfPayment)
                    .HasColumnName("date_of_payment")
                    .HasColumnType("date")
                    .HasDefaultValueSql("now()")
                    .HasComment("День оплаты");

                entity.Property(e => e.Summ)
                    .HasColumnName("summ")
                    .HasColumnType("numeric(6,2)")
                    .HasDefaultValueSql("25")
                    .HasComment("Сумма заказа");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.Contractid)
                    .HasConstraintName("contractfk");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.ToTable("services");

                entity.HasComment("Таблица услуг");

                entity.HasIndex(e => e.Name)
                    .HasName("index_services_name");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('services_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Название'::character varying")
                    .HasComment("Название услуги");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(6,2)")
                    .HasDefaultValueSql("15")
                    .HasComment("Цена услуги");
            });

            modelBuilder.Entity<ServicesContract>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("services_contract");

                entity.HasComment("Услуги и контракты");

                entity.Property(e => e.Contractid)
                    .HasColumnName("contractid")
                    .HasDefaultValueSql("1")
                    .HasComment("Идентификатор контракта");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('services_contract_seq'::regclass)");

                entity.Property(e => e.Servicesid)
                    .HasColumnName("servicesid")
                    .HasDefaultValueSql("1")
                    .HasComment("Идентификатор услуги");

                entity.HasOne(d => d.Contract)
                    .WithMany()
                    .HasForeignKey(d => d.Contractid)
                    .HasConstraintName("contractidfk");

                entity.HasOne(d => d.Services)
                    .WithMany()
                    .HasForeignKey(d => d.Servicesid)
                    .HasConstraintName("servicesidfk");
            });

            modelBuilder.HasSequence("contract_seq");

            modelBuilder.HasSequence("customer_base_seq");

            modelBuilder.HasSequence("employee_seq");

            modelBuilder.HasSequence("materials_contract_seq");

            modelBuilder.HasSequence("materials_seq");

            modelBuilder.HasSequence("payment_seq");

            modelBuilder.HasSequence("services_contract_seq");

            modelBuilder.HasSequence("services_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private string GetConnectionString()
        {
            if (File.Exists(CONFIG_FILE_ADDRESS))
            {
                if (!CheckConfigFile(CONFIG_FILE_ADDRESS))
                {
                    throw new Exception("Неверный формат файла конфигурации");
                }
                StringBuilder str = new StringBuilder();
                using (StreamReader sr = new StreamReader(CONFIG_FILE_ADDRESS, Encoding.GetEncoding(1251)))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        str.Append(line);
                    }
                }
                Console.WriteLine(str.ToString());
                return str.ToString();
            }
            else
            {
                throw new Exception("Файл конфигурации не найден");
            }
        }
        private bool CheckConfigFile(string fileAddress)
        {
            int count = 0;
            using (StreamReader sr = new StreamReader(fileAddress))
            {
                while (sr.ReadLine() != null)
                {
                    count++;
                }
            }
            return count == 5 ? true : false;
        }
    }
}
