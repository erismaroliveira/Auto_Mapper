using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class ItemTarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }

        [ForeignKey("Tarefa")]
        [Column(Order = 1)]
        public int IdTarefa { get; set; }
        // public virtual Tarefa Tarefa { get; set; }
    }
}
