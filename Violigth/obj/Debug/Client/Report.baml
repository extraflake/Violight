   M S B A M L   `   `   `  ����C  ?Violigth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Violigth.ClientVioligth.Client  5          Violigth.Client.Report   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Violigth.Client     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        .��5      � .+�5   
   �� $
��Left=�6   $��78��60   $��	10,30,0,0q�6<   $	��Top=�6O   $	��314��6g     �� Orientation$  
Horizontal=�6s   .+�5      �� $  Vertical=�6   .+�5      �� $
��Dari��6   6)   (  "System.Windows.Controls.DatePicker  5      -   5        $��FromDate��5      $	��150��6-   5      �� 5      �� 5      $  Vertical=�6   .+�5      �� $��Ke��6   6'     5      -   5        $��ToDate��5      $	��150��6+   67   5      5      �� 5   
   $
��Left=�6   $	��378��60   $��
10,113,0,0q�6=   $	��Top=�6Q   $	��780��6i   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��
ReportGrid��5         
IsReadOnly . $
��Left=�6;   $	��242��6V   $	��Top=�6c   $	��782��6{      AutoGenerateColumns .  $��0,0,-2,0q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Kode Transaksi��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *Id+6Z     5      $ Tanggal Transaksi��6)    6D   �� *
CreateDate+6e     5      $ Diskon��6)    69   �� *
Discount+6X     5      $ Total��6)    68   �� *Total+6T   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Action��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6=      CellTemplate 5      �� 5       .R�5!   "   �� $  
Horizontal=�6-   .+�5"   &   �� $��	DetailBTN��6-   -   5        ���	#FF8522BD���	#FF8522BD$��0,0,9,0q�5"   �   .��5#   *   � $��15��6/   .+�5$   .   '  !MaterialDesignThemes.Wpf.PackIcon  �	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]] 	  Kind$ Details=�6F   $��Center=�6U   �� 5%   .   $��Right=�68   $��Comic Sans MS)�6T   $��0,0,28,0q�6o   5&   +   5'   '   5(   #   5)      5+      5-      �� 5.      �� 5/      $	��136��6   .+�50      �� $	��250��6   $	��125��6'   $	��Top=�64   $
��Left=�6L   $��Laporan��6g   .��51      �� $  
Horizontal=�6!   .+�52      �� $��Pemasukan :��6    �� 53      -   5        $��
IncomeText��53   "   {�.  $	��Top=�6F   $	��150��6^   54      55      56      57      �� 58   
   -   5        $��ReceiptTempText��58      $
��Left=�6)   $��23��6D   $��
377,41,0,0q�6P   	 �� TextWrapping$
	 Wrap=�6d   $��TextBox��6x   $	��Top=�6�   $	��120��6�   $y�Hidden=�6�   5:      5;      