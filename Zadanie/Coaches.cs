using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Zadanie
{
    public class Coaches
    {
        [JsonIgnore]
        public int Id { get; set; }
 
        public string first_name { get; set; }
       
        public string last_name { get; set; }

        public List<Season> Seasons { get; set; }
    }
}