using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Zadanie
{
    public class Teams
    {
        [JsonIgnore]
        public int Id { get; set; }
        public  string School { get; set; }
        
     
        public List<Coaches> Coacheses { get; set; } = new List<Coaches>(); 
    }
}