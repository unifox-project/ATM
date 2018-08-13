﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CRYPTOMAT
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        protected override void OnStartup(StartupEventArgs e)
        {
            // Let the base apllication start
            base.OnStartup(e);

            // Setup IoC
            IoC.Setup();

            //  Show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();


          


        }
    }
}
