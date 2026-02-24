using System.Text.Json.Serialization;

namespace EComApp.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RefundMethod
    {
        Original,   // Refund back to the original payment method
        PayPal,
        Stripe,
        BankTransfer,
        Manual
    }
}
