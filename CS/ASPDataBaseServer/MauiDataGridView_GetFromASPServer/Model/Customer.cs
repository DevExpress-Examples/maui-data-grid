using System;
using System.Text.Json.Serialization;

namespace MauiDataGridView_GetFromASPServer.Model
{
    public class Customer
    {
        [JsonPropertyName("id")] public int ID { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("birthDate")] public DateTime BirthDate { get; set; }
        [JsonPropertyName("favoriteStore")] public string FavoriteStore { get; set; }
        [JsonPropertyName("phone")] public string Phone { get; set; }
        [JsonPropertyName("registered")] public bool Registered { get; set; }
        [JsonPropertyName("photo")] public string Photo { get; set; }

        public ImageSource Image
        {
            get
            {
                byte[] bytes = Convert.FromBase64String(Photo);
                MemoryStream ms = new MemoryStream(bytes);
                return ImageSource.FromStream(() => ms);
            }
        }
    }
}

