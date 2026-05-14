using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Models;

[Route("Exercise07")]
public class Ex07Controller : Controller
{
    [HttpPost("Calc")]
    public IActionResult Inputdata(Exercise07Form form)
    {
        return Content($"{form.value1}+{form.value2}={form.value1 + form.value2}");
    }
}