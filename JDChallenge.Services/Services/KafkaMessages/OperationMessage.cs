using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JDChallenge.Services.Services.KafkaMessages;

public class OperationMessage
{
    public Guid Id { get; protected set; } = Guid.NewGuid();

    [JsonConverter(typeof(StringEnumConverter))]
    public OperationType OperationType { get; protected set; }

    public OperationMessage(OperationType operationType)
    { 
        this.OperationType = operationType; 
    }
}

public enum OperationType 
{ 
    get,
    request,
    modify
}
