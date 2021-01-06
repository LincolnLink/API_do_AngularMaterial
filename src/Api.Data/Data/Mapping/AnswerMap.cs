using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class AnswerMap : IEntityTypeConfiguration<Questions>
    {
        public void Configure(EntityTypeBuilder<Questions> builder)
        {
            //Definindo o nome da tabela
            builder.ToTable("Answer");

            //Definindo a chave primaria
            builder.HasKey(p => p.Id);

            //Criando um Index e Definindo como campo unico
            builder.HasIndex(p => p.Index)
                   .IsUnique();

            //Definindo como requirido e um tamanho maximo
            builder.Property(u => u.Text)
                   .IsRequired()
                   .HasMaxLength(60);

        }
    }
}
