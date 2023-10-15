﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace iBudget.Framework
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public CustomExceptionFilter(IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            var result = new ViewResult { ViewName = Constants.CustomErrorView };
            result.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);

            if (context.Exception is DbUpdateException dbUpdateException)
            {
                if (IsUniqueConstraintViolationException(dbUpdateException))
                {
                    result.ViewData.Add(Constants.ThrowDBException, Messages.UniqueDBMessage);
                }
                else
                {
                    result.ViewData.Add(
                        Constants.ThrowDBException,
                        Messages.GenericDBExceptionMessage
                    );
                }
            }
            else
            {
                result.ViewData.Add(Constants.ThrowException, context.Exception);
            }

            context.ExceptionHandled = true;
            context.Result = result;
        }

        private bool IsUniqueConstraintViolationException(DbUpdateException dbUpdateException)
        {
            return dbUpdateException.InnerException is PostgresException postgresException
                && postgresException.SqlState == "23505"; // Unique Key Exception PostgreSQL
        }
    }
}
