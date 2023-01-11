using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TISelvagem.Aplicacao;
using TiSelvagem.Dominio;

namespace TISelvagem.UI.web.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Index()
        {
            var appAluno = new AlunoAplicacao();
            var listaDeAlunos = appAluno.ListarTodos();
            return View(listaDeAlunos);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var appAluno = new AlunoAplicacao();
                appAluno.Salvar(aluno);
                return RedirectToAction("index");
            }
            return View(aluno);
        }

        public ActionResult Editar(int id)
        {
            var appAluno = new AlunoAplicacao();
            var aluno = appAluno.ListarPorId(id);

            if (aluno == null)
                return HttpNotFound();

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var appAluno = new AlunoAplicacao();
                appAluno.Salvar(aluno);
                return RedirectToAction("index");
            }
            return View(aluno);
        }

        public ActionResult Detalhes(int Id)
        {
            var appAluno = new AlunoAplicacao();
            var aluno = appAluno.ListarPorId(Id);

            if (aluno == null)
                return HttpNotFound();

            return View(aluno);
        }

        public ActionResult Excluir(int Id)
        {
            var appAluno = new AlunoAplicacao();
            var aluno = appAluno.ListarPorId(Id);

            if (aluno == null)
                return HttpNotFound();

            return View(aluno);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int Id)
        {
            var appAluno = new AlunoAplicacao();
            appAluno.Excluir(Id);
            return RedirectToAction("Index");
        }
    }

    
}