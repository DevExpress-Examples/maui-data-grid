using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ASPDataBaseServer.Model {
    public class Customer {
        [JsonPropertyName("id")] public int ID { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("birthDate")] public DateTime BirthDate { get; set; }
        [JsonPropertyName("favoriteStore")] public string FavoriteStore { get; set; }
        [JsonPropertyName("phone")] public string Phone { get; set; }
        [JsonPropertyName("registered")] public bool Registered { get; set; }
        [JsonPropertyName("photo")] public string Photo { get; set; }
    }
}
