using Microsoft.Extensions.DependencyInjection;
using Test.Brokers.Infrastructure;
using Test.Brokers.Kafka;

namespace Test.Brokers.Kafka;

public class KafkaConsumerService : KafkaConsumerService<KafkaMessageHandlersController>
{
    public KafkaConsumerService(IServiceScopeFactory serviceScopeFactory, KafkaOptions kafkaOptions)
        : base(serviceScopeFactory, kafkaOptions) { }
}
