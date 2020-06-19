using System;
using System.Linq;
using System.Collections.Generic;
using WebCode.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebCode.Models
{
    public class Demanda
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataType (DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]      
        public DateTime Data { get; set; }

        public virtual Origem Origem { get; set; }
        [Display(Name = "Origem")]        
        public int OrigemId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Tipo")]        
        public TipoDemanda TipoDemanda { get; set; }

        [Display(Name = "Processo Origem")]
        public string ProcessoOrigem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Número Proa")]
        public string NumeroProa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Data Inicial")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]        
        public DateTime DataInicial { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Prazo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Data Final")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]        
        public DateTime DataFinal { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public StatusDemanda Status { get; set; }
        public ICollection<Atividade> Atividades { get; set; } = new List<Atividade>();
        
        public Demanda()
        {
        }

        public Demanda(int id, string numero, DateTime data, Origem origem, TipoDemanda tipoDemanda, string processoOrigem, string descricao, string numeroProa, DateTime dataInicial, int prazo, DateTime dataFinal, StatusDemanda status)
        {
            Id = id;
            Numero = numero;
            Data = data;
            Origem = origem;
            TipoDemanda = tipoDemanda;
            ProcessoOrigem = processoOrigem;
            Descricao = descricao;
            NumeroProa = numeroProa;
            DataInicial = dataInicial;
            Prazo = prazo;
            DataFinal = dataFinal;
            Status = status;
        }

        public void AddAtividades(Atividade ar)
        {
            Atividades.Add(ar);
        }
        
        public void RemoveAtividades(Atividade ar)
        {
            Atividades.Remove(ar);
        }         

    }   
}
