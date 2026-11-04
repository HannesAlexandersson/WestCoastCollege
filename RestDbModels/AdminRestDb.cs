using WestCoastCollege.Models;

namespace WestCoastCollege.RestDbModels;

public record AdminRestDb : Admin
{
    public string _id { get; set; } = string.Empty;
}
