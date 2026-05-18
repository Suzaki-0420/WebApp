using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
/// <summary>
/// リスト5-2 PRGパターンとTempDataの利用
/// </summary>
[Route("PRG")]
public class PRGController : Controller
{
    /// <summary>
    /// 入力画面を出力する
    /// </summary>
    /// <returns></returns>
    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        var form = new PRGForm();
        return View(form);
    }

    [HttpPost("Submit")]
    public IActionResult Submit(PRGForm form)
    {
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        ILogger logger = loggerFactory.CreateLogger("PRGController");
        logger.LogInformation("[送信]ボタンクリック!!!");

        //バリデーションチェック＝不正なものが入っていたらエラーを返す
        if (!ModelState.IsValid)
        {
            return View("Enter", form); //エラーだったら入力画面に戻る
        }
        //以下正常系
        TempData["PRGForm"] = JsonSerializer.Serialize(form);
        return RedirectToAction("Result");
    }

    /// <summary>
    /// [送信]ボタンクリック
    /// </summary>
    /// <param name="form">PRGForm</param>
    /// <returns></returns>
    [HttpGet("Result")]
    public IActionResult Result()
    {
        var json = (string)TempData["PRGForm"]!;
        if (string.IsNullOrEmpty(json))
        {
            return RedirectToAction("Enter"); //何も入ってなかったら入力画面にリダイレクト
        }

        var form = JsonSerializer.Deserialize<PRGForm>(json!);
        form!.Length = form.Text?.Length ?? 0;
        return View(form);
    }

    /// <summary>
    /// [戻る]ボタンクリックに対するアクション
    /// </summary>
    /// <returns></returns>
    [HttpGet("Back")]
    public IActionResult Back()
    {
        // 入力画面を出力するアクションメソッドにリダイレクトする
        return RedirectToAction("Enter");
    }
}