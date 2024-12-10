using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administrationConsole
{
    //reden voor static class in plaats van simpleton:
    //de variabele die ik wil gebruiken "folderPath" wordt niet vaak gevraagd.
    //Ik verwacht geen problemen met multi-threading
    public static class Globals
    {
        public static string folderPath;
    }
}
