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

    public virtual DbSet<TbMenu> TbMenus { get; set; }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    public virtual DbSet<TblComment> TblComments { get; set; }

    public virtual DbSet<TblEquipment> TblEquipments { get; set; }

    public virtual DbSet<TblInvoice> TblInvoices { get; set; }

    public virtual DbSet<TblInvoiceDetail> TblInvoiceDetails { get; set; }

    public virtual DbSet<TblMember> TblMembers { get; set; }

    public virtual DbSet<TblMemberPackage> TblMemberPackages { get; set; }

    public virtual DbSet<TblMemberService> TblMemberServices { get; set; }

    public virtual DbSet<TblPackage> TblPackages { get; set; }

    public virtual DbSet<TblRoom> TblRooms { get; set; }

    public virtual DbSet<TblSchedule> TblSchedules { get; set; }

    public virtual DbSet<TblService> TblServices { get; set; }

    public virtual DbSet<TblTrainer> TblTrainers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-R4TO9PD;Initial Catalog=QLGYM;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbMenu>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_Menu");

            entity.Property(e => e.Alias).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.MenuId).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__tblBlog__FA0AA70D399F788C");

            entity.ToTable("tblBlog");

            entity.Property(e => e.BlogId).HasColumnName("blogID");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.ImageBlog)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_Blog");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.TrainerId).HasColumnName("trainerID");

            entity.HasOne(d => d.Trainer).WithMany(p => p.TblBlogs)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK__tblBlog__trainer__05D8E0BE");
        });

        modelBuilder.Entity<TblComment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__tblComme__CDDE91BDB84304CB");

            entity.ToTable("tblComments");

            entity.Property(e => e.CommentId).HasColumnName("commentID");
            entity.Property(e => e.Comment)
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.MemberId).HasColumnName("memberID");
            entity.Property(e => e.ReplyTo).HasColumnName("reply_to");
            entity.Property(e => e.ServiceId).HasColumnName("serviceID");

            entity.HasOne(d => d.Member).WithMany(p => p.TblComments)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__tblCommen__membe__6754599E");

            entity.HasOne(d => d.Service).WithMany(p => p.TblComments)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__tblCommen__servi__68487DD7");
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
            entity.HasKey(e => e.InvoiceId).HasName("PK__tblInvoi__1252410C0DB18582");

            entity.ToTable("tblInvoices");

            entity.Property(e => e.InvoiceId).HasColumnName("invoiceID");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.InvoiceDate).HasColumnName("invoice_date");
            entity.Property(e => e.MemberId).HasColumnName("memberID");
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

            entity.HasOne(d => d.Member).WithMany(p => p.TblInvoices)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__tblInvoic__membe__619B8048");
        });

        modelBuilder.Entity<TblInvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId).HasName("PK__tblInvoi__830778398C71340B");

            entity.ToTable("tblInvoiceDetails");

            entity.Property(e => e.DetailId).HasColumnName("detailID");
            entity.Property(e => e.InvoiceId).HasColumnName("invoiceID");
            entity.Property(e => e.ItemName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("item_name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");

            entity.HasOne(d => d.Invoice).WithMany(p => p.TblInvoiceDetails)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK__tblInvoic__invoi__6477ECF3");
        });

        modelBuilder.Entity<TblMember>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__tblMembe__7FD7CFF68AA309CC");

            entity.ToTable("tblMembers");

            entity.Property(e => e.MemberId).HasColumnName("memberID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .HasColumnName("gender");
            entity.Property(e => e.JoinDate).HasColumnName("join_date");
            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasColumnName("last_login");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.ProfileImage)
                .HasMaxLength(255)
                .HasColumnName("profile_image");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasColumnName("role");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("username");
        });

        modelBuilder.Entity<TblMemberPackage>(entity =>
        {
            entity.HasKey(e => e.MemberPackageId).HasName("PK__tblMembe__8AD398804C418ABC");

            entity.ToTable("tblMemberPackages");

            entity.Property(e => e.MemberPackageId).HasColumnName("member_packageID");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.MemberId).HasColumnName("memberID");
            entity.Property(e => e.PackageId).HasColumnName("packageID");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.StatusMemberPackages).HasColumnName("status_MemberPackages");

            entity.HasOne(d => d.Member).WithMany(p => p.TblMemberPackages)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__tblMember__membe__4F7CD00D");

            entity.HasOne(d => d.Package).WithMany(p => p.TblMemberPackages)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK__tblMember__packa__5070F446");
        });

        modelBuilder.Entity<TblMemberService>(entity =>
        {
            entity.HasKey(e => e.ServiceRegistrationId).HasName("PK__tblMembe__F3599FF69250E598");

            entity.ToTable("tblMemberServices");

            entity.Property(e => e.ServiceRegistrationId).HasColumnName("service_registrationID");
            entity.Property(e => e.MemberId).HasColumnName("memberID");
            entity.Property(e => e.RegistrationDate).HasColumnName("Registration_date");
            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            entity.Property(e => e.StatusMemberServices)
                .HasMaxLength(100)
                .HasColumnName("status_MemberServices");

            entity.HasOne(d => d.Member).WithMany(p => p.TblMemberServices)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__tblMember__membe__5AEE82B9");

            entity.HasOne(d => d.Service).WithMany(p => p.TblMemberServices)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__tblMember__servi__5BE2A6F2");
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
            entity.Property(e => e.MemberId).HasColumnName("memberID");
            entity.Property(e => e.RoomId).HasColumnName("roomID");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.TrainerId).HasColumnName("trainerID");

            entity.HasOne(d => d.Member).WithMany(p => p.TblSchedules)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Schedule_Member");

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
