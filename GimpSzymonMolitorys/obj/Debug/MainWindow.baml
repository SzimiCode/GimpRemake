   M S B A M L   `   `   `  ����N  JGimpSzymonMolitorys, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GimpSzymonMolitorysGimpSzymonMolitorys  5   	   $    GimpSzymonMolitorys.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:GimpSzymonMolitorys     5   	     � Title$
  Gism��5   	   $	��600��6   $
��1000��6#   .��5	      � .+�5
   
   �� -   5        $��paintSurface��5
      ��5      �� 5       �� Color$ White��6"    �� Opacity$ 1Q�60   5      a� 5   
   $	��Top=�6   .+�5      c� .@�5      �� -   5         ��Name$ btnDraw��5      .��6@   Paint Freely5      �� 5      -   5        $ 	btnPoints��5      .��6D   Paint points5      o� 5      .@�5      m� $��Lines��6   .@�5      m� -   5         m�Name$ btnLines��5   8   $��Paint Lines��6#   6J   m� 5      -   5        $ editLine��5   #   $��
Edit Lines��65   6I   m� 5      -   5        $ 
brokenLine��5   #   $��Broken line��67   6L   5      5      o� 5      .@�5      m� $��Figures��6   .@�5       m� -   5        $ drawEllipse��5    #   $��Ellipse��68   6I   m� 5!      -   5        $ drawRectangle��5!   #   $��	Rectangle��6:   6M   m� 5"      -	   5        $ drawPolygon��5"   #   $��Polygon��68   6I   m� 5#      -
   5        $ drawTree��5#   #   $��Christmas Tree��65   6M   m� 5$      -   5        $ drawPlus��5$   #   $
��Plus��65   6C   m� 5%      -   5        $ drawStar��5%   #   $
��Star��65   6C   m� 5&      -   5        $ 	drawArrow��5&   #   $��Arrow��66   6E   m� 5'      -   5        $ drawTriangle��5'   #   $��Triangle��69   6K   5(      5)      �� 5*      -   5         ��Name$ 
whichColor��5*   @   $��30��6   $��30��6'   
��� � �5,      5-      5.      5/      50      