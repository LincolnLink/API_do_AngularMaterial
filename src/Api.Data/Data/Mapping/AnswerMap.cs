
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Data.Mapping
{
    public class AnswerMap : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            //Definindo o nome da tabela
            builder.ToTable("Answer");

            //Definindo a chave primaria
            builder.HasKey(p => p.Id);

            //Criando um Index e Definindo como campo unico
            builder.HasIndex(p => p.Index);             

            //Definindo como requirido e um tamanho maximo
            builder.Property(u => u.Text)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property<Guid?>("QuestionsId")
                .HasColumnType("uniqueidentifier");

            builder.HasIndex("QuestionsId");

            builder.HasOne("Domain.Entities.Questions", "Questions")
                .WithMany("Answer")
                .HasForeignKey("QuestionsId");

            builder.Navigation("Questions");

        }
    }
}
