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
using Fabrica.Mascaras.Web.ViewModels.Mascara;
using Fabrica.Mascaras.Web.ViewModels.Tecido;

namespace Fabrica.Mascaras.Web.Controllers
{
    [Authorize]
    public class MascarasController : Controller
    {
        private IRepositorioGenerico<Mascara, long>
            repositorioMascaras = new MascarasRepositorio(new MascaraDbContext());

        private IRepositorioGenerico<Tecido, int>
            repositorioTecidos = new TecidosRepositorio(new MascaraDbContext());

        // GET: Mascaras
        public ActionResult Index()
        {
            //var mascaras = db.Mascaras.Include(m => m.Tecido);
            return View(Mapper.Map<List<Mascara>,
                        List<MascaraIndexViewModels>>(repositorioMascaras.Selecionar()));
        }

        // GET: Mascaras/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascara mascara = repositorioMascaras.SelecionarPorId(id.Value);
            if (mascara == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Mascara, MascaraIndexViewModels>(mascara));
        }

        // GET: Mascaras/Create
        public ActionResult Create()
        {
            //ViewBag.IdTecido = new SelectList(db.Tecidos, "Id", "Tipo");
            List<TecidoIndexViewModel> tecidos = Mapper.Map<List<Tecido>,
                List<TecidoIndexViewModel>>(repositorioTecidos.Selecionar());

            SelectList dropDownTecidos = new SelectList(tecidos, "id", "Tipo");
            ViewBag.DropDownTecidos = dropDownTecidos;
            return View();
        }

        // POST: Mascaras/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMascara,NomeMascara,Cor,Tamanho,IdTecido,Ano")] MascaraViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Mascara mascara = Mapper.Map<MascaraViewModel, Mascara>(viewModel);
                repositorioMascaras.Inserir(mascara);
                return RedirectToAction("Index");
            }

            //ViewBag.IdTecido = new SelectList(db.Tecidos, "Id", "Tipo", mascara.IdTecido);
            return View(viewModel);
        }

        // GET: Mascaras/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascara mascara = repositorioMascaras.SelecionarPorId(id.Value);
            if (mascara == null)
            {
                return HttpNotFound();
            }
            //ViewBag.IdTecido = new SelectList(db.Tecidos, "Id", "Tipo", mascara.IdTecido);
            List<TecidoIndexViewModel> tecidos = Mapper.Map<List<Tecido>,
                List<TecidoIndexViewModel>>(repositorioTecidos.Selecionar());

            SelectList dropDownTecidos = new SelectList(tecidos, "id", "Tipo");
            ViewBag.DropDownTecidos = dropDownTecidos;
            return View(Mapper.Map<Mascara, MascaraViewModel>(mascara));
        }

        // POST: Mascaras/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMascara,NomeMascara,Cor,Tamanho,IdTecido,Ano")] MascaraViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Mascara mascara = Mapper.Map<MascaraViewModel, Mascara>(viewModel);
                repositorioMascaras.Alterar(mascara);
                return RedirectToAction("Index");
            }
            //ViewBag.IdTecido = new SelectList(db.Tecidos, "Id", "Tipo", mascara.IdTecido);
            return View(viewModel);
        }

        // GET: Mascaras/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascara mascara = repositorioMascaras.SelecionarPorId(id.Value);
            if (mascara == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Mascara, MascaraIndexViewModels>(mascara));
        }

        // POST: Mascaras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            repositorioMascaras.ExcluirPorId(id);
            return RedirectToAction("Index");
        }

        
    }
}
