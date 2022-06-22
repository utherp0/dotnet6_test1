using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using test1.Models;
using test1.Services;

[BindProperty]
public Cat NewCat { get; set;} = new();

namespace test1.Pages
{
  public class CatModel : PageModel
  {
    public List<Cat> cats = new();

    public void OnGet()
    {
      cats = CatService.GetAll();
    }

    public IActionResults OnPost()
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
      CatService.delete(name);
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
