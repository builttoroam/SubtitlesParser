using System;
using System.Diagnostics;
using System.Text;
using BuildIt;
using SubtitlesParserNew.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;

namespace SubtitlesParserTest.Portable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
	    public MainPage()
	    {
	        InitializeComponent();

            var resourceIds = GetType().GetTypeInfo().Assembly.GetManifestResourceNames();
            foreach(var resourceId in resourceIds)
            {
                ProcessSubtitle(resourceId);
            }
        }


        private void ProcessSubtitle(string resourceId)
        {
            Debug.WriteLine($"Resource Id: {resourceId}");
            try
            {
                var fileNames = resourceId.Split('.');
                var fileName = fileNames.Length > 1 ?  $"{fileNames[fileNames.Length - 2]}.{fileNames[fileNames.Length - 1]}" : string.Empty;
                Debug.WriteLine($"FileName: {fileName}");
                var resourceStream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream(resourceId);
	            var parser = new SubtitlesParserNew.Classes.Parsers.SubParser();
            
	            var mostLikelyFormat = parser.GetMostLikelyFormat(fileName);
	            if (mostLikelyFormat == SubtitlesFormat.TtmlFormat)
	            {
	                var ttmlItems = parser.ParseStream(resourceStream, Encoding.UTF8, mostLikelyFormat);
                    ttmlList.ItemsSource = ttmlItems;
                }
                else if (mostLikelyFormat == SubtitlesFormat.WebVttFormat)
	            {
	                var vttItems = parser.ParseStream(resourceStream, Encoding.UTF8, mostLikelyFormat);
                    vttList.ItemsSource = vttItems;
                }
            }
	        catch (Exception ex)
	        {
                ex.LogException();
	        }
        }
    }
}