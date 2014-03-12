using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QDBackup;
using QDBackup.Mappers;
using ReplMvc;
using ReplMvc.Controllers;
using ReplMvc.Views;

using qdbucli.Controllers;

namespace qdbucli
{
    class Program
    {
        private static IBackupSetListMapper _SetListMapper;

        static void Main(string[] args)
        {
            string xmlFilePath = Path.Combine(Environment.CurrentDirectory, "Sets", "setlist.xml");
            _SetListMapper = new XmlBackupSetListMapper(xmlFilePath);
            var setController = new BackupSetController(_SetListMapper);

            var view = new ConsoleView();
            var controllers = new IController[] { setController };

            var app = new ReplApplication(view, controllers) { Quieter = true };
            app.Repl();
        }
    }
}
