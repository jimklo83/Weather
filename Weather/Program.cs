using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

var client = new HttpClient();
var apiKeyObj = System.IO.File.ReadAllText("appsettings.json");
var apiKey = JObject.Parse(apiKeyObj).GetValue("apiKey").ToString();
var latitude = 41.87;
var longitude = -87.62;
var apiUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={apiKey}&units=imperial";
var weatherResult = client.GetStringAsync(apiUrl).Result;
var temperature = JObject.Parse(weatherResult)["main"]["temp"].ToString();
var feels = JObject.Parse(weatherResult)["main"]["feels_like"].ToString();
var min = JObject.Parse(weatherResult)["main"]["temp_min"].ToString();
var max = JObject.Parse(weatherResult)["main"]["temp_max"].ToString();
var city = JObject.Parse(weatherResult)["name"].ToString();


Console.WriteLine($"Today's weather in {city} is {temperature}\u00B0, though it feels like {feels}\u00B0.\nToday's low is {min}\u00B0 and the high is {max}\u00B0.");