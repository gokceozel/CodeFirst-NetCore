using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CodeFirst.Data.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateTimeKindAttribute : Attribute
    {
        private DateTimeKind _utc;

        public DateTimeKindAttribute(DateTimeKind utc)
        {
            _utc = utc;
        }

        public DateTimeKind Utc
        {
            get { return _utc; }
        }

        private static ValueConverter<DateTime, DateTime> CreateSpecifyKindValueConverter(DateTimeKind utc)
        {
            return new ValueConverter<DateTime, DateTime>(v => v, v => DateTime.SpecifyKind(v, utc));
        }

        public static void Apply(IMutableEntityType entity)
        {
            if (entity == null)
                return;

            var properties = entity
                .GetProperties()
                .Where(x => x.PropertyInfo != null && (x.PropertyInfo.PropertyType == typeof(DateTime) || x.PropertyInfo.PropertyType == typeof(DateTime?)));

            foreach (var property in properties)
            {
                var attr = property.PropertyInfo.GetCustomAttribute<DateTimeKindAttribute>();
                if (attr == null)
                    continue;

                property.SetValueConverter(CreateSpecifyKindValueConverter(attr.Utc));
            }
        }

    }
}
