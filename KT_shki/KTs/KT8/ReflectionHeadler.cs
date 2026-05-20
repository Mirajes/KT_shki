using System;
using System.Reflection;

namespace KT_shki
{
    public class ReflectionHeadler
    {
        public void PrintTypeInfo(object obj)
        {
            Console.Write("\n");

            Type type = obj.GetType();

            // vse svoistva
            PropertyInfo[] propertyInfos = type.GetProperties();
            Console.WriteLine("\nСвойства:");
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Console.WriteLine(propertyInfo);
            }

            // vsee polya
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("\nПоля:");
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                Console.WriteLine(fieldInfo);
            }

            // vse metodi
            MethodInfo[] methodInfos = type.GetMethods();
            Console.WriteLine("\nМетоды:");
            foreach (MethodInfo methodInfo in methodInfos)
            {
                Console.WriteLine(methodInfo);
            }
        }

        public void PrintObjectValues(object obj)
        {
            Console.WriteLine("\n");

            Type type = obj.GetType();

            // schitat' vse svoistva
            PropertyInfo[] propertyInfos = type.GetProperties();
            Console.WriteLine("\n Значения свойств");
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Console.WriteLine($"[{propertyInfo.Name}] => {propertyInfo.GetValue(obj)}");
            }

            // schitat' vase polya
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("\n Значения полей");
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                Console.WriteLine($"[{fieldInfo.Name}] => {fieldInfo.GetValue(obj)}");
            }
        }
    }
}