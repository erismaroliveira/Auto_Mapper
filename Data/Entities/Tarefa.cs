﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Tarefa")]
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [NotMapped]
        public List<ItemTarefa> ItensTarefa { get; set; }
    }
}
