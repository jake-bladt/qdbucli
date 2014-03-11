using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QDBackup;
using ReplMvc;
using ReplMvc.Controllers;

namespace qdbucli.Controllers
{
    public class BackupSetController : IController
    {
        private BackupSetList _setList;
        private BackupSet _activeSet = null;

        public BackupSetController(BackupSetList list)
        {
            _setList = list;
        }

        public ActionResult ListSets(string[] args)
        {
            var ret = new ActionResult(null, true, false);
            if (_setList.Count == 0)
            {
                ret.Messages = new string[] { "(no sets)" };
            }
            else
            {
                ret.Messages = _setList.Keys.ToArray();
            }
            return ret;
        }

        public ActionResult LoadSet(string[] args)
        {
            if (null == args || args.Count() < 1) return new ActionResult(new string[] { "USAGE: load-set <setname>" }, false, true);
            string setName = args[0];
            if (_setList.ContainsKey(setName))
            {
                _activeSet = _setList[setName];
                var msgs = new string[] { String.Format("{0} is now the active set.", setName) };
                return new ActionResult(msgs, true, false);
            }
            else
            {
                var msgs = new string[] { String.Format("There is no set named {0}.", setName) };
                return new ActionResult(msgs, false, false);
            }
        }

        public ActionResult NewSet(string[] args)
        {
            if (null == args || args.Count() < 1) return new ActionResult(new string[] { "USAGE: create-set <setname>" }, false, true);
            string setName = args[0];
            if (_setList.ContainsKey(setName))
            {
                var msgs = new string[] { String.Format("There is already a set named {0}. Please select another name.", setName) };
                return new ActionResult(msgs, false, false);
            }
            else
            {
                _activeSet = new BackupSet();
                _setList[setName] = _activeSet;
                var msgs = new string[] { String.Format("{0} is now the active set.", setName) };
                return new ActionResult(msgs, true, false);
            }
        }

        public Dictionary<string, Func<string[], ReplMvc.ActionResult>> GetCommandActions()
        {
            return new Dictionary<string, Func<string[], ActionResult>> {
                { "list-sets", this.ListSets },
                { "load-set", this.LoadSet },
                { "create-set", this.NewSet }
            };
        }

        public string Name
        {
            get { return "backup set controller"; }
        }
    }
}
