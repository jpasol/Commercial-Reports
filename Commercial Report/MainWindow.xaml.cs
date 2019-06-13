using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
namespace Commercial_Report
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Syncfusion.Windows.Shared.ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(!DesignerProperties.GetIsInDesignMode(this))
            {
                switch(((ComboBoxItem)e.AddedItems[0]).Content.ToString())
                {
                    case "Shipping Line":
                        dataGridArea.Content = new YieldperTEUShipper();
                        break;
                    case "Import Consignee":
                        dataGridArea.Content = new YieldperTEUImport();
                        break;
                    case "Export Consignee":
                        dataGridArea.Content = new YieldperTEUExport();
                        break;
                }

                
            }
            
                                    
        }
    }
}
