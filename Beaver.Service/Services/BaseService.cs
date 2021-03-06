﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Beaver.Service.Data;
using Beaver.Service.Data.Entities;
using Beaver.Service.Models.ResultModels;
using Beaver.Service.Resources;
using Beaver.Service.Utilities.Models;

namespace Beaver.Service.Services
{
    internal class BaseService<TEntity> where TEntity : BaseEntity
    {
        protected BeaverContext Context;

        public BaseService(BeaverContext context)
        {
            Context = context;
        }


        public virtual OperationResult Insert(TEntity item)
        {
            Context.Entry(item).State = EntityState.Added;
            return OperationResult.Success;
        }

        public virtual OperationResult InsertRange(ICollection<TEntity> items)
        {
            Context.Set<TEntity>().AddRange(items);
            return OperationResult.Success;
        }

        public virtual OperationResult Update(TEntity item)
        {
            Context.Entry(item).State = EntityState.Modified;
            return OperationResult.Success;
        }

        public virtual OperationResult UpdateRange(ICollection<TEntity> items)
        {
            foreach (var item in items)
            {
                Context.Entry(item).State = EntityState.Modified;
            }
            return OperationResult.Success;
        }

        public virtual OperationResult Delete(TEntity item)
        {
            Context.Entry(item).State = EntityState.Deleted;
            return OperationResult.Success;
        }

        public virtual OperationResult Delete(Guid id)
        {
            var item = FindById(id);
            if (item == null)
            {
                return OperationResult.Failed(ErrorMessages.Services_General_ItemNotFound);
            }

            Delete(item);
            return OperationResult.Success;
        }

        public virtual OperationResult Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var item = Get(predicate);
            return item == null
                ? OperationResult.Failed(ErrorMessages.Services_General_ItemNotFound)
                : Delete(item);
        }

        public virtual OperationResult DeleteRange(ICollection<TEntity> items)
        {
            foreach (var item in items)
            {
                Context.Entry(item).State = EntityState.Deleted;
            }
            return OperationResult.Success;
        }

        public virtual OperationResult DeleteRange(Expression<Func<TEntity, bool>> predicate)
        {
            var items = Search(predicate);
            return items == null
                ? OperationResult.Failed(ErrorMessages.Services_General_ItemNotFound)
                : DeleteRange(items.ToList());
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Context.Set<TEntity>().FirstOrDefault(predicate);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual TEntity FindById(Guid id)
        {
            return Get(x => x.Id == id);
        }

        public virtual async Task<TEntity> FindByIdAsync(Guid id)
        {
            return await GetAsync(x => x.Id == id);
        }

        public virtual IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Context.Set<TEntity>().Where(predicate);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual int? Count(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Context.Set<TEntity>().Count(predicate);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<int?> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await Context.Set<TEntity>().CountAsync(predicate);
            }
            catch (Exception)
            {
                return null;
            }
        }


        protected bool ValidateModel<T>(T model)
        {
            var vc = new ValidationContext(model, null, null);
            return Validator.TryValidateObject(model, vc, null, true);
        }

        protected Cluster<TEntity> Search<TOrderingKey>(Expression<Func<TEntity, bool>> expression, Ordering<TEntity, TOrderingKey> ordering)
        {
            var result = Search(expression);
            if (result == null)
                return null;

            var rvalue = new Cluster<TEntity>();
            try
            {
                if (ordering.IsAscending)
                {
                    rvalue.List =
                        result.OrderBy(ordering.OrderByKeySelector)
                            .Skip(ordering.Skip)
                            .Take(ordering.Take)
                            .ToList();
                }
                else
                {
                    rvalue.List =
                        result.OrderByDescending(ordering.OrderByKeySelector)
                            .Skip(ordering.Skip)
                            .Take(ordering.Take)
                            .ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }


            var count = Count(expression);
            if (count == null)
                return null;
            rvalue.CountAll = count.Value;
            return rvalue;
        }

        protected ICollection<T> ExceptById<T>(ICollection<T> collection, ICollection<T> with) where T : BaseEntity
        {
            return collection.Where(x => with.All(b => x.Id != b.Id)).ToList();
        }

        protected ICollection<T> AllyById<T>(ICollection<T> collection, ICollection<T> with) where T : BaseEntity
        {
            return collection.Where(x => with.Any(b => x.Id == b.Id)).ToList();
        }
    }
}
