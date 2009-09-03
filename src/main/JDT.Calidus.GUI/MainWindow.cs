using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JDT.Calidus.Projects;

namespace JDT.Calidus.GUI
{
    public partial class MainWindow : Form
    {
        private const String NOT_SET = "<Not Set>";
        private const String TITLE = "Calidus GUI Test Runner - [{0}]";
        private const String NEW_PROJECT = "New Project";
        private const String UNSAVED_PROJECT = "Unsaved Project";

        public MainWindow()
        {
            InitializeComponent();

            CurrentProject = null;

            DisplayProjectDetails();
        }

        #region Events

        private void lnkSourceDirectory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog browseDirectory = new FolderBrowserDialog();
            browseDirectory.ShowNewFolderButton = false;
            browseDirectory.ShowDialog(this);

            String selectedDir = browseDirectory.SelectedPath;
            if(selectedDir.Equals(String.Empty) == false)
            {
                CurrentProject = new CalidusProject(selectedDir, null);
                DisplayProjectDetails();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Methods

        private void DisplayProjectDetails()
        {
            if(CurrentProject == null)
            {
                Text = String.Format(TITLE, NEW_PROJECT);
                lnkSourceDirectory.Text = NOT_SET;
            }
            else
            {
                String projectName = UNSAVED_PROJECT;
                if (CurrentProject.ProjectLocation != null)
                    projectName = CurrentProject.Name;

                Text = String.Format(TITLE, projectName);
                lnkSourceDirectory.Text = CurrentProject.SourceLocation;
            }
        }

        #endregion

        #region Properties

        private CalidusProject CurrentProject { get; set; }

        #endregion
    }
}