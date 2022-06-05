using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace BiasApp.Models
{
    public class SituationCard
    {
        public int ID { get; }
        public string Category { get; set; }    // FrontView
        public string Scene { get; set; }       // FrontView
        public string Biases { get; set; }      // BackView
        public string Handling { get; set; }    // BackView

        public SituationCard(string input)
        {
            try
            {
                var result = input.Split(';');
                ID = int.Parse(result[0]);
                Category = result[1].Trim();
                Scene = result[2].Trim();
                Biases = result[3].Trim();
                Handling = result[4].Trim();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to construct situation card: {ex}");
                Application.Current.MainPage.DisplayAlert("Fejl!", ex.Message, "OK");
            }
        }
    }
}
