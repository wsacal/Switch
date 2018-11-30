﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Infra.Data.Config
{
    public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
    {

        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(g => g.Nome).IsRequired().HasMaxLength(100);
            builder.Property(g => g.Descricao).IsRequired().HasMaxLength(400);
            builder.Property(g => g.UrlFoto).IsRequired().HasMaxLength(1000);
            builder.HasMany(g => g.Postagens).WithOne(p => p.Grupo);
        }
    }
}
