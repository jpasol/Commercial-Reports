   M S B A M L   `   `   `  ����  Commercial Report"    Commercial_Report.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      e aSyncfusion.GridCommon.Wpf, Version=17.1460.0.38, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Tools.Wpf, Version=17.1400.0.38, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.SfGrid.WPF, Version=17.1460.0.38, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89`	 \Syncfusion.Linq.Base, Version=17.1460.0.38, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a
 ]Syncfusion.Shared.Wpf, Version=17.1460.0.38, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89_ [Syncfusion.Grid.Wpf, Version=17.1460.0.38, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89c _Syncfusion.SampleLayout, Version=17.1460.0.38, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89>
syncfusion!http://schemas.syncfusion.com/wpf    	 
   5        � Title$  
MainWindow��5      $	��720��60   $
��1080��6=   .��5      � $��Stretch=�6   $��Stretch=�6)    � ColumnDefinitions 5	   
   �� 5
      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   4  .Syncfusion.Windows.Controls.Grid.LayoutControl     
HeaderText$ Yield per TEU��6#      HeaderDescriptionText$7 1Shows the Yield per TEU from each kind of Revenue��6>      
LayoutMode$ Metro=�6�   $��1��6�   $��0��6�      GridView 5       � 5      -   5          �Name$ dataGridArea��5        � NavigationUIVisibility$ Hidden=�6.   	   UserOptionsView	 5      2  ,Syncfusion.Windows.Controls.Grid.UserOptions  
   
HeaderText$
 Revenue Kind��6)   .��5      �� .+�5      �� $
��Left=�6$   $��Center=�5       $��12(�5       $
��Bold"�5       $��Revenue Kind: ��5       �� 5      -   5        $��comboBinding��5   #   $	��150��5   #   $��0,10,0,0q�5   #   $
��Left=�5    #   $��Center=�5!   #    �� SelectedIndex$ 0��5"   #   .@�5%      �� $��Shipping Line��6+   �� 5&      $��Import Consignee��6+   �� 5'      $��Export Consignee��6+   5)      5*      5+      5-      5.      50      