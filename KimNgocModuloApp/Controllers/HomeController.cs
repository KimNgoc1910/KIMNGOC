using Microsoft.AspNetCore.Mvc;

namespace ModuloApp.Controllers
{
    public class HomeController : Controller
    {
        // Hàm tính nghịch đảo modulo sử dụng thuật toán Euclid mở rộng
        public static int InverseModulo(int a, int b)//m=b
{
    if (b == 0)
    {
        throw new ArgumentException("Modulo không thể bằng 0.");
    }

    int m0 = b, t, q;
    int x0 = 0, x1 = 1;

    // Kiểm tra nếu a và m không có nghịch đảo modulo
    if (a == 0)
    {
        throw new ArgumentException("Số a không thể bằng 0 khi tính nghịch đảo modulo.");
    }

    while (a > 1)
    {
        // Điều kiện chia cho 0 nếu m = 0
        if (b == 0)
        {
            throw new DivideByZeroException("Mẫu số không thể bằng 0 trong quá trình tính nghịch đảo.");
        }

        q = a / b;
        t = b;

        b = a % b;
        a = t;

        t = x0;
        x0 = x1 - q * x0;
        x1 = t;
    }

    if (x1 < 0)
        x1 += m0;

    return x1;
}


        // Hàm tính số âm modulo
        public static int NegativeModulo(int a, int b)
        {
            return ((a % b) + b) % b;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
public IActionResult Calculate(int number, int modulo)
{
    try
    {
        // Kiểm tra và hiển thị giá trị nhập vào
        Console.WriteLine($"Số nhập vào: {number}, Modulo nhập vào: {modulo}");

        // Kiểm tra nếu modulo bằng 0
        if (modulo == 0)
        {
            ViewData["Result"] = "Modulo không thể bằng 0.";
            return View("Index");
        }

        // Tính nghịch đảo modulo
        int inverse = InverseModulo(number, modulo);
        // Tính số âm modulo
        int negativeMod = NegativeModulo(number, modulo);

        ViewData["Result"] = $"<br/>Nghịch đảo modulo của {number} mod {modulo} là {inverse}.<br/>" +
                              $"Số âm modulo của {number} mod {modulo} là {negativeMod}.";
    }
    catch (Exception ex)
    {
        ViewData["Result"] = "Nghịch Đảo Không Tồn Tại : " + ex.Message;
    }

    return View("Index");
}

    }
}
