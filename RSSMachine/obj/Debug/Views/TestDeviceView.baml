   M S B A M L   `   `   `  ����H  DRSSMachine, Version=1.0.2.1589, Culture=neutral, PublicKeyToken=null'clr-namespace:RSSMachine
RSSMachine  5          RSSMachine.TestDeviceView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:RSSMachine     5         RSSMachine.ViewBase    Loaded$  ViewBase_Loaded��5   >   ���#dddddd$
��1920��6#   $
��1080��61   .��5	      � .+�5
   
      RSSMachine.HMIButton  -   5          Name$ btnBeep��5
         RSSMachine.HMIButton   Click$ btnBeep_Click��6�   $
��Left=�6+   $��
686,34,0,0q�6F   $	��Top=�6Z   $	��150��6r   $	��158��6      CaptionFontSize$ 50Q�6�      Text$  ��6�      	FillBrush 5      �� 5       �� ImageSource$% /image/Actions-speaker-icon.png��6    j� Stretch$ Uniform=�6K   5      �� 5   
   -   5         ��Name$ recMouse��5      	 �� RadiusY$	 10��6&   
 �� RadiusX$
 10��63   
���   �$��34,34,660,1602q�6O   ��5      �� 5       �� 
StartPoint$ 0.5,0&�6&    �� EndPoint$ 0.5,1&�69    � MappingMode$ RelativeToBoundingBox=�6J   .��5      �  � Color$ 	#FFFFFFFE��6#    � Offset$ 0Q�65   � 5      $ 	#FFA2A2A2��6#   $ 1Q�65   5      5        5   
   -   5        $ btnAllow��5      $ btnAllow_Click��6�      ClickUp$ btnAllow_ClickUp��6�   $
��Left=�6,   $��
69,142,0,0q�6G   $	��Top=�6[   $	��150��6s   $	��158��6�   $ 50Q�6�   $  ��6�    5      �� 5      $- '/image/Actions-dialog-ok-apply-icon.png��6   $ Uniform=�6S   5        5   
   -   5        $ btnDeny��5      $ btnDeny_Click��6�   $ btnDeny_ClickUp��6�   $
��Left=�6+   $��232,142,0,0q�6F   $	��Top=�6[   $	��150��6s   $	��158��6�   $ 50Q�6�   $  ��6�    5      �� 5      $) #/image/Actions-edit-delete-icon.png��6   $ Uniform=�6O   5       �� 5!   
   -   5         ��Name$ 
txtCaption��5!      $
��Wrap=�6(   
 �� Top$ 6.002��6<   $��50(�6O   $��Center=�6]   $��Center=�6z   $��Пульт кассира��6�   $��34,34,660,1810q�6�   $��76��6�   $	��386��6�    �� TextAlignment$ Center=�6�   �� 5"   
   -   5        $ recMouse_Copy��5"      $	 10��6+   $
 10��68   
���   �$��34,404,236,1149q�6T   ��5#      �� 5$      $ 0.5,0&�6&   $ 0.5,1&�69   $ RelativeToBoundingBox=�6J   .��5%      � $ 	#FFFFFFFE��6#   $ 0Q�65   � 5&      $ 	#FFA2A2A2��6#   $ 1Q�65   5'      5)      �� 5*   
   -   5        $ txtCaption_Copy��5*      $
��Wrap=�6-   $��50(�6A   $��Center=�6O   $��Center=�6l   $��Статистика��6�   $��34,404,660,1440q�6�   $��76��6�   $	��386��6�   $ Center=�6�   �� 5+   
   -   5         ��Name$ lblLoopCount��5+      $��?��6&   $
��Left=�62   $��
34,485,0,0q�6M   $	��Top=�6a   $��90��6y   $	��810��6�   $��50(�6�   �� 5,   
   -	   5        $ lblCycleSpan��5,      $��?��6&   $
��Left=�62   $��
34,580,0,0q�6M   $	��Top=�6a   $��80��6y   $	��810��6�   $��50(�6�   �� 5-   
   -
   5        $ lblQueueCount��5-      $��?��6'   $
��Left=�63   $��
34,665,0,0q�6N   $	��Top=�6b   $��82��6z   $	��810��6�   $��50(�6�   51      52      