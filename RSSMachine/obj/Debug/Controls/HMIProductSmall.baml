   M S B A M L   `   `   `  ����H  DRSSMachine, Version=1.0.2.1589, Culture=neutral, PublicKeyToken=null'clr-namespace:RSSMachine
RSSMachine  5           RSSMachine.HMIProductSmall   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      *localclr-namespace:RSSMachine     5      $	��267��5	      $	��401��6   .��5
      �   � ColumnDefinitions  5   
   �� 5      $��27 �6   �� 5      $
��206* �6   �� 5      $��27 �6    � RowDefinitions 5   
   �� 5      $��44 �6   �� 5      $��30 �6   �� 5      $��15 �6   �� 5      $
��231* �6   �� 5      $��25 �6   �� 5      $��50 �6   �� 5      $��20 �6   '  !System.Windows.VisualStateManager   VisualStateGroups 5    
   %  System.Windows.VisualStateGroup  5!      -   5        MouseStateGroup��   Transitions 5"      %  System.Windows.VisualTransition  5#         GeneratedDuration$ 0D�6'      States. 5%         System.Windows.VisualState  -   5        ControlMouseEnter��   
Storyboard. 5&      �� .��5'      W�  g� Duration$ 0D�6*   	 W� To$ 4X�67   	 �� TargetProperty$	 (Shape.StrokeThickness)�6>   
 �� 
TargetName$
 recMouse��6r   �� 5(      $ 0D�6)   	 �� To$
 BlueX�66   $,	 &(Shape.Stroke).(SolidColorBrush.Color)�6@   $
 recMouse��6�   5)      5*        5+      -   5        ControlMouseLeave��5+      5,        5-      -   5        ValueStateGroup��5-        5.      -   5        ActualStateGroup��. 5/        -   5        ControlActualTrue��. 50      �� .��51      T� $	 (UIElement.Visibility)�68   $
 	vwWarning��6k   ..�52      i�  R� KeyTime$ 0��65    R� Value 53   "     System.Windows.Visibility 54   &   	Collapsed=�6<   56      57      58      59        5:      -   5        ControlActualFalse��. 5;      �� .��5<      T� $	 (UIElement.Visibility)�68   $
 	vwWarning��6k   ..�5=      i� $ 0��65    5>   "    5?   &   Visible=�6:   5A      5B      5C      5D      5E      .+�5G   
   �� -   5         ��Name$ recMouse��5G      
���   �$��7��65   $��3��6F   5K      (� 5L   
   -	   5         (�Name$ 	vwWarning��5L      $y�	Collapsed=�6%   $��7��6<   $��3��6M   .��5M      � $��31��6   $��31��6   .+�5N      F� '����Ԅ� ���єf�����(v�U�?���	 �� Stretch$
 Fill=�6V   
���   � � UseLayoutRounding .  ��5O      �� 5P       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5Q      �  � Color$ 	#FFC2E000��6+    � Offset$ 0Q�6=   � 5R      $ 	#FFF0410E��6+   $ 1Q�6=   5S      5U      �� 5V      $
��Wrap=�6   $��!��60   $��26.667(�69    �� TextAlignment$ Center=�6K   5W      5X      �� 5Y   
   -
   5        $ 
recProduct��5Y      
���   �$��0��67   $��0,-7,0,0q�6K   $��3��6]   $��3��6j   5]      �� 5^   
   -   5         ��Name$ 	txtSKUBig��5^      $
��Wrap=�6'   $��28(�6;   $
��Left=�6J   $	��Top=�6f   $��SKU Big��6   $
��Auto��6�   
�������$
��Auto��6�   $��1��6�   $��-0.001,0,0,0q�6�   �� 5_   
   -   5        $ txtSKUSmall��5_      $
��Wrap=�6)   $��20(�6=   $
��Left=�6K   $	��Top=�6g   $��	SKU Small��6�   $
��Auto��6�   
�������$
��Auto��6�   $��1��6�   $��1��6�   $��-0.001,0,0,0q�6�   �� 5`   
   -   5        $ recPrice��5`       �� RadiusY$ 20��6&    �� RadiusX$ 20��63   
���   �$��5��6O   $��1��6\   ��5a      �� 5b      $ 0.5,0&�6&   $ 0.5,1&�69    � MappingMode$ RelativeToBoundingBox=�6J   .��5c      � $ 	#FF8D9DE6��6#   $ 0Q�65   � 5d      $ 	#FF0C00FD��6#   $ 1Q�65   5e      5g      �� 5h   
   -   5        $ txtPrice��5h      $
��Wrap=�6&   $��20(�6:   $��Center=�6H   $	��Top=�6e   $��Price��6~   $
��Auto��6�   
�������$
��30.5��6�   $��5��6�   $��1��6�   $��85.153,10,85.153,0q�6�   5i      5j      