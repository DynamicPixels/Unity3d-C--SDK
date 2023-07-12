namespace models.dto
{
    public class Achievement
    {
        public int Id = 0;
        public string Name = "";
        public string Desc = "";
        public string Image = "";
        public string StartAt = "";
        public string EndAt = "";
        public Step[] Steps = new Step[]{};

    }

    public class Step {
        public int Id = 0;
        public string Name= "";
        public int Point = 0;
        public string Payload = "";
        public bool Unlocked = false;
    }

    public class Unlock
    {
        public int Player = 0;
        public int Achievement = 0;
        public int Step = 0;
    }
}