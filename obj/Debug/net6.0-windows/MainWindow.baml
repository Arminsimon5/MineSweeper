   M S B A M L   `   `   `  ����F  BMineSweeper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MineSweeperMineSweeper  5   	       MineSweeper.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:MineSweeper     5   	   
�������  � 
ResizeMode$  NoResize=�5	   	    � Title$ MineSweeper��5
   	   $	��700��6   $	��500��6*   .��5      �  � 	Resources 5   
      akna �� ImageSource j� Stretch��%E   &	        �� 5      $ akna.png��6&   $ UniformToFill=�6=   5       � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��500 �6   �� 5      $	��100 �6   .+�5   
   �� -   5        $��2��5   (   $��Új játék��65   $��Center=�6H   $
��Left=�6c   $��	30,0,0,50q�6~   $��20(�6�   $	��120��6�   $��30��6�   $��Bahnschrift)�6�   �� 5   
   -   5         ��Name$ nehezseg��5      $��2��6%   $��0��62   $��	0,0,30,50q�6B   $	��120��6U   $��30��6a   $��Center=�6m   $��Right=�6�   $��Bahnschrift)�6�   $��20(�6�   .@�5      �� $��Könnyű��6    �� 
IsSelected$
 True��6-   �� 5      $��Normál��6   �� 5      $��Nehéz��6   5      �� 5   
   -   5        	 ��Name$	 aknakTB��5   <   $��0��6   $
��Left=�6!   $��20q�6M   $��20(�6Y   $��30��6g   $��Bahnschrift)�6s   � 5   
   -   5        
 �Name$
 gridTo��5   (   $��1��6   $��20q�6   $��Center=�68   6W   �� 5   
   -   5         ��Name$ doomGuy��5      $��doomGuy0.png��6!   $��0��67   $��center=�6D   �� 5    
   -   5        $	 idozito��5       $��0��6%   $��Right=�62   $��20q�6N   $��20(�6Z   $��30��6h   $��Bahnschrift)�6t   �� 5!   
   -   5        $	 testTB��5!      $��2��6$   $��Center=�61   $��20q�6N   $��20(�6Z   $��30��6h   $��Bahnschrift)�6t   5"      5#      