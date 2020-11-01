using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AssemblyExample
{
    public class ReflectionUtils
    {
        /// <summary>
        /// Get Class Names
        /// </summary>
        /// <param name="dllName"></param>
        /// <returns></returns>
        public static List<string> GetClassNames(string dllName)
        {
            string pathName = AppDomain.CurrentDomain.BaseDirectory + "bin\\";        //Get the Location of the application
            Assembly assembly = Assembly.LoadFile(pathName + dllName);
            return assembly.GetTypes().OrderBy(b => b.FullName).Select(a => a.FullName.ToString()).ToList();
        }

        /// <summary>
        /// Get Properties Name
        /// </summary>
        /// <param name="dllName"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public static List<string> GetPropertiesName(string dllName, string className)
        {
            string pathName = AppDomain.CurrentDomain.BaseDirectory + "bin\\";        //Get the Location of the application
            Assembly assembly = Assembly.LoadFile(pathName + dllName);
            Type type = assembly.GetType(className);
            return Type.GetType(type.AssemblyQualifiedName).GetProperties().Select(a => a.ToString()).ToList();
        }

        /// <summary>
        /// Get Instances by Get Interfaces
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetInstances<T>()
        {
            return (from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.GetInterfaces().Contains(typeof(T)) && t.GetConstructor(Type.EmptyTypes) != null
                    select (T)Activator.CreateInstance(t)).ToList();
        }

        /// <summary>
        /// Get Instances by Base Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<T> GetInstancesByBaseType<T>()
        {
            return (from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.BaseType == (typeof(T)) && t.GetConstructor(Type.EmptyTypes) != null
                    select (T)Activator.CreateInstance(t)).ToList();
        }

        /// <summary>
        /// returns a list of strings containing the names of all classes implementing the IDomainEntity interface
        /// https://garywoodfine.com/get-c-classes-implementing-interface/
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllEntities()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                 .Where(x => typeof(IDomainEntity).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                 .Select(x => x.Name).ToList();
        }

        /// <summary>
        /// https://stackoverflow.com/questions/14467943/c-sharp-list-all-methods-in-a-control
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<string> PrintMethods(object o)
        {
            Type t = o.GetType();
            MethodInfo[] methods = t.GetMethods();
            return methods.Select(x => x.Name).ToList();
            //foreach (MethodInfo method in methods)
            //{
            //    Print(method.Name);
            //}
        }
    }
}