   M S B A M L   `   `   `  ����C  ?Violigth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Violigth.ClientVioligth.Client  5      !    Violigth.Client.Transaction   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Violigth.Client     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null6mah,http://metro.mahapps.com/winfx/xaml/controls  5      -   5        .��5      � .+�5   
   �� -   5        $��TempNameText��5      $
��Left=�6&   $��23��6A   $��
154,10,0,0q�6M     �� TextWrapping$
  Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   $y�Hidden=�6�   �� 5   
   -   5        $��TempNameCartText��5      $
��Left=�6*   $��23��6E   $��
154,10,0,0q�6Q   $
  Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   $y�Hidden=�6�   �� 5   
   -   5        $��TempReceiptText��5      $
��Left=�6)   $��23��6D   $��	54,23,0,0q�6P   $
  Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   $y�Hidden=�6�   �� 5   
   $
��Left=�6   $	��282��60   $��	10,46,0,0q�6=   $	��Top=�6P   $	��513��6h   .+�5      �� 6   &   System.Windows.Controls.DataGrid  5      -   5        $��SellGrid��5         
IsReadOnly . $
��Left=�69   $	��265��6T   $	��Top=�6a   $	��503��6y      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Nama��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *	Item.Name+6W     5      $ Jumlah��6)    69   �� *
Quantity+6X     5      $ Harga��6)    68   �� *Price+6T     5      $ 	Sub Total��6)    6<   �� *
SubTotal+6[   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Action��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6=      CellTemplate 5      �� 5      .R�5   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5   &   �� $��	DeleteBtn��6-   -   5        ���	#FF8522BD���	#FF8522BD$��0,0,9,0q�5   �   .��5   *   � $��15��6/   .+�5   .   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]	   Kind$	 RemoveCircle=�6F   $��Center=�6Z   �� 5   .   $��Right=�68   $��Comic Sans MS)�6T   $��0,0,28,0q�6o   5    +   5!   '   5"   #   5#      5%      5'      5(      �� 5)   
   $
��Left=�6   $	��328��60   $��
523,46,0,0q�6=   $	��Top=�6Q   $	��267��6i   .+�5*      �� -   5        $��CategoryCombo��5*      
 �� Text$
 Pilih Kategori��6^    �� 
IsEditable .  �� 
IsReadOnly . $
��Left=�6�   $	��Top=�6�   $	��120��6�    �� DisplayMemberPath$
 Name��6�    �� SelectedValuePath$ Id��6�   �� 5+      6   �� 5,      -   5         ��Name$ ProductText��5,   Y   $	��267��6   $��Center=�6#   $
��Left=�6>   $��Cari Produk��6n   6�   �� 5-      6     5.      -	   5        $��ProductGrid��5.       . $
��Left=�6<   $	��166��6W   $	��Top=�6d   $	��267��6|    .   5/        50      $
 Nama��6)    67   �� *Name+6R     51      $ Jumlah��6)    69   �� *Stock+6U     52      $ Harga��6)    68   �� *Price+6T   54      �� 55      6   �� 56      $ 
Horizontal=�6   .+�57      *	  $MahApps.Metro.Controls.NumericUpDown	  -
   5        $��QuantityText��57   $    	  Minimum$ 0Q�68    	  Maximum$ 10000Q�6D    	  Interval$ 1Q�6T   $	��266��6a   �� 59      -   5        $ QuantityValidationText��59   ]   $	��258��6   $��Center=�6'   $
��Left=�6B   $y�Hidden=�6}   5:      �� 5;      6   �� 5<      -   5        $��
AddCartBtn��5<      ���	#FF8522BD���	#FF8522BD$��38��6q   .��5=      � $	��150��6   .+�5>        $	 CartAdd=�6.   $��Center=�6=   �� 5?      $��Center=�6    $��Tambah Keranjang��6=   $��Comic Sans MS)�6U   5@      5A      5B      �� 5C   
   $��10,333,287,10q�6   $ 
Horizontal=�6,   .+�5D      �� $��Result��6   $
��Left=�6'   $	��157��6B   $	��Top=�6O   $	��250��6g   .��5E      �� $ 
Horizontal=�6   .+�5F      �� .+�5G      �� $��	Sub Total��6    66   �� 5H      $��Discount��6    65   5I      �� 5J      6   �� 5K      .+�5L      �� $��:��6    6.   �� 5M      $��:��6    6.   5N      �� 5O      6   �� 5P      .+�5Q      �� -   5        $��SubTotalText��5Q   "   $	��140��66   {�.  6V   �� 5R      -   5        $��DiscountText��5R   "   $	��140��66   6_   5S      5T      5U      �� 5V      6   �� 5W      $��
Pembayaran��6   $
��Left=�6+   $	��Top=�6F   $	��243��6^   $	��157��6j   .��5X      �� $ 
Horizontal=�6   .+�5Y      �� .+�5Z      �� $��Tunai��6    62   �� 5[      $��Grand Total��6    68   �� 5\      $��Kembali��6    64   5]      �� 5^      6   �� 5_      .+�5`      �� $��:��6    6.   �� 5a      $��:��6    6.   �� 5b      $��:��6    6.   5c      �� 5d      6   �� 5e      .+�5f      �� -   5        $��CashText��5f   "   $	��150��62   6W   �� 5g      -   5        $��GrandTotalText��5g   "   $	��150��68   {�.  6X   �� 5h      -   5        $��
ChangeText��5h   "   $	��150��64   {�.  6T   5i      5j      5k      5l      �� 5m   
   $
��Left=�6   $	��111��60   $��523,379,0,0q�6=   $	��Top=�6R   $	��267��6j   .+�5n      �� -   5        $��
PayCartBtn��5n      ���	#FF8522BD���	#FF8522BD$��50��6p   .��5o      � $	��150��6   .+�5p        $	 Payment=�6.   $��Center=�6=   �� 5q      $��Center=�6    $��Bayar��6=   $��Comic Sans MS)�6J   $��30(�6e   
�������6s   5r      5s      �� 5t      6   �� 5u      -   5        $��CancelCartBtn��5u      ���	#FF8522BD���	#FF8522BD$��50��6v   .��5v      � $	��150��6   .+�5w        $	 Cancel=�6.   $��Center=�6<   �� 5x      $��Center=�6    $��Batal��6=   $��Comic Sans MS)�6J   $��30(�6e   5y      5z      5{      5|      5}      