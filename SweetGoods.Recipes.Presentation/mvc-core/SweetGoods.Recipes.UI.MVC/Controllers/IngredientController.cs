using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SweetGoods.Recipes.UI.MVC.ViewModels;

namespace SweetGoods.Recipes.UI.MVC.Controllers
{
    public class IngredientController : Controller
    {
        public IActionResult Index()
        {
            var model = new IngredienteViewModel()
            {
                Id = 0,
                Nome = "Ingrediente",
                Quantidade = 2
            };

            return View(model);
        }

        public IActionResult Cadastro(IngredienteViewModel model)
        {
            model.Id = 10;

            return new JsonResult(model);
        }
    }
}