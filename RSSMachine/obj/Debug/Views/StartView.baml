   M S B A M L   `   `   `  ����H  DRSSMachine, Version=1.0.2.1589, Culture=neutral, PublicKeyToken=null'clr-namespace:RSSMachine
RSSMachine  5          RSSMachine.StartView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:RSSMachine     5         RSSMachine.ViewBase    Loaded$  UserControl_Loaded��5
   #      IsVisibleChanged$  StartView_IsVisibleChanged��6?   $
��1920��5	      $
��1080��6   ���#dddddd.��5      � -   5         �Name$ myGrid��5      $
��1920��6    � RowDefinitions 5   
   �� 5      $��1145* �6   �� 5      $
��198* �6   �� 5      $
��577* �6   .+�5   
   r� -   5         r�Name$	 GIF��5       r� LoadedBehavior$ Manual=�6@    r� UnloadedBehavior$ Manual=�6X   $��0��6r   $��201,74,171,0q�6   6�   �� 5   
   ���#003399$
��Bold"�6%   $	��190(�67   $��246,1095,203,10q�6F   $��
ТАБАК��6_   $��2��6o      RSSMachine.UpdateControl  5   
   -   5          Name$ updGIF��5      $
��Left=�6.   $��405,450,0,0q�6I   $	��Top=�6^   $	��319��6v   $	��293��6�   �� 5   
   -   5         ��Name$ btnStart��5      $��Start��6#   $
��Left=�63   $��
10,331,0,0q�6N   $��2��6b   $	��Top=�6o   $	��272��6�   $	��123��6�   $��72(�6�   6�   �� 5   
   -   5        $ btnStop��5      $
��Stop��6"   $
��Left=�61   $��287,331,0,0q�6L   $��2��6a   $	��Top=�6n   $	��272��6�   $	��123��6�   $��72(�6�   6�      RSSMachine.HMIButton  5   
      RSSMachine.HMIButton	   Click$	 HMIButton_Click��6�   $
��Left=�6   $��
246,48,0,0q�65   $��2��6I   $	��Top=�6V   $��92��6n   $	��594��6z   
   RectangleRadius$
 30Q�6�      CaptionFontSize$ 50Q�6�      Text$( "Нажмите для выбора��6�      RSSMachine.HMIBase   Actual . 6�   5      5      