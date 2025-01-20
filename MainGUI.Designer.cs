namespace TimelineBuilderPro
{
    partial class MainGUI
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomMenu;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetZoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem featuresMenu;
        private System.Windows.Forms.ToolStripMenuItem showGridLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleSidebarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.featuresMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.showGridLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleSidebarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();



            // MenuStrip
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.fileToolStripMenuItem,
                this.editToolStripMenuItem,
                this.viewToolStripMenuItem,
                this.helpToolStripMenuItem
            });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Visible = true; // Ensure menu strip is visible

            // File Menu
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.newToolStripMenuItem,
                this.openToolStripMenuItem,
                this.closeToolStripMenuItem,
                this.saveToolStripMenuItem,
                this.saveAsToolStripMenuItem,
                this.printToolStripMenuItem,
                this.exitToolStripMenuItem
            });
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Visible = true; // Ensure menu item is visible

            // Each File Menu Item
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Visible = true;

            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Visible = true;

            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Visible = true;

            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Visible = true;

            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Visible = true;

            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Visible = true;

            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Visible = true;

            // Edit Menu
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.undoToolStripMenuItem,
                this.redoToolStripMenuItem,
                this.cutToolStripMenuItem,
                this.copyToolStripMenuItem,
                this.pasteToolStripMenuItem,
                this.findToolStripMenuItem,
                this.replaceToolStripMenuItem
            });
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Visible = true;// Ensure menu item is visible

            // Each Edit Menu Item
            this.undoToolStripMenuItem.Text = "Undo";
            this.newToolStripMenuItem.Visible = true;

            this.redoToolStripMenuItem.Text = "Redo";
            this.newToolStripMenuItem.Visible = true;

            this.cutToolStripMenuItem.Text = "Cut";
            this.newToolStripMenuItem.Visible = true;

            this.copyToolStripMenuItem.Text = "Copy";
            this.newToolStripMenuItem.Visible = true;

            this.pasteToolStripMenuItem.Text = "Paste";
            this.newToolStripMenuItem.Visible = true;

            this.findToolStripMenuItem.Text = "Find";
            this.newToolStripMenuItem.Visible = true;
            
            this.replaceToolStripMenuItem.Text = "Replace";
            this.newToolStripMenuItem.Visible = true;

            // View Menu
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.zoomMenu,
                this.featuresMenu,
                this.fullScreenToolStripMenuItem
            });
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Visible = true;

            // Zoom Menu
            this.zoomMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.zoomInToolStripMenuItem,
                this.zoomOutToolStripMenuItem,
                this.resetZoomToolStripMenuItem
            });
            this.zoomMenu.Text = "Zoom";
            this.zoomMenu.Visible = true;

            // Zoom Items
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Visible = true;
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Visible = true;
            this.resetZoomToolStripMenuItem.Text = "Reset Zoom";
            this.resetZoomToolStripMenuItem.Visible = true;

            // Features Menu
            this.featuresMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.showGridLinesToolStripMenuItem,
                this.toggleSidebarToolStripMenuItem
            });
            this.featuresMenu.Text = "Features";
            this.featuresMenu.Visible = true;

            // Features Items
            this.showGridLinesToolStripMenuItem.Text = "Show Grid Lines";
            this.showGridLinesToolStripMenuItem.Visible = true;
            this.toggleSidebarToolStripMenuItem.Text = "Toggle Sidebar";
            this.toggleSidebarToolStripMenuItem.Visible = true;

            // Full Screen
            this.fullScreenToolStripMenuItem.Text = "Full Screen";
            this.fullScreenToolStripMenuItem.Visible = true;


            // Each Edit Menu Item
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.viewToolStripMenuItem.Visible = true;
            
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.viewToolStripMenuItem.Visible = true;

            this.resetZoomToolStripMenuItem.Text = "Reset Zoom";
            this.viewToolStripMenuItem.Visible = true;

            this.fullScreenToolStripMenuItem.Text = "Full Screen";
            this.viewToolStripMenuItem.Visible = true;

            // Help Menu
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.aboutToolStripMenuItem,
                this.documentationToolStripMenuItem
            });
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Visible = true;// Ensure menu item is visible

            // Each Edit Menu Item
            this.aboutToolStripMenuItem.Text = "About";
            this.documentationToolStripMenuItem.Visible = true;

            this.documentationToolStripMenuItem.Text = "Documentation";
            this.aboutToolStripMenuItem.Visible = true;


            // MainGUI
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainGUI";
            this.Text = "Timeline Builder Pro";

        }
    }
}
