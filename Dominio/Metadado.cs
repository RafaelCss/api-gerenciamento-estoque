
using System.Reflection;


namespace Dominio
{
    public static class Metadado
    {
        public static Assembly GetAssembly() => typeof(Metadado).Assembly;
    }
}
