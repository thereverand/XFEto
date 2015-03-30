using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Reflection;
using Xamarin.Forms;



namespace Harness.Platform
{
	

	public class ObservableObject : INotifyPropertyChanged
	{

		protected Task StartTask (Action task)
		{
			return UI.Scheduler.ScheduleAction (task);
		}

		public void Set<T> (Expression<Func<T>> member, T value)
		{
			var body = member.Body as MemberExpression;
			if (body != null) {
				if (body.Member == null) {
					throw new ArgumentException ("property");
				}
				var prop = body.Member as PropertyInfo;
				if (prop != null) {
					prop.SetValue (this, value);
					OnPropertyChanged (body.Member.Name);
				}
			} else
				throw new ArgumentException ("property");
		}

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual async void OnPropertyChanged (string name)
		{
			var handler = PropertyChanged;
			var args = new PropertyChangedEventArgs (name);

			var notifyHandlers = StartTask (() => {
				if (handler != null)
					handler (this, args);
			});
		
			await notifyHandlers;
		}

		protected virtual void OnPropertyChanged<T> (Expression<Func<T>> property)
		{
			var body = property.Body as MemberExpression;
			if (body != null) {
				var member = body;
				if (member.Member == null) {
					throw new ArgumentException ("property");
				}
				OnPropertyChanged (member.Member.Name);
			} else
				throw new ArgumentException ("property");
		}

		#endregion INotifyPropertyChanged implementation

	
	}
}