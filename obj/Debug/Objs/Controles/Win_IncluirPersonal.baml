   M S B A M L   `   `   `  ����>  :SIC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Contrato.objects.paginasContrato.objects.paginas  5   �   7 clr-namespace:SIC.Objs.ControlesSIC.Objs.Controles  6�   ,    &SIC.Objs.Controles.Win_IncluirPersonal   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   :paginas&clr-namespace:Contrato.objects.paginas     6�   2local clr-namespace:SIC.Objs.Controles     6�   -   5          �Name$  us_Win_IncluirPersonal��5   �    � Title$" Incluir Personal NO docente.��5   	   $��632.448��6.   $	��737��6?    � WindowStartupLocation$ CenterScreen=�6K    � 
ResizeMode$ NoResize=�6p   .��5      � -   5         �Name$ gri_general��5      .+�5   
   � -   5        $ grid_controles��5      .+�5      �� $
��Left=�6   $��50��6/   $��	10,20,0,0q�6;   $	��Top=�6N   $��50��6f   $1��+/SIC;component/Objs/Comun/imgs/group_48.png��6q   � 5
      -   5        $ grid_info_personal��5
      $��
10,87,10,0q�6/   $	��Top=�6C   $	��148��6[   .+�5      �� 
���   �$��1q�6-   $
��Left=�6A   $��75��6\   $��	20,48,0,0q�6h   $	��Top=�6{   $��75��6�   ._�5      �� $��UniformToFill=�6�   ��6   �� *DocenteIncluido.Foto+ �� ElementName$ us_Win_IncluirPersonal�� �� UpdateSourceTrigger$ PropertyChanged=�6�   5      �� 5      $��32.666��6   $	��Top=�6)   ���	#74747474.+�5      ��  � ToolTip$ Dirección del docente��6    $
��Left=�6@   $��Información Personal��6[   $	��Top=�6w   $��197.003��6�    �� Left$ 35��6�   
	 �� Top$	 8.464��6�   
���   �$
��Bold"�6�   �� 5      $��27��6   $ 5��6(   $ Dirección del docente��68   $	 3.464��6X   $��27��6k   $9��3/SIC;component/Objs/Comun/imgs/administrator_32.png��6v   5      �� 5      -   5        
 ��Name$
 border_Copy��5      $��1q�6/   ��5      �� 5       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5      �  � Color$ 	#BC726E6E��6+    � Offset$ 1Q�6=   � 5      $ 	#30FFFFFF��6+   5      5      �� 5      $
��Left=�6   $��18��67   $��
109,48,0,0q�6C   $
��Wrap=�6W   $	��Top=�6�   $	��231��6�   $
��Bold"�6  $��14(�6  ��6k   �� *DocenteIncluido.CedulaF+$ us_Win_IncluirPersonal��$ PropertyChanged=�6  �� 5      $
��Left=�6   $��18��67   $��
109,71,0,0q�6C   $
��Wrap=�6W   $	��Top=�6�   $	��231��6�   ��6k   �� * DocenteIncluido.NombreCompleto+$ us_Win_IncluirPersonal��$ PropertyChanged=�6�   �� 5      $
��Left=�6   $��18��67   $��
109,89,0,0q�6C   $
��Wrap=�6W   $	��Top=�6�   $	��231��6�   ��6k   �� *DocenteIncluido.EsMasculinof+$ us_Win_IncluirPersonal��$ PropertyChanged=�6�   �� 5      $
��Left=�6   $��18��67   $��109,104,0,0q�6C   $
��Wrap=�6X   $	��Top=�6�   $	��231��6  ��6l   �� *&$DocenteIncluido.EdadPartida_FormatoA+$ us_Win_IncluirPersonal��$ PropertyChanged=�6  5      �� 5      $��
75,20,10,0q�6   $
��Wrap=�6,   $1��+Asistente para incluir personal no docente.��6@   $	��Top=�6s   $��18(�6�   $
��Bold"�6�   ���	#FF000C896�   �� 5       $��
75,49,10,0q�6   $
��Wrap=�6,   $H��BPuede incluir personal no procedente del Ministerio de educación.��6@   $	��Top=�6�   � 5!      -   5        $ grid_inf_laboral��5!      $��10,240,10,0q�6-   $	��Top=�6B   $	��290��6Z   .+�5"      �� $��32.666��6   $	��Top=�6)   ���	#74747474.+�5#      �� $ Dirección del docente��6    $
��Left=�6@   $��Información Laboral��6[   $	��Top=�6v   $��197.003��6�   $ 35��6�   $	 8.464��6�   
���   �$
��Bold"�6�   �� 5$      $��27��6   $ 5��6(   $ Dirección del docente��68   $	 3.464��6X   $��27��6k   $1��+/SIC;component/Objs/Comun/imgs/files_32.png��6v   5%      �� 5&      -   5        $
 border_Copy1��5&      $��1q�60   ��5'      �� 5(      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5)      � $ 	#BC726E6E��6+   $ 1Q�6=   � 5*      $ 	#30FFFFFF��6+   5+      5-      �� 5.      $
��Left=�6   $��	26,62,0,0q�67   $
��Wrap=�6J   $	��Top=�6^   $��17��6v   $��75��6�   �� 6�    � Language$ es-do�6�   $�Fecha actual��6�   6�   �� 5/      -   5         ��Name$ 	Txt_Fecha��5/      $
��Left=�6/   $��
131,62,0,0q�6J   $
��Wrap=�6^   $	��Top=�6r   $��17��6�   $	��160��6�   �� 6�   $ es-do�6�   $�
01/01/2010��6�   6�   �� 50      $
��Left=�6   $��	26,89,0,0q�67   $
��Wrap=�6J   $	��Top=�6^   $��17��6v   $��93��6�   �� 6�   $ es-do�6�   $�Monto Sueldo��6�   6�   �� 51      -	   5         ��Name$ 	Txt_Monto��51      $
��Left=�6-   $��23��6H   $��
131,83,0,0q�6T    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��210��6�   $��0��6�   �� 52      $
��Left=�6   $��
26,117,0,0q�67   $
��Wrap=�6K   $	��Top=�6_   $��17��6w   $��93��6�   �� 6�   $ es-do�6�   $�Tiempo Servicio��6�   6�   �� 53      -
   5        $ Txt_TiempoServicio��53      $
��Left=�66   $��23��6Q   $��131,111,0,0q�6]   $
 Wrap=�6r   $	��Top=�6�   $	��210��6�   $��0��6�   �� 54      $
��Left=�6   $��
26,155,0,0q�67   $
��Wrap=�6K   $	��Top=�6_   $��17��6w   $��93��6�   �� 6�   $ es-do�6�   $�Lugar Trabajo��6�   6�   �� 55      $
��Left=�6   $��131,171,0,0q�67   $
��Wrap=�6L   $	��Top=�6`   $��17��6x   $	��392��6�   $��Italic$�6�   $
��Bold"�6�   ���	#FF807E7E�� 6�   $ es-do�6�   $F�@Para buscar una empresa escriba su RNC o Nombre y presione Enter��6�   6-  '   !SIC.Objs.Controles.ERSuplidormini  56      -   5          Name$ us_er_empresa��56   '   '   !SIC.Objs.Controles.ERSuplidormini   SeleccionItem$! us_er_empresa_SeleccionItem��6U   $��131,145,10,10q�6>   6U   57      �� 58      -   5         ��Name$ But_Guardar��58   1   $
��Left=�6   $��8,0,0,23q�6H   $	��102��6Z   $��28��6f   $��Bottom=�6r   .��59      � $	��102��6   .+�5:      ��  �� Orientation$ 
Horizontal=�6!   .+�5;      �� $��24��6    $��24��6+   $��5,0,2,0q�67   $
��Left=�6H   $.��(/SIC;component/Objs/Comun/imgs/ok_24.png��6c   �� 5<      $��5,5,10,0q�6$   $��Guardar��66   5=      5>      5?      �� 5@      -   5        $ 	But_Salir��5@   1   $
��Left=�6   $��
115,0,0,23q�6E   $	��102��6Y   $��28��6e   $��Bottom=�6q   .��5A      � $	��102��6   .+�5B      �� $ 
Horizontal=�6!   .+�5C      �� $��24��6    $��24��6+   $��5,0,2,0q�67   $
��Left=�6H   $3��-/SIC;component/Objs/Comun/imgs/ddelete_32.png��6c   �� 5D      $��5,5,10,0q�6$   $��19��66   $	��Top=�6B   $��Salir��6Z   5E      5F      5G      �� 5H      -   5        $ But_OtraBusqueda��5H      $��	0,0,10,15q�61   $��28��6D   $��Bottom=�6P   $��Right=�6k   $	��152��6�   .��5I      � $	��102��6   .+�5J      �� $ 
Horizontal=�6!   $��	0,0,-18,0q�6:   .+�5K      �� $��24��6    $��24��6+   $��5,0,2,0q�67   $
��Left=�6H   $3��-/SIC;component/Objs/Comun/imgs/ddelete_32.png��6c   �� 5L      $��0,5,10,5q�6$   $��19��66   $	��Top=�6B   $��Otra Busqueda��6Z   $��84��6o   5M      5N      5O      5Q      � 5R   
   -   5        $ grid_inicial��5R      
�������.+�5S      � $
��Left=�6   $��
144,0,0,64q�6.   $	��564��6B   $��50��6N   $��Bottom=�6Z   .+�5T      �� $
��Left=�6   $
��Wrap=�67   $��Aviso:��6K   $	��Top=�6Y   ���	#FFBB0A0A$
��Bold"�6�   �� 5U      $��	46,0,10,0q�6   $
��Wrap=�6/   $����El siguiente personal que incluira en nuestro sistema, es un personal no docente por consiguiente existen reglas y calculos no aplicable para este personal.��6C   $	��Top=�6�   $��40��6�   $
��Bold"�6  5V      �� 5W      $��Center=�6   $��Center=�66   $	��342��6Q   .+�5X      �� $
��Wrap=�6   $	��Top=�60   $��0,0,0,5q�6H   �� 6Z   $�Introdusca una c��6^   �� 6x   $�é��6|   �� 6�   $�dula y presion��6�   �� 6�   $�e��6�   �� 6�   $� enter o buscar��6�   6�   .   (Contrato.objects.paginas.ERBuscarPersona  5Y      -   5          Name$ us_buscarempresa��5Y   *   .   (Contrato.objects.paginas.ERBuscarPersona   	Limpiando$ ERBuscarPersona_Limpiando��6p      SeleccionItem$# ERBuscarPersona_SeleccionItem��6�   $��Center=�6D   $��0,0,0,5q�6_   6�   �� 5Z      -   5        $��Buscar��5Z      $��Center=�6*   $��Center=�6E   $	��100��6b   $��26��6n   6z   5[      � 5\      $
��Left=�6   $	��126��6.   ���	#FF36363A6:   � 5]      ���	#FF36363A$��126,0,23,20q�6*   $��28��6?   $��Bottom=�6K   � 5^      $��44��6   $	��Top=�6   ���	#FF36363A$��126,21,23,0q�6N   .+�5_      �� $��	10,10,0,0q�6   $
��Wrap=�6/   $$��ASISTENTE PARA BUSCAR PERSONAL��6C   $	��Top=�6i   $��22(�6�   $
��Bold"�6�   
�������$
��Left=�6�   $	��527��6�   $��30��6�   5`      5a      5b      5c      