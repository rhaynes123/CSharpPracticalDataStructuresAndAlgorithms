using System;
using Microsoft.AspNetCore.SignalR;
using SecretaryOfStateQue.Models;

namespace SecretaryOfStateQue.Hubs
{
    public class CustomerHub: Hub
    {
        
        public CustomerHub()
        {
           
        }
        public async Task SendMessageAsync(Customer customer)
        {
            await Clients.All.SendAsync("QueuedCustomer", customer);
        }
    }
}

