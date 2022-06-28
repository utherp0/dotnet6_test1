using test1.Models;

namespace test1.Services;

public static class CatService
{
  static List<Cat> Cats { get; }

  static CatService()
  {
    Cats = new List<Cat>
    {
      new Cat { Name = "Winnie", Age = 11, AllowedOutside = false },
      new Cat { Name = "Molly", Age = 12, AllowedOutside = true },
      new Cat { Name = "Dexter", Age = 10, AllowedOutside = true },
      new Cat { Name = "Kali", Age = 9, AllowedOutside = false },
      new Cat { Name = "Jessie", Age = 7, AllowedOutside = true },
      new Cat { Name = "Murphy", Age = 7, AllowedOutside = false }
    };
  }

  public static List<Cat> GetAll() => Cats;

  public static Cat Get( string name ) => Cats.FirstOrDefault(target => target.Name == name );

  public static void Add( Cat cat )
  {
    Cats.Add(cat);
  }

  public static void Delete( string name )
  {
    var cat = Get( name );
    if( name is null )
      return;

    Cats.Remove( cat );
  }

  public static void Update( Cat cat )
  {
    var exists = Cats.FindIndex( target => target.Name == cat.Name );
    if( exists == -1 )
      return;

    Cats[exists] = cat;
  }
}
