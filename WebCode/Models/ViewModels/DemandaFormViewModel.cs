using System.Collections.Generic;

namespace WebCode.Models.ViewModels
{
    public class DemandaFormViewModel
    {
        public Demanda Demanda { get; set; }
        public ICollection<Origem> Origens { get; set; }

    }
}
