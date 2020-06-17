using System;
using WebCode.Models.Enums;

namespace WebCode.Models
{
    public class Atividade
    {
        public int Id { get; set; }
        public string Acao { get; set; }
        public string NumeroProa { get; set; }
        public string Setor { get; set; }
        public string Responsavel { get; set; }
        public DateTime DataInicial { get; set; }
        public int Prazo { get; set; }
        public string TipoPrazo { get; set; }
        public DateTime DataFinal { get; set; }
        public StatusAtividade Status { get; set; }
        public Demanda Demanda { get; set; }

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
