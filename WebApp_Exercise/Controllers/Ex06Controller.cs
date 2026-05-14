using Microsoft.AspNetCore.Mvc;

[Route("Exercise04")]
public class Ex06Controllor : Controller
{
    [HttpGet("Param/{value1}/{value2}")]
    public IActionResult Calc(int value1, int value2)
    {
        if (!ModelState.IsValid) //型変換エラーが出たとき
        {
            //valid1、2のどちらかなのか、両方なのかを場合分け
            if ((ModelState["value1"]?.Errors.Count ?? 0) > 0
            && (ModelState["value2"]?.Errors.Count ?? 0) > 0)
            {
                return Content("value1とvalue2は整数ではありません。");
            }

            if ((ModelState["value1"]?.Errors.Count ?? 0) > 0)
            {
                return Content("value1は整数ではありません。");
            }

            if ((ModelState["value2"]?.Errors.Count ?? 0) > 0)
            {
                return Content("value2は整数ではありません。");
            }
        }
        return Content($"{value1}+{value2}={value1 + value2}");
    }
}