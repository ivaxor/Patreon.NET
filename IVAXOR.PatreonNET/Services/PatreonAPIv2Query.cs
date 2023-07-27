using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace IVAXOR.PatreonNET.Services
{
    public class PatreonAPIv2Query<TAttributes>
        where TAttributes : IPatreonAttributes
    {
        protected internal HashSet<string> TopLevelIncludes { get; set; } = new HashSet<string>();
        protected internal HashSet<string> IncludeFields { get; set; } = new HashSet<string>();

        public PatreonAPIv2Query<TAttributes> Include(string topLevelInclude)
        {

            TopLevelIncludes.Add(topLevelInclude);

            return this;
        }

        public PatreonAPIv2Query<TAttributes> IncludeField(string propertyName)
        {
            if (!typeof(TAttributes).GetProperties().Any(_ => _.Name == propertyName)) throw new ArgumentException("Invalid value", nameof(propertyName));
            IncludeFields.Add(propertyName);

            return this;
        }

        public PatreonAPIv2Query<TAttributes> IncludeField(Expression<Func<TAttributes, object>> selector)
        {
            var propertyType = (PropertyInfo)((MemberExpression)selector.Body).Member;
            IncludeField(propertyType.Name);

            return this;
        }
    }
}
