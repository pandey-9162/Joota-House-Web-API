using Microsoft.AspNetCore.Mvc;
using ContosoShoe.models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ContosoShoe.DataAccess;


namespace ContosoShoe.Controllers

{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : Controller
    {
        [HttpGet]
        public IResult Get()
        {
            ProductRepository repo = new ProductRepository();
            IList<CategoryCount> categoryCounts = repo.getbyCategory();  

            if (categoryCounts == null || categoryCounts.Count == 0)
            {
                return Results.NotFound("No categories found.");
            }

            return Results.Ok(categoryCounts);
        }


    }
}
