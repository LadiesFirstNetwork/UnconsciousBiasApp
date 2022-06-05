using BiasApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using MvvmHelpers;

namespace BiasApp.Storage
{
    /**
     * Denne klasse indeholder metoder, der gemmer objekter af klasser, så man
     * senere kan finde frem til og referere disse objekter.
     * Klassen indeholder også metoder til at hente, opdatere og slette objekter.
     */
    public class Storage
    {
        public ObservableRangeCollection<SituationCard> SituationCards;
        public ObservableRangeCollection<BiasCard> BiasCards;

        // Singleton pattern.
        private static Storage _instance;

        private Storage ()
        {
            SituationCards = GetSituationCards();
            BiasCards = GetBiasCards();
        }

        // Singleton pattern.
        public static Storage GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Storage();
            }

            return _instance;
        }

        // Make list of situation cards.
        public ObservableRangeCollection<SituationCard> GetSituationCards()
        {
            // Get objects from file.
            List<string> objects = GetObjectsFromTxtFile("BiasApp.Resources.Database.SituationCardDatabase.txt");

            // Make list of cards.
            ObservableRangeCollection<SituationCard> cards = new ObservableRangeCollection<SituationCard>();

            for (int i = 0; i < objects.Count; i++)
            {
                SituationCard card = new SituationCard(objects[i]);
                cards.Add(card);
            }

            return cards;
        }

        // Make list of bias cards.
        public ObservableRangeCollection<BiasCard> GetBiasCards()
        {
            // Get objects from file.
            List<string> objects = GetObjectsFromTxtFile("BiasApp.Resources.Database.BiasCardDatabase.txt");

            // Make list of cards.
            ObservableRangeCollection<BiasCard> cards = new ObservableRangeCollection<BiasCard>();

            for (int i = 0; i < objects.Count; i++)
            {
                BiasCard card = new BiasCard(objects[i]);
                cards.Add(card);
            }

            return cards;
        }

        // Helper: Retrieves objects from textfiles.
        private List<string> GetObjectsFromTxtFile(string file)
        {
            // Setup.
            var assembly = Assembly.GetExecutingAssembly();
            string filename = file;
            string rawText;

            // Read text from file.
            using (Stream stream = assembly.GetManifestResourceStream(filename))
            using (StreamReader reader = new StreamReader(stream))
            {
                rawText = reader.ReadToEnd();
            }

            // Skip comment in text file and remove all unnecessary trailing whitespace and starting brackets.
            int startIndex = rawText.IndexOf("ID:1");
            string rawData = rawText.Substring(startIndex).Replace("{", "");

            // Make list of objects starting from "ID:" and ending at ending brackets.
            List<string> objects = new List<string>();

            int[] beginSeparatorIndexes = Regex.Matches(rawData, "ID:").Cast<Match>().Select(m => m.Index).ToArray();
            int[] endSeparatorIndexes = Regex.Matches(rawData, "}").Cast<Match>().Select(n => n.Index).ToArray();

            int i = 0;
            int j = 0;

            while (i < beginSeparatorIndexes.Length && j < endSeparatorIndexes.Length)
            {
                int start = beginSeparatorIndexes[i] + 3;
                int length = endSeparatorIndexes[j] - start;

                string obj = rawData.Substring(start, length);
                objects.Add(obj);
                i++;
                j++;
            }

            return objects;
        }
    }
}
