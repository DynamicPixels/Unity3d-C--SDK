//using adapters.repositories.table.services;
//using models.dto;
//using models.inputs;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.Services.Chat;
using DynamicPixels.GameService.Services.Chat.Models;
using DynamicPixels.GameService.Services.Chat.Repositories;
using DynamicPixels.GameService.Services.MultiPlayer.Room;
using DynamicPixels.GameService.Utils.WebsocketClient;
using Unity.Plastic.Newtonsoft.Json;
using MessageType = DynamicPixels.Services.Chat.MessageType;

namespace DynamicPixels.GameService.Services.services
{
    public class ChatService: IChatService
    {
        
        private readonly ISocketAgent _socketAgent;
        private readonly IChatRepository _repository;

        public event EventHandler OnPrivateMessage;
        public event EventHandler OnPublicMessage;
        public event EventHandler OnSubscribe;
        public event EventHandler OnUnsubscribe;
        public event EventHandler OnEditMessage;
        public event EventHandler OnDeleteMessage;
        public event EventHandler OnDeleteAllMessage;

        public ChatService(ISocketAgent socketAgent)
        {
            _socketAgent = socketAgent;
            _repository = new ChatRepository();
            _socketAgent.OnMessageReceived += OnMessage;
        }

        private void OnMessage(object source, Request packet)
        {
            switch (packet.Method)
            {
                case MessageType.ChatSendPrivate:
                    OnPrivateMessage?.Invoke(this, packet);
                    break;
                case MessageType.ChatSendGroup:
                    OnPublicMessage?.Invoke(this, packet);
                    break;
                case MessageType.ChatSubscribe:
                    OnSubscribe?.Invoke(this, packet);
                    break;
                case MessageType.ChatUnsubscribe:
                    OnUnsubscribe?.Invoke(this, packet);
                    break;
                case MessageType.ChatMessageEdit:
                    OnEditMessage?.Invoke(this, packet);
                    break;
                case MessageType.ChatMessageDelete:
                    OnDeleteMessage?.Invoke(this, packet);
                    break;
                case MessageType.ChatMessageDeleteAll:
                    OnDeleteAllMessage?.Invoke(this, packet);
                    break;
            }
        }

        
        // interactions
        public Task Send<T>(T param) where T : SendParams
        {
            _socketAgent.Send(new Request
            {
                Method = param.Type == ConversationType.Private ? MessageType.ChatSendPrivate: MessageType.ChatSendGroup,
                ReceiverId = param.TargetUserId,
                Payload = new Payload
                {
                    TargetId = param.TargetUserId,
                    Message = param.Message
                }.ToString(),
            });
            
            return Task.CompletedTask;
        }

        public Task Subscribe<T>(T param) where T : SubscribeParams
        {
            _socketAgent.Send(new Request
            {
                Method = MessageType.ChatSubscribe,
                Payload = new Payload
                {
                    TargetId = param.ConversationId,
                    Value = param.ConversationName,
                }.ToString(),
            });
            
            return Task.CompletedTask;
        }

        public Task Unsubscribe<T>(T param) where T : UnsubscribeParams
        {
            _socketAgent.Send(new Request
            {
                Method = MessageType.ChatUnsubscribe,
                Payload = new Payload
                {
                    TargetId = param.ConversationId,
                }.ToString(),
            });
            
            return Task.CompletedTask;
        }
        
        public Task EditMessage<T>(T param) where T : EditMessageParams
        {
            _socketAgent.Send(new Request
            {
                Method = MessageType.ChatMessageEdit,
                Payload = new Payload
                {
                    TargetId = param.ConversationId,
                    MessageId = param.MessageId,
                    Message = param.Message,
                }.ToString(),
            });
            
            return Task.CompletedTask;
        }

        public Task DeleteMessage<T>(T param) where T : DeleteMessageParams
        {
            _socketAgent.Send(new Request
            {
                Method = MessageType.ChatMessageDelete,
                Payload = new Payload {
                    TargetId = param.ConversationId,
                    MessageId = param.MessageId,
                }.ToString(),
            });
            
            return Task.CompletedTask;
        }

        public Task DeleteAllMessage<T>(T param) where T : DeleteAllMessageParams
        {
            _socketAgent.Send(new Request
            {
                Method = MessageType.ChatMessageDeleteAll,
                Payload = new Payload
                {
                    TargetId = param.ConversationId,
                    SubTargetId = param.TargetUserId,
                }.ToString(),
            });
            
            return Task.CompletedTask;
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