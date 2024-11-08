using DmitriyVanchinKt_42_21.Database.Helpers;
using DmitriyVanchinKt_42_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DmitriyVanchinKt_42_21.Database.Configurations
{
    public class LecturerConfiguration : IEntityTypeConfiguration<Lecturer>
    {
        //название таблицы, которое будет отображаться в БД
        private const string TableName = "cd_lecturer";
        public void Configure(EntityTypeBuilder<Lecturer> builder)
        {
            //задаем первичный ключ
            builder
                .HasKey(p=>p.LecturerId)
                .HasName($"pk_{TableName}_lecturer_id");
            //Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.LecturerId)
                .ValueGeneratedOnAdd();
            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.LecturerId)
                .HasColumnName("lecturer_id")
                .HasComment("Идентификатор записи предподавателя");

            //Мой код
            //builder.Property(p => p.CathedraId)
            //    .HasColumnName("cathedra_id")
            //    .HasComment("Идентификатор кафедры");

            //HasComment добавит комментарий, который будет отображаться в СУБД (добавлять по желанию)
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_lecturer_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя предподавателя");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_lecturer_lactname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия предподавателя");

            builder.Property(p => p.MiddleName)
                .IsRequired()
                .HasColumnName("c_lecturer_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество предподавателя");

            //Связь между кафедрой и предподавателем
            builder.ToTable(TableName)
                .HasOne(p => p.Cathedra)
                .WithMany()
                .HasForeignKey(p => p.CathedraId)
                .HasConstraintName("fk_f_cathedra_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.CathedraId, $"idx_{TableName}_fk_f_cathedra_id");

            //Добавим явную автоподгрузку связанной сущности
            builder.Navigation(p => p.Cathedra)
                .AutoInclude();
            //builder.Navigation(p => p.Disciplines) 
            //    .AutoInclude();

            //
            builder.HasOne(p => p.Cathedra)
            .WithMany()
            .HasForeignKey(p => p.CathedraId)
            .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(p=>p.Disciplines)
            //   .WithMany()
            //   .HasForeignKey(p=>p.DisciplineId) 
            //   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
