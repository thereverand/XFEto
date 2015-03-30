using Eto;
using Eto.Drawing;
using Eto.Forms;

namespace Xamarin.Forms.EtoForms.Controls
{

	public class CellStyle
	{

		public static readonly BindableProperty SelectedProperty =
			BindableProperty.CreateAttached<CellStyle, Style> (b => GetSelected (b), new Style (typeof(Cell)), propertyChanged: SetSelected);

		public static readonly BindableProperty EnabledProperty =
			BindableProperty.CreateAttached<CellStyle, Style> (b => GetEnabled (b), new Style (typeof(Cell)), propertyChanged: SetEnabled);

		public static readonly BindableProperty DisabledProperty =
			BindableProperty.CreateAttached<CellStyle, Style> (b => GetDisabled (b), new Style (typeof(Cell)), propertyChanged: SetDisabled);

		public static readonly BindableProperty BackgroundColorProperty =
			BindableProperty.CreateAttached<CellStyle, Color> (b => GetBackgroundColor (b), Color.Transparent, propertyChanged: SetBackgroundColor);

		public static Color GetBackgroundColor (BindableObject bindable)
		{
			return (Color)bindable.GetValue (BackgroundColorProperty);
		}

		public static Style GetSelected (BindableObject bindable)
		{
			return (Style)bindable.GetValue (SelectedProperty);
		}

		public static Style GetEnabled (BindableObject bindable)
		{
			return (Style)bindable.GetValue (EnabledProperty);
		}

		public static Style GetDisabled (BindableObject bindable)
		{
			return (Style)bindable.GetValue (DisabledProperty);
		}

		private static void SetBackgroundColor (BindableObject bindable, Color oldvalue, Color newvalue)
		{
		}

		private static void SetSelected (BindableObject bindable, Style oldvalue, Style newvalue)
		{
		}

		private static void SetEnabled (BindableObject bindable, Style oldvalue, Style newvalue)
		{
		}

		private static void SetDisabled (BindableObject bindable, Style oldvalue, Style newvalue)
		{
		}
	}
}