using ExampleRepoClient.DesignerRepositoryClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleRepoClient
{
    public partial class Form1 : Form
    {
        SessionUserContext clientUC = null;

        public Form1()
        {
            InitializeComponent();

            //lbChanges.DataSource = CHANGELIST;
            //lbChanges.DisplayMember = "Name";

            clientLoginPanel.OnLoginSuccess += AfterLogin;
        }

        private void AfterLogin()
        {
            lblStatus.Visible = true;
            clientUC = new SessionUserContext() {
                SessionValue = clientLoginPanel.SessionId
            };
            // Get Client and Load Projects.
            try
            {
                SetStatus("Loading modules from repo client....");
                // Prompt for login to actual server indicated
                string[] moduleNames = clientLoginPanel.ClientSvcClient.GetModules(clientUC);
                //clientLoginPanel.ClientSvcClient.
                cbModules.Items.AddRange(moduleNames);
                SetStatus("Select Module");
            }
            catch (Exception ex) {
                MessageBox.Show("Please configure the Repository Client settings on this server before continuing: " + ex.ToString());
            }
        }

        private void SetStatus(string v)
        {
            if (lblStatus.InvokeRequired)
                lblStatus.Invoke(new Action<string>(SetStatus), new object[] { v });
            else
                lblStatus.Text
                     = v;
        }

        private void AfterModulePicked(object sender, EventArgs e)
        {
            cbBranches.Items.Clear();
            SetStatus("Loading Branches...");
            string[] branches = clientLoginPanel.ClientSvcClient.GetBranches(clientUC, GetSelectedModule());
            SetStatus("Select Branch");
            cbBranches.Items.AddRange(branches);
            btnViewChanges.Enabled = true;
            btnGetServerUpdates.Enabled = true;
        }

        private string GetSelectedModule()
        {
            string selectedModule = (string)cbModules.SelectedItem;
            return selectedModule;
        }

        private string GetSelectedBranch()
        {
            string selectedModule = (string)cbBranches.SelectedItem;
            return selectedModule;
        }

        //private ObservableCollection<ResourceCheckinInfo> CHANGELIST = new ObservableCollection<ResourceCheckinInfo>();
        //private ObservableCollection<string> CHANGELIST = new ObservableCollection<string>();

        private void btnViewChanges_Click(object sender, EventArgs e)
        {
            SetStatus("Fetching Changes...");
            //CHANGELIST.Clear();
            lbChanges.Items.Clear();

            // Shows changes that need to be sent to the repository server.           
            var checkins = clientLoginPanel.ClientSvcClient.GetCheckinInfos(clientUC, GetSelectedModule(), GetSelectedBranch());

            if (checkins.Length > 0)
            {
                foreach (var c in checkins)
                {
                    lbChanges.Items.Add(c.Action + " [" +c.Name + "] mod by: " + c.ModifiedBy + " from: " + c.Path);
                    Debug.WriteLine(c.Action + " " + c.TypeName);
                   
                }
                lbChanges.Update();
                SetStatus("Done");
            }
            else {
                SetStatus("No Pending Changes Found");
            }          
            
        }



        private void btnGetServerUpdates_Click(object sender, EventArgs e)
        {
            SetStatus("Fetching Pending Updates...");
            lbServerChanges.Items.Clear();

            // Shows updates from the server       
            var updates = clientLoginPanel.ClientSvcClient.GetInfoFiles(clientUC, GetSelectedModule(), GetSelectedBranch());

            if (updates.Length > 0)
            {
                foreach (var yy in updates)
                {
                    lbServerChanges.Items.Add(yy.Name + " [" + yy.ModifiedOnRevisionId + "] mod by: " + yy.ModifiedBy + " from: " + yy.Path);

                }
                lbServerChanges.Update();
                SetStatus("Done");
            }
            else {
                SetStatus("No Pending Changes Found");
            }

            // Revert this way = clientLoginPanel.ClientSvcClient.Revert(cli);
            // get updates this way = clientLoginPanel.ClientSvcClient.Checkout();
               
        }

        private void btnCheckInChanges_Click(object sender, EventArgs e)
        {
            var result = clientLoginPanel.ClientSvcClient.Checkin(clientUC, GetSelectedModule(), GetSelectedBranch(),
                clientLoginPanel.ClientSvcClient.GetCheckinInfos(clientUC, GetSelectedModule(), GetSelectedBranch()),
                "Checkin from example repo client");

            if (result.Errors.Length > 0) SetStatus(string.Format("Error on Checkin: {0}", result.Errors.First()));
            else SetStatus(string.Format("Checked in at revision: {0}", result.RevisionId));
        }

        private void btnUpdateLocal_Click(object sender, EventArgs e)
        {
            // this is not quite as terse as it could be, broken out for clarity

            // updating the repo client requires that we know the local folder where these entities reside.
            // in practice, this would require making calls to the folder service and perhaps allowing the user to pick a folder
            var folderId = "60738822-089b-11e6-80be-08002707b377"; 

            var infos = clientLoginPanel.ClientSvcClient.GetInfoFiles(clientUC, GetSelectedModule(), GetSelectedBranch());
            var resources = clientLoginPanel.ClientSvcClient.GetCheckoutResources(clientUC, GetSelectedModule(), infos);

            // Here the resources are the files from the repository project that you want to update and if you
            // do not want to update absolutely everything you would edit the list of resources here 
            // before calling checkout. 
            
            var result = clientLoginPanel.ClientSvcClient.StartCheckout(clientUC, GetSelectedModule(), GetSelectedBranch(), null); // Null for revision is newest

            CheckoutResources cr = clientLoginPanel.ClientSvcClient.GetCheckoutResources(clientUC, GetSelectedModule(), infos);

            string id = clientLoginPanel.ClientSvcClient.StartImportResources(clientUC, GetSelectedModule(), GetSelectedBranch(), folderId, resources);
            // can look for & remediate resource issues in a loop now.
            

            ImportResult ItemResult = clientLoginPanel.ClientSvcClient.FinishImportResources(clientUC, id, GetSelectedModule(), GetSelectedBranch(), folderId, resources);
            foreach (string eachError in ItemResult.Errors) {
                // Show Message, or resolve somehow.
            }

            clientLoginPanel.ClientSvcClient.CommitCheckout(clientUC, result);

           SetStatus(string.Format("Updated with status"));
        }
    }
}
