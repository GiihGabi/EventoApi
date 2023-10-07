﻿using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.GeralContext
{
    public class Eventos
    {
        [Key]
        public int IdEventos { get; set; }
        public string NomeEvento { get; set; }

        public string Descricao { get; set; }

        public float ValorIngresso { get; set; }

        public string LocalEvento { get; set; }

        public DateTime DataEvento { get; set; }

        public int QtdLimiteIngresso { get; set; }

        public bool Ativo { get; set; }
        public IList<Comprador>? Compradores { get; set; }
    }
}
