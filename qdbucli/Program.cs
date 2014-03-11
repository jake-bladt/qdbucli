using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QDBackup;
using ReplMvc;
using ReplMvc.Controllers;
using ReplMvc.Views;

using qdbucli.Controllers;

namespace qdbucli
{
    class Program
    {
        private static BackupSetList _SetList;

        static void Main(string[] args)
        {
            // TODO Populate setlist from XML file.
            _SetList = new BackupSetList();

            var setController = new BackupSetController(_SetList);

            var view = new ConsoleView();
            var controllers = new IController[] { setController };

            var app = new ReplApplication(view, controllers) { Quieter = true };
            app.Repl();
        }
    }
}
