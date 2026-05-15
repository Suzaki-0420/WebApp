using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Models;

[Route("Exercise09")]//リンク設定
public class Ex09Controller : Controller
{
    // /FormSample/Enterにアクセスされたらcshtmlのformを返す
    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        var form = new Exercise07Form();
        return View(form);
    }

    //送信ボタンが押されたとき→/FormSample/Resultにアクセス
    [HttpPost("Result")]
    public IActionResult Result(Exercise07Form form)
    {
        if (!ModelState.IsValid)
        {
            // バリデーションエラーの場合は入力画面に遷移する
            return View("Enter", form);
        }
        //正常だったら足し算した答えを入れたformを返す
        form.Answer = form.value1 + form.value2;
        return View(form);
    }

    [HttpGet("Back")]
    public IActionResult Back()
    {
        var form = new Exercise07Form();
        return View("Enter", form);
    }
}
