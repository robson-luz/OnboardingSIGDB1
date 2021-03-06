﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.Domain.Notifications
{
    public class NotificationFilter /*: IAsyncResultFilter*/ : IResultFilter
    {
        private readonly NotificationContext _notificationContext;

        public NotificationFilter(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {

        }

        //public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        //{
        //    if(_notificationContext.HasNotifications)
        //    {
        //        context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
        //        context.HttpContext.Response.ContentType = "application/json";

        //        var notifications = JsonConvert.SerializeObject(_notificationContext.Notifications);
        //        await context.HttpContext.Response.WriteAsync(notifications);

        //        return;
        //    }

        //    await next();
        //}

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (_notificationContext.HasNotifications)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                var notifications = JsonConvert.SerializeObject(_notificationContext.Notifications);
                context.HttpContext.Response.WriteAsync(notifications);

                return;
            }
        }
    }
}
