using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class LocationList
    {
        public List<string> States { get; set; }
        public SortedList<string, List<string>> Cities { get; set; }

        public LocationList()
        {
            var root = AppDomain.CurrentDomain.BaseDirectory;

            StreamReader stream = new StreamReader(root + @"/src/json/malaysian-states/states.json");
            string json = stream.ReadToEnd();
            States = JsonConvert.DeserializeObject<List<String>>(json);

            stream = new StreamReader(root + @"/src/json/malaysian-states/states-cities.json");
            json = stream.ReadToEnd();
            Cities = JsonConvert.DeserializeObject<SortedList<string, List<string>>>(json);
        }
    }
}