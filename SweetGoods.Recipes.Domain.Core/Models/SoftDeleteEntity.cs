using System;
using System.Collections.Generic;
using System.Text;

namespace SweetGoods.Recipes.Domain.Core.Models
{
    public class SoftDeleteEntity : Entity
    {
        public bool SoftDeleted { get; set; }
    }
}