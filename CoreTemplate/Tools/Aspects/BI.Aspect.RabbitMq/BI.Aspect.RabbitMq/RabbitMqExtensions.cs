using RabbitMQ.Client;

namespace BI.Aspect.RabbitMq
{
    internal static class RabbitMqExtensions
    {
        internal static QueueDeclareOk DeclareExchangeAndQueue(this IModel chnl, RabbitMqSettingsValues rs)
        {
            var resp = chnl.QueueDeclare(
                rs.QueueName,
                rs.QueueDurable,
                rs.QueueExclusive,
                rs.QueueAutoDelete);
            if (string.IsNullOrEmpty(rs.ExchangeName))
                return resp;
            chnl.ExchangeDeclare(
                rs.ExchangeName,
                rs.ExchangeType,
                rs.ExchangeDurable,
                rs.ExchangeAutoDelete);

            chnl.QueueBind(rs.QueueName, rs.ExchangeName, resp.QueueName);

            return resp;
        }

        internal static QueueDeclareOk DeclareResponseQueue(this IModel chnl, RabbitMqSettingsValues rs, string replyTo)
        {
            var resp = chnl.QueueDeclare(replyTo);

            if (string.IsNullOrEmpty(rs.ExchangeName))
                return resp;

            chnl.ExchangeDeclare(rs.ExchangeName, rs.ExchangeType, rs.ExchangeDurable, rs.ExchangeAutoDelete);

            chnl.QueueBind(resp.QueueName, rs.ExchangeName, resp.QueueName);
            return resp;
        }
    }
}