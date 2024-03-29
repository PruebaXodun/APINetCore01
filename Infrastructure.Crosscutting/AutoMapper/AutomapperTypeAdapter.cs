﻿using AutoMapper;
using Infrastructure.Crosscutting.Adapter;

namespace Infrastructure.Crosscutting.AutoMapper
{
    public class AutomapperTypeAdapter : ITypeAdapter
    {
        #region ITypeAdapter Members

        /// <summary>
        /// <see cref="ITypeAdapter"/>
        /// </summary>
        /// <typeparam name="TSource"><see cref="ITypeAdapter"/></typeparam>
        /// <typeparam name="TTarget"><see cref="ITypeAdapter"/></typeparam>
        /// <param name="source"><see cref="ITypeAdapter"/></param>
        /// <returns><see cref="ITypeAdapter"/></returns>
        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return Mapper.Map<TSource, TTarget>(source);
        }

        /// <summary>
        /// <see cref="ITypeAdapter"/>
        /// </summary>
        /// <typeparam name="TTarget"><see cref="ITypeAdapter"/></typeparam>
        /// <param name="source"><see cref="ITypeAdapter"/></param>
        /// <returns><see cref="ITypeAdapter"/></returns>
        public TTarget Adapt<TTarget>(object source) where TTarget : class, new()
        {
            return Mapper.Map<TTarget>(source);
        }

        #endregion ITypeAdapter Members
    }
}