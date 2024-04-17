using System.Collections.ObjectModel;
using Formula1.Models;
using System.Net.Http.Json;
namespace Formula1;

public partial class PilotiPage : ContentPage
{
	private string _apiDrivers = "https://ergast.com/api/f1/2001/drivers.json";
	public ObservableCollection<Driver> drivers { get; set; } = new();

    public int _valueEntry = 2001;
	HttpClient _httpClient;

    public PilotiPage()
	{
		InitializeComponent();
		BindingContext = this;
		_httpClient = new HttpClient();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var responseDrivers = await _httpClient.GetFromJsonAsync<ResultDrivers>(_apiDrivers);

        responseDrivers.MRData.DriverTable.Drivers.ForEach(driver =>
        {
            drivers.Add(driver);
        });

        Loading(_valueEntry);
    }

    public async void Loading(int year)
    {
        drivers.Clear();
        ResultDrivers response = await _httpClient.GetFromJsonAsync<ResultDrivers>($"{_apiDrivers}{_valueEntry}/drivers.json");
        response?.MRData.DriverTable.Drivers.ForEach(item => drivers.Add(item));
    }
}