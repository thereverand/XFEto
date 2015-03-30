using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Xamarin.Forms.Support
{

	public static class Types
	{

		public static void InvokeGenericMethod (this object o, string methodName, Type[] typeParameters, object[] parameters)
		{
			o.InvokeGenericMethodReturning<object> (methodName, typeParameters, parameters);
		}

		public static MethodInfo FindMethod (Type type, string methodName, params Func<MethodInfo, bool>[] predicates)
		{
			return type.GetRuntimeMethods ()
                .FirstOrDefault (m =>
                    m.Name.StartsWith (methodName, StringComparison.Ordinal) &&
			predicates.All (p => p (m)));
		}

		public static T InvokeGenericMethodReturning<T> (this object o, string methodName, Type[] typeParameters, object[] parameters)
		{
			return
            (T)FindMethod (o.GetType (),
				methodName,
				m => m.IsGenericMethodDefinition,
				m => m.GetGenericArguments ().Count () == typeParameters.Length)
            .MakeGenericMethod (typeParameters)
            .Invoke (o, parameters);
		}

		public static bool IsDefault (this object value)
		{
			return Default (value.GetType ()).IsEqualTo (value);
		}

		public static object Default (this Type type)
		{
			return
                FindMethod (typeof(Types), "Default", m => m.IsGenericMethodDefinition)
                    .MakeGenericMethod (type)
                    .Invoke (null, null);
		}

		public static T Default<T> ()
		{
			return default(T);
		}

		public static bool IsEqualTo<T> (this T t1, T t2)
		{
			return EqualityComparer<T>.Default.Equals (t1, t2);
		}

		public static TypeInfo GetInfo (this object o)
		{
			return o.GetType ().GetTypeInfo ();
		}

		public static IEnumerable<Type> GetLineage (Type type)
		{
			var t = type.GetTypeInfo ();
			while (t.BaseType != null) {
				yield return t.BaseType;
				t = t.BaseType.GetTypeInfo ();
			}
		}

		public static IEnumerable<PropertyInfo> GetProperties (Type t)
		{
			return t.GetRuntimeProperties ();
		}

		public static IEnumerable<MethodInfo> GetMethods (Type t)
		{
			return t.GetRuntimeMethods ();
		}

		public static MethodInfo FindMethod (Type t, string name, Type returnType, bool isGeneric = false, bool isAbstract = false)
		{
			var matchMethod =
				GetMethods (t).FirstOrDefault (
					mm => mm.Name == name &&
					mm.ReturnType == returnType &&
					isGeneric || !mm.IsGenericMethodDefinition &&
					isAbstract || !mm.IsAbstract
				);

			return matchMethod;
		}

		public static object InvokeWithOptionalParameters (this object owner, MethodInfo method, params object[] parameters)
		{
			if (method == null)
				return null;
			var paramCount = method.GetParameters ().Length;
			return paramCount < 1 ?
                method.Invoke (owner, new object[] { }) :
                method.Invoke (owner, parameters.Take (paramCount).ToArray ());
		}

		public static T GetProperty<T> (this object o, string property)
		{
			var t = o.GetType ();
			var p = GetProperties (t).FirstOrDefault (prop => prop.Name == property);
			return p == null ? default(T) : (T)p.GetValue (o);
		}

		public static void SetProperty (this object o, string property, object value)
		{
			var t = o.GetType ();
			var p = GetProperties (t).FirstOrDefault (prop => prop.Name == property);
			if (p == null)
				return;
			p.SetValue (o, value);
		}

		public static IEnumerable<T> GetCustomAttributes<T> (this Type type, bool inherit = true)
		{
			return type.GetTypeInfo ().GetCustomAttributes (typeof(T), inherit).OfType<T> ();
		}

		public static T GetCustomAttribute<T> (this Type type, bool inherit = false)
		{
			return type.GetCustomAttributes<T> (inherit).FirstOrDefault ();
		}
	}
}