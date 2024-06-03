using JDChallenge.Services.Services.KafkaMessages;

namespace JDChallenge.Services.Interfaces;

public interface IKafkaProducer
{
    Task Publish(OperationMessage operationMessage);
}
