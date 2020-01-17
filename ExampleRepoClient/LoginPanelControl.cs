using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using ExampleRepoClient.AccSvc;
using System.Diagnostics;
using System.ServiceModel.Channels;
using System.IO;
using Newtonsoft.Json;

namespace ExampleRepoClient
{
    public partial class LoginPanelControl : UserControl
    {
        bool client = true;
        
        DesignerRepositoryClient.DesignerRepositoryClientServiceClient repoClientClient = null;
            
        //RepositoryServer.DesignerRepositoryServiceClient serverClient = null;
        AccSvc.AccountServiceClient accClient = null;
        SessionUserContext suc = null;
        public delegate void LoginSuccess();
        public LoginSuccess OnLoginSuccess;
        public string sessionIDModules = null;
        public LoginPanelControl()
        {
            BasicHttpBinding binding = null;
            binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.MaxBufferSize = int.MaxValue;
            binding.MaxBufferPoolSize = int.MaxValue;
            binding.ReceiveTimeout = new TimeSpan(20, 10, 0);
            binding.SendTimeout = new TimeSpan(21, 10, 0);
            binding.OpenTimeout = new TimeSpan(22, 10, 0);
            binding.CloseTimeout = new TimeSpan(23, 10, 0);
            //httpBindingElement.MaxBufferSize = Int32.MaxValue;
           // httpBindingElement.MaxReceivedMessageSize = Int32.MaxValue;
            //binding.Elements.Add(httpBindingElement);

            client = true;
            repoClientClient = new DesignerRepositoryClient.DesignerRepositoryClientServiceClient(binding, new EndpointAddress("http://localhost/decisions"));
            //serverClient = new RepositoryServer.DesignerRepositoryServiceClient(binding, new EndpointAddress("http://localhost/decisions"));
            accClient = new AccSvc.AccountServiceClient(binding, new EndpointAddress("https://localhost/decisions/Primary/API/AccountService"));    

            InitializeComponent();

            if(File.Exists("creds.json"))
            {
                var filecontents = File.ReadAllText("creds.json");
                var deserialised = JsonConvert.DeserializeObject<Datatypes.LocalCreds>(filecontents);
                tbURL.Text = deserialised.ClientServerURL;
                tbPwd.Text = deserialised.ClientPassword;
                tbUser.Text = deserialised.ClientUsername;

                tbRepoServerURL.Text = deserialised.RepoServerURL;
                tbRepoServerUser.Text = deserialised.RepoUserName;
                tbRepoServerPass.Text = deserialised.ReposPassword;
            }
            else
            {

                tbURL.Text = "http://172.16.1.130/decisions/Primary/API/DesignerRepositoryClientService";
                tbRepoServerURL.Text = "https://172.16.1.12/Decisions/Primary/API/DesignerRepositoryClientService";
                tbRepoServerUser.Text = "";
                tbRepoServerPass.Text = "";
                tbPwd.Text = "";
                tbUser.Text = "";
            }
            

        }





        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                SetStatus("Starting Login...");


                var RepoAuth = new Functions().LoginRepo(tbRepoServerURL.Text, tbRepoServerUser.Text, tbRepoServerPass.Text);
                if (RepoAuth == null)
                {
                    throw new Exception("Repo Auth didnt work");
                }
            
                var ClientAuth = new Functions().LoginRepo(tbURL.Text, tbUser.Text, tbPwd.Text);
                if (ClientAuth == null)
                {
                    throw new Exception("Client Auth didnt work");
                }

                SetStatus("Logged In...");

                ClientSvcClient.Endpoint.Address = new EndpointAddress(tbURL.Text);

                
                ClientSvcClient.UpdateUserCredentials(
                    new DesignerRepositoryClient.SessionUserContext() { SessionValue = ClientAuth.SessionValue },
                    tbRepoServerUser.Text,
                    tbRepoServerPass.Text, true);

                

                if (OnLoginSuccess != null)
                {
                    sessionIDModules = ClientAuth.SessionValue;
                    OnLoginSuccess();
                }
                SetStatus("Login Complete");
                




            }
            catch (Exception ex) {
                Debug.Write(ex.ToString());
                SetStatus("Error Logging in.");
            }

        }

        public string SessionId {
            
            get {
                return suc != null ? suc.SessionValue : null;
            }
            
        }

        public DesignerRepositoryClient.DesignerRepositoryClientServiceClient ClientSvcClient
        {
            get
            {
                return repoClientClient;
            }

        }

        public void SetStatus(string v)
        {
            if (lblStatus.InvokeRequired)
            {
                this.Invoke(new Action<string>(SetStatus), new object[] { v });
            }
            else
            {
                lblStatus.Text = v;
            }
        }




        
    }
}
