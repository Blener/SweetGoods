using SweetGoods.Recipes.Domain.Core.Commands;
using SweetGoods.Recipes.Domain.Interfaces;
using SweetGoods.Recipes.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweetGoods.Recipes.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SweetGoodsRecipesContext _context;

        public UnitOfWork(SweetGoodsRecipesContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}