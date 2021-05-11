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
                type = "colorful",
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
                grid = new[]
                {
                    new[] {"OPEN", "OPEN", "OPEN"},
                    new[] {"OPEN", "OPEN", "OPEN"},
                    new[] {"OPEN", "OPEN", "OPEN"},
                    new[] {"OPEN", "OPEN", "OPEN"},
                },
                layout = new[]
                {
                    new[] {"NONE", "NONE", "GEM"},
                    new[] {"NONE", "NONE", "NONE"},
                    new[] {"NONE", "NONE", "NONE"},
                    new[] {"NONE", "NONE", "NONE"},
                },
                misc = new[]
                {
                    new[] {"WHITE", "WHITE", "WHITE",},
                    new[] {"WHITE", "WHITE", "WHITE",},
                    new[] {"WHITE", "WHITE", "WHITE",},
                    new[] {"WHITE", "WHITE", "WHITE",},
                },
                portals = Array.Empty<Portal>(),
                locks = Array.Empty<Lock>(),
                players = new[]
                {
                    new Player() {id = 1, x = 0, y = 0, dir = "DOWN", role = "PLAYER", stamina = 90},
                    new Player() {id = 2, x = 1, y = 0, dir = "DOWN", role = "SPECIALIST", stamina = 120},
                    new Player() {id = 3, x = 2, y = 0, dir = "DOWN", role = "PLAYER", stamina = 100},
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