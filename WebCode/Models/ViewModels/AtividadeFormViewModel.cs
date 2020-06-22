using System.Collections.Generic;

namespace WebCode.Models.ViewModels
{
    public class AtividadeFormViewModel
    {
        public Atividade Atividade { get; set; }
        public ICollection<Demanda> Demandas { get; set; }

    }
}