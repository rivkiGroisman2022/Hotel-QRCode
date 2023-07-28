using HotelDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDAL
{
    public class ChatRepository : IChatRepository
    {
        public readonly HotelContext context;
        public ChatRepository(HotelContext context)
        {
            this.context = context;
        }
        public async Task<List<Message>> AddGuestMsg(string customerId, string message)
        {
            try
            {
                int userId = context.Customers.Where(x => x.Id == customerId).FirstOrDefault().CustomerId;
                if (userId != 0)
                {
                    Message messageToInsert = new Message();
                    messageToInsert.MessageDatetime = DateTime.Now;
                    messageToInsert.UserId = userId;
                    messageToInsert.MessageContent = message;
                    messageToInsert.RequestOrResponse = "Request";

                    await context.Messages.AddAsync(messageToInsert);
                    await context.SaveChangesAsync();

                    //var user = context.Customers.Where(x => x.Id == customerId).FirstOrDefault();
                    var msges = context.Messages.Where(x => x.User.CustomerId == userId || x.ResponseTo == userId).OrderBy(x => x.MessageDatetime).ToList();
                    foreach (var item in msges)
                    {
                        item.User = null;
                        item.User = null;
                    }
                    return msges;
                }
                else return new List<Message>();


            }
            catch (Exception ex)
            {
                EmailManager email = new EmailManager();
                email.SendErrorEmail("AddGuestMsg", ex.Message);
                return new List<Message>();
            }
        }

        public async Task<List<Message>> AddServiceMsg(string customerId, string message)
        {
            try
            {
                int userId = context.Customers.Where(x => x.Id == customerId).FirstOrDefault().CustomerId;
                if (userId != 0)
                {
                    Message messageToInsert = new Message();
                    messageToInsert.MessageDatetime = DateTime.Now;
                    messageToInsert.UserId = 1008;
                    messageToInsert.MessageContent = message;
                    messageToInsert.ResponseTo = userId;
                    messageToInsert.RequestOrResponse = "Response";


                    await context.Messages.AddAsync(messageToInsert);
                    await context.SaveChangesAsync();

                    var user = context.Customers.Where(x => x.Id == customerId).FirstOrDefault();
                    var msges = context.Messages.Where(x => x.User.CustomerId == userId || x.ResponseTo == userId).OrderBy(x => x.MessageDatetime).ToList();
                    foreach (var item in msges)
                    {
                        item.User = null;
                        item.User = null;
                    }
                    return msges;
                }
                else return new List<Message>();

            }
            catch (Exception ex)
            {
                EmailManager email = new EmailManager();
                email.SendErrorEmail("AddServiceMsg",ex.Message);
                return new List<Message>();
            }
        }

        public List<Message> Clear(string customerId)
        {
            try
            {
                int userId = context.Customers.Where(x => x.Id == customerId).FirstOrDefault().CustomerId;
                if (userId != 0)
                {
                    var msges = context.Messages.Where(x => x.User.CustomerId == userId || x.ResponseTo == userId).OrderBy(x => x.MessageDatetime).ToList();
                    context.RemoveRange(msges);
                    context.SaveChanges();
                    return new List<Message>();
                }
                return new List<Message>();
            }
            catch (Exception ex)
            {
                EmailManager email = new EmailManager();
                email.SendErrorEmail("Clear", ex.Message);
                return new List<Message>();
            }
        }

        public List<Message> ReloadChat(string customerId)
        {
            try
            {
                int userId = context.Customers.Where(x => x.Id == customerId).FirstOrDefault().CustomerId;
                if (userId != 0)
                {
                    var msges = context.Messages.Where(x => x.UserId == userId || x.ResponseTo == userId).OrderBy(x => x.MessageDatetime).ToList();
                    foreach (var item in msges)
                    {
                        item.User = null;
                        item.User = null;
                    }
                    return msges;
                }
                else return new List<Message>();
            }
            catch (Exception ex)
            {
                EmailManager email = new EmailManager();
                email.SendErrorEmail("ReloadChat",ex.Message);
                return new List<Message>();
            }
        }
    }
}
