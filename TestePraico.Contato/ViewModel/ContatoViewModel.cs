using ENT;
using NEG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestePraico.Contato.ViewModel
{
    public class ContatoViewModel
    {
        public eContato Contato { get; set; }
        public IEnumerable<eContato> List { get; set; }
        public string MensagemAlerta { get; set; }

        public ContatoViewModel(string mensagem)
        {
            Contato = new eContato();
            List = new List<eContato>();
            MensagemAlerta = mensagem;
        }

        public ContatoViewModel()
        {

        }

        public void CarregarList()
        {
            List = nContato.Get();
        }
    }
}