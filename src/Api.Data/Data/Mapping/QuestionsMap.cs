using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class QuestionsMap : IEntityTypeConfiguration<Questions>
    {
        public void Configure(EntityTypeBuilder<Questions> builder)
        {
            //Definindo o nome da tabela
            builder.ToTable("Questions");

            //Definindo a chave primaria
            builder.HasKey(p => p.Id);

            //Criando um Index e Definindo como campo unico
            builder.HasIndex(p => p.Index);

            //Definindo como requirido e um tamanho maximo
            builder.Property(u => u.Text)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property<Guid?>("ChapterId")
                .HasColumnType("uniqueidentifier");

            builder.Property("TypeQuestions");

            builder.HasIndex("ChapterId");

            builder.HasOne("Domain.Entities.Chapter", "Chapter")
                .WithMany("Questions")
                .HasForeignKey("ChapterId");

            builder.Navigation("Chapter");

        }
    }
}
