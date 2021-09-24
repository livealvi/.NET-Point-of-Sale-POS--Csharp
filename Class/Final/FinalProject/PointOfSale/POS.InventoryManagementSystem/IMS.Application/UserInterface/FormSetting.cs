using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace FinalPoject
{
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        private void btnBackupDB_Click(object sender, EventArgs e)
        {
            ProgressBar.Value = 0;

            try
            {
                Server dbServer = new Server(new ServerConnection(txtServer.Text, txtUsername.Text, txtPassword.Text));
                Backup dbBackup = new Backup(){Action = BackupActionType.Database, Database = txtDatabase.Text};

                dbBackup.Devices.AddDevice(@"C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup\inventoryDB.bak", DeviceType.File);
                dbBackup.Initialize = true;

                dbBackup.PercentComplete += DbBackup_PercentComplete;
                dbBackup.Complete += DbBackup_Complete;
                dbBackup.SqlBackupAsync(dbServer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error );
                throw;
            }
        }

        private void DbBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                lblStatus.Invoke((MethodInvoker)delegate
                {
                   lblStatus.Text = e.Error.Message;
                });
                MessageBox.Show("Backup Done", "Database", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
           
        }

        private void DbBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            ProgressBar.Invoke((MethodInvoker)delegate
            {
                ProgressBar.Value = e.Percent;
                ProgressBar.Update();
            });

            this.lblPersent.Invoke((MethodInvoker)delegate
            {
                lblPersent.Text = $"{e.Percent}%";
            });

        }

        private void btnDBRestore_Click(object sender, EventArgs e)
        {
            ProgressBar.Value = 0;

            try
            {
                Server dbServer = new Server(new ServerConnection(txtServer.Text, txtUsername.Text, txtPassword.Text));
                Restore dbRestore = new Restore() {Database = txtDatabase.Text, Action = RestoreActionType.Database, ReplaceDatabase = true, NoRecovery = false};

                dbRestore.Devices.AddDevice(@"C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup\inventoryDB.bak", DeviceType.File);

                dbRestore.PercentComplete += DbRestore_PercentComplete;
                dbRestore.Complete += DbRestore_Complete;

                dbRestore.SqlRestoreAsync(dbServer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void DbRestore_Complete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                lblStatus.Invoke((MethodInvoker)delegate
                {
                    lblStatus.Text = e.Error.Message;
                });
                MessageBox.Show("Restore Done", "Database", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void DbRestore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            ProgressBar.Invoke((MethodInvoker)delegate
            {
                ProgressBar.Value = e.Percent;
                ProgressBar.Update();
            });

            this.lblPersent.Invoke((MethodInvoker)delegate
            {
                lblPersent.Text = $"{e.Percent}%";
            });
        }

    }
}
