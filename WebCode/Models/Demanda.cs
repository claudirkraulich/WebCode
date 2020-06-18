using System;
using System.Linq;
using System.Collections.Generic;
using WebCode.Models.Enums;

namespace WebCode.Models
{
    public class Demanda
    {

        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public virtual Origem Origem { get; set; }
        public int OrigemId { get; set; }
        public TipoDemanda TipoDemanda { get; set; }
        public string ProcessoOrigem { get; set; }
        public string Descricao { get; set; }
        public string NumeroProa { get; set; }
        public DateTime DataInicial { get; set; }
        public int Prazo { get; set; }
        public DateTime DataFinal { get; set; }
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
