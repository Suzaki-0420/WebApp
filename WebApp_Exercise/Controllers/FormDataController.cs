using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Models;

[Route("Form")]
public class FormDataControllor : Controller
{
    [HttpPost("Enter")]
    public IActionResult InputData(SampleForm form)
    {
        return Content($"氏名:{form.Name} , 年齢:{form.Age}");
    }
}