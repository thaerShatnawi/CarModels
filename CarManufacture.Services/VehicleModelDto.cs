using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacture.Services
{
    public class CarModelResponse
    {  
        public List<CarModelResult> Results { get; set; }
    }
}

public class CarModelResult
{
    public int Make_ID { get; set; }
    public string Make_Name { get; set; }
    public int Model_ID { get; set; }
    public string Model_Name { get; set; }
}
