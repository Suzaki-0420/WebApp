using Microsoft.AspNetCore.Mvc;

[Route("Option02")]
public class Op02Controller : Controller
{
    [HttpGet("Calc/{value1}/{value2}/{opt}")]
    public IActionResult Calc(int value1, int value2, int opt)
    {
        if (opt == 1)
        {
            return Content($"{value1}+{value2}={value1 + value2}");
        }
        else if (opt == 2)
        {
            return Content($"{value1}-{value2}={value1 - value2}");
        }
        else if (opt == 3)
        {
            return Content($"{value1}×{value2}={value1 * value2}");
        }
        else if (opt == 4)
        {
            return Content($"{value1}÷{value2}={value1 / value2}");
        }
        else
        {
            return Content("不明な計算種別です");
        }
    }
}