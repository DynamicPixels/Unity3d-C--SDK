using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using adapters.repositories.table.services;
using models.dto;
using models.inputs;

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
        
        public ChatService()
        {
            _repository = new ChatRepository();
            DynamicPixels.Agent.OnMessageReceived += OnMessage;
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
            DynamicPixels.Agent.Send(new Request
            {
                Method = MessageType.ChatSendGroup,
                Payload = param.ToString(),
            });
            
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
        public async Task<List<Conversation>> GetSubscribedConversations<T>(T param) where T : GetSubscribedConversationsParams
        {
            var conversations = await this._repository.GetSubscribedConversations(param);
            return conversations.List;
        }

        public async Task<List<Message>> GetConversationMessages<T>(T param) where T : GetConversationMessagesParams
        {
            var messages = await this._repository.GetConversationMessages(param);
            return messages.List;
        }

        public async Task<List<ConversationMember>> GetConversationMembers<T>(T param) where T : GetConversationMembersParams
        {
            var members = await this._repository.GetConversationMembers(param);
            return members.List;
        }

    }
}