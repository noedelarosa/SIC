   M S B A M L   `   `   `  ����H  DEmpresa.Comun, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:Empresa.Comun;assembly=Empresa.ComunEmpresa.Comun  5   	    SIC;   5SIC.Objs.Controles.Dialogos.Dial_IndiqueSueldoDecreto   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   DComun2clr-namespace:Empresa.Comun;assembly=Empresa.Comun     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     6J   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�   -   5          �Name$"  us_Dial_IndiqueSueldoDecreto��5   	    � Title$1 +Indique El sueldo Que tendra en el Decreto.��5   	   $	��466��6=   $	��550��6J    � 
ResizeMode$ NoResize=�6V    � WindowStartupLocation$ CenterScreen=�6l    � ShowInTaskbar .   � 	Resources 5      '   !Empresa.Comun.ConvertMesNombreAno   ConvertMesNombreAno��%   &	          5   
   6$   5	      .��5
      � .+�5   
   �� -   5         ��Name$ ch_NoSueldo��5      $��Sueldo Disponible��6(   $
��Left=�6D   $��	27,75,0,0q�6_   $	��Top=�6r   $	��261��6�   �� 5   
   .��5      � $��10,99,11,135q�6   {�6)   ��  �� ElementName$ ch_NoSueldo�� �� Path$ 	IsChecked�.+�5      � $	��177��6   $��	10,10,9,0q�6$   $	��Top=�67   .+�5      �� ���	#FF666666$��1q�65   �� 5      $
��Left=�6    $��	10,44,0,0q�6;   $
��Wrap=�6N   $	��Top=�6b   $	��101��6z   $
��Bold"�6�   ���	#FFC7C4C4�� 6�   	 � Language$	 es-do�6�   $�Sueldo Actual��6�   6�   �� 5      -   5        
 ��Name$
 lbl_SueldoActual��5       $
��Left=�6�   $��
123,44,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $	��206��6  $
��Bold"�6   � ToolTip$8 2Ultimo sueldo Registrado en la nomina del docente.��6-  ��6:   �� **(Docente.HistorialPagos.Ultimo.MontoBruto+$" us_Dial_IndiqueSueldoDecreto�� �� StringFormat$ {0:N}���� 6k  $	 es-do�6o  6�  �� 5      $
��Left=�6    $��	10,13,0,0q�6;   $
��Wrap=�6N   $	��Top=�6b   $	��101��6z   $
��Bold"�6�   $��14(�6�   �� 6�   $	 es-do�6�   $�Sueldo Decreto��6�   6�   �� 5      -   5         ��Name$ Txt_SueldoDecreto��5      $
��Left=�69   $��22��6T   $��
123,10,0,0q�6`    �� TextWrapping$
 Wrap=�6t   $	��Top=�6�   $	��208��6�   $9 3Ponga el sueldo que el docente tendra en el decreto��6�   $��0��6�   �� 5      -   5        $
 lbl_fechapromedio��5       $
��Left=�6�   $��
123,65,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $	��206��6  $
��Bold"�6#  $8 2Ultimo sueldo Registrado en la nomina del docente.��65  ��6;   �� *Decreto.FechaPromedio+ �� 	Converter# [  $" us_Dial_IndiqueSueldoDecreto���� 6s  $	 es-do�6w  6�  �� 5      $
��Left=�6    $��	10,65,0,0q�6;   $
��Wrap=�6N   $	��Top=�6b   $	��101��6z   $
��Bold"�6�   ���	#FFC7C4C4�� 6�   $	 es-do�6�   $�Fecha Promedio��6�   6�   �� 5      $
��Left=�6    $��
10,112,0,0q�6;   $
��Wrap=�6O   $	��Top=�6c   $	��101��6{   $
��Bold"�6�   ���	#FFC7C4C4�� 6�   $	 es-do�6�   $�	Porciento��6�   6�   �� 5      -   5        $ Txt_Porciento��5   �   $
��Left=�6   $	��100��6Y   $��125,107,0,0q�6e   $
 Wrap=�6z   $	��115��6�   $��23��6�   $	��Top=�6�   �� 5      $
��Left=�6    $��
371,0,0,49q�6;   $
��Wrap=�6O   $��15��6c   $
��Bold"�6n   $��20��6�   $��Bottom=�6�    J� RenderTransformOrigin$ 0.533,0&�6�   �� 6�   $	 es-do�6�   $�%��6�   6�   �� 5      -   5        $
 lbl_montopromedio��5       $
��Left=�6�   $��
123,86,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $	��206��6  $
��Bold"�6  $8 2Ultimo sueldo Registrado en la nomina del docente.��6$  ��6;   �� *Decreto.FechaPromedio+# [  $ usercontrol���� 6b  $	 es-do�6f  6z  �� 5      $
��Left=�6    $��	10,86,0,0q�6;   $
��Wrap=�6N   $	��Top=�6b   $	��101��6z   $
��Bold"�6�   ���	#FFC7C4C4�� 6�   $	 es-do�6�   $�Monto Promedio��6�   6�   �� 5      -   5         ��Name$  But_CalcularSueldoPromedio��5      $��Calcular Porciento��6A   $��245,107,0,0q�6^   $��24��6�   $	��Top=�6�   $
��Left=�6�   $	��121��6�   �� 5      $
��Left=�6    $��
125,0,0,25q�6;   $
��Wrap=�6O   $	��149��6c   $
��Bold"�6o   $��20��6�   $��Bottom=�6�   ���	#FF5D5C5C$��Italic$�6�   �� 6�   $	 es-do�6�   $�Indicar numero(s) entero��6�   6  �� 5      -	   5        $ but_promediotabla��5      $��0,0,5,5q�69   $��25��6J   $��Bottom=�6V   $��Right=�6q   $	��135��6�   $��0q�6�   
���������6�   Z� .��5      �� $��Promedio Salarial��6$   $��	Underline{�6=   $
��Bold"�6Y   6m   5       5"      5#      5$      � 5&   
   $
��Left=�6   $��51��6*   $��	27,10,0,0q�66   $	��Top=�6I   $	��292��6a   .+�5'      �� $��	55,10,0,0q�6   $
��Wrap=�6+   $	��Top=�6?   $��16(�6W   $
��Bold"�6e   $
��Left=�6w   $	��231��6�   �� 6�   $	 es-do�6�   $#�Indique sueldo en el Decreto?��6�   6�   �� 5(      $
��Left=�6   $��48��6/   $��2,2,0,0q�6;   $	��Top=�6L   $��48��6d   $8��2/SIC;component/Objs/Comun/imgs/payment_help_48.png��6o   5)      � 5*   
   $��32��6   $��27,298,28,0q�6   $	��Top=�60   .+�5+      �� $
��Left=�6   $��10,6,0,0q�63   $
��Wrap=�6E   $	��Top=�6Y   $	��101��6q   $
��Bold"�6}   ���	#FFC9C9C9�� 6�   $	 es-do�6�   $�Tipo:��6�   6�   �� 5,      -
   5         ��Name$ Com_PJ��5,       �� DisplayMemberPath$ Nombre��6'   $c ]Indique si el docente como se registrara el docente en el decreto como Pensionado o Jubilado.��6B   $
��Left=�6�   $��	125,4,0,0q�6�   $	��Top=�6�   $	��152��6�   6�   �� 5-      ���	#FF7A7A7A$��1q�6-   5.      �� 50   
   -   5        $ But_Aceptar��50      $��Aceptar��6@   $
��Left=�6R   $��23��6m   $��
34,340,0,0q�6y   $	��Top=�6�   $��83��6�   �� 51   
   -   5        $ But_SueldoActualMismo��51      $��Mismo Sueldo Promedio��60   $
��Left=�6t   $��23��6�   $��122,340,0,0q�6�   $	��Top=�6�   $	��139��6�   $[ Usi desea indicar que el sueldo del decreto sera el ultimo que docente tubo en nomina.��6�   �� 52   
   -   5        $ 	But_Salir��52      $��Salir��6$   $
��Left=�6L   $��23��6g   $��266,340,0,0q�6s   $	��Top=�6�   $��83��6�   $ salir��6�   �� 53   
   $��
79,0,19,19q�6   $
��Wrap=�6(   $q��kEl MONTO PROMEDIO es calculado en base a 12 sueldos anterior a la fecha promedio establecida en el decreto.��6<   $��34��6�   $��Bottom=�6�   $
��Bold"�6�   �� 54   
   $��	34,0,0,19q�6   $
��Wrap=�6'   $��Aviso:��6;   $��34��6I   $��Bottom=�6U   $
��Left=�6p   $��34��6�   $
��Bold"�6�   ���	#FFC517176�   55      56      