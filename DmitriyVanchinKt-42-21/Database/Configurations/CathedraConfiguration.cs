using DmitriyVanchinKt_42_21.Database.Helpers;
using DmitriyVanchinKt_42_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DmitriyVanchinKt_42_21.Database.Configurations
{
    public class CathedraConfiguration : IEntityTypeConfiguration<Cathedra>
    {
        //название таблицы, которое будет отображаться в БД
        private const string TableName = "cd_cathedra";
        public void Configure(EntityTypeBuilder<Cathedra> builder)
        {
            //задаем первичный ключ
            builder
                .HasKey(p => p.CathedraId)
                .HasName($"pk_{TableName}_cathedra_id");
            //Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.CathedraId)
                .ValueGeneratedOnAdd();
            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.CathedraId)
                .ValueGeneratedOnAdd()
                .HasColumnName("cathedra_id")
                .HasComment("Идентификатор записи кафедры");
            //HasComment добавит комментарий, который будет отображаться в СУБД (добавлять по желанию)
            builder.Property(p => p.CathedraName)
                .IsRequired()
                .HasColumnName("c_cathedra_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название кафедры");

            //
            //Связь с заведующим кафедрой(один преподаватель является заведующим кафедры)
            builder.ToTable(TableName)
                .Property(p => p.HeadLecturerId)
                .HasColumnName("head_lecturer_id")
                .HasComment("Идентификатор заведующего кафедрой");
            // Связь с преподавателем-заведующим
            builder.ToTable(TableName)
                .HasOne(p => p.HeadLecturer)
                .WithOne() // Заведующий кафедрой не будет иметь коллекцию кафедр
                .HasForeignKey<Cathedra>(p =>p.HeadLecturerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_cathedra_head_lecturer_id");  // Заведующий кафедрой
        }
    }
}
