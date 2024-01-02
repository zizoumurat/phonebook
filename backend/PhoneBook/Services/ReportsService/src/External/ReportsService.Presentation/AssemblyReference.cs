using System.Reflection;

namespace ReportsService.Presentation;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(Assembly).Assembly;
}