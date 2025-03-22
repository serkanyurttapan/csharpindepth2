
using System.Text;
using Newtonsoft.Json;

class Program
{
    private static readonly string TrustPayApiBase = "https://api.trustpay.eu/v1";
    private static readonly string ApiKey = "YOUR_API_KEY"; // Buraya kendi API Key'ini eklemelisin.
    
    static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");

        // 1. Kart Bilgilerini Kaydetme ve CardID Alma
        string cardId = await RegisterCard(client);
        if (string.IsNullOrEmpty(cardId))
        {
            Console.WriteLine("Kart kaydedilemedi!");
            return;
        }

        Console.WriteLine($"Kart başarıyla kaydedildi! CardID: {cardId}");

        // 2. Kayıtlı Kart ile Ödeme Yapma
        bool paymentSuccess = await MakePayment(client, cardId);
        Console.WriteLine(paymentSuccess ? "Ödeme başarılı!" : "Ödeme başarısız!");
    }

    // Kart Bilgilerini Kaydetme ve CardID Alma
    private static async System.Threading.Tasks.Task<string> RegisterCard(HttpClient client)
    {
        var requestData = new
        {
            cardNumber = "4111111111111111",
            cardExpiryMonth = "12",
            cardExpiryYear = "2026",
            cardHolderName = "Serkan Yurttapan",
            cvc = "123"
        };

        var response = await client.PostAsync($"{TrustPayApiBase}/cards/register",
            new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode) return null;

        var responseData = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
        return responseData?.cardId;
    }

    // CardID Kullanarak Ödeme Yapma
    private static async System.Threading.Tasks.Task<bool> MakePayment(HttpClient client, string cardId)
    {
        var requestData = new
        {
            amount = 1000, // 10.00 EUR
            currency = "EUR",
            cardId = cardId,
            description = "Test Ödemesi"
        };

        var response = await client.PostAsync($"{TrustPayApiBase}/payments",
            new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json"));

        return response.IsSuccessStatusCode;
    }
}


 