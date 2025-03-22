using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

class Program
{
    static async Task Main()
    {
        try
        {

        // Ödeme bilgilerini XML olarak oluştur
        XDocument xmlData = new XDocument(
            new XElement("payment",
                new XElement("uuid", Guid.NewGuid().ToString()),
                new XElement("merchantid", "test_merchant"), 
                new XElement("amount", 10),
                new XElement("order_id", 9876),
                new XElement("description", "Entegrasyon Testi"),
                new XElement("lang", "ru"),
                new XElement("method", "bpay"),
                new XElement("success_url", "https://bpay.md/success"),
                new XElement("fail_url", "https://bpay.md/fail"),
                new XElement("callback_url", "https://bpay.md/callback"),
                new XElement("valute", 498),
                new XElement("dtime", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")),
                new XElement("getUrl", "1"),
                new XElement("params",
                    new XElement("type_of_payer", "main"),
                    new XElement("info", "test bilgisi"),
                    new XElement("invoice",
                        new XElement("item",
                            new XElement("id", 156),
                            new XElement("name", "cep telefonu"),
                            new XElement("model", "iphone 8+"),
                            new XElement("sum", 800)
                        ),
                        new XElement("item",
                            new XElement("id", 556),
                            new XElement("name", "TV Philips"),
                            new XElement("model", "K223AA2200"),
                            new XElement("sum", 300)
                        )
                    )
                )
            )
        );

        // XML verisini Base64 formatına çevir
        string xmlString = xmlData.ToString();
        string base64Data = Convert.ToBase64String(Encoding.UTF8.GetBytes(xmlString));

        // Dijital imza oluştur (SHA-256)
        string signatureKey = "imza_anahtarınız";  // Kendi imza anahtarınızı girin
        string key = ComputeSha256Hash(base64Data + signatureKey);

        // HTTP POST isteği gönder
        using HttpClient client = new();
        var requestData = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("data", base64Data),
            new KeyValuePair<string, string>("key", key)
        });

        HttpResponseMessage response = await client.PostAsync("https://pay.bpay.md/merchant", requestData);
        string responseContent = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"Sunucu Yanıtı: {responseContent}");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    // SHA-256 ile imza oluşturma fonksiyonu
    static string ComputeSha256Hash(string rawData)
    {
        using SHA256 sha256Hash = SHA256.Create();
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
        StringBuilder builder = new();
        foreach (byte b in bytes)
        {
            builder.Append(b.ToString("x2"));
        }
        return builder.ToString();
    }
}
