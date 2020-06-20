using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlSoftV1._3.Clases;
using ControlSoftV1._3.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControlSoftV1._3.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("api/Categoria/listarCategoria")]
        public IEnumerable<CategoriaCLS> ListarCategorias()
        {
            using (var db = new BDRestauranteContext())
            {
                List<CategoriaCLS> listaCategoria = (from categoria in db.Categoria
                                                    where categoria.Bhabilitado == 1
                                                    select new CategoriaCLS {
                                                        IdCategoria = categoria.Iidcategoria,
                                                        Nombre = categoria.Nombre
                                                    }).ToList();
                return listaCategoria;
            }
        }
    }
}