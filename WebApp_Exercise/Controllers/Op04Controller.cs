using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Models;

[Route("Option04")]//リンク設定
public class Op04Controller : Controller
{
    // /FormSample/Enterにアクセスされたらcshtmlのformを返す
    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        var form = new Op03Form();
        return View(form);
    }

    //送信ボタンが押されたとき→/FormSample/Resultにアクセス
    [HttpPost("Result")]
    public IActionResult Result(Op03Form form)
    {
        if (!ModelState.IsValid)
        {
            // バリデーションエラーの場合は入力画面に遷移する
            return View("Enter", form);
        }

        //それぞれの計算方法で返す
        if (form.opt == 1)
        {
            form.Answer = form.value1 + form.value2;
        }
        else if (form.opt == 2)
        {
            form.Answer = form.value1 - form.value2;
        }
        else if (form.opt == 3)
        {
            form.Answer = form.value1 * form.value2;
        }
        else if (form.opt == 4)
        {
            form.Answer = form.value1 / form.value2;
        }
        else if (form.opt == 5)
        {
            form.Answer = form.value1 % form.value2;
        }
        return View(form);
    }

    [HttpGet("Back")]
    public IActionResult Back(Op03Form form)
    {
        return View("Enter", form);
    }
}
