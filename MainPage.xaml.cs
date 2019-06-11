using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Data.SqlClient;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    
        
    public sealed partial class MainPage : Page
    {
        const string connstring = "Data Source=DESKTOP-NBNJR96;Initial Catalog=RTO;Integrated Security=True";
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // you can also add items in code behind
           

            // set the initial SelectedItem 
            foreach (NavigationViewItemBase item in NavView.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "Home")
                {
                    NavView.SelectedItem = item;
                    break;
                }
            }
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                switch (args.InvokedItem)
                {
                    case "Home":
                        ContentFrame.Navigate(typeof(Home));
                        break;

                    case "DL":
                        ContentFrame.Navigate(typeof(NewDL1));
                        break;

                    case "FV":
                        ContentFrame.Navigate(typeof(FV));
                        break;

                    case "Reg":
                        ContentFrame.Navigate(typeof(Registration));
                        break;

                    case "LL":
                        ContentFrame.Navigate(typeof(NewLL));
                        break;

                    case "Database":
                        ContentFrame.Navigate(typeof(ShowDatabase));
                        break;

                    case "GD":
                        ContentFrame.Navigate(typeof(GetDocuments));
                        break;
                }
            }
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {

                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag)
                {
                    case "Home":
                        ContentFrame.Navigate(typeof(Home));
                        break;

                    case "DL":
                        ContentFrame.Navigate(typeof(NewDL1));
                        break;

                    case "FV":
                        ContentFrame.Navigate(typeof(FV));
                        break;

                    case "Reg":
                        ContentFrame.Navigate(typeof(Registration));
                        break;

                    case "LL":
                        ContentFrame.Navigate(typeof(NewLL));
                        break;

                    case "Database":
                        ContentFrame.Navigate(typeof(ShowDatabase));
                        break;

                    case "GD":
                        ContentFrame.Navigate(typeof(GetDocuments));
                        break;

                }
            }
        }
    }
   
}
