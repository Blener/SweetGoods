using SweetGoods.Recipes.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SweetGoods.Recipes.Infra.Data.Context
{
    public class SweetGoodsRecipesContext : ContextBase<SweetGoodsRecipesContext>
    {
        public SweetGoodsRecipesContext(DbContextOptions<SweetGoodsRecipesContext> options) : base(options)
        {
        }
    }
}