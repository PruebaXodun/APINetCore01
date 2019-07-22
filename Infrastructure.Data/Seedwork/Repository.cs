using Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Seedwork
{
    /// <summary>
    /// Repository base class
    /// </summary>
    /// <typeparam name="TEntity">The type of underlying entity in this repository</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        #region Members

        private IQueryableUnitOfWork _UnitOfWork;

        #endregion Members

        #region Constructor

        /// <summary>
        /// Create a new instance of repository
        /// </summary>
        /// <param name="unitOfWork">Associated Unit Of Work</param>
        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == (IUnitOfWork)null)
                throw new ArgumentNullException("unitOfWork");

            _UnitOfWork = unitOfWork;
        }

        #endregion Constructor

        #region IRepository Members

        /// <summary>
        /// <see cref="IRepository2{TEntity}"/>
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _UnitOfWork;
            }
        }

        /// <summary>
        /// <see cref="IRepository2{TEntity}"/>
        /// </summary>
        /// <param name="item"><see cref="IRepository2{TEntity}"/></param>
        public virtual void Add(TEntity item)
        {
            if (item != (TEntity)null)
                GetSet().Add(item); // add new item in this set
            else
            {
                //XENDOR
                //LoggerFactory.CreateLog()
                //          .LogInfo("Messages.info_CannotAddNullEntity", typeof(TEntity).ToString());
            }
        }

        /// <summary>
        /// <see cref="IRepository2{TEntity}"/>
        /// </summary>
        /// <param name="item"><see cref="IRepository2{TEntity}"/></param>
        public virtual void Remove(TEntity item)
        {
            if (item != (TEntity)null)
            {
                //attach item if not exist
                _UnitOfWork.Attach(item);

                //set as "removed"
                GetSet().Remove(item);
            }
            else
            {
                //XENDOR
                //LoggerFactory.CreateLog()
                //          .LogInfo("Messages.info_CannotRemoveNullEntity", typeof(TEntity).ToString());
            }
        }

        /// <summary>
        /// <see cref="IRepository2{TEntity}"/>
        /// </summary>
        /// <param name="item"><see cref="IRepository2{TEntity}"/></param>
        public virtual void TrackItem(TEntity item)
        {
            if (item != (TEntity)null)
                _UnitOfWork.Attach<TEntity>(item);
            else
            {
                //XENDOR
                //LoggerFactory.CreateLog()
                //          .LogInfo("Messages.info_CannotRemoveNullEntity", typeof(TEntity).ToString());
            }
        }

        /// <summary>
        /// <see cref="IRepository2{TEntity}"/>
        /// </summary>
        /// <param name="item"><see cref="IRepository2{TEntity}"/></param>
        public virtual void Modify(TEntity item)
        {
            if (item != (TEntity)null)
                _UnitOfWork.SetModified(item);
            else
            {
                //XENDOR
                //LoggerFactory.CreateLog()
                //          .LogInfo("Messages.info_CannotRemoveNullEntity", typeof(TEntity).ToString());
            }
        }

        /// <summary>
        /// <see cref="IRepository2{TEntity}"/>
        /// </summary>
        /// <param name="id"><see cref="IRepository2{TEntity}"/></param>
        /// <returns><see cref="IRepository2{TEntity}"/></returns>
        public virtual TEntity Get(object id)
        {
            return GetSet().Find(id);
        }

        /// <summary>
        /// <see cref="IRepository2{TEntity}"/>
        /// </summary>
        /// <returns><see cref="IRepository2{TEntity}"/></returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            return GetSet();
        }

        /// <summary>
        /// <see cref="IRepository2{TEntity}"/>
        /// </summary>
        /// <param name="specification"><see cref="IRepository2{TEntity}"/></param>
        /// <returns><see cref="IRepository2{TEntity}"/></returns>
        public virtual IEnumerable<TEntity> AllMatching(Domain.Seedwork.Specification.ISpecification<TEntity> specification)
        {
            return GetSet().Where(specification.SatisfiedBy());
        }

        /// <summary>
        /// <see cref="IRepository2{TEntity}"/>
        /// </summary>
        /// <typeparam name="S"><see cref="IRepository2{TEntity}"/></typeparam>
        /// <param name="pageIndex"><see cref="IRepository2{TEntity}"/></param>
        /// <param name="pageCount"><see cref="IRepository2{TEntity}"/></param>
        /// <param name="orderByExpression"><see cref="IRepository2{TEntity}"/></param>
        /// <param name="ascending"><see cref="IRepository2{TEntity}"/></param>
        /// <returns><see cref="IRepository2{TEntity}"/></returns>
        public virtual IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        {
            var set = GetSet();

            if (ascending)
            {
                return set.OrderBy(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
            else
            {
                return set.OrderByDescending(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
        }

        /// <summary>
        /// <see cref="IRepository2{TEntity}"/>
        /// </summary>
        /// <param name="filter"><see cref="IRepository2{TEntity}"/></param>
        /// <returns><see cref="IRepository2{TEntity}"/></returns>
        public virtual IEnumerable<TEntity> GetFiltered(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            return GetSet().Where(filter);
        }

        /// <summary>
        /// <see cref="IRepository2{TEntity}"/>
        /// </summary>
        /// <param name="persisted"><see cref="IRepository2{TEntity}"/></param>
        /// <param name="current"><see cref="IRepository2{TEntity}"/></param>
        public virtual void Merge(TEntity persisted, TEntity current)
        {
            _UnitOfWork.ApplyCurrentValues(persisted, current);
        }

        public virtual IEnumerable<TEntity> GetWithoutTrack(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return GetSet().AsNoTracking().Where(predicate);
        }

        #endregion IRepository Members

        #region IDisposable Members

        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            if (_UnitOfWork != null)
                _UnitOfWork.Dispose();
        }

        #endregion IDisposable Members

        #region Private Methods

        private DbSet<TEntity> GetSet()
        {
            return _UnitOfWork.CreateSet<TEntity>();
        }

        #endregion Private Methods
    }
}