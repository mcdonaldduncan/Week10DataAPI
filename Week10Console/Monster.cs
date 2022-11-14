using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Week10Console
{
    internal class Monster
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Type")]
        public string? Type { get; set; }

        [JsonPropertyName("HP")]
        public string? HP { get; set; }

        [JsonPropertyName("MP")]
        public string? MP { get; set; }

        [JsonPropertyName("Location")]
        public string? Location { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@$"ID: {ID}" + Environment.NewLine);
            sb.Append(@$"Name: {Name}" + Environment.NewLine);
            sb.Append(@$"Type: {Type}" + Environment.NewLine);
            sb.Append(@$"HP: {HP}" + Environment.NewLine);
            sb.Append(@$"MP: {MP}" + Environment.NewLine);
            sb.Append(@$"Location: {Location}" + Environment.NewLine);

            return sb.ToString();
        }

    }
}
