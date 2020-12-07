using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Fabrica.Mascaras.Dados.Entity.Context;
using Fabrica.Mascaras.Dominio;
using Fabrica.Mascaras.Repositorios.Comum;
using Fabrica.Mascaras.Repositorios.Entity;
using Fabrica.Mascaras.Web.Filtros;
using Fabrica.Mascaras.Web.ViewModels.Tecido;

namespace Fabrica.Mascaras.Web.Controllers
{
    [Authorize]
    public class TecidosController : Controller
    {
        private IRepositorioGenerico<Tecido, int>
            repositorioTecidos = new TecidosRepositorio(new MascaraDbContext());

        // GET: Tecidos

        [LogActionFilter]
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Tecido>, List<TecidoIndexViewModel>>(repositorioTecidos.Selecionar()));
        }

        public ActionResult FiltrarPorNome(string pesquisa)
        {
            List<Tecido> tecidos = repositorioTecidos
                .Selecionar()
                .Where(t => t.Tipo.Contains(pesquisa)).ToList();
            List<TecidoIndexViewModel> viewModels = Mapper
                .Map<List<Tecido>, List<TecidoIndexViewModel>>(tecidos);

            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }

        // GET: Tecidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecido tecido = repositorioTecidos.SelecionarPorId(id.Value);
            if (tecido == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Tecido, TecidoIndexViewModel>(tecido));
        }

        // GET: Tecidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tecidos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo,Composicao,Caracteristica,Fornecedor,Email")] TecidoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Tecido tecido = Mapper.Map<TecidoViewModel, Tecido>(viewModel);
                repositorioTecidos.Inserir(tecido);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Tecidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecido tecido = repositorioTecidos.SelecionarPorId(id.Value);
            if (tecido == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Tecido, TecidoIndexViewModel>(tecido));
        }

        // POST: Tecidos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo,Composicao,Caracteristica,Fornecedor,Email")] TecidoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Tecido tecido = Mapper.Map<TecidoViewModel, Tecido>(viewModel);
                repositorioTecidos.Alterar(tecido);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Tecidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecido tecido = repositorioTecidos.SelecionarPorId(id.Value);
            if (tecido == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Tecido, TecidoIndexViewModel>(tecido));
        }

        // POST: Tecidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositorioTecidos.ExcluirPorId(id);
            return RedirectToAction("Index");
        }

    }
}
