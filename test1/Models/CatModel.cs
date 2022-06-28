using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using test1.Models;
using test1.Services;

namespace test1.Pages
{
  [BindProperties]
  public class CatModel : PageModel
  {
    public Cat NewCat { get; set;} = new();

    public List<Cat> cats = CatService.GetAll();

    public void OnGet()
    {
      cats = CatService.GetAll();
    }

    public IActionResult OnPost()
    {
      if( !ModelState.IsValid)
      {
        return Page();
      }
    
      CatService.Add(NewCat);
      return RedirectToAction("Get");
    }

    public IActionResult OnPostDelete(string name)
    {
      CatService.Delete(name);
      return RedirectToAction("Get");
    }

    public string AllowedOutsideText( Cat cat )
    {
      if( cat.AllowedOutside)
        return "Allowed to go out.";

      return "Keep the door closed!";
    }
  }
}
