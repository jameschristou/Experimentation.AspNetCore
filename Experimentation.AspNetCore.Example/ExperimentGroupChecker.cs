using Microsoft.AspNetCore.Http;
using System.Linq;
using System;

namespace Experimentation.AspNetCore.Example
{
    public interface IExperimentGroupChecker
    {
        bool IsInGroup(string groupName);
    }

    public class ExperimentGroupChecker : IExperimentGroupChecker
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private const string _experimentsHeader = "EXP_HEADER";

        public ExperimentGroupChecker(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsInGroup(string groupName)
        {
            if(!_httpContextAccessor.HttpContext.Request.Headers.TryGetValue(_experimentsHeader, out var headerValue))
            {
                return false;
            }

            var groups = headerValue.ToString().Split(",").ToList();

            return groups.Any(s => String.Equals(s, groupName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
