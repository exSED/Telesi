   M S B A M L   `   `   `  ����A  =Telesi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Telesi.TypesTelesi.Types  5          Telesi.Types.InvoiceList   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Telesi.Types     5      .��5	      � -   5          �Name$  InvoicesPanel��5	       � RowDefinitions 5
   
   �� 5      �� 5      $��0 �6   .+�5   
   � -   5        $  MarginReference��5      $y�Hidden=�6(   $��1��6<   $��50 10q�6I   � 5   
   -   5        $  WhiteReference��5      $y�Hidden=�6'   $��1��6;   $��100 0q�6H   ��5      
� 5      .��5      �  � Color$ 	#CCFFFFFF��6#    � Offset$
 0.15Q�65   � 5      $ 	#00FF0000��6#   $ 1Q�65   5      5      � 5   
   -   5        $  BlackReference��5      $y�Hidden=�6'   $��1��6;   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67    �� RelativeTransform 5      V� 5      .~�5      ��  �� CenterY$	 0.5Q�6-    �� CenterX$	 0.5Q�6;   �� 5      	 �� CenterY$		 0.5Q�6,   
 �� CenterX$	
 0.5Q�6:   �� 5       �� Angle$ 90Q�6.    �� CenterY$	 0.5Q�69    �� CenterX$	 0.5Q�6G   T� 5      5       .��5"      � $ 	#00000000��6#   $ 0Q�65   � 5#      $ 	#99FF0000��6#   $	 0.3Q�65   5$      5&      � 5'   
   -   5        $
  BRef��5'      $y�Hidden=�6   $��1��61   ��5(      �� 5)      $ 0.5,1&�6&   $ 0.5,0&�67    5*      V� 5+      .~�5,      �� $	 0.5Q�6-   $	 0.5Q�6;   �� 5-      $		 0.5Q�6,   $	
 0.5Q�6:   �� 5.      $ 90Q�6.   $	 0.5Q�69   $	 0.5Q�6G   T� 5/      50      .��52      � $ 	#E5FF0000��6#   $ 0Q�65   � 53      $ 	#E5000000��6#   $ 1Q�65   54      56      � 57   
   $y�Hidden=�6   $��1��6#    � ColumnDefinitions 58      �� 59      -   5         ��Name$ ColumnReference��59   #   $��75 �6<   �� 5:      -   5        $ numRef��5:   #   $	��110 �63   �� 5;      -   5        $ dateRef��5;   #   $	��200 �64   �� 5<      -	   5        $ totalRef��5<   #   $��1* �65   �� 5=      -
   5        $ prRef��5=   #   $	��110 �62   �� 5>      -   5        $ editIconRef��5>   #   $��40 �68   �� 5?      -   5        $ 
delIconRef��5?   #   $��40 �67   �� 5@      -   5        $ 
newIconRef��5@   #   $��40 �67   5B      �� 5C   
   -   5         ��Name$ DelRef��5C      $y�Hidden=�6    $��/Image/XNegro.png��64   $��1��6O   �� 5D   
   -   5        $ Deleted��5D      $y�Hidden=�6!   $��/Image/XNegro.png��65   $��1��6P   $��20q�6]   �� 5E   
   -   5        $ EditRef��5E      $y�Hidden=�6!   $��/Image/LapizVerde.png��65   $��5q�6T   $��1��6_    � Cursor$
 Hand��6l   �� 5F   
   -   5        $ MoreRef��5F      $y�Hidden=�6!   $��/Image/MasFondoBlanco.png��65   $
��4 20q�6X   $��1��6f   �� 5G   
   -   5        $ Paloma��5G      $y�Hidden=�6    $��/Image/PalomaVerde.png��64   $
��4 20q�6T   $��1��6b   �� 5H   
   -   5        $ Ok��5H      $y�Hidden=�6   $��/Image/OjoChafa.png��60   $��5q�6M   $��1��6X   �� 5I   
   -   5        $ ImageRef��5I      $y�Hidden=�6"   $��1��66   $��/Image/Inventario2.png��6C   �� 5J   
   -   5         ��Name$
 Alli��5J      $y�Hidden=�6   $��Center=�62   $��Center=�6O   $��8(�6j   �� 5K   
   -   5         ��Name$ TBoxRef��5K      $�� ��6$   $y�Hidden=�6,   $��1��6@   ���	#3FFFFFFF$
��5 15q�6d   5L      5M      