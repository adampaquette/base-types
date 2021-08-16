﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.Threading.Tasks;

namespace AD.BaseTypes.ModelBinders
{
    public class BaseTypeModelBinder<TBaseType, TWrapped> : IModelBinder where TBaseType : IBaseType<TWrapped>
    {
        static readonly TypeConverter converter;

        static BaseTypeModelBinder()
        {
            converter = TypeDescriptor.GetConverter(typeof(TWrapped));
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var fieldName = bindingContext.FieldName;
            var providerResult = bindingContext.ValueProvider.GetValue(fieldName);
            if (providerResult == ValueProviderResult.None) return Task.CompletedTask;

            var value = converter.ConvertFrom(null, providerResult.Culture, providerResult.FirstValue);
            if (value is not null)
            {
                if (BaseType<TBaseType, TWrapped>.TryCreate((TWrapped)value, out var baseType, out var errorMessage))
                {
                    bindingContext.Result = ModelBindingResult.Success(baseType);
                }
                else
                {
                    bindingContext.ModelState.TryAddModelError(fieldName, errorMessage);
                }
            }
            return Task.CompletedTask;
        }
    }
}