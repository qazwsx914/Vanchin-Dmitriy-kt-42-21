using DmitriyVanchinKt_42_21.Database.Helpers;
using DmitriyVanchinKt_42_21.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DmitriyVanchinKt_42_21.Database.Configurations
{
    public class LoadConfiguration : IEntityTypeConfiguration<Load>
    {
        //название таблицы, которое будет отображаться в БД
        private const string TableName = "cd_load";
        public void Configure(EntityTypeBuilder<Load> builder)
        {
            //Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.LoadId)
                .ValueGeneratedOnAdd();
            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.LoadId)
                .HasColumnName("LoadId")
                .HasComment("Идентификатор записи нагрузки");
            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.OpeningHours)
                .HasColumnName("OpeningHours")
                .HasComment("Часы работы");

            //
            builder.HasOne(p => p.Discipline)
               .WithMany()
               .HasForeignKey(p => p.DisciplineId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Lecturer)
               .WithMany()
               .HasForeignKey(p => p.LecturerId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
