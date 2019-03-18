﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ApiCore.Extensions
{
    public static class EnumerationExtensions
    {
        public static string GetDescription(this Enum e)
        {
            var attribute = e.GetType()
                    .GetTypeInfo()
                    .GetMember(e.ToString())
                    .FirstOrDefault(member => member.MemberType == MemberTypes.Field)
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .SingleOrDefault() as DescriptionAttribute;

            return attribute?.Description ?? e.ToString();
        }
    }
}
