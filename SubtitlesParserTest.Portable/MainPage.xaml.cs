using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BuildIt;
using SubtitlesParserNew.Classes;
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
	        try
	        {
	            Task.Run(() =>
	            {
	                var ttmlFile = "2518_aud_SpReco.ttml";
	                ProcessSubtitle(ttmlFile);
                });
	        }
	        catch (Exception ex)
	        {
	            ex.LogException();   
	        }
	    }

	    private void OnVTTProcessed(object sender, EventArgs e)
	    {
	        try
	        {
	            Task.Run(() =>
	            {
	                var ttmlFile = "2518_aud_SpReco.vtt";
	                ProcessSubtitle(ttmlFile);
                });
	        }
	        catch (Exception ex)
	        {
	            ex.LogException();
	        }
	    }


	    private void ProcessSubtitle(string filePath)
	    {
            Debug.WriteLine("ProcessSubtitle fired!");
	        var parser = new SubtitlesParserNew.Classes.Parsers.SubParser();
	        var fileName = Path.GetFileName(filePath);
	        Debug.WriteLine($"File Read! {fileName}");

            using (var fileStream = File.OpenRead(filePath))
	        {
	            Debug.WriteLine($"File Open Read! {filePath}");
                try
                {
	                var mostLikelyFormat = parser.GetMostLikelyFormat(fileName);
	                if (mostLikelyFormat == SubtitlesFormat.TtmlFormat)
	                {
	                    var ttmlItems = parser.ParseStream(fileStream, Encoding.UTF8, mostLikelyFormat);
	                    ttmlCaption.Text = string.Join(", ", ttmlItems?.FirstOrDefault()?.Lines);
	                }
                    else if (mostLikelyFormat == SubtitlesFormat.WebVttFormat)
	                {
	                    var vttItems = parser.ParseStream(fileStream, Encoding.UTF8, mostLikelyFormat);
	                    vttCaption.Text = string.Join(", ", vttItems?.FirstOrDefault()?.Lines);

                    }
                    //   var items = parser.ParseStream(fileStream, Encoding.UTF8, mostLikelyFormat);
                    //if (items.Any())
                    //{
                    //Console.WriteLine("Parsing of file {0}: SUCCESS ({1} items - {2}% corrupted)",
                    //    fileName, items.Count, (items.Count(it => it.StartTime <= 0 || it.EndTime <= 0) * 100) / items.Count);
                    //}
                }
	            catch (Exception ex)
	            {
                    ex.LogException();
	            }
	        }
        }
    }
}