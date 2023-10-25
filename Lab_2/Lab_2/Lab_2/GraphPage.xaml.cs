using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab_2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraphPage : ContentPage
    {
        public GraphPage(string json)
        {
            InitializeComponent();

            //var results = JsonConvert.DeserializeObject<List<CalculationResult>>(json);

            //var plotModel = new PlotModel();
            //var series = new LineSeries();

            //foreach (var result in results)
            //{
            //    series.Points.Add(new DataPoint(result.X, result.Result));
            //}

            //plotModel.Series.Add(series);
            //GraphImage.Source = ImageSource.FromStream(() => plotModel.ToBitmapStream());
            var results = JsonConvert.DeserializeObject<List<CalculationResult>>(json);

            var plotModel = new PlotModel();
            var series = new LineSeries();

            foreach (var result in results)
            {
                //if (series.Points.Count == 0)
                //{
                //    throw new Exception("No data points for the graph.");
                //}
                series.Points.Add(new DataPoint(result.X, result.Result));
            }

            plotModel.Series.Add(series);
            GraphView.Model = plotModel;
        }

    }
}