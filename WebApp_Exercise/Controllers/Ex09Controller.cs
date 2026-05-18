using System.Text.Json;
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
    [HttpGet("Result")]
    public IActionResult Result()
    {
        // TempDataからERxercise07Formを取り出す
        string? json = (string)TempData["Exercise07Form"]!;
        if (string.IsNullOrEmpty(json))
        {
            // TempDataにExercise07Formが無い場合、入力画面表示にリダイレクトする
            return RedirectToAction("Enter");
        }
        // 存在する場合はデシリアライズする
        var form = JsonSerializer.Deserialize<Exercise07Form>(json);
        form!.Answer = form.value1 + form.value2;
        return View(form);
    }

    [HttpGet("Back")]
    public IActionResult Back()
    {
        return RedirectToAction("Enter");
    }

    [HttpPost("Calc")]
    public IActionResult Calc(Exercise07Form form)
    {
        // バリデーションチェック
        if (!ModelState.IsValid)
        {
            // バリデーションエラーの場合入力画面を表示する
            return View("Enter", form);
        }
        // Exercise07Formをシリアライズする
        var json = JsonSerializer.Serialize(form);
        // TempDataに登録する
        TempData["Exercise07Form"] = json;
        // 計算結果を表示するResultへリダイレクトする
        return RedirectToAction("Result");
    }
}
