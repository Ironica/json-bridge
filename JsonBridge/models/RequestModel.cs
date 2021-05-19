namespace JsonBridge.models
{
    public class RequestModel
    {
        public string type { get; set; }
        public string code { get; set; }
        public string[,] grid { get; set; }
        public string[,] layout { get; set; }
        public string[,] colors { get; set; }
        public int[,] levels { get; set; } 
        public Portal[] portals { get; set; }
        public Lock[] locks { get; set; }
        public Stair[] stairs { get; set; }
        public Player[] players { get; set; }
    }
   
}