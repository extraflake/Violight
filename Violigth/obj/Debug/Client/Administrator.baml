   M S B A M L   `   `   `  ����C  ?Violigth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:VioligthVioligth  5   	   1clr-namespace:Violigth.ClientVioligth.Client  5   	   A%clr-namespace:Violigth.Data.ViewModelVioligth.Data.ViewModel  5   	   #    Violigth.Client.Administrator   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Violigth     5   	   0clientclr-namespace:Violigth.Client     5   	   <
viewmodels%clr-namespace:Violigth.Data.ViewModel     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  Administrator��5   	   $	��600��6   $
��1024��6,    � WindowStyle$
 None=�69    � 	Resources 5       �� DataType'   !Violigth.Data.ViewModel.ProfileVM   Violigth.Client.Profile � DataContext$   Violigth.Data.ViewModel.SellVM!   Violigth.Client.Transaction&    Violigth.Data.ViewModel.ReportVM   Violigth.Client.Report&    Violigth.Data.ViewModel.MasterVM   Violigth.Client.Master��%�  (��       5   .   *, +)(�� R     5   2   *, +)(�� �     5   -   *, +)(�� �     5   +   *, +)�� 5   
   ProfileMaster��"  6.   .R�5         6   �� 5      �� 5   
   TransactionMaster��"  62   .R�5         6!   �� 5      �� 5   
   ReportMaster��"  6-   .R�5         6   �� 5      �� 5   
   
DataMaster��"  6+   .R�5         6   �� 5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6    � RowDefinitions 5    
   �� 5!      $��30 �6   �� 5"      $��* �6   .+�5%   
   � $��1��6   $��1��6   ���	#FFC5C5C5.+�5&      �� 5'      5(      ]� 5*   
   $��1��6   .+�5+      � $��1��6   ��5,      �� 5-       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5.      � 	 � Color$	 	#FFE0E0E0��6'   
 � Offset$
 1Q�69   � 5/      $	 White��6'   50       52      �� 53      $	��100 �6$   �� 54      $��* �6$    J� Effect 56      3	  -System.Windows.Media.Effects.DropShadowEffect	  57       	  
BlurRadius$ 20Q�6'    	  Color$ 	#FFDEDEDE��67    	  RenderingBias$ Quality=�6I    	  ShadowDepth$ 1Q�6a   .+�5:      � ���	#FFA46FE4.+�5;      �� $��1��6   $_��YC:\Users\NaufalAj\Documents\Visual Studio 2017\Projects\Violigth\Violigth\Client\logo.png��5<       �� BitmapScalingMode$
 Fant=�5=      $
��Fill=�5>      $	��200��5?      $	��100��5@      $	��Top=�5A      $��0,0,0,0q�5B      $��Center=�5C      5D      �� 5F      $��1��6   .+�5G      �� -   5        $��Account��5G      $��10q�6,   ���	#FF8522BD���	#FF8522BD.��5H      � $	��150��6   .+�5I      '
  !MaterialDesignThemes.Wpf.PackIcon
  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Account=�66   $��Center=�6E   �� 5J      $��Center=�6(   $��PROFILE��6E   $��Comic Sans MS)�6T   5K      5L      �� 5N      -   5        $��TransactionBTN��5N   )   $��10q�6   ���	#FF8522BD���	#FF8522BD.��5O      � $	��150��6   .+�5P      
  $ TruckDelivery=�66   $��Center=�6K   �� 5Q      $��Center=�6(   $��TRANSACTION��6E   $��Comic Sans MS)�6X   5R      5S      �� 5U      -   5        $��	ReportBTN��5U   )   $��10q�6   ���	#FF8522BD���	#FF8522BD.��5V      � $	��150��6   .+�5W      
  $ FileDocument=�66   $��Center=�6J   �� 5X      $��Center=�6(   $��REPORT��6E   $��Comic Sans MS)�6S   5Y      5Z      �� 5\      -   5        $��Master��5\      $��10q�6+   ���	#FF8522BD���	#FF8522BD.��5]      � $	��150��6   .+�5^      
  $ ContentPaste=�66   $��Center=�6J   �� 5_      $��Center=�6(   $��MASTER DATA��6E   $��Comic Sans MS)�6X   5`      5a      5b      5c      5d      � 5f   
   -   5         �Name$ GridAdministrator��5f      $��2��6*   ���	#FF8522BD.+�5g      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $
��10,0q�6N   .+�5h      �� $��Hello, ��6   $��Center=�6+   $��32��6F   
�������6Q   �� 5i      -   5        $��AccountText��5i      $��Center=�6/   $	��100��6J   
�������6V   �� 5j       0  ,MaterialDesignFloatingActionMiniAccentButton#��[  6   $��25��6_   $��25��6j   
���������6v   Z� ��6�   Z� .��5k      
  $
 Bell=�6.   $��Right=�6:   5l      �� 5m      #��[  6   $��25��6_   $��25��6j   
���������6v   Z� ��6�   Z� .��5n      
  $ Account=�6.   $��Right=�6=   5o      �� 5p      -   5         ��Name$ Power��5p      #��[  6(   $��25��6n   $��25��6y   
���������6�   Z� ��6�   Z� .��5q      
  $ Power=�6.   $��Right=�6;   5r      5s      5t      �� 5v   
   $��0��6   $��1��6&   $��4��66   $��5��6J   ��6[   �� 5w      5x      