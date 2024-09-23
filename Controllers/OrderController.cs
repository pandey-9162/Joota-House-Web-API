using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContosoShoe.DataAccess;
using ContosoShoe.models;


namespace ContosoShoe.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public async Task<IResult> PastOrder()
        {
            ProductRepository repo = new ProductRepository(); ;

            var pastOrder = await repo.PastOrders();

            return Results.Ok(pastOrder);

        }
    }
}
