using ExampleRepoClient.DesignerRepositoryClient;
using Newtonsoft.Json;
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
                SessionValue = clientLoginPanel.sessionIDModules
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

        private async void btnUpdateLocal_Click(object sender, EventArgs e)
        {
            // this is not quite as terse as it could be, broken out for clarity

            // updating the repo client requires that we know the local folder where these entities reside.
            // in practice, this would require making calls to the folder service and perhaps allowing the user to pick a folder
            var folderId = "MY__DESIGNS__FOLDER__ID"; 

            var infos = clientLoginPanel.ClientSvcClient.GetInfoFiles(clientUC, GetSelectedModule(), GetSelectedBranch());

            CheckoutResources resources = new CheckoutResources();
            ResourceCheckoutInfo[] u = new ResourceCheckoutInfo[] { };
            resources.ToUpdate = u;
            int i = 0;
            int chunkSize = 3;
            var rsult = infos.GroupBy(s => i++ / chunkSize).Select(g => g.ToArray()).ToArray();


            List<ResourceCheckoutInfo> Del = new List<ResourceCheckoutInfo>();
            List<ResourceCheckoutInfo> Merge = new List<ResourceCheckoutInfo>();
            List<ResourceCheckoutInfo> Update = new List<ResourceCheckoutInfo>();
            foreach (var info in rsult)
            {


                
                var resourceslocal = clientLoginPanel.ClientSvcClient.GetCheckoutResources(clientUC, GetSelectedModule(), info);
                resources.ExtensionData = resourceslocal.ExtensionData;
                foreach (var item in resourceslocal.ToDelete)
                {
                    Del.Add(item);
                }

                foreach (var item in resourceslocal.ToMerge)
                {
                    Merge.Add(item);
                }

                foreach (var item in resourceslocal.ToUpdate)
                {
                    Update.Add(item);
                }

                

            }
            if (Del.Count != 0)
            {
                resources.ToDelete = Del.ToArray();
            }
            else
            {
                resources.ToDelete = new ResourceCheckoutInfo[0];
            }
            if (Merge.Count != 0)
            {
                resources.ToMerge = Merge.ToArray();
            }
            else
            {
                resources.ToMerge = new ResourceCheckoutInfo[0];
            }


            if (Update.Count != 0)
            {
                resources.ToUpdate = Update.ToArray();
            }
            else
            {
                resources.ToUpdate = new ResourceCheckoutInfo[0];
            }






            // Here the resources are the files from the repository project that you want to update and if you
            // do not want to update absolutely everything you would edit the list of resources here 
            // before calling checkout. 

            var result = clientLoginPanel.ClientSvcClient.StartCheckout(clientUC, GetSelectedModule(), GetSelectedBranch(), null); // Null for revision is newest



            string iddiscarded = "";
            int ii = 0;
            int chunkySize = 2;

            ResourceCheckoutInfo[][] ToDeletechunks = new ResourceCheckoutInfo[0][];
            ResourceCheckoutInfo[][] ToMergeChunks = new ResourceCheckoutInfo[0][];
            ResourceCheckoutInfo[][] ToUpdateChunks = new ResourceCheckoutInfo[0][];

            if (resources.ToDelete != null)
            {
                ToDeletechunks = resources.ToDelete.GroupBy(s => ii++ / chunkySize).Select(g => g.ToArray()).ToArray();
            }
            if (resources.ToMerge != null)
            {
                ToMergeChunks = resources.ToMerge.GroupBy(s => ii++ / chunkySize).Select(g => g.ToArray()).ToArray();
            }

            if (resources.ToUpdate != null)
            {
                ToUpdateChunks = resources.ToUpdate.GroupBy(s => ii++ / chunkySize).Select(g => g.ToArray()).ToArray();
            }





            foreach (var item in ToDeletechunks)
            {
                CheckoutResources resourceslocal = new CheckoutResources();
                ResourceCheckoutInfo[] del = new ResourceCheckoutInfo[] { };
                resources.ToDelete = item;
                //resources.ToDelete = item;
                iddiscarded = clientLoginPanel.ClientSvcClient.StartImportResources(clientUC, GetSelectedModule(), GetSelectedBranch(), folderId, resourceslocal);
            }
            foreach (var item in ToMergeChunks)
            {
                CheckoutResources resourceslocal = new CheckoutResources();
                ResourceCheckoutInfo[] update = new ResourceCheckoutInfo[] { };
                resources.ToDelete = item;
                iddiscarded = clientLoginPanel.ClientSvcClient.StartImportResources(clientUC, GetSelectedModule(), GetSelectedBranch(), folderId, resourceslocal);

            }

            foreach (var item in ToUpdateChunks)
            {
                CheckoutResources resourceslocal = new CheckoutResources();
                ResourceCheckoutInfo[] update = new ResourceCheckoutInfo[] { };
                resources.ToUpdate = item;
                resourceslocal.ToUpdate = item;
                resourceslocal.ExtensionData = resources.ExtensionData;
                iddiscarded = clientLoginPanel.ClientSvcClient.StartImportResources(clientUC, GetSelectedModule(), GetSelectedBranch(), folderId, resourceslocal);

            }



            
            

            ImportResult ItemResult = clientLoginPanel.ClientSvcClient.FinishImportResources(clientUC, id, GetSelectedModule(), GetSelectedBranch(), folderId, resources); 
            foreach (string eachError in ItemResult.Errors) {
                // Show Message, or resolve somehow.
            }

            clientLoginPanel.ClientSvcClient.CommitCheckout(clientUC, result);

           SetStatus(string.Format("Updated with status"));
        }
    }
}
