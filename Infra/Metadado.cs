using System.Reflection;


namespace Infra;

public static class Metadado
{
    public static Assembly GetAssembly() => typeof(Metadado).Assembly;
}