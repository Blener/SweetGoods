using AutoMapper;
using AutoMapper.QueryableExtensions;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Core.Models;
using SweetGoods.Recipes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Application.Services
{
    public abstract class AppQueryBaseService<TEntity, TViewModel> : IAppQueryBaseService<TViewModel> where TEntity : Entity where TViewModel : ViewModel
    {
        protected readonly IQueryRepository<TEntity> queryRepository;
        private readonly IMapper mapper;

        public AppQueryBaseService(IQueryRepository<TEntity> queryRepository, IMapper mapper)
        {
            this.queryRepository = queryRepository;
            this.mapper = mapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TViewModel> GetAll()
        {
            return queryRepository.GetAll().ProjectTo<TViewModel>();
        }

        public async Task<TViewModel> GetByAggregateId(Guid aggregateId)
        {
            return MapGetForReturn(await queryRepository.GetByAggregateId(aggregateId));
        }

        protected TViewModel MapGetForReturn(TEntity entity) => mapper.Map<TViewModel>(entity);
    }
}