﻿using ClassLibrary1;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.PetShop.Orm.Repositories
{
    public interface IEntityRepo<TEntity>
    {
        IList<TEntity>GetAll();
        TEntity GetById(int id);

        void Add(TEntity entity);

        void Update(int id, TEntity entity);

        void Delete(int id);
    }
}
