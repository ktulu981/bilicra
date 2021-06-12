using System.Linq;
using System.Threading.Tasks;
using bilicra.dataaccess;
using bilicra.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bilicra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase{

private readonly Datacontext _context;
        public ProductsController(Datacontext context)
        {
            _context=context;
        }


        [HttpGet]
        public async Task<ActionResult> GetAsync(){


            return Ok(await _context.Products.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Product model){
           
           if( _context.Products.Any(x=>x.Code==model.Code)){
               throw new System.Exception("Product code must be unique");
           }

           if(!ModelState.IsValid)
           throw new System.Exception("Model is not valid");

           await _context.Products.AddAsync(model);
           await _context.SaveChangesAsync();
           
            return Ok();
        }

        [HttpPut("{id}")]
            public async Task<ActionResult> UpdateAsync(int id,Product model){
           
          var product=await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);

          if(product==null)
          throw new System.Exception("Product not found");

          if(!ModelState.IsValid)
           throw new System.Exception("Model is not valid");

          product.Name=model.Name;
          product.Code=model.Code;
          product.Photo=model.Photo;
          product.Price=model.Price;
          product.LastUpdated=System.DateTime.UtcNow;
           await _context.SaveChangesAsync();
           
            return Ok();
        }


    [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteAsync(int id){
           
          var product=await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);

          if(product==null)
          throw new System.Exception("Product not found");

           _context.Products.Remove(product);
           await _context.SaveChangesAsync();
           
            return NoContent();
        }

    }
    

}