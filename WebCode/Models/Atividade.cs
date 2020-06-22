using System;
using System.ComponentModel.DataAnnotations;
using WebCode.Models.Enums;

namespace WebCode.Models
{
    public class Atividade
    {
        public int Id { get; set; }

        public virtual Demanda Demanda { get; set; }
        [Display(Name = "Demanda")]
        public int DemandaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Ação")]
        public string Acao { get; set; }

        [Display(Name = "Número Proa")]
        public string NumeroProa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]       
        public string Setor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Responsável")]
        public string Responsavel { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Data Inicial")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicial { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Prazo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Tipo Prazo")]
        public string TipoPrazo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Data Final")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFinal { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public StatusAtividade Status { get; set; }


        public Atividade()
        {
        }

        public Atividade(int id, string acao, string numeroProa, string setor, string responsavel, DateTime dataInicial, int prazo, string tipoPrazo, DateTime dataFinal, StatusAtividade status, Demanda demanda)
        {
            Id = id;
            Acao = acao;
            NumeroProa = numeroProa;
            Setor = setor;
            Responsavel = responsavel;
            DataInicial = dataInicial;
            Prazo = prazo;
            TipoPrazo = tipoPrazo;
            DataFinal = dataFinal;
            Status = status;
            Demanda = demanda;
        }
    }
}
