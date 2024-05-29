using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CsvHelper;
using Newtonsoft.Json;


namespace CarManufacture.Services
{
    public class CarModelService
    {

        private Dictionary<string, string> _makeIdMap;

        string filePath = "C:\\github\\CarManufacture\\CarManufacture.Services\\CarMakefiles\\CarMake.csv.csv";
        public async Task<List<string>> GetAllCarModelsProduced(string make, int modelYear)
        {
            _makeIdMap = LoadMakeIdMapFromCsv(filePath);
            if (_makeIdMap.TryGetValue(make, out string makeId))
            {
                var VehicleModels = await GetVehicleModelsForMakeAndYear(Convert.ToInt32( makeId), modelYear);
                return VehicleModels;
            }
            else
            {
                return null;
            }
        }
              
        private Dictionary<string, string> LoadMakeIdMapFromCsv(string filePath)
        {
            var makeIdMap = new Dictionary<string, string>();

            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();

                    while (csv.Read())
                    {
                        var make = csv.GetField("make_name");
                        var makeId = csv.GetField("make_id");

                        makeIdMap[make] = makeId;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading CSV file: " + ex.Message);
            }

            return makeIdMap;
        }

        public async Task< List<string>> GetVehicleModelsForMakeAndYear(int makeId, int modelYear)
        {
            // NHTSA API endpoint
            string apiUrl = $"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{modelYear}?format=json";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var modelNames = new List<string>();
                    // Send a GET request to the API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON response into DTO
                        //VehicleModel vehicleModelDto = JsonConvert.DeserializeObject<VehicleModel>(responseBody);
                        var vehicleModelDto = JsonConvert.DeserializeObject<CarModelResponse>(responseBody);
                        foreach (var result in vehicleModelDto.Results)
                        {
                            modelNames.Add(result.Model_Name);
                        }
                        // Return the list of vehicle models
                        return modelNames;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

    }

}