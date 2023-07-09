using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using models.dto;
using models.inputs;
using ports;
using ports.services;
using ports.utils;

namespace adapters.services.table.services
{

    public partial class MessageType
    {
        public const string ChatSendPrivate = "chat:send";
        public const string ChatSendGroup = "chat:group:send";
        public const string ChatSubscribe = "chat:subscribe";
        public const string ChatUnsubscribe = "chat:unsubscribe";
        public const string ChatMessageEdit = "chat:message:edit";
        public const string ChatMessageDelete = "chat:message:delete";
        public const string ChatMessagePurge = "chat:message:purge";
        public const string ChatMessageDeleteAll = "chat:group:delete";
    }
    
    public class ChatService: IChat
    {
        // dependencies
        private IChatRepository _repository;
        private ISocketAgent socket;
        public ChatService(ISocketAgent conn)
        {
            socket = conn;
            conn.onMessage += OnMessage; 
        }

        private void OnMessage(object source, Request packet)
        {
            switch (packet.Method)
            {
                case MessageType.ChatSendPrivate:
                    Send(new SendParams{});
                    break;
                case MessageType.ChatSendGroup:
                    Send(new SendParams{});
                    break;
                case MessageType.ChatSubscribe:
                    Subscribe(new SubscribeParams{});
                    break;
                case MessageType.ChatUnsubscribe:
                    Unsubscribe(new UnsubscribeParams{});
                    break;
                case MessageType.ChatMessageEdit:
                    EditMessage(new EditMessageParams{});
                    break;
                case MessageType.ChatMessageDelete:
                    DeleteMessage(new DeleteMessageParams{});
                    break;
                case MessageType.ChatMessagePurge:
                    
                    break;
                case MessageType.ChatMessageDeleteAll:
                    DeleteAllMessage(new DeleteAllMessageParams{});
                    break;
            }
        }

        
        // interactions
        public Task Send<T>(T param) where T : SendParams
        {
            // socket.Send(new Request
            // {
            //     Method = MessageType.ChatSendGroup,
            //     Payload = 
            // });
            
            return Task.CompletedTask;
        }

        public Task Subscribe<T>(T param) where T : SubscribeParams
        {
            throw new System.NotImplementedException();
        }

        public Task Unsubscribe<T>(T param) where T : UnsubscribeParams
        {
            throw new System.NotImplementedException();
        }
        
        public Task EditMessage<T>(T param) where T : EditMessageParams
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteMessage<T>(T param) where T : DeleteMessageParams
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAllMessage<T>(T param) where T : DeleteAllMessageParams
        {
            throw new System.NotImplementedException();
        }
        
        // https
        public Task<List<Conversation>> GetSubscribedConversations<T>(T param) where T : GetSubscribedConversationsParams
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Message>> GetConversationMessages<T>(T param) where T : GetConversationMessagesParams
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ConversationMember>> GetConversationMembers<T>(T param) where T : GetConversationMembersParams
        {
            throw new System.NotImplementedException();
        }

    }
}