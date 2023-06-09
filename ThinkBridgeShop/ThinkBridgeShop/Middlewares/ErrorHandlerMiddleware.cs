﻿using System;
using System.Net;
using System.Text.Json;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ThinkBridgeShop.Application.Exceptions;

namespace ThinkBridgeShop.Middlewares
{
	public class ErrorHandlerMiddleware
	{
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                await HandleException(context,error);
            }
        }

        private async Task HandleException(HttpContext context,Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var validationsErrors = new Dictionary<string,string[]>();
            var result = string.Empty;
            switch (error)
            {
                case BadRequestException e:
                    result=JsonSerializer.Serialize(e.Message);
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case UnAuthorizedException e:
                    result = JsonSerializer.Serialize(e.Message);
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;


                case NotFoundException e:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case ValidationException e:
                    validationsErrors =e.ErrorsDictionary;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                default:
                    
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            if (!string.IsNullOrEmpty(result))
                await response.WriteAsync(result);

            if (validationsErrors.Count > 0)
            {
                var serializeResult = JsonSerializer.Serialize(validationsErrors);
                await response.WriteAsync(serializeResult);
            }
            

        }
    }
}

