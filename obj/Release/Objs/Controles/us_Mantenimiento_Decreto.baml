   M S B A M L   `   `   `  ����   SIC1    +SIC.Objs.Controles.us_Mantenimiento_Decreto   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -     >�Name$  UserControl��.��� .+�� $��94��$��
10,10,10,0q�$	��Top=����	#FFDEDEDE.+��� $
��Left=�$��48��$��	10,10,0,0q�$	��Top=�$��48��$3��-/SIC;component/Objs/Comun/imgs/decreto_48.png���� $
��Left=�$��	70,10,0,0q�$
��Wrap=�$	��Top=�$	��255��$
��Bold"�$��16(���  � Language$ es-do�$�Mantenimiento de Decretos���� $��60��$��	72,37,0,0q�$
��Wrap=�$	��Top=�$
��Left=�$	��642���� $ es-do�$���El siguiente Asistente le ayudara a crear y modificar los decretos, debe tener disponible el Numero de decreto, las fechas de emsion y primer pago puede dejar la fecha por defecto que posteriormente seran modificadas corespondiente sus fecha de emsión(cuando se emita el decreto y cuando sea haga la primera fecha de pago del decreto)���� -    ��Name$ tab_control��$��10,109,10,50q�.@��� $��Crear��.��� ���	#FFF0EEEE.+�� $��10,51,10,70q�.+��� ���	#FF878787$��1q�$��0q��� $
��Left=�$��	10,13,0,0q�$
��Wrap=�$	��Top=��� $ es-do�$�Número Decreto���� -    ��Name$ Txt_Decreto��$
��Left=�$��23��$��	137,6,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��251�� � ToolTip$4 .Indique que el numero de decreto. Empl(334-12)�� �� MaxLines$ 1�� �� 	MaxLength$ 15������ *Decreto.Numero+ �� ElementName$ UserControl��	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� NotifyOnValidationError
 .  �� ValidatesOnDataErrors .  �� NotifyOnSourceUpdated .  �� NotifyOnTargetUpdated . �� $
��Left=�$��	10,70,0,0q�$
��Wrap=�$	��Top=�$	��116���� $ es-do�$�Primero Fecha Pago���� $
��Left=�$��	10,45,0,0q�$
��Wrap=�$	��Top=�$	��116���� $ es-do�$�Fecha Emisión��(  "System.Windows.Controls.DatePicker  -     Name$ Txt_FechaEmision��   SelectedDateFormat$
 Long=�$
��Left=�$��
137,34,0,0q�$	��Top=�$	��251��$ Fecha por defecto.��   SelectedDate �� *Decreto.FechaEmision+$ UserControl��$	 PropertyChanged=�
 .  .   -   $ Txt_FechaPrimerPago��$
 Long=�$
��Left=�$��
137,62,0,0q�$	��Top=�$	��251��$ fecha por defecto.�� �� *Decreto.FechaPrimerPago+$ UserControl��$	 PropertyChanged=�
 .  . �� $
��Left=�$��	10,98,0,0q�$
��Wrap=�$	��Top=�$	��116���� $ es-do�$�Fecha Promedio��  -   $ Txt_FechaPromedio��$
 Long=�$
��Left=�$��
137,92,0,0q�$	��Top=�$	��251��$ fecha por defecto.�� �� *Decreto.FechaPromedio+$ UserControl��
 . $	 PropertyChanged=� . �� $
��Left=�$��
393,90,0,0q�$
��Wrap=�$	��Top=�$	��250���� $ es-do�$B�<Inicio Fecha, Promedio 12 meses Apartir de la presente fecha���� $
��Left=�$��137,116,0,0q�$
��Wrap=�$	��Top=�$	��250��$> 8solo se utiliza año y mes para el calculo del promedio.��$
��Bold"����	#FF5D5D5D�� $ es-do�$!�Solo se utiliza Año y Mes.���� $
��Left=�$��138,132,0,0q�$
��Wrap=�$	��250��$< 6Nombre de persona quien decreta el documento(Decreto).��$
��Bold"����	#FF5D5D5D$��16��$	��Top=����� *Decreto.Presidente.Nombres+$	 PropertyChanged=�$ UserControl���� $ es-do��� $
��Left=�$��
11,132,0,0q�$
��Wrap=�$	��Top=�$	��116���� $ es-do�$�Decretado por:���� $��Creando Decreto��$
��Left=�$��	10,20,0,0q�$	��Top=�$	��146��$��16(�$
��Bold"�� $��
9,209,10,0q�.+��� $
��Left=�$��	10,10,0,0q�$
��Wrap=�$	��Top=�$	��130��$��14(�$
��Bold"��� $ es-do�$�Ultimo Decreto���� -    ��Name$ Txt_UltimoDecreto��$
��Left=�$��
145,13,0,0q�$
��Wrap=�$	��Top=�$��93���� ���	#FF878787$��1q�$��0q��� -    ��Name$ But_AgregarUltimo��$��Agregar Docentes��$
��Left=�$��21��$��	10,34,0,0q�$	��Top=�$	��137���� -	   $��	Modificar��.��� ���	#FFE5E5E5.+��� -
    ��Name$ com_decretos�� �� DisplayMemberPath$ Numero��$��
148,22,0,0q�$��24��$	��Top=�$
��Left=�$	��249��� $��10,51,10,70q�.+��� ���	#FF878787$��1q�$��0q��� $
��Left=�$��	10,13,0,0q�$
��Wrap=�$	��Top=��� $ es-do�$�Número Decreto���� -   $ Txt_Decreto_modificacion��$
��Left=�$��23��$��	137,6,0,0q�$
 Wrap=�$	��Top=�$	��251��$4 .Indique que el numero de decreto. Empl(334-12)��$ 1��$ 15������ *SelectedItem.Numero+$ com_decretos��$	 PropertyChanged=�
 .  .  .  . �� $
��Left=�$��	10,70,0,0q�$
��Wrap=�$	��Top=�$	��116���� $ es-do�$�Primero Fecha Pago���� $
��Left=�$��	10,45,0,0q�$
��Wrap=�$	��Top=�$	��116���� $ es-do�$�Fecha Emisión��  -   $# Txt_FechaEmision_modificacion��$
 Long=�$
��Left=�$��
137,34,0,0q�$	��Top=�$	��251��$ Fecha por defecto.�� �� *SelectedItem.FechaEmision+$ com_decretos��$	 PropertyChanged=�
 .  .   -   $&  Txt_FechaPrimerPago_modificacion��$
 Long=�$
��Left=�$��
137,62,0,0q�$	��Top=�$	��251��$ fecha por defecto.�� �� *SelectedItem.FechaPrimerPago+$ com_decretos��$	 PropertyChanged=�
 .  . �� $
��Left=�$��	10,98,0,0q�$
��Wrap=�$	��Top=�$	��116���� $ es-do�$�Fecha Promedio��  -   $$ Txt_FechaPromedio_modificacion��$
 Long=�$
��Left=�$��
137,92,0,0q�$	��Top=�$	��251��$ fecha por defecto.�� �� *SelectedItem.FechaPromedio+$ com_decretos��
 . $	 PropertyChanged=� . �� $
��Left=�$��
393,90,0,0q�$
��Wrap=�$	��Top=�$	��250���� $ es-do�$B�<Inicio Fecha, Promedio 12 meses Apartir de la presente fecha���� $
��Left=�$��137,116,0,0q�$
��Wrap=�$	��Top=�$	��250��$> 8solo se utiliza año y mes para el calculo del promedio.��$
��Bold"����	#FF5D5D5D�� $ es-do�$!�Solo se utiliza Año y Mes.���� $
��Left=�$��138,132,0,0q�$
��Wrap=�$	��250��$< 6Nombre de persona quien decreta el documento(Decreto).��$
��Bold"����	#FF5D5D5D$��16��$	��Top=����� *!SelectedItem.Presidente.Nombres+$	 PropertyChanged=�$ com_decretos���� $ es-do��� $
��Left=�$��
11,132,0,0q�$
��Wrap=�$	��Top=�$	��116���� $ es-do�$�Decretado por:���� $
��Left=�$��	10,30,0,0q�$
��Wrap=�$	��Top=��� $ es-do�$�Seleccione el decreto��� $��
12,0,10,10q�$��40��$��Bottom=�.+��� -   $ But_Guardar��$��Guardar��$
��Left=�$��0,10,0,0q�$	��Top=�$��99���� -   $ But_Cancelar��$��Cancelar��$
��Left=�$��
113,10,0,0q�$	��Top=�$��99��