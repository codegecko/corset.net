using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using Corset.Core.Configuration;

namespace Corset.Web.Extensions
{
    public static class ICorsetConfigurationOptionsExtensions
    {
        public static ICorsetConfigurationOptions<HttpRequestBase, HttpResponseBase> EnableEtags(this ICorsetConfigurationOptions<HttpRequestBase, HttpResponseBase> options) {
            return options.Use((req, resp) => SetupEtags(req, resp));
        }

        public static ICorsetConfigurationOptions<HttpRequestBase, HttpResponseBase> SetExpiry(this ICorsetConfigurationOptions<HttpRequestBase, HttpResponseBase> options, DateTime expires) {
            return options.Use((req, resp) => SetExpiry(req, resp, expires));
        }

        private static void SetExpiry(HttpRequestBase req, HttpResponseBase resp, DateTime expires) {
            resp.Expires = (int)expires.Subtract(DateTime.UtcNow).TotalMinutes;
        }

        private static void SetupEtags(HttpRequestBase req, HttpResponseBase resp, Func<HttpRequestBase, HttpResponseBase, string> method) {
            resp.AddHeader("ETag", method(req, resp));
        }
    }
}
