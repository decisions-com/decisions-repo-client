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

namespace ExampleRepoClient
{
    public partial class LoginPanelControl : UserControl
    {
        bool client = true;
        BasicHttpBinding binding = null;
        DesignerRepositoryClient.DesignerRepositoryClientServiceClient repoClientClient = null;
            
        //RepositoryServer.DesignerRepositoryServiceClient serverClient = null;
        AccSvc.AccountServiceClient accClient = null;
        SessionUserContext suc = null;
        public delegate void LoginSuccess();
        public LoginSuccess OnLoginSuccess;
         
        public LoginPanelControl()
        {
            binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.MaxBufferSize = int.MaxValue;
            binding.MaxBufferPoolSize = int.MaxValue;
            binding.ReceiveTimeout = TimeSpan.MaxValue;
            binding.SendTimeout = TimeSpan.MaxValue;

            //httpBindingElement.MaxBufferSize = Int32.MaxValue;
            //httpBindingElement.MaxReceivedMessageSize = Int32.MaxValue;
            //binding.Elements.Add(httpBindingElement);

            client = true;
            repoClientClient = new DesignerRepositoryClient.DesignerRepositoryClientServiceClient(binding, new EndpointAddress("http://localhost/decisions"));
            //serverClient = new RepositoryServer.DesignerRepositoryServiceClient(binding, new EndpointAddress("http://localhost/decisions"));
            accClient = new AccSvc.AccountServiceClient(binding, new EndpointAddress("https://localhost/decisions/Primary/API/AccountService"));    

            InitializeComponent();

            if (client)
            {
                tbURL.Text = "http://localhost/decisions/Primary/API/DesignerRepositoryClientService";
                
            }
            else {
                //tbURL.Text = "https://localhost/decisions/Primary/API/DesignerRepositoryService";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetStatus("Starting Login...");

            string accSvcUrl = tbURL.Text.Replace("/API/DesignerRepositoryClientService", "/API/AccountService");

            accClient.Endpoint.Address = new EndpointAddress(accSvcUrl);

            if (client)
            {
                repoClientClient.Endpoint.Address = new EndpointAddress(tbURL.Text);
                // repoClientClient.Log
            }
            else
            {
                //serverClient.Endpoint.Address = new EndpointAddress(tbRepoServerBaseUrl.Text);
            }

            
            try
            {
                suc = accClient.LoginUser(new PasswordCredentialsUserContext()
                {
                    UserID = tbUser.Text,
                    Password = tbPwd.Text
                });
                SetStatus("Login ok! - Updating Repo user...");

                ClientSvcClient.UpdateUserCredentials(
                    new DesignerRepositoryClient.SessionUserContext() { SessionValue = suc.SessionValue }, 
                    tbRepoServerUser.Text, 
                    tbRepoServerPass.Text, true);

                if (OnLoginSuccess != null) {
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

        private void SetStatus(string v)
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
