using BiasApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace BiasApp.Storage
{
    /**
     * Denne klasse indeholder metoder, der gemmer objekter af klasser, så man
     * senere kan finde frem til og referere disse objekter.
     * Klassen indeholder også metoder til at hente, opdatere og slette objekter.
     */
    public class Storage
    {
        public ObservableCollection<SituationCard> SituationCards;
        public ObservableCollection<BiasCard> BiasCards;

        // Singleton pattern.
        private static Storage _instance;

        private Storage()
        {
            SituationCards = new ObservableCollection<SituationCard>();
            Task.Run(async () => await GetSituationCardsAsync());

            BiasCards = new ObservableCollection<BiasCard>();
            Task.Run(async () => await GetBiasCardsAsync());
        }

        // Singleton pattern.
        public static Storage GetInstance()
        {
            if (_instance is null)
            {
                _instance = new Storage();
            }

            return _instance;
        }

        // Fill list of situation cards.
        public async Task GetSituationCardsAsync()
        {
            string json = null;
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream("BiasApp.Database.SituationCardData.json"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = await reader.ReadToEndAsync();
                }
            }

            var situationCards = JsonConvert.DeserializeObject<List<SituationCard>>(json);

            SituationCards.Clear();

            foreach (var situationCard in situationCards)
            {
                SituationCards.Add(situationCard);
            }
        }

        // Fill list of bias cards.
        public async Task GetBiasCardsAsync()
        {
            string json = null;
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream("BiasApp.Database.BiasCardData.json"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = await reader.ReadToEndAsync();
                }
            }

            var biasCards = JsonConvert.DeserializeObject<List<BiasCard>>(json);

            BiasCards.Clear();

            foreach (var biasCard in biasCards)
            {
                BiasCards.Add(biasCard);
            }
        }
    }
}
