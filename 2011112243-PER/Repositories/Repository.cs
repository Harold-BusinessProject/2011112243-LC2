﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _2011112243;

namespace MovieStore.Persistence.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private readonly DbContext _Context;

		protected Repository()
		{

		}

		public Repository(DbContext context)
		{
			_Context = context;
		}

		void IRepository<TEntity>.Add(TEntity entity)
		{
			
		}

		void IRepository<TEntity>.AddRange(IEnumerable<TEntity> entities)
		{
			
		}

		IEnumerable<TEntity> IRepository<TEntity>.Find(Expression<Func<TEntity, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		TEntity IRepository<TEntity>.Get(int? id)
		{
			throw new NotImplementedException();
		}

		IEnumerable<TEntity> IRepository<TEntity>.GetAll()
		{
			throw new NotImplementedException();
		}

		void IRepository<TEntity>.Remove(TEntity entity)
		{
			
		}

		void IRepository<TEntity>.RemoveRange(IEnumerable<TEntity> entities)
		{
			
		}

		void IRepository<TEntity>.Update(TEntity entity)
		{
			
		}

		void IRepository<TEntity>.UpdateRange(IEnumerable<TEntity> entities)
		{
			
		}
	}
}
