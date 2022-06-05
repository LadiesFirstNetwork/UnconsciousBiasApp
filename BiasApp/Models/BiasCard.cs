using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace BiasApp.Models
{
    public class BiasCard
    {
        public int ID { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public BiasCard(string input)
        {
            try
            {
                var result = input.Split(';');
                ID = Convert.ToInt32(result[0]);
                Name = result[1].Trim();
                Description = result[2].Trim();
                Image = result[3].Trim();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to construct bias card: {ex}");
                Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
        }
    }
}
