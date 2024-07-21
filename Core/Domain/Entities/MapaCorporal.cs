using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Domain.Entities;

public class MapaCorporal
{
    public int MapaCorporalId { get; set; }

    [JsonProperty("valorx")]
    public List<int> ValorX { get; set; }

    [JsonProperty("rangodolor")]
    public List<int> RangoDolor { get; set; }

    public string Nota { get; set; } = null!;

    public int DiagnosticoId { get; set; }

    public virtual Diagnostico? Diagnostico { get; set; }
}
