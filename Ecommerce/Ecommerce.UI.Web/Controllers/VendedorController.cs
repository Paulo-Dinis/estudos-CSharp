using System;
using System.Linq;
using System.Web.Mvc;
using Ecommerce.Aplicacao;
using Ecommerce.Dominio;

namespace Ecommerce.UI.Web.Controllers
{
    public class VendedorController : Controller
    {
        // GET: Vendedor
        public ActionResult Vendedor()
        {
            var appProduto = new EcommerceAplicacao();
            var listaDeProdutos = appProduto.ListarTodos();
            return View(listaDeProdutos);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Produto produto) 
        {

            if (ModelState.IsValid)
            {
                var appProduto = new EcommerceAplicacao();
                appProduto.Salvar(produto);
                return RedirectToAction("Ofertas", "Ofertas");
            }
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var appProduto = new EcommerceAplicacao();
                appProduto.Salvar(produto);
                return RedirectToAction("Vendedor", "Vendedor");
            }
            return View(produto);
        }

        public ActionResult Editar(int id)
        {
            var appProduto = new EcommerceAplicacao();
            var produto = appProduto.ListarPorId(id);

            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }

        public ActionResult Excluir(int id)
        {
            var appProduto = new EcommerceAplicacao();
            var produto = appProduto.ListarPorId(id);

            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }

        public ActionResult ExcluirConfirma(int id)
        {
            var appProduto = new EcommerceAplicacao();
            appProduto.Excluir(id);
            return RedirectToAction("Vendedor");
        }

    }
}