namespace JsonBridge.models
{

    public class Coordinate
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Portal
    {
        public Coordinate coo { get; set; }
        public Coordinate dest { get; set; }
        public bool isActive { get; set; }
    }

    public class Lock
    {
        public Coordinate coo { get; set; }
        public Coordinate[] controlled { get; set; }
    }
    
    public class Player
    {
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string dir { get; set; }
        public string role { get; set; }
        public int stamina { get; set; }
    }
}