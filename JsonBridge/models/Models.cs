namespace JsonBridge.models
{

    public class Coordinate
    {
        public int x { get; set; }
        public int y { get; set; }

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Portal
    {
        public Coordinate coo { get; set; }
        public Coordinate dest { get; set; }
        public bool isActive { get; set; }

        public Portal(Coordinate coo, Coordinate dest, bool isActive)
        {
            this.coo = coo;
            this.dest = dest;
            this.isActive = isActive;
        }
    }

    public class Lock
    {
        public Coordinate coo { get; set; }
        public Coordinate[] controlled { get; set; }

        public Lock(Coordinate coo, Coordinate[] controlled)
        {
            this.coo = coo;
            this.controlled = controlled;
        }
    }

    public class Stair
    {
        public Stair(Coordinate coo, string dir)
        {
            this.coo = coo;
            this.dir = dir;
        }

        public Coordinate coo { get; set; }
        public string dir { get; set; }
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