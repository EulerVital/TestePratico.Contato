using ENT;
using NEG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestePraico.Contato.ViewModel;

namespace TestePraico.Contato.Controllers
{
    public class ContatoController : Controller
    {
        // GET: Contato
        public ActionResult Index(string mensagem)
        {
            var viewModel = new ContatoViewModel(mensagem);
            viewModel.CarregarList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ContatoViewModel viewModel)
        {
            if (nContato.Set(viewModel.Contato) > 0)
                return RedirectToAction("Index", new { mensagem = "Contato adicionado com sucesso" });
            else
            {
                viewModel.MensagemAlerta = "Erro ao tentar cadastrar contato.";
                viewModel.CarregarList();
                return View(viewModel);
            }
        }

        public ActionResult Excluir(int id)
        {
            nContato.Del(id);
            return RedirectToAction("Index");
        }
    }
}