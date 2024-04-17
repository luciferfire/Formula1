using System.Collections.ObjectModel;
using Formula1.Models;
using System.Net.Http.Json;
using System.Net.Http;
namespace Formula1;

public partial class GarePage : ContentPage
{
    private string _apiGare = "https://ergast.com/api/f1/2001.json";
    public ObservableCollection<Race> gare { get; set; } = new();
    HttpClient _httpClient;

    public GarePage()
    {
        InitializeComponent();
        BindingContext = this;
        _httpClient = new HttpClient();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var responseGare = await _httpClient.GetFromJsonAsync<ResultGares>(_apiGare);

        responseGare.MRData.RaceTable.Races.ForEach(race =>
        {
            gare.Add(race);
        });
    }
}