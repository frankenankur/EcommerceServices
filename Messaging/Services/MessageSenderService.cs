using System;
using System.Messaging;

namespace Messaging.Services
{
    public static class MessageSenderService
    {
        public static bool SendMessageToQueue(string queueName, object messageObject)
        {
            var queue = new MessageQueue(queueName);
            var messageFormatter = new XmlMessageFormatter(new Type[] { typeof(String) });
            var message = new Message();

            messageFormatter.Write(message, messageObject);

            if (queue.Transactional == true)
            {
                try
                {
                    var transaction = new MessageQueueTransaction();
                    transaction.Begin();
                    queue.Send(message, transaction);
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
            else
            {
                try
                {
                    queue.Send(message);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
        }
    }
}
