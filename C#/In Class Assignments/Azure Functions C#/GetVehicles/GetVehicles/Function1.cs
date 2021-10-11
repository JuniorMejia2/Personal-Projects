using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GetVehicles
{
    public static class getVehicles
    {
        private class Brand
        {
            public string Name { get; set; }
            public string StreetAddress { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
            public Brand(string strName, string strStreetAddress, string strCity, string strState, string strZip)
            {
                Name = strName;
                StreetAddress = strStreetAddress;
                City = strCity;
                State = strState;
                Zip = strZip;
            }

        }
        private class Vehicle
        {
            public object Brand { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public double MPG { get; set; }
            public Vehicle(object objBrand, string strModel, int intYear, double dblMPG)
            {
                Brand = objBrand;
                Model = strModel;
                Year = intYear;
                MPG = dblMPG;
            }
        }
        
        [FunctionName("getVehicles")]
        public static async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
    ILogger log)
        {
            string strBrand = req.Query["Brand"];
            string strModel = req.Query["Model"];

            log.LogInformation("C# HTTP trigger function processed a request.");

            Brand Toyota = new Brand("Toyota", "1540 Interstate Dr", "Cookeville", "TN", "38501");
            Brand Ford = new Brand("Ford", "1600 Interstate Dr", "CookeVille", "TN", "38501");
            Brand Volkswagen = new Brand("VolksWaggon", "2431 Gallatin Pike", "Madison", "TN", "37115");

            Vehicle GR86 = new Vehicle("Toyota", "GR86", 2021, 21);
            Vehicle Supra = new Vehicle("Toyora", "Supra", 2021, 25);
            Vehicle Ranger = new Vehicle("Ford", "Ranger", 2021, 21);
            Vehicle Mustang = new Vehicle("Ford", "Mustang", 2021, 21);
            Vehicle GolfGTI = new Vehicle("Volkswagen", "GolfGTI", 2021, 30);
            Vehicle Jetta = new Vehicle("Volkswagen", "Jetta", 2021, 30);

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);


            Brand[] arrBrand = new Brand[] { Toyota, Ford, Volkswagen };
            List<Brand> firstBrand = new List<Brand>();

            Vehicle[] arrVehicles = new Vehicle[] { GR86, Supra, Ranger, Mustang, GolfGTI, Jetta };
            List<Vehicle> firstVehicle = new List<Vehicle>();


            foreach (Brand brdBrand in arrBrand) 
            {
                if (strBrand == brdBrand.Name) 
                {
                    firstBrand.Add(brdBrand);
                }
            }
            if(firstBrand.Count > 0) 
            {
                return new OkObjectResult(firstBrand);            
            }
            else 
            {
                return new OkObjectResult("Brand Not Found");            
            }
        }
    }
}
