﻿using System.Reflection;

namespace PersonService.Infrasturcture
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(Assembly).Assembly;
    }
}
