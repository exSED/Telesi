   M S B A M L   `   `   `  ����A  =Telesi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Telesi.ViewsTelesi.Views  5          Telesi.Views.InvoicesView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Telesi.Views     5        � 	Resources  5	         ScrollThumbs �� 
TargetType �� Property �� Value �Name ��Name �� CornerRadius �� Triggers P� Property	 P� Value
 �� 
TargetName �� 
TargetType ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton P� 
SourceName  ButtonSelectBrush  	DarkBrush �� Angle�� 5
   
   %$	  &	        '�� M    �� 5      " n�6)   .�5      ��  � �� 5      �� 5      .R�5      � $
 Grid��6#   .+�5   "   �� $��Stretch=�6,   $��Stretch=�6J   $
��Auto��6f   $
��Auto��5   ,   
������ 6:   �� 5   "   $ 
Rectangle1��6)   $ 	10 0 0 10��6=   $��Stretch=�6V   $��Stretch=�5   )   $
��Auto��6E   $
��Auto��6R   #��z��5   )   5       5      P� 5   "    �@�Tag$	 
Horizontal��69   . �5   &   �� $
 
Rectangle1��6-    � ��$
 Auto��6V   �� 5   &   $
 
Rectangle1��6-    � ��$ 7��6W   5   #   5      5      5      �� 5"      " ��6/   .�5#      ��  �@��IsFlicksEnabled$ False��6;   �� 5$       � �� �	#AAA8341A6/   �� 5%       � ��
 �����6/   �� 5&       � ��$ 10��6*   �� 5'       � �� 5(      �� 5)      " ��6*   .R�5*      � $ GridRoot��6#   $��12��65   ��6@   Z� .+�5+   "   ]� $ 
PART_Track��6(   $��0��6<   $
��true��6I   $|�False��6d    5,   &   n� 5-   *   $ Thumb��60   #��z��6?   #���   5.   0    50   &   �� 51   *   $ PageUp��67   $��ScrollBar.PageDownCommand��6G   $ 0Q�6k   $|�False��6w    53   &   �� 54   *   $ PageDown��67   $��ScrollBar.PageUpCommand��6I   $ 0Q�6k   $|�False��6w   56   #   57       59      P� 5:   "   $ Thumb��6*    �@J�IsMouseOver$
	 true��6T   . �5;   &   �� # �  6-   $
 Thumb��5<   -    � ��6@   5=   #   P� 5>   "   $ Thumb��6*    �@n�
IsDragging$
	 true��6S   . �5?   &   �� # �  6-   $
 Thumb��6Q    � ��6d   5@   #   P� 5B   "    � {�$	 false��6?   . �5C   &   �� $
 Thumb��6-    � y�$ 	Collapsed=�6V   5D   #   P� 5E   "    �@��Orientation$	 
Horizontal=�6A   . �5F   &   �� $
 GridRoot��6-    �@�LayoutTransform 5G   *   �� 5H   .   $	 -90Q�6>   5J   '   �� 5K   &   $
 
PART_Track��6-    �@�LayoutTransform 5L   *   �� 5M   .   $	 -90Q�6>   5O   '   �� 5P   &    � ��$
 Auto��6>   �� 5Q   &    � ��$ 12��6?   �� 5R   &   $
 Thumb��6-    �@�Tag$ 
Horizontal��6O   �� 5S   &   $
 PageDown��6-    � ��$ ScrollBar.PageLeftCommand��6V   �� 5T   &   $
 PageUp��6-    � ��$  ScrollBar.PageRightCommand��6T   5U   #   5W      5Y      5Z      5[      ��5^      �� 5_   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5`      �  � Color$ 	#33FFFFFF��6    � Offset$	 0.8Q�6-   � 5a      $ 	#00000000��6   $ 1Q�6-   5b      .��5e      �  � RowDefinitions 5f   
   �� 5g      $
��0.6* �6   �� 5h      $��6* �6   �� 5i      $��0 �6   .+�5k   
   � $��0��6    � ColumnDefinitions 5l      �� 5m      $	��10* �6#   �� 5n      $
��0.6* �6#   .+�5p      � $��80 20 100 10q�6    5q      �� 5r      �� 5s      $��40 �6'   .+�5u      � $��1��6   ���	#33FFFFFF.+�5v      �� $��/Image/Lupa.png��6   5w      �� 5x      -   5         ��Name$ Buscar��5x      $��0��5y      ���	#33FFFFFF$��0,0,0,0q�5|      $��24(�5}      $��Buscar��5~      $��Arial Rounded MT Bold)�5       �� TextAlignment$
 Left=�5�      ��5{      Z� 5�      5�      � 5�      $��3��6   5�      5�      � 5�   
   $��1��6   $��
20 5 20 20q�6    5�      �� 5�      $��50 �6    �� 5�      .+�5�      � $��0��6   $��Right=�6#   $��0,0,0,10q�6?   .+�5�      �� -   5         ��Name$ NewInvoP��5�      $��/Image/NuevoDocumento.png��5�      $	 0.8Q�5�       � Cursor$
 Hand��5�      5�      � 5�      -   5        $	 Til��5�      $��0��6    $��150,1,200,10q�6-   $��0��6C   ��5�      �� 5�      $ 0.5,1&�6*   $ 0.5,0&�6;    �� RelativeTransform 5�      V� 5�      .~�5�   "   ��   �� CenterY$	  0.5Q�61   ! �� CenterX$	! 0.5Q�6?   �� 5�   "   " �� CenterY$	" 0.5Q�60   # �� CenterX$	# 0.5Q�6>   �� 5�   "   $ 90Q�62   $ �� CenterY$	$ 0.5Q�6=   % �� CenterX$	% 0.5Q�6K   T� 5�   "   5�      .��5�      � $ 	#00000000��6'   � 5�      $ 	#B2620000��6'   $ 0.078Q�69   5�       5�      �� 5�      $	��110 �6'   �� 5�      $	��200 �6'   �� 5�      $��1* �6'   .+�5�      �� $��Número��6   $��0��6)   $��Center=�6:   $��Arial Rounded MT Bold)�6U   $��20(�6x   
�������$��34��6�   �� 5�      $��Fecha��6   $��1��6(   $��Center=�68   $��Arial Rounded MT Bold)�6S   $��20(�6v   
�������$��34��6�   �� 5�      $��Total pagado��6   $��2��6/   $��Center=�6?   $��Arial Rounded MT Bold)�6Z   
�������$��20(�6�   $��2                        q�6�   5�      �� 5�      -   5        & ��Name$& ScrViwer��5�      $��1��6-   $��100,0,40,30q�6:   .��5�      �� -   5        $��Pp��5�      $��5q�6#   $	��Top=�6.   5�      5�      5�      5�      5�      