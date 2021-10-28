using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Newtonsoft.Json;

namespace KafkaClients
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }


        private const string Server = "127.0.0.1:9092"; // thats where the broker is available on docker
        private const string topicName = "ProjectCode_UseCase1"; // Topic that can uniquely define subscription source and publishing destination

        private void addTopicButton_Click(object sender, EventArgs e)
        {
            var adminClient = new Confluent.Kafka.AdminClientBuilder(
                new AdminClientConfig()
                {
                    BootstrapServers = Server, //in production there would be more than one broker
                    SecurityProtocol = SecurityProtocol.Plaintext //this is unsecure and may be used for test or demo pupose only.  
                }
                ).Build();

            var matadata = adminClient.GetMetadata(timeout: TimeSpan.FromSeconds(5));
            //if topic doesnt exist add it.
            if (!matadata.Topics.Exists(topic => topic.Topic == topicName))

                adminClient.CreateTopicsAsync(new[]
                {
                   new TopicSpecification
                   {
                       Name = topicName,
                       NumPartitions = 1 // shards, governs throughput
                   }
                });
        }

        private void produceMessageButton_Click(object sender, EventArgs e)
        {
            //1. Setup Producer client.  Key is id of message and the other is the value. This needs to be same for producer and consumer
            var producerClient = new Confluent.Kafka.ProducerBuilder<string, string>(new ProducerConfig()
            {
                BootstrapServers = Server,
                SecurityProtocol = SecurityProtocol.Plaintext 
            }).Build();

            //2. For simplicity, the model is serialized as string. However, not having a strictly defined format has drawbacks.
            TestModel testModel = new TestModel()
            {
                Field1 = field1TextBox.Text,
                Field2 = field2TextBox.Text,
            };
            string stringRep = JsonConvert.SerializeObject(testModel);
                
            //3. Send the message & check delivery status
            producerClient.Produce(
                topicName,
                new Message<string, string>()
                {
                    Key = Guid.NewGuid().ToString(),
                    Value = stringRep
                },
               deliveryReport =>
               {
                   if (deliveryReport.Error.Code != ErrorCode.NoError)
                   {
                       Console.WriteLine($"Failed to deliver message: {deliveryReport.Error.Reason}");
                   }
                   else
                   {
                       Console.WriteLine($"Produced message to: {deliveryReport.TopicPartitionOffset}");
                   }
               });

            //4. As the producer is created within the scope of this function, its vital that any in flight requests are processed before the producer is terminated 
            int queueSize =  producerClient.Flush(TimeSpan.FromSeconds(10));
            if (queueSize > 0)
            {
                Console.WriteLine("WARNING: Producer event queue has " + queueSize + " pending events on exit.");
            }
            producerClient.Dispose();
        }

        private void consumeMessageButton_Click(object sender, EventArgs e)
        {          
            var consumerClient = new Confluent.Kafka.ConsumerBuilder<string, string>(new ConsumerConfig()
            {
                BootstrapServers = Server,
                SecurityProtocol = SecurityProtocol.Plaintext,
                GroupId = "gp1", //Kafka scales topic consumption by distributing partitions among a consumer group, which is a set of consumers sharing a common group identifier.
                EnableAutoCommit = false, // If the consumer crashes before committing offsets for messages that have been successfully processed, then another consumer will end up repeating the work. The more frequently you commit offsets, the less duplicates you will see in a crash.
                //When a group is first initialized, the consumers typically begin reading from either the earliest or latest offset in each partition. The messages in each partition log are then read sequentially.               
                AutoOffsetReset = AutoOffsetReset.Earliest, 
            }).
            Build();

            consumerClient.Subscribe(topicName);
            var result = consumerClient.Consume(timeout:TimeSpan.FromSeconds(2));
            //Nothing to read
            if(result == null)
                MessageBox.Show("Nothing recieved!!");
            else
            {
                TestModel recievedModel = JsonConvert.DeserializeObject<TestModel>(result.Message.Value);
                MessageBox.Show($"Recieved message: {Environment.NewLine}Field1: {recievedModel.Field1}{Environment.NewLine}Field2: {recievedModel.Field2}");
                //As the message is processed. Its safe to commit the offset now. 
                //A more reasonable approach might be to commit after every N messages where N can be tuned for better performance. 
                consumerClient.Commit(); 
            }
            consumerClient.Close();
        }
    }

    public class TestModel
    {
        public string Field1;
        public string Field2;
    }
}

