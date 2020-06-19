using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebCode.Models
{
    public class Origem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }
        public ICollection<Demanda> Demandas { get; set; } = new List<Demanda>();

        public Origem()
        {
        }

        public Origem(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AddDemanda(Demanda demanda)
        {
            Demandas.Add(demanda);
        }
    }        
}
