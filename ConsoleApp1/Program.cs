// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.Json.Serialization;
using ConsoleApp1;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;


// var client = new HttpClient();
// var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sandbox.deepstack.io/api/v1/payments/charge");
// request.Headers.Add("hmac", "c2tfdGVzdF9kMzc1NmFlZS03MDRjLTQzYTgtYjhlYi0wZGY2OWY0YWE1MGV8UE9TVHwyMDI0LTA5LTEwVDE5OjU4OjQ2LjA0M1p8NzAzZmFhMjEtMTAyMy00N2E5LWJjYmMtMzBiZTdjNzhlMTdhfHYyRC9TOGQxNHpVV3NtT2V2WVUySmRBUzJ1c0xKZmNQQWlwNStDSUhzMjQ9");
// var content = new StringContent("{\n  \"source\": {\n    \"type\": \"credit_card\",\n    \"credit_card\": {\n      \"account_number\": \"4111111111111111\",\n      \"expiration\": \"0929\",\n      \"cvv\": \"999\"\n    },\n    \"billing_contact\": {\n      \"first_name\": \"serkan\",\n      \"last_name\": \"kürttapan\",\n      \"address\": {\n        \"line_1\": \"2500 Northwest 107th Avenue\",\n        \"line_2\": \"\",\n        \"city\": \"Doral\",\n        \"state\": \"FL\",\n        \"postal_code\": \"33172\",\n        \"country_code\": \"USA\"\n      },\n      \"phone\": \"16644684845\",\n      \"email\": \"ustest@mobil.com\"\n    }\n  },\n  \"transaction\": {\n    \"amount\": 500,\n    \"cof_type\": \"UNSCHEDULED_CARDHOLDER\",\n    \"capture\": true,\n    \"currency_code\": \"USD\",\n    \"avs\": false,\n    \"save_payment_instrument\": false\n  },\n  \"meta\": {\n    \"client_customer_id\": \"12885847\",\n    \"client_transaction_id\": null,\n    \"client_transaction_description\": \"Farmasi Product\",\n    \"client_invoice_id\": null,\n    \"shipping_info\": {\n      \"first_name\": \"Pinar\",\n      \"last_name\": \"Test \",\n      \"address\": {\n        \"line_1\": \"2500 Northwest 107th Avenue\",\n        \"line_2\": \"\",\n        \"city\": \"Doral\",\n        \"state\": \"FL\",\n        \"postal_code\": \"33172\",\n        \"country_code\": \"USA\"\n      },\n      \"phone\": \"16644684845\",\n      \"email\": \"ustest@mobil.com\"\n    },\n    \"cardholder_ip_address\": \"123.2.3.6\"\n  }\n}", null, "application/json");
// request.Content = content;
// var response = await client.SendAsync(request);
// response.EnsureSuccessStatusCode();
// Console.WriteLine(await response.Content.ReadAsStringAsync());
var appId = "sk_live_01089cdc-9e10-4e42-8021-4f98";
var requestMethod = "POST";
var sharedSecret = "yfWdnedFgI5GasgNmHHgH9URxFWAICa5BZ3cHRKxHFI=";

var client =new HttpClient();
var url = "https://api.deepstack.io/api/v1/payments/charge";

//client.DefaultRequestHeaders.Add("Content-Type", "application/json");
// client.DefaultRequestHeaders.Add("hmac", "c2tfdGVzdF9kMzc1NmFlZS03MDRjLTQzYTgtYjhlYi0wZGY2OWY0YWE1MGV8UE9TVHwyMDI0LTA5LTEwVDE5OjU4OjQ2LjA0M1p8NzAzZmFhMjEtMTAyMy00N2E5LWJjYmMtMzBiZTdjNzhlMTdhfHYyRC9TOGQxNHpVV3NtT2V2WVUySmRBUzJ1c0xKZmNQQWlwNStDSUhzMjQ9");

var paymentRequest = new PaymentRequest
        {
            Source = new Source
            {
                Type = "credit_card",
                CreditCard = new CreditCard
                {
                    AccountNumber = "5178058680337220",
                    Expiration = "0726",
                    Cvv = "980"
                },
                BillingContact = new BillingContact
                {
                    FirstName = "Ozan",
                    LastName = "Ercan",
                    Address = new Address
                    {
                        Line1 = "2500 Northwest 107th Avenue",
                        Line2 = "",
                        City = "Doral",
                        State = "FL",
                        PostalCode = "33172",
                        CountryCode = "USA"
                    },
                    Phone = "16644684845",
                    Email = "ustest@mobil.com"
                }
            },
            Transaction = new Transaction
            {
                Amount = 100,
                CofType = "UNSCHEDULED_CARDHOLDER",
                Capture = true,
                CurrencyCode = "USD",
                Avs = false,
                SavePaymentInstrument = false
            },
            Meta = new Meta
            {
                ClientCustomerId = "12885847",
                ClientTransactionDescription = "Farmasi Product",
                ClientInvoiceId = "212123123",
                ShippingInfo = new ShippingInfo
                {
                    FirstName = "Pinar",
                    LastName = "Test ",
                    Address = new Address
                    {
                        Line1 = "2500 Northwest 107th Avenue",
                        Line2 = "",
                        City = "Doral",
                        State = "FL",
                        PostalCode = "33172",
                        CountryCode = "USA"
                    },
                    Phone = "16644684845",
                    Email = "ustest@mobil.com"
                },
                CardholderIpAddress = "123.2.3.6"
            }
        };
var js =
    "{\n  \"source\": {\n    \"type\": \"credit_card\",\n    \"credit_card\": {\n      \"account_number\": \"4111111111111111\",\n      \"expiration\": \"0929\",\n      \"cvv\": \"999\"\n    },\n    \"billing_contact\": {\n      \"first_name\": \"serkan\",\n      \"last_name\": \"kürttapan\",\n      \"address\": {\n        \"line_1\": \"2500 Northwest 107th Avenue\",\n        \"line_2\": \"\",\n        \"city\": \"Doral\",\n        \"state\": \"FL\",\n        \"postal_code\": \"33172\",\n        \"country_code\": \"USA\"\n      },\n      \"phone\": \"16644684845\",\n      \"email\": \"ustest@mobil.com\"\n    }\n  },\n  \"transaction\": {\n    \"amount\": 500,\n    \"cof_type\": \"UNSCHEDULED_CARDHOLDER\",\n    \"capture\": true,\n    \"currency_code\": \"USD\",\n    \"avs\": false,\n    \"save_payment_instrument\": false\n  },\n  \"meta\": {\n    \"client_customer_id\": \"12885847\",\n    \"client_transaction_id\": null,\n    \"client_transaction_description\": \"Farmasi Product\",\n    \"client_invoice_id\": null,\n    \"shipping_info\": {\n      \"first_name\": \"Pinar\",\n      \"last_name\": \"Test \",\n      \"address\": {\n        \"line_1\": \"2500 Northwest 107th Avenue\",\n        \"line_2\": \"\",\n        \"city\": \"Doral\",\n        \"state\": \"FL\",\n        \"postal_code\": \"33172\",\n        \"country_code\": \"USA\"\n      },\n      \"phone\": \"16644684845\",\n      \"email\": \"ustest@mobil.com\"\n    },\n    \"cardholder_ip_address\": \"123.2.3.6\"\n  }\n}";
         
// var content = new StringContent("{\n  \"source\": {\n    \"type\": \"credit_card\",\n    \"credit_card\": {\n      \"account_number\": \"4111111111111111\",\n      \"expiration\": \"0929\",\n      \"cvv\": \"999\"\n    },\n    \"billing_contact\": {\n      \"first_name\": \"serkan\",\n      \"last_name\": \"kürttapan\",\n      \"address\": {\n        \"line_1\": \"2500 Northwest 107th Avenue\",\n        \"line_2\": \"\",\n        \"city\": \"Doral\",\n        \"state\": \"FL\",\n        \"postal_code\": \"33172\",\n        \"country_code\": \"USA\"\n      },\n      \"phone\": \"16644684845\",\n      \"email\": \"ustest@mobil.com\"\n    }\n  },\n  \"transaction\": {\n    \"amount\": 500,\n    \"cof_type\": \"UNSCHEDULED_CARDHOLDER\",\n    \"capture\": true,\n    \"currency_code\": \"USD\",\n    \"avs\": false,\n    \"save_payment_instrument\": false\n  },\n  \"meta\": {\n    \"client_customer_id\": \"12885847\",\n    \"client_transaction_id\": null,\n    \"client_transaction_description\": \"Farmasi Product\",\n    \"client_invoice_id\": null,\n    \"shipping_info\": {\n      \"first_name\": \"Pinar\",\n      \"last_name\": \"Test \",\n      \"address\": {\n        \"line_1\": \"2500 Northwest 107th Avenue\",\n        \"line_2\": \"\",\n        \"city\": \"Doral\",\n        \"state\": \"FL\",\n        \"postal_code\": \"33172\",\n        \"country_code\": \"USA\"\n      },\n      \"phone\": \"16644684845\",\n      \"email\": \"ustest@mobil.com\"\n    },\n    \"cardholder_ip_address\": \"123.2.3.6\"\n  }\n}", null, "application/json");

JObject jsonObject = JObject.Parse(JsonSerializer.Serialize(paymentRequest));
string formattedJson = jsonObject.ToString(Formatting.Indented);
var content = new StringContent(formattedJson, null, "application/json");
string hmacHeader = HmacUtility.CreateHmacHeader(formattedJson, sharedSecret, appId, requestMethod);
client.DefaultRequestHeaders.Add("hmac", hmacHeader);

var response = await client.PostAsync(url, content);

var responseContent = await response.Content.ReadAsStringAsync();
Console.WriteLine(responseContent);

string encodedString1 = "c2tfdGVzdF9kMzc1NmFlZS03MDRjLTQzYTgtYjhlYi0wZGY2OWY0YWE1MGV8UE9TVHwyMDI0LTA5LTEwVDE5OjU4OjQ2LjA0M1p8NzAzZmFhMjEtMTAyMy00N2E5LWJjYmMtMzBiZTdjNzhlMTdhfHYyRC9TOGQxNHpVV3NtT2V2WVUySmRBUzJ1c0xKZmNQQWlwNStDSUhzMjQ9";
string encodedString2 = hmacHeader;

// Base64 decode
byte[] data1 = Convert.FromBase64String(encodedString1);
string decodedString1 = Encoding.UTF8.GetString(data1);

byte[] data2 = Convert.FromBase64String(encodedString2);
string decodedString2 = Encoding.UTF8.GetString(data2);

// Decoded sonuçları yazdırma
Console.WriteLine($"Decoded String 1: {decodedString1}");
Console.WriteLine($"Decoded String 2: {decodedString2}");
Console.ReadKey();


        
public class PaymentRequest
{
    [JsonPropertyName("source")]
    public Source Source { get; set; }

    [JsonPropertyName("transaction")]
    public Transaction Transaction { get; set; }

    [JsonPropertyName("meta")]
    public Meta Meta { get; set; }
}

public class Source
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("credit_card")]
    public CreditCard CreditCard { get; set; }

    [JsonPropertyName("billing_contact")]
    public BillingContact BillingContact { get; set; }
}

public class CreditCard
{
    [JsonPropertyName("account_number")]
    public string AccountNumber { get; set; }

    [JsonPropertyName("expiration")]
    public string Expiration { get; set; }

    [JsonPropertyName("cvv")]
    public string Cvv { get; set; }
}

public class BillingContact
{
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("address")]
    public Address Address { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }
}
public class Address
{
    [JsonPropertyName("line_1")]
    public string Line1 { get; set; }

    [JsonPropertyName("line_2")]
    public string Line2 { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("postal_code")]
    public string PostalCode { get; set; }

    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }
}

public class Transaction
{
    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    [JsonPropertyName("cof_type")]
    public string CofType { get; set; }

    [JsonPropertyName("capture")]
    public bool Capture { get; set; }

    [JsonPropertyName("currency_code")]
    public string CurrencyCode { get; set; }

    [JsonPropertyName("avs")]
    public bool Avs { get; set; }

    [JsonPropertyName("save_payment_instrument")]
    public bool SavePaymentInstrument { get; set; }
}
public class Meta
{
    [JsonPropertyName("client_customer_id")]
    public string ClientCustomerId { get; set; }
    [JsonPropertyName("client_transaction_id")]
    public string ClientTransactionId { get; set; }
    [JsonPropertyName("client_transaction_description")]
    public string ClientTransactionDescription { get; set; }
    [JsonPropertyName("client_invoice_id")]
    public string ClientInvoiceId { get; set; }

    [JsonPropertyName("shipping_info")]
    public ShippingInfo ShippingInfo { get; set; }

    [JsonPropertyName("cardholder_ip_address")]
    public string CardholderIpAddress { get; set; }
}

public class ShippingInfo
{
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("address")]
    public Address Address { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }
}