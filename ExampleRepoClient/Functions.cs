using ExampleRepoClient.DesignerRepositoryClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Windows.Forms;

using ExampleRepoClient.AccSvc;

using System.ServiceModel.Channels;


namespace ExampleRepoClient
{
    public class Functions
    {

        public AccSvc.SessionUserContext LoginRepo (string RepoServerURL, string UserName, string Password )
        {

            

            dynamic binding = null;
            if (RepoServerURL.StartsWith("https"))
            {
                binding = new BasicHttpsBinding();
            }
            else
            {
                binding = new BasicHttpBinding();
            }
           
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.MaxBufferSize = int.MaxValue;
            binding.MaxBufferPoolSize = int.MaxValue;
            binding.ReceiveTimeout = TimeSpan.MaxValue;
            binding.SendTimeout = TimeSpan.MaxValue;
            AccSvc.SessionUserContext suc = null;
            try
            {
                string accSvcUrl = RepoServerURL.Replace("/API/DesignerRepositoryClientService", "/API/AccountService");
                AccSvc.AccountServiceClient accClient = null;
                accClient = new AccSvc.AccountServiceClient(binding, new EndpointAddress("https://localhost/decisions/Primary/API/AccountService"));

                accClient.Endpoint.Address = new EndpointAddress(accSvcUrl);

                suc = accClient.LoginUser( new AccSvc.PasswordCredentialsUserContext()
                { 
                    UserID = UserName,
                    Password = Password
                }); ;
                //SetStatus("Login ok! - Updating Repo user...");

                //                ClientSvcClient.UpdateUserCredentials(
                //                    new DesignerRepositoryClient.SessionUserContext() { SessionValue = suc.SessionValue },
                //tbRepoServerUser.Text,
                //                    tbRepoServerPass.Text, true);

                //                if (OnLoginSuccess != null)
                //                {
                //                    OnLoginSuccess();
                //                }
                //                SetStatus("Login Complete");
                return suc;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                new LoginPanelControl().SetStatus("Error Logging in");
                return null;
               // SetStatus("Error Logging in.");
            }

        }
    }
}
