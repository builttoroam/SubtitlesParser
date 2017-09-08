using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SubtitlesParserTest.Portable
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
	    public MainPage()
	    {
	        InitializeComponent();
	    }

	    private void OnTTMLProcessed(object sender, EventArgs e)
	    {
	        
	    }

	    private void OnVTTProcessed(object sender, EventArgs e)
	    {

	    }

    }
}