using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            Category = _context.Categories.Find(id);
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(Category);   
                _context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
