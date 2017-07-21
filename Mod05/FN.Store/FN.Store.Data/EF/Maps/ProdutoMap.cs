﻿using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Data.EF.Maps
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            //Table
            ToTable("Produto");

            //PK
            HasKey(pk => pk.Id);
            //Chave Composta
            //HasKey(pk => new { pk.Id, pk.Nome });

            //Campos
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nome).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(c => c.Preco).HasColumnType("money");
        }
    }
}
