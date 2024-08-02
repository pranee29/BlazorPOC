namespace BlazorApp2_Chartjs_File.Data
{
    public class CountryInfo
    {
        public int id { get; set; } = 0;

        public string name { get; set; } = "";


        public int TotalCases { get; set; } = 0;

        public int TotalDeaths { get; set; } = 0;
        public string DeathPercentage => (this.TotalDeaths * 100) / this.TotalCases + "%";


        public List<CountryInfo> GetCountryInfos()
        {
            var countryInfos = new List<CountryInfo>();


            countryInfos.Add(new CountryInfo() { id = 1, name = "ABCD", TotalCases = 12113, TotalDeaths = 100 });
            countryInfos.Add(new CountryInfo() { id = 2, name = "XYZABCD", TotalCases = 2113, TotalDeaths = 120 });
            countryInfos.Add(new CountryInfo() { id = 3, name = "ABCDXYZ", TotalCases = 1113, TotalDeaths = 10 });
            countryInfos.Add(new CountryInfo() { id = 4, name = "ABCDPQR", TotalCases = 113, TotalDeaths = 1 });

            return countryInfos;
        }

    }




}
