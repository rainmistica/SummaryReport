namespace SummaryReport
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesMaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfTrucksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfDriversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.truckAndDriversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditTrailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 325);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(809, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesMaintenanceToolStripMenuItem,
            this.modifyFilesToolStripMenuItem,
            this.auditTrailToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.userSettingsToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(809, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesMaintenanceToolStripMenuItem
            // 
            this.filesMaintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listOfTrucksToolStripMenuItem,
            this.listOfDriversToolStripMenuItem,
            this.listOfCustomersToolStripMenuItem,
            this.truckAndDriversToolStripMenuItem});
            this.filesMaintenanceToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filesMaintenanceToolStripMenuItem.Name = "filesMaintenanceToolStripMenuItem";
            this.filesMaintenanceToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.filesMaintenanceToolStripMenuItem.Text = "Files Maintenance";
            // 
            // listOfTrucksToolStripMenuItem
            // 
            this.listOfTrucksToolStripMenuItem.Name = "listOfTrucksToolStripMenuItem";
            this.listOfTrucksToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.listOfTrucksToolStripMenuItem.Text = "List Of Trucks";
            this.listOfTrucksToolStripMenuItem.Click += new System.EventHandler(this.listOfTrucksToolStripMenuItem_Click);
            // 
            // listOfDriversToolStripMenuItem
            // 
            this.listOfDriversToolStripMenuItem.Name = "listOfDriversToolStripMenuItem";
            this.listOfDriversToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.listOfDriversToolStripMenuItem.Text = "List Of Drivers";
            this.listOfDriversToolStripMenuItem.Click += new System.EventHandler(this.listOfDriversToolStripMenuItem_Click);
            // 
            // listOfCustomersToolStripMenuItem
            // 
            this.listOfCustomersToolStripMenuItem.Name = "listOfCustomersToolStripMenuItem";
            this.listOfCustomersToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.listOfCustomersToolStripMenuItem.Text = "List of Customers";
            this.listOfCustomersToolStripMenuItem.Click += new System.EventHandler(this.listOfCustomersToolStripMenuItem_Click);
            // 
            // truckAndDriversToolStripMenuItem
            // 
            this.truckAndDriversToolStripMenuItem.Name = "truckAndDriversToolStripMenuItem";
            this.truckAndDriversToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.truckAndDriversToolStripMenuItem.Text = "Truck and Drivers";
            this.truckAndDriversToolStripMenuItem.Click += new System.EventHandler(this.truckAndDriversToolStripMenuItem_Click);
            // 
            // modifyFilesToolStripMenuItem
            // 
            this.modifyFilesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyFilesToolStripMenuItem.Name = "modifyFilesToolStripMenuItem";
            this.modifyFilesToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.modifyFilesToolStripMenuItem.Text = "Summary Report";
            this.modifyFilesToolStripMenuItem.Click += new System.EventHandler(this.modifyFilesToolStripMenuItem_Click);
            // 
            // auditTrailToolStripMenuItem
            // 
            this.auditTrailToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.auditTrailToolStripMenuItem.Name = "auditTrailToolStripMenuItem";
            this.auditTrailToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.auditTrailToolStripMenuItem.Text = "Audit Trail";
            this.auditTrailToolStripMenuItem.Visible = false;
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupDatabaseToolStripMenuItem,
            this.restoreDatabaseToolStripMenuItem,
            this.resetDatabaseToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // backupDatabaseToolStripMenuItem
            // 
            this.backupDatabaseToolStripMenuItem.Name = "backupDatabaseToolStripMenuItem";
            this.backupDatabaseToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.backupDatabaseToolStripMenuItem.Text = "Backup Database";
            this.backupDatabaseToolStripMenuItem.Click += new System.EventHandler(this.backupDatabaseToolStripMenuItem_Click);
            // 
            // restoreDatabaseToolStripMenuItem
            // 
            this.restoreDatabaseToolStripMenuItem.Name = "restoreDatabaseToolStripMenuItem";
            this.restoreDatabaseToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.restoreDatabaseToolStripMenuItem.Text = "Restore Database";
            this.restoreDatabaseToolStripMenuItem.Visible = false;
            // 
            // resetDatabaseToolStripMenuItem
            // 
            this.resetDatabaseToolStripMenuItem.Name = "resetDatabaseToolStripMenuItem";
            this.resetDatabaseToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.resetDatabaseToolStripMenuItem.Text = "Reset Database";
            this.resetDatabaseToolStripMenuItem.Visible = false;
            this.resetDatabaseToolStripMenuItem.Click += new System.EventHandler(this.resetDatabaseToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // userSettingsToolStripMenuItem
            // 
            this.userSettingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userSettingsToolStripMenuItem.Name = "userSettingsToolStripMenuItem";
            this.userSettingsToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.userSettingsToolStripMenuItem.Text = "User Settings";
            this.userSettingsToolStripMenuItem.Visible = false;
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.logOutToolStripMenuItem.Text = "Log-Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 347);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shifthead Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesMaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfTrucksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfDriversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem truckAndDriversToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem auditTrailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}