using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatagoryAPi.Models;

namespace ProductCatagoryAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategorysController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProductCategorysController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>>GetProductCategorys()
        {
            return await _db.ProductCategories.Include(pc => pc.Products).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategory(int id)
        {
            var productCategory = await _db.ProductCategories.Include(pc => pc.Products).SingleOrDefaultAsync(pc => pc.ProductCategoryID == id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return Ok( productCategory);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        { 
        var productCategory=await _db.ProductCategories.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            _db.ProductCategories.Remove(productCategory);
            await _db.SaveChangesAsync();
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory productCategory)
        {
            _db.ProductCategories.Add(productCategory);
            await _db.SaveChangesAsync();
            return CreatedAtAction("GetProductCategory", new { id = productCategory.ProductCategoryID }, productCategory );
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutProductCategory(int id, ProductCategory productCategory)
        {
            if (id != productCategory.ProductCategoryID)
                return BadRequest("ProductCategoryID Mismatch");
            _db.Entry(productCategory).State=EntityState.Modified;
            foreach (var products in productCategory.Products)
            {
                if (products.ProductID != 0)
                {
                    _db.Entry(products).State = EntityState.Modified;
                }
                else
                { 
                _db.Entry(products).State=EntityState.Added;
                }
            }
            var idsOfProducts = productCategory.Products.Select(s => s.ProductID).ToList();
            var productIdtoDelete = await _db.Products.Where(s => !idsOfProducts.Contains(s.ProductID) && s.ProductCategoryID == productCategory.ProductCategoryID).ToListAsync();
            if (productIdtoDelete.Count > 0)
            {
                _db.Products.RemoveRange(productIdtoDelete);
            }
            await _db.SaveChangesAsync();
            return NotFound();
        }
       
    }
}
