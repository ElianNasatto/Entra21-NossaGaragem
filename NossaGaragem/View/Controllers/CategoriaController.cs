﻿using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        private CategoriaRepository repository;

        //Construtor tem como objetivo inicializa objetos ou tipos primitivos para o funcionamento da classe
        //Sempre é executado o contrutor ao instanciar um objeto da class
        public CategoriaController()
        {
            repository = new CategoriaRepository();
        }

        public ActionResult Index()
        {
            List<Categoria> lista = repository.ObterTodos();
            ViewBag.Categorias = lista;
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Alterar(int id)
        {
            Categoria categoria = repository.ObterPeloId(id);
            ViewBag.Categoria = categoria;
            return View();
        }

        public ActionResult Update(int id,string nome)
        {
            Categoria categoria = new Categoria();
            categoria.Id = (id);
            categoria.Nome = nome;
            repository.Alterar(categoria);
            return RedirectToAction("Index");
        }
        
        public ActionResult Store(string nome)
        {
            Categoria categoria = new Categoria();
            categoria.Nome = nome;
            repository.Inserir(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repository.Deletar(id);
            return RedirectToAction("Index");
        }
    }
}