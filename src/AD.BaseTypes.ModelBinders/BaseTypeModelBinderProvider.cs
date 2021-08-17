﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Reflection;

namespace AD.BaseTypes.ModelBinders
{
    /// <summary>
    /// Provides model binders for base types.
    /// </summary>
    public class BaseTypeModelBinderProvider : IModelBinderProvider
    {
        /// <inheritdoc/>
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            var baseType = context.Metadata.ModelType;
            var iBaseType = GetBaseTypeInterface(baseType);
            if (iBaseType is null) return null!;

            var wrapped = iBaseType.GenericTypeArguments[0];
            return new BinderTypeModelBinder(typeof(BaseTypeModelBinder<,>).MakeGenericType(baseType, wrapped));
        }

        static Type? GetBaseTypeInterface(Type baseType)
        {
            try
            {
                return baseType.GetInterface(typeof(IBaseType<>).Name);
            }
            catch (AmbiguousMatchException)
            {
                return default;
            }
        }
    }
}
