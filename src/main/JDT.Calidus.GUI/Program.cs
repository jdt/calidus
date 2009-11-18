using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using JDT.Calidus.UI.Controllers;
using JDT.Calidus.UI.Model;
using JDT.Calidus.Projects;
using JDT.Calidus.Rules;

namespace JDT.Calidus.GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //get the project file
            StartUpWindow win = new StartUpWindow();
            win.ShowDialog();

            //if a file selected
            if (win.DialogResult == DialogResult.OK)
            {
                //build main objects
                CalidusProjectManager projectManager = new CalidusProjectManager();
                CalidusProjectModel project = new CalidusProjectModel(projectManager.ReadFrom(win.SelectedProjectFile));
                CalidusRuleConfigurationFactory configFactory = new CalidusRuleConfigurationFactory(project, projectManager);
                
                RuleRunner runner = new RuleRunner();
                RuleViolationList violationList = new RuleViolationList();
                
                //prepare main view
                MainWindow mainView = new MainWindow();

                //assign controllers
                MainController c = new MainController(mainView, project, win.IsNewProject, projectManager, runner, violationList);

                ViolationListController violationListController = new ViolationListController(mainView.ViolationListView, project, violationList);
                CheckableRuleTreeController checkableRuleListController = new CheckableRuleTreeController(mainView.CheckableRuleTreeView, new CalidusRuleProvider(), configFactory);
                FileTreeController fileListController = new FileTreeController(mainView.FileListView, project);
                SourceLocationController sourceLocationController = new SourceLocationController(mainView.SourceLocationView, project);
                RuleRunnerController ruleRunnerController = new RuleRunnerController(mainView.RuleRunnerView, runner, project, configFactory);
                StatusController statusController = new StatusController(mainView.StatusView, violationList);

                //run application
                Application.Run(mainView);
            }
        }
    }
}
