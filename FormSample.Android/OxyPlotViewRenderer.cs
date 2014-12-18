using System;

using FormSample;
using FormSample.Droid;

using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;



using Android.OS;
using OxyPlot.XamarinAndroid;

[assembly: ExportRenderer(typeof(OxyPlotView), typeof(OxyPlotViewRenderer))]
namespace FormSample.Droid
{
	using Xamarin.Forms.Platform.Android;
	using OxyPlot.XamarinAndroid;
	using System.ComponentModel;

	public class OxyPlotViewRenderer : ViewRenderer<OxyPlotView, PlotView>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<OxyPlotView> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement != null || this.Element == null)
			{
				return;
			}

			var plotView = new PlotView(this.Context)
			{
				Model = this.Element.Model,
				Controller = this.Element.Controller
			};

			if (this.Element.Model.Background.IsVisible())
			{
				plotView.SetBackgroundDrawable(new Android.Graphics.Drawables.ColorDrawable(Android.Graphics.Color.Bisque)); // new Android.Graphics.Drawables.ColorDrawable(this.Element.Model.Background.ToColor());
			}

			this.SetNativeControl(plotView);
		}

		/// <summary>
		/// Raises the element property changed event.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The event arguments.</param>
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			if (this.Element == null || this.Control == null)
			{
				return;
			}

			if (e.PropertyName == OxyPlotView.ModelProperty.PropertyName)
			{
				this.Control.Model = Element.Model;
			}

			if (e.PropertyName == OxyPlotView.ControllerProperty.PropertyName)
			{
				this.Control.Controller = Element.Controller;
			}
		}
	}
}

