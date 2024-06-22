using DynamicPixels.GameService.Services.Table;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Chat.Repositories
{
    public class Message : Row
    {
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public int Type { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public string Payload { get; set; }
        public string Buttons { get; set; }
        public int Like { get; set; }
        public int Version { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Conversation : Row
    {
        public string Name { get; set; }
        public int Owner { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ConversationMember : Row
    {
        public int Group { get; set; }
        public int Player { get; set; }
        public string Role { get; set; }
        public int Label { get; set; }
    }
}