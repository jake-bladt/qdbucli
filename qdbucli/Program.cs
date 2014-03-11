using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ReplMvc;
using ReplMvc.Controllers;
using ReplMvc.Views;

namespace qdbucli
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new ConsoleView();

            var app = new ReplApplication(view, null) { Quieter = true };
            app.Repl();
        }
    }
}
