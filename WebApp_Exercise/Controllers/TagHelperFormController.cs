using Microsoft.AspNetCore.Mvc;

[Route("FormSample")]//リンク設定
public class TagHelperFormController : Controller
{
    // /FormSample/Enterにアクセスされたらcshtmlのformを返す
    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        var form = new SampleForm();
        return View(form);
    }

    //送信ボタンが押されたとき→/FormSample/Resultにアクセス
    [HttpPost("Result")]
    public IActionResult Result(SampleForm form)
    {
        if (!ModelState.IsValid)
        {
            // バリデーションエラーの場合は入力画面に遷移する
            return View("Enter", form);
        }
        return View(form);
    }

    [HttpPost("Back")]
    public IActionResult Back(SampleForm form)
    {
        return View("Enter", form);
    }
}
