using System;
using System.Threading;
using System.Threading.Tasks;
using models;
using models.dto;
using Newtonsoft.Json;
using ports.utils;
using UnityEngine;
using WebSocketSharp;

namespace adapters.utils.WebsocketClient
{
    public class WebsocketClient: ISocketAgent
    {
        private WebSocket ws;
        private bool _isAvailable;
        public event EventHandler<Request> onMessage;

        public bool IsConnected()
        {
            return ws != null && _isAvailable;
        }

        public Task Connect(string endpoint, string token)
        {
            Logger.Logger.LogNormal<string>(DebugLocation.Connection, "Connect", "Connecting to " + endpoint);
           
            ws = new WebSocket(endpoint);
            ws.OnOpen += OnOpen;
            ws.OnClose += OnClose;
            ws.OnError += OnError;
            ws.OnMessage += OnMessage;
            
            ws.SetCredentials("user", token, true);
            ws.ConnectAsync();
            
            Logger.Logger.LogNormal<string>(DebugLocation.Connection, "Connect", "Connected to " + endpoint);

            return Task.CompletedTask;
        }
        
        private void OnMessage(object sender, MessageEventArgs message)
        {
            if (!message.IsText) return;

            if (onMessage != null) 
                onMessage(this, JsonConvert.DeserializeObject<Request>(message.Data));
        }
        
        private void OnError(object sender, ErrorEventArgs error)
        {
            if(error.Exception != null)
                Logger.Logger.LogException<Exception>(error.Exception, DebugLocation.Connection, "onError");
            else 
                Logger.Logger.LogException<DynamicPixelsException>(new DynamicPixelsException(error.Message), DebugLocation.Connection, "onError");
        }
        
        private void OnClose(object sender, CloseEventArgs close)
        {
            if (!_isAvailable || close.WasClean) return;
            _isAvailable = false;
            Logger.Logger.LogNormal<string>(DebugLocation.Connection, "Connect", "Disconnected from " + close.Reason);
        }
        
        private void OnOpen(object sender, EventArgs e)
        {
            _isAvailable = true;
        }

        public Task Send(Request request)
        {
            if (!_isAvailable)
                Logger.Logger.LogException<DynamicPixelsException>(new DynamicPixelsException("connection not ready"), DebugLocation.Connection, "Send");
            try
            {
                ws.SendAsync(request.ToString(), null);
            }
            catch (Exception e)
            {
                if (
                    e is OperationCanceledException || 
                    e is ObjectDisposedException || 
                    e is ArgumentOutOfRangeException
                ) return Task.CompletedTask;
                
                _isAvailable = false;
            }

            return Task.CompletedTask;
        }

    }
}