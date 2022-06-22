using System.ComponentModel.DataAnnotations;

namespace test1.Models
{
  public class Cat
  {
    public string Name { get; set; }

    [Required]
    public string? Colour { get; set; }
    public bool AllowedOutside { get; set; }

    [Range(1,25)]
    public int Age { get; set; }
  }

  public enum CatColours { Ginger, Tabby, Grey, Torty }
}
