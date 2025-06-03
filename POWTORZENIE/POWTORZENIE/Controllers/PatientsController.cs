using Microsoft.AspNetCore.Mvc;
using POWTORZENIE.DTOs;
using POWTORZENIE.Exceptions;
using POWTORZENIE.Services;

namespace POWTORZENIE.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientsController(IDbService service) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentsDetails([FromRoute] int id)
    {
        try
        {
            return Ok(await service.GetPatientDetailsByIdAsync(id));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] PrescriptionCreateDTO prescription)
    {
        try
        {
            await service.CreatePrescriptionAsync(prescription);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        return Ok();
    }
}