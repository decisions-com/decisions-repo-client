using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleRepoClient.Datatypes
{
    public class LocalCreds
    {
        public string RepoServerURL { get; set; }
        public string RepoUserName { get; set; }

        public string ReposPassword { get; set; }
        public string ClientServerURL { get; set; }

        public string ClientUsername { get; set; }

        public string ClientPassword { get; set; }
    }
}
