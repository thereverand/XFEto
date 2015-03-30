
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


using Harness.Platform;
using Xamarin.Forms.Support;



namespace Harness.Platform.Support
{
	public interface IModelBinder
	{
		void Bind (object view, object model);
	}

	public class XamarinModelBinder : IModelBinder
	{

		private static readonly TypeInfo CommandType = typeof(ICommand).GetTypeInfo ();

		public static Binding BindProperty (BindableProperty p, BindableObject view, IEnumerable<PropertyInfo> modelProperties)
		{
			var pName = p.PropertyName;
			var pType = p.ReturnType;
			//var pBindingMode = p.DefaultBindingMode;

			var matchProp = modelProperties.FirstOrDefault (mp => mp.Name == pName && pType.GetTypeInfo ().IsAssignableFrom (mp.PropertyType.GetTypeInfo ()));

			if (matchProp == null)
				return null;

			var binding = new Binding (pName, BindingMode.TwoWay);

			view.SetBinding (p, binding);

			return binding;
		}

		public static Command BindMethod (BindableProperty p, object model, BindableObject view, IEnumerable<MethodInfo> modelMethods)
		{
			var command = CreateCommand (view, p.PropertyName, model);

			if (view != null)
				view.SetValue (p, command);
			return command;
		}

		private static IEnumerable<BindableProperty> GetAllBindableProperties (Type type)
		{
			return Types.GetLineage (type).SelectMany (c => GetBindableProperties (c.GetTypeInfo ()));
		}

		private static IEnumerable<BindableProperty> GetBindableProperties (TypeInfo type)
		{
			var fields = type.DeclaredFields;
			return
				fields
					.Where (x => x.IsStatic && x.FieldType == typeof(BindableProperty))
					.Select (x => (BindableProperty)x.GetValue (null))
					.ToArray ();
		}

		/// <summary>
		/// Creates a Command instance whose operations are COMPLETELY defered until execution.
		/// </summary>
		/// <returns>The command.</returns>
		/// <param name="view">View.</param>
		/// <param name="method">Method.</param>
		/// <param name="model">Defered Model.</param>
		public static Command CreateCommand (BindableObject view, string method, Func<Object> model)
		{
			
			Func<object,MethodInfo> FindMethod = m => {

				if (m == null)
					return null;
				var t = m.GetType ();

				return Types.FindMethod (t, method);
			};

			//And again...
			Func<object,MethodInfo> getGuard = m => {

				if (m == null)
					return null;
				var t = m.GetType ();

				return Types.FindMethod (t, "Can" + method);
			};
			//NOW in this scope, let's create a Command, using our funcs.
			var command =
				new Command (
					o => {
						var m = model ();
						var cMethod = FindMethod (m);
						if (m == null || cMethod == null)
							return;
						var paramList = o as IEnumerable<object>;
						if (!paramList.IsDefault ())
							m.InvokeWithOptionalParameters (cMethod, paramList.ToArray ());
						else if (!o.IsDefault ())
							m.InvokeWithOptionalParameters (cMethod, o);
						else
							m.InvokeWithOptionalParameters (cMethod);
					},
					o => {
						var m = model ();
						if (m.IsDefault ())
							return false;
						var guard = getGuard (m);
						if (guard == null)
							return true;
                       
						var paramList = o as IEnumerable<object>;
						if (!paramList.IsDefault ())
							return (bool)m.InvokeWithOptionalParameters (guard, paramList.ToArray ());
						else if (!o.IsDefault ())
							return (bool)m.InvokeWithOptionalParameters (guard, o);
						else
							return (bool)m.InvokeWithOptionalParameters (guard);
					});

			Action canExecute = command.ChangeCanExecute;
			HandleChanges (view, canExecute, p => canExecute ()); //Let's enusre it rebinds and reacts to changes.
			return command; //return the defered command
		}


		/// <summary>
		/// Creates a Command instance that is bound to the model or DataContext immediately.
		/// </summary>
		/// <returns>The command.</returns>
		/// <param name="view">View.</param>
		/// <param name="method">Method.</param>
		/// <param name="model">Model.</param>
		public static Command CreateCommand (BindableObject view, string method, object model)
		{
			model = model ?? view.BindingContext;
			var t = model.GetType ();

			var matchMethod = Types.FindMethod (t, method);
			if (matchMethod == null)
				return null;
			var guard = Types.FindMethod (t, "Can" + method);

            

			var command = 
				new Command (
					o => {
						var paramList = o as IEnumerable<object>;
						if (!paramList.IsDefault ())
							model.InvokeWithOptionalParameters (matchMethod, paramList.ToArray ());
						else if (!o.IsDefault ())
							model.InvokeWithOptionalParameters (matchMethod, o);
						else
							model.InvokeWithOptionalParameters (matchMethod);
					}, 
					o => {
						if (guard == null)
							return true;
						var paramList = o as IEnumerable<object>;
						if (!paramList.IsDefault ())
							return (bool)model.InvokeWithOptionalParameters (guard, paramList.ToArray ());
						else if (!o.IsDefault ())
							return (bool)model.InvokeWithOptionalParameters (guard, o);
						else
							return (bool)model.InvokeWithOptionalParameters (guard);
					});

			Action canExecute = command.ChangeCanExecute;
			HandleChanges (view, canExecute, p => canExecute ());
			return command;
		}

		public static void HandleChanges (
			BindableObject view,
			Action onContextChange,
			Action<PropertyChangedEventArgs> onPropertyChange
		)
		{
			view.BindingContextChanged += (sender, args) => {
				onContextChange ();
				var inpc = view.BindingContext as INotifyPropertyChanged;
				if (inpc != null)
					inpc.PropertyChanged += (s, a) => onPropertyChange (a);
			};
		}

		public void Bind (object view, object model)
		{
			var v = view as BindableObject;
			if (v == null)
				return;

			var t = model.GetType ();
			var properties = GetAllBindableProperties (view.GetType ()).ToArray ();
			var modelProperties = Types.GetProperties (t);
			var modelMethods = Types.GetMethods (t);

			foreach (var p in properties.Where(p => !p.IsReadOnly)) {
				if (CommandType.IsAssignableFrom (p.ReturnType.GetTypeInfo ()))
					BindMethod (p, model, v, modelMethods);
				BindProperty (p, v, modelProperties);
			}

			v.BindingContext = model;
		}
	}


}