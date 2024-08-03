using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;

[Route("api/[controller]")]
[ApiController]

public class UserController: ControllerBase
{ 
    private readonly DbManager _dbManager;
    Response response = new Response();

    public UserController(IConfiguration configuration)
    {
        _dbManager = new DbManager(configuration);
    }

    //Get 
    [HttpGet]
    public IActionResult GetUser()
    {
        try 
        {
            response.status = 200;
            response.message = "Succes";
            response.data = _dbManager.GetAllUser();
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }
}