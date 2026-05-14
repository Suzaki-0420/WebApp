using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Models;

[Route("Option03")]
public class Option03Controller : Controller
{
    [HttpPost("Calc")]
    public IActionResult Calc(Op03Form form)
    {
        if (form.opt == 1)
        {
            return Content($"{form.value1}+{form.value2}={form.value1 + form.value2}");
        }
        else if (form.opt == 2)
        {
            return Content($"{form.value1}-{form.value2}={form.value1 - form.value2}");
        }
        else if (form.opt == 3)
        {
            return Content($"{form.value1}×{form.value2}={form.value1 * form.value2}");
        }
        else if (form.opt == 4)
        {
            return Content($"{form.value1}÷{form.value2}={form.value1 / form.value2}");
        }
        else if (form.opt == 5)
        {
            return Content($"{form.value1}&{form.value2}={form.value1 & form.value2}");
        }
        return Content("不明な計算種別です");
    }
}