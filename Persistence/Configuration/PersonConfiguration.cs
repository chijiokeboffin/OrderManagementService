using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    internal sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(nameof(Person));
            builder.HasKey(person => person.Id);
            builder.Property(person => person.Id).ValueGeneratedOnAdd();
            builder.Property(person => person.Email).IsRequired();
            builder.Property(person => person.Email).HasMaxLength(100);
            builder.HasIndex((Person person) => person.Email).IsUnique();          
        }
    }
}
