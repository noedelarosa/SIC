   M S B A M L   `   `   `  ����>  :SIC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5      I)clr-namespace:SIC.Objs.Controles.PortadasSIC.Objs.Controles.Portadas  6D   0    *SIC.Objs.Controles.Portadas.PortadaMensaje   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9WpfApplication1clr-namespace:WpfApplication1     5      ;local)clr-namespace:SIC.Objs.Controles.Portadas     6D   $	��300��5   3   $	��350��6@     � 	Resources  5         Entrada �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value 
 Salida��%�  &	        &	 l    �� 5	   
   .��5
      U� $ (UIElement.Opacity)�6,   $ esperacircular��6\   .\�5        $ 0��6'   $ 1Q�63     5      $ 0:0:0.3��6'   $ 0Q�69   5      U� 5      $ (UIElement.Opacity)�6,   $
 grid��6\   .\�5        $ 0:0:0.3��6'   $ 0.805Q�69     5      $ 0:0:0.6��6'   $ 0Q�69   5      5      �� 5   
   .��5      U� $ (UIElement.Opacity)�6,   $ esperacircular��6\   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.3��6'   $ 1Q�69   5      U� 5      $ (UIElement.Opacity)�6,   $
 grid��6\   .\�5        $ 0:0:0.3��6'   $ 0Q�69     5      $ 0:0:0.6��6'   $ 0.805Q�69   5      5      5       � Triggers 5      :� 5   
    :� RoutedEvent$&  local:PortadaMensaje.EsTerminado��6   .[�5       �� #��[  6   5!      :� 5"   
   $# local:PortadaMensaje.EsInicio��6   .[�5#      �� -   5         ��Name$ Salida_BeginStoryboard��5#      #��[ 6>   5$      ��5&      �� 5'   
    �� EndPoint$ 0.5,1&�6   	 �� 
StartPoint$	 0.5,0&�6/   .��5(      � 
 � Color$
 White��6    � Offset$ 0Q�6)   � 5)      $
 	#19FFFFFF��6   $ 1Q�6-   5*      .��5,      � .+�5-   
   � -   5         �Name$ grid_01��5-      $��10,10,10,81q�6    .+�5.      �� $��32.666��6   $	��Top=�6%   ���	#74747474.+�5/      �� $
��Left=�6   $��Mensaje��67   $	��Top=�6F   $��197.003��6^    �� Left$ 10��6n   
 �� Top$ 8.464��6   
���   �$
��Bold"�6�   50      �� 51      -   5         ��Name$ border_Copy7��51      $��1q�6,   ��52      �� 53      $ 0.5,1&�6*   $	 0.5,0&�6;   .��54      � $
 	#BC726E6E��6'   $ 1Q�69   � 55      $
 	#30FFFFFF��6'   56      ._�58      �� $
��Left=�6   $��48��63   $��9,47,0,0q�6?   $	��Top=�6Q   $��48��6i   $2��,/SIC;component/Objs/Comun/imgs/hijack_48.png��6t   5;      5=      �� 5>   
   $��73,50,10,81q�6   .+�5?      �� -   5         ��Name$ Txt_TituloInterno��5?      $
��Left=�63   $��5q�6N   $
��Wrap=�6Y   $	��n/d��6m   $	��Top=�6x   $	��249��6�   $��MS Reference Sans Serif)�6�   $��14(�6�   �� 5@      -   5        $ 	Txt_Cifra��5@      $
��Left=�6+   $��5,5,0,5q�6F   $
��Wrap=�6W   $	��0.0��6k   $	��Top=�6v   $	��252��6�   $��MS Reference Sans Serif)�6�   $��30(�6�   5A      �� 5B   
   -   5        $ 
TxT_Titulo��5B      $��10,224,10,0q�6(   $
��Wrap=�6=   $	��n/d��6Q   $	��Top=�6\   $��21��6t   $��Microsoft Sans Serif)�6�   $
��Bold"�6�   �� 5C   
   -   5        $ 	Txt_Texto��5C      $��10,245,10,0q�6'   $
��Wrap=�6<   $	��n/d��6P   $	��Top=�6[   $��45��6s   � 5D   
   -   5        $
 grid��5D      $��0q�6   ���	#FF2C2C2C J� Opacity$ 0.805Q�6?   .+�5E      $   WpfApplication1.esperacircular  -	   5          Name$ esperacircular��5E   *   $��0q�6B   $	��150��6M   $��30��6Y   5F      5G      5H      