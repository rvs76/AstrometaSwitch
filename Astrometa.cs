using System;
using System.IO;
using System.Security;
using System.Windows.Forms;
using Microsoft.Win32;
//using System.Threading;
using System.ComponentModel;

namespace AstrometaForm
{
    public partial class Astrometa : Form
    {
        private const string KeyName = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\AMDVBT2BDA\Parameters";
        private const string ValueName = "DVBCMode";
        private const string DeviceName = "Astrometa DVB-T2 Device";

        private int KeyValue;
        private Boolean BwIsWorking = false;

        public Astrometa()
        {
            InitializeComponent();
            bw.DoWork += new DoWorkEventHandler(ChangeValueAndResetKey);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(EnableControls);
        }

        private void Astrometa2_Load(object sender, EventArgs e)
        {
            LoadValueKey();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            if (!BwIsWorking)
            {
                BwIsWorking = true;
                foreach (Control ctr in this.Controls)
                {
                    ctr.Enabled = false;
                }
                foreach(ToolStripItem smi in cmSystray.Items)
                {
                    smi.Enabled = false;
                }
                bw.RunWorkerAsync();
            }

        }

        private void EnableControls(object sender, EventArgs e)
        {
            LoadValueKey();
            BwIsWorking = false;
            foreach (Control ctr in this.Controls)
            {
                ctr.Enabled = true;
            }
            foreach (ToolStripItem smi in cmSystray.Items)
            {
                smi.Enabled = true;
            }

        }

        private void ChangeValueAndResetKey(object sender, EventArgs e)
        {
            try
            {
                Registry.SetValue(KeyName, ValueName, KeyValue==0 ? 1 : 0);
                HH_Lib hwh = new HH_Lib();
                bool Reset = hwh.ResetDevice(DeviceName);
                hwh = null;
                if (!Reset)
                {
                    MessageBox.Show("The key is not find in this PC." + Environment.NewLine + "The parameter will be effective when the key is pluged.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("The RegistryKey is read-only, and thus cannot be written to", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (SecurityException ex)
            {
                MessageBox.Show("You do not have the permissions required to read from the registry key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            NIcon.Visible = false;
        }

        private void btHide_Click(object sender, EventArgs e)
        {
            Hide();
            NIcon.Visible = true;
        }

        private void LoadValueKey()
        {
            try
            {
                object testRegistry = Registry.GetValue(KeyName, ValueName, null);
                if (testRegistry == null)
                {
                    MessageBox.Show("The key doesn't exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Close();
                }
                else
                {
                    KeyValue = int.Parse(testRegistry.ToString());
                    switch (Convert.ToInt32(testRegistry))
                    {
                        case 0:
                            rbtDVBT.Checked = true;
                            smiDVBT.Checked = true;
                            smiDVBC.Checked = false;
                            break;
                        case 1:
                            rbtDVBC.Checked = true;
                            smiDVBC.Checked = true;
                            smiDVBT.Checked = false;
                            break;
                        default:
                            MessageBox.Show("The value of the key is not correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Close();
                            break;
                    }

                }
            }
            catch (SecurityException ex)
            {
                MessageBox.Show("You do not have the permissions required to read from the registry key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("The RegistryKey that contains the specified value has been marked for deletion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Close();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("The value of the key is not correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Close();
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("The value of the key is not correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Close();
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("The value of the key is not correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Close();
            }

        }

    }
}
