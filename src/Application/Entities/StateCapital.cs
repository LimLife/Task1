namespace Application.Entities
{
    public class StateCapital
    {
        public Dictionary<string, string> StateCapitalDictionary { get; private set; }

        private Random _random;

        public StateCapital()
        {
            _random = new Random();
            InitData();
        }
        public (string State, string City) GetRandomCitySate()
        {
            var index = _random.Next(StateCapitalDictionary.Count);
            var randomKey = StateCapitalDictionary.Keys.ElementAt(index);
            var randomValue = StateCapitalDictionary[randomKey];

            return (randomKey, randomValue);
        }
        public string GetRandomState()
        {
            var index = _random.Next(StateCapitalDictionary.Count);
            var randomKey = StateCapitalDictionary.Keys.ElementAt(index);
            return randomKey;
        }
        public string GetRandomCity()
        {
            var index = _random.Next(StateCapitalDictionary.Count);
            var randomKey = StateCapitalDictionary.Keys.ElementAt(index);
            var randomValue = StateCapitalDictionary[randomKey];
            return randomValue;
        }

        private void InitData()
        {
            StateCapitalDictionary = new Dictionary<string, string>()
            {
                {"Alabama","Montgomery" } ,
                { "Alaska", "Juneau"},
                {" Arizona", "Phoenix" },
                {" Arkansas", "LittleRock" },
                {"California", "Sacramento" },
                {"Colorado", "Denver" },
                {"Connecticut", "Hartford" },
                {"Delaware", "Dover" },
                { "Florida", "Tallahassee" },
                {"Georgia", "Atlanta" },
                { "Hawaii", "Honolulu" },
                { "Idaho", "Boise" },
                { "Illinois", "Springfield" },
                { "Indiana", "Indianapolis" },
                { "Iowa", "DesMoines" },
                { "Kansas", "Topeka" },
                { "Kentucky", "Frankfort" },
                {"Louisiana", "BatonRouge" },
                { "Maine", "Augusta" },
                { "Maryland", "Annapolis" },
                { "Massachusetts", "Boston"},
                { "Michigan", "Lansing" },
                {"Minnesota", "SaintPaul" },
                { "Mississippi", "Jackson" },
                { "Missouri", "JeffersonCity" },
                { "Montana", "Helena" },
                { "Nebraska", "Lincoln" },
                { "Nevada", "CarsonCity" },
                { "NewHampshire", "Concord" },
                { "NewJersey", "Trenton" },
                { "NewMexico", "SantaFe" },
                {"NewYork", "Albany" },
                { "NorthCarolina", "Raleigh" },
                { "NorthDakota", "Bismarck" },
                { "Ohio", "Columbus"}
            };
        }
    }
}
