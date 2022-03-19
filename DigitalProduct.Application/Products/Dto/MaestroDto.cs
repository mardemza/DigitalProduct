﻿using System.Text.Json.Serialization;

namespace DigitalProduct.Application.Products.Dto;

public class MaestroDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("gender")]
    public string Gender { get; set; }
    [JsonPropertyName("status")]
    public string Status { get; set; }
}

