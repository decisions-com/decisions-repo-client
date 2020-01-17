using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleRepoClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //var x = new Datatypes.LocalCreds()
            //{
            //    ClientPassword = "",
            //    ClientServerURL = "",
            //    ClientUsername = "",
            //    RepoServerURL = "",
            //    ReposPassword = "",
            //    RepoUserName = ""
            //};

            //var s = JsonConvert.SerializeObject(x)

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
