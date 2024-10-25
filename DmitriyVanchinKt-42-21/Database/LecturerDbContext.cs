﻿using dmitriyVanchinKt_42_21.Database.Configurations;
using dmitriyVanchinKt_42_21.Models;
using Microsoft.EntityFrameworkCore;

namespace dmitriyVanchinKt_42_21.Database
{
    public class LecturerDbContext : DbContext
    {
        //Добавляем таблицы
        DbSet<Lecturer> Lecturers { get; set; }
        DbSet<Cathedra> Cathedras { get; set; }
        DbSet<Discipline> Disciplines { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new LecturerConfiguration());
            modelBuilder.ApplyConfiguration(new CathedraConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
        }
        public LecturerDbContext(DbContextOptions<LecturerDbContext> options) : base(options)
        {
        }
    }
}