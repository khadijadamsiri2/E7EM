﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
namespace producteurkafka
{
    class Program
    {
        
        public  static async Task  Main(string[] args)
        {
           
                var config = new ProducerConfig
                {
                    BootstrapServers = "localhost:9092"
                };

                // Create a producer that can be used to send messages to kafka that have no key and a value of type string 
               var p = new ProducerBuilder<Null, string>(config).Build();

                var i = 0;
                while (true)
                {
                    // Construct the message to send (generic type must match what was used above when creating the producer)
                    var message = new Message<Null, string>
                    {
                        Value = $"Message #{++i}"
                    };

                    // Send the message to our test topic in Kafka                
                    var dr = await p.ProduceAsync("streamingkafka", message);
                    Console.WriteLine($"Producteur by khadija damsiri");

                    Thread.Sleep(5000);
                }
            }
    }
}
