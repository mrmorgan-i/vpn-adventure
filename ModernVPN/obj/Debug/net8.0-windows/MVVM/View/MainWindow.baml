   M S B A M L   `   `   `  ����D  @ModernVPN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ModernVPN	ModernVPN  5   	   /clr-namespace:ModernVPN.CoreModernVPN.Core  5   	   C&clr-namespace:ModernVPN.MVVM.ViewModelModernVPN.MVVM.ViewModel  5   	       ModernVPN.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ModernVPN     5   	   3
extensionsclr-namespace:ModernVPN.Core     5   	   <	viewModel&clr-namespace:ModernVPN.MVVM.ViewModel     5   	     � Title$  KLM VPN��5
   	   $	��450��6   $	��800��6&    � WindowStyle$
 None=�5   	    � Icon$H BC:\Users\ikell\source\repos\ModernVPN\ModernVPN\MVVM\View\bg2.jpeg��5   	   
������  � AllowsTransparency$
 True��5   	    � 
ResizeMode$ 	CanResize=�5   	    � DataContext 5      ,  &ModernVPN.MVVM.ViewModel.MainViewModel  5   
   .��5      ]� ���#1E1E1E$��7q�6%   .+�5   
   �� ���#252525$��28��5      $	��Top=�5       J� InputBindings 5      d� 5       d� MouseAction$ 	LeftClicke�6    �� Command 5      �� *MoveWindowCommand+._�5       � 	 � ColumnDefinitions	 5!      �� 5"      �� 5#      $	��100 �6+   .+�5%      �� $��KLM VPN 1.0.1��6   $��Center=�5&      $��Center=�5'      $��	100,0,0,0q�5(      
�������$��Consolas)�5*      �� 5,      $��1��6   
 �� Orientation$
 
Horizontal=�5-      $��Right=�5.      $��0,0,4,0q�5/      .+�51      �� $	��—��6   $��0,0,0,2q�53      ��52      �� *MinimizeWindowCommand+53      �� 54      $	��□��6   $��0,0,0,3q�55      ��56      �� *MaximizeWindowCommand+�� 57      $��×��6   $��0,0,0,2q�58      ��59      �� *ShutdownWindowCommand+5;      5<      5>      �� 5?   
   $��50��6   $
��Left=�5@      ���#252525��5C      �� 5D       �� Triggers 5E      :� 5F       :� RoutedEvent$ Border.MouseEnter��6'   [�5G      �� 5H   "   .��5I   &   �� .��5J   *   W�  �� TargetProperty$ (Border.Width)�6:   	 W� To 1205K   :    g� Duration$ 0:0:.1D�5L   :   5M   '   5N   #   5P      :� 5Q      $ Border.MouseLeave��6'   [�5R      �� 5S   "   .��5T   &   �� .��5U   *   W� $ (Border.Width)�6:    505V   :   $ 0:0:.1D�5W   :   5X   '   5Y   #   5[      5]      ._�5`      �� .+�5a      	� $	��VPN��6     ModernVPN.Core.Extensions   Icon$
 🛡��5b      
������� d� 	IsChecked$
 TrueY�5d      $��7.6,3.5,8,0q�5e      $��16(�5f      $��Normal"�5g      ��5h      �� *ShowProtectionView+	� 5m      $��	 Settings��6   $	 ⚙��5n      
�������$��6,3.5,4.7,0q�5p      $��16(�5q      $��Normal"�5r      ��5s      �� *ShowSettingsView+5t      5v      �� 5x   
   ��6   �� *CurrentView+5{      5|      