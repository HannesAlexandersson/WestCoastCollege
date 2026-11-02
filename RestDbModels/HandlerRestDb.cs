using System;
using WestCoastCollege.Models;

namespace WestCoastCollege.RestDbModels;

public record HandlerRestDb : Handler
{
    public string _id { get; set; } = string.Empty;
}
