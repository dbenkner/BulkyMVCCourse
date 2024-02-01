using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public void OnGet(int? id)
        {
            Category = _context.Categories.Find(id);
        }
        public IActionResult OnPost()
        {
            _context.Categories.Remove(Category);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
