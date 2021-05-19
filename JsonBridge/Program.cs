using System;
using JsonBridge.models;
using Newtonsoft.Json;

namespace JsonBridge
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new RequestModel
            {
                type = "colorfulmountainous",
                code =
                    "cst a = Player()\n" +
                    "cst b = Player()\n" +
                    "cst c = Specialist()\n" +
                    "for _ in 1 ... 3 {\n" +
                    "    a.changeColor(\"RED\")\n" +
                    "    a.moveForward()\n" +
                    "    b.changeColor(\"BLACK\")\n" +
                    "    b.moveForward()\n" +
                    "    c.changeColor(\"GREEN\")\n" +
                    "    c.moveForward()\n" +
                    "}\n",
                grid = new[,]
                {
                    {"OPEN", "OPEN", "OPEN"},
                    {"OPEN", "STAIR", "OPEN"},
                    {"OPEN", "STAIR", "STAIR"},
                    {"STAIR", "OPEN", "STAIR"},
                },
                layout = new[,]
                {
                    {"NONE", "NONE", "GEM"},
                    {"NONE", "NONE", "NONE"},
                    {"NONE", "NONE", "NONE"},
                    {"NONE", "NONE", "NONE"},
                },
                colors = new[,]
                {
                    {"WHITE", "WHITE", "WHITE",},
                    {"WHITE", "WHITE", "WHITE",},
                    {"WHITE", "WHITE", "WHITE",},
                    {"WHITE", "WHITE", "WHITE",},
                },
                levels = new[,]
                {
                    {1, 1, 1}, 
                    {1, 2, 1},
                    {1, 2, 2},
                    {2, 1, 3}
                },
                portals = Array.Empty<Portal>(),
                locks = Array.Empty<Lock>(),
                stairs = new []
                {
                    new Stair(new Coordinate(0, 3), "UP"), 
                    new Stair(new Coordinate(1, 1), "UP"), 
                    new Stair(new Coordinate(1, 2), "DOWN"),
                    new Stair(new Coordinate(2, 2), "UP"),
                    new Stair(new Coordinate(2, 3), "UP")
                },
                players = new[]
                {
                    new Player {id = 1, x = 0, y = 0, dir = "DOWN", role = "PLAYER", stamina = 90},
                    new Player {id = 2, x = 1, y = 0, dir = "DOWN", role = "SPECIALIST", stamina = 120},
                    new Player {id = 3, x = 2, y = 0, dir = "DOWN", role = "PLAYER", stamina = 100},
                }
            };

            var resp = new JsonRequestHandler("http://127.0.0.1:8080/paidiki-xara")
                .Feed(JsonConvert.SerializeObject(data))
                .Fetch()
                .get();
            var answers = JsonConvert.DeserializeObject<ResponseModel>(resp);
            try
            {
                Console.WriteLine(answers.status);
            
                foreach (var pm in answers.payload)
                {
                    pm.PrintFrame();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            } 
        }
    }
}