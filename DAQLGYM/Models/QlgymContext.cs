using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAQLGYM.Models;

public partial class QlgymContext : DbContext
{
    public QlgymContext()
    {
    }

    public QlgymContext(DbContextOptions<QlgymContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAccount> TblAccounts { get; set; }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    public virtual DbSet<TblBlogComment> TblBlogComments { get; set; }

    public virtual DbSet<TblClass> TblClasses { get; set; }

    public virtual DbSet<TblContact> TblContacts { get; set; }

    public virtual DbSet<TblEquipment> TblEquipments { get; set; }

    public virtual DbSet<TblInvoice> TblInvoices { get; set; }

    public virtual DbSet<TblMemberPackage> TblMemberPackages { get; set; }

    public virtual DbSet<TblMenu> TblMenus { get; set; }

    public virtual DbSet<TblPackage> TblPackages { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblRoom> TblRooms { get; set; }

    public virtual DbSet<TblSchedule> TblSchedules { get; set; }

    public virtual DbSet<TblService> TblServices { get; set; }

    public virtual DbSet<TblTrainer> TblTrainers { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId);

            entity.ToTable("tblAccount");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.LastLogin)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.TblAccounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblAccount_tblRole");
        });

        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("tblBlog");

            entity.Property(e => e.Alias).HasMaxLength(250);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.SeoDescription).HasMaxLength(500);
            entity.Property(e => e.SeoKeywords).HasMaxLength(250);
            entity.Property(e => e.SeoTitle).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);

            entity.HasOne(d => d.Account).WithMany(p => p.TblBlogs)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_tblBlog_tblAccount");
        });

        modelBuilder.Entity<TblBlogComment>(entity =>
        {
            entity.HasKey(e => e.CommentId);

            entity.ToTable("tblBlogComment");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Detail).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.Blog).WithMany(p => p.TblBlogComments)
                .HasForeignKey(d => d.BlogId)
                .HasConstraintName("FK_tblBlogComment_tblBlog");
        });

        modelBuilder.Entity<TblClass>(entity =>
        {
            entity.HasKey(e => e.ClassId);

            entity.ToTable("tblClass");

            entity.Property(e => e.ClassId).HasColumnName("classID");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.NameClass)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_class");
            entity.Property(e => e.ScheduleId).HasColumnName("scheduleID");
            entity.Property(e => e.TrainerId).HasColumnName("trainerID");

            entity.HasOne(d => d.Schedule).WithMany(p => p.TblClasses)
                .HasForeignKey(d => d.ScheduleId)
                .HasConstraintName("FK_tblClass_tblSchedules");

            entity.HasOne(d => d.Trainer).WithMany(p => p.TblClasses)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK_tblClass_tblTrainers");
        });

        modelBuilder.Entity<TblContact>(entity =>
        {
            entity.HasKey(e => e.ContactId);

            entity.ToTable("tblContact");

            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<TblEquipment>(entity =>
        {
            entity.HasKey(e => e.EquipmentId).HasName("PK__tblEquip__996A22D165109849");

            entity.ToTable("tblEquipment");

            entity.Property(e => e.EquipmentId).HasColumnName("equipmentID");
            entity.Property(e => e.AssignedRoomId).HasColumnName("assigned_roomID");
            entity.Property(e => e.Brand)
                .HasMaxLength(100)
                .HasColumnName("brand");
            entity.Property(e => e.DeviceType)
                .HasMaxLength(100)
                .HasColumnName("device_type");
            entity.Property(e => e.EquipmentName)
                .HasMaxLength(255)
                .HasColumnName("equipment_name");
            entity.Property(e => e.LocationEquipment)
                .HasMaxLength(255)
                .HasColumnName("location_Equipment");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");
            entity.Property(e => e.StatusEquipment)
                .HasMaxLength(200)
                .HasColumnName("status_Equipment");

            entity.HasOne(d => d.AssignedRoom).WithMany(p => p.TblEquipments)
                .HasForeignKey(d => d.AssignedRoomId)
                .HasConstraintName("FK__tblEquipm__assig__5EBF139D");
        });

        modelBuilder.Entity<TblInvoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId);

            entity.ToTable("tblInvoices");

            entity.Property(e => e.InvoiceId).HasColumnName("invoiceID");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.InvoiceDate).HasColumnName("invoice_date");
            entity.Property(e => e.MemberPackageId).HasColumnName("member_packageID");
            entity.Property(e => e.Notes)
                .HasColumnType("text")
                .HasColumnName("notes");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.StatusInvoices)
                .HasMaxLength(100)
                .HasColumnName("status_Invoices");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");

            entity.HasOne(d => d.MemberPackage).WithMany(p => p.TblInvoices)
                .HasForeignKey(d => d.MemberPackageId)
                .HasConstraintName("FK_tblInvoices_tblMemberPackages");
        });

        modelBuilder.Entity<TblMemberPackage>(entity =>
        {
            entity.HasKey(e => e.MemberPackageId);

            entity.ToTable("tblMemberPackages");

            entity.Property(e => e.MemberPackageId).HasColumnName("member_packageID");
            entity.Property(e => e.ClassId).HasColumnName("classID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.MemberName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("member_name");
            entity.Property(e => e.PackageId).HasColumnName("packageID");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.Class).WithMany(p => p.TblMemberPackages)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblMemberPackages_tblClass");

            entity.HasOne(d => d.Package).WithMany(p => p.TblMemberPackages)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK_tblMemberPackages_tblPackages");
        });

        modelBuilder.Entity<TblMenu>(entity =>
        {
            entity.HasKey(e => e.MenuId);

            entity.ToTable("tblMenu");

            entity.Property(e => e.Alias).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<TblPackage>(entity =>
        {
            entity.HasKey(e => e.PackageId).HasName("PK__tblPacka__AA8D20E8F59DB4FB");

            entity.ToTable("tblPackages");

            entity.Property(e => e.PackageId).HasColumnName("packageID");
            entity.Property(e => e.Describe)
                .HasColumnType("text")
                .HasColumnName("describe");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.ImagePackages)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_Packages");
            entity.Property(e => e.PackageName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("package_name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("tblRole");

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblRoom>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__tblRooms__6C3BF5DEA0732D86");

            entity.ToTable("tblRooms");

            entity.Property(e => e.RoomId).HasColumnName("roomID");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Equipment)
                .HasColumnType("text")
                .HasColumnName("equipment");
            entity.Property(e => e.RoomName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("room_name");
        });

        modelBuilder.Entity<TblSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__tblSched__A532EDB41DF8AFE5");

            entity.ToTable("tblSchedules");

            entity.Property(e => e.ScheduleId).HasColumnName("scheduleID");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(100)
                .HasColumnName("day_of_week");
            entity.Property(e => e.Describe)
                .HasColumnType("text")
                .HasColumnName("describe");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.RoomId).HasColumnName("roomID");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.TrainerId).HasColumnName("trainerID");

            entity.HasOne(d => d.Room).WithMany(p => p.TblSchedules)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__tblSchedu__roomI__5629CD9C");

            entity.HasOne(d => d.Trainer).WithMany(p => p.TblSchedules)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK__tblSchedu__train__5535A963");
        });

        modelBuilder.Entity<TblService>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__tblServi__4550733FD0771762");

            entity.ToTable("tblServices");

            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            entity.Property(e => e.Describe)
                .HasColumnType("text")
                .HasColumnName("describe");
            entity.Property(e => e.ImageServices)
                .HasMaxLength(255)
                .HasColumnName("image_Services");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("service_name");
        });

        modelBuilder.Entity<TblTrainer>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK__tblTrain__3550F2A64FBA01DB");

            entity.ToTable("tblTrainers");

            entity.Property(e => e.TrainerId).HasColumnName("trainerID");
            entity.Property(e => e.Bio)
                .HasColumnType("text")
                .HasColumnName("bio");
            entity.Property(e => e.ContactInfo)
                .HasMaxLength(255)
                .HasColumnName("contact_info");
            entity.Property(e => e.Experience).HasColumnName("experience");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.ProfileImage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("profile_image");
            entity.Property(e => e.Specialization)
                .HasMaxLength(255)
                .HasColumnName("specialization");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
