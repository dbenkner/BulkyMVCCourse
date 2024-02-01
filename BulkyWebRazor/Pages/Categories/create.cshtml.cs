using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyWebRazor.Pages.Categories
{
    [BindProperties]
    public class createModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Category Category { get; set; }
        public createModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            Category = _context.Categories.Find(id);
            int i = 0;
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
