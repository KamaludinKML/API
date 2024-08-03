// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Configuration;
// using System.Data;

// [Route("api/[controller]")]
// [ApiController]

// public class ProduksiController: ControllerBase
// { 
//     private readonly DbManager _dbManager;
//     Response respone = new Response();

//     public ProduksiController(IConfiguration configuration)
//     {
//         _dbManager = new DbManager(configuration);
//     }

//     //Get 
//     [HttpGet]
//     public IActionResult GetProduksi()
//     {
//         try 
//         {
//             Response.Status = 200;
//             Response.message = "Succes";
//             respone.data = _dbManager.GetAllProduksi();
//         }
//         catch (Exception ex)
//         {
//             Response.Status = 500;
//             Response.message = ex.Message;
//         }
//         return Ok(response);
//     }
// }