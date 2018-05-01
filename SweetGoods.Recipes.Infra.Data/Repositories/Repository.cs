using Microsoft.EntityFrameworkCore;
using SweetGoods.Recipes.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SweetGoods.Recipes.Domain.Interfaces;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> where TEntity : class
    {
        protected readonly IQueryRepository<TEntity> queryRepository;
        protected readonly ICommandRepository<TEntity> commandRepository;

        public Repository(IQueryRepository<TEntity> queryRepository, ICommandRepository<TEntity> commandRepository)
        {
            this.queryRepository = queryRepository;
            this.commandRepository = commandRepository;
        }
    }
}