using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SweetGoods.Recipes.UI.MVC.ViewModels;

namespace SweetGoods.Recipes.UI.MVC.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult Index()
        {
            var receita = new ReceitaViewModel()
            {
                Descrição = "Receita do backend",
                Nome = "Backend",
                Id = 0
            };

            return View(receita);
        }

        public IActionResult Cadastro(ReceitaViewModel model)
        {
            model.Id = 10;

            return new JsonResult(model);
        }
    }
}