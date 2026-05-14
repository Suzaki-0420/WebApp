using Microsoft.AspNetCore.Mvc;

[Route("Exercise03")]
public class Ex03Controller : Controller //Controllorを継承
{
    [HttpGet("Morning")]
    public IActionResult Goodmorning()
    {
        return Content("おはようございます");
    }

    [HttpGet("Evening")]
    public IActionResult GoodEvening()
    {
        return Content("こんばんは");
    }
}