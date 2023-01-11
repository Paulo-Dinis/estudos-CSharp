using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Schema;
using Ecommerce.Aplicacao;
using Ecommerce.Dominio;

namespace Ecommerce.UI.Web.Controllers
{
    public class OfertasController : Controller
    {
        // GET: Ofertas
        public ActionResult Ofertas()
        {
            var appProduto = new EcommerceAplicacao();
            var listaDeProdutos = appProduto.ListarTodos();
            return View(listaDeProdutos);
        }

        public ActionResult ComprarProduto(int id)
        {
            var appProduto = new EcommerceAplicacao();
            var produto = appProduto.ListarPorId(id);
            return View(produto);
        }

        
        public ActionResult Carrinho(int id)
        {
            var appProduto = new EcommerceAplicacao();
            appProduto.Carrinho(id);
            return RedirectToAction("RetornarCarrinho");
        }

        public ActionResult RetornarCarrinho(Produto produto)
        {
            var appProduto = new EcommerceAplicacao();
            var carrinho = appProduto.ListarCarrinho();
            return View(carrinho);
        }

        public ActionResult ExcluirDoCarrinho(int id)
        {
            var appProduto = new EcommerceAplicacao();
            appProduto.ExcluirDoCarrinho(id);
            return RedirectToAction("RetornarCarrinho");
        }

        public ActionResult FinalizarCompra()
        {
            var appProduto = new EcommerceAplicacao();
            appProduto.LimparCarrinho();
            return RedirectToAction("Ofertas");
        }
    }
}