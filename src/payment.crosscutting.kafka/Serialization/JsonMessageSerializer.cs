namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Serialization
{
    using System.Text;
    using Newtonsoft.Json;

    public class JsonMessageSerializer<TMessage> : IMessageSerializer<TMessage>
        where TMessage : class
    {
        public string Name => "Newtonsoft";

        public TMessage Deserialize(byte[] content)
        {
            return JsonConvert.DeserializeObject<TMessage>(Encoding.UTF8.GetString(content));
        }

        public byte[] Serialize(TMessage message)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
        }
    }
}
