using System.Collections.Generic;
using Eto;

namespace Xamarin.Forms.EtoForms.Controls
{
	/*
     *  <eto:TableLayout>
     *      <eto:RowSet>
     *          <eto:TableRow>
     *              <eto:TableCell/>
     *
     */

	[ContentProperty ("Sections")]
	public class TableLayout : View
	{

		protected static readonly BindablePropertyKey SectionsProperty = BindableProperty.CreateReadOnly<TableLayout, IList<Section>> (
			                                                                       t => t.Sections,
			                                                                       new ExtendedObservableCollection<Section> ());

		public IList<Section> Sections {
			get { return (IList<Section>)GetValue (SectionsProperty.BindableProperty); }
		}
	}

    
}