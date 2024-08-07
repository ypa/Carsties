﻿using Contracts;
using MassTransit;

namespace AuctionService;

public class AuctionCreatedFaultConsumer : IConsumer<Fault<AuctionCreated>>
{

    public async Task Consume(ConsumeContext<Fault<AuctionCreated>> context)
    {
        Console.WriteLine("--> Consuming fault creation");

        var exception = context.Message.Exceptions.First();

        if (exception.ExceptionType == "System.ArgumentException")
        {
            // Contrived example: Fix up the model
            context.Message.Message.Model = "FooBar";

            // Send it back to the regular queue
            await context.Publish(context.Message.Message);
        }
        else
        {
            Console.WriteLine("Not an argument exception - update error dashboard somewhere");
        }
    }
}
