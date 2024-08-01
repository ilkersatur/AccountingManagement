using System.Reflection;

namespace Accounting.Presentation
{
    //Assembly sayesinde yapımızı tanıtacağız.
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(Assembly).Assembly;
    }
}
