   M S B A M L   `   `   `  ����  SIC5    /SIC.Objs.Controles.us_notificacionFallecimiento   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      f bXceed.Wpf.DataGrid.v4.3, Version=4.3.12074.17240, Culture=neutral, PublicKeyToken=ba83ff368b7563c6f bXceed.Wpf.Controls.v4.3, Version=4.3.12074.17240, Culture=neutral, PublicKeyToken=ba83ff368b7563c67xcdg*http://schemas.xceed.com/wpf/xaml/datagrid   5        � 	Resources  5      5  /Xceed.Wpf.DataGrid.DataGridCollectionViewSource   source_data9  3Xceed.Wpf.DataGrid.DataGridCollectionViewSourceBase   Source��%&   &	          5	   
    6@   �� 5      .��5      � .+�5   
   � ���	#FFDEDEDE$��
10,10,10,0q�6&   $��74��6:   $	��Top=�6F   .+�5      �� $
��Left=�6   $��	81,33,0,0q�63   $
��Wrap=�6F   $	��Top=�6Z   $	��561��6r   $��16��6~   �� 6�   $O�ILas personas notificadas para fallecimiento son para fines investigación��6�   6�   �� 5      $
��Left=�6   $��	81,10,0,0q�63   $
��Wrap=�6F   $	��Top=�6Z   $	��304��6r   $
��Bold"�6~   $��14(�6�   �� 6�    � Language$ es-do�6�   $"�Notificaciones de Fallecidos��6�   6�   �� 5      $
��Left=�6   $��48��6/   $��	10,10,0,0q�6;   $	��Top=�6N   $��48��6f   $8��2/SIC;component/Objs/Comun/imgs/writer_close_48.png��6q   5      (  "Xceed.Wpf.DataGrid.DataGridControl  5   
   -   5          Name$ 	datagrid1��5         ItemsSourceName$ Listados Beneficiarios��63      AutoCreateColumns .  $��Stretch=�6v   $��10,139,10,46q�6�      ItemScrollingBehavior$ 	Immediate=�6�   ��6�   ��  �� Source# [     Columns 5        Xceed.Wpf.DataGrid.Column  5      #  Xceed.Wpf.DataGrid.ColumnBase	   	FieldName$	 Descripcion��6   
   Title$
 Descripción��66     5      $	 Fecha��6   $
 Fecha��60     5      $	 Docente.Cedula��6   $
 Cedula��69     5      $	 Docente.NombreCompleto��6   $
 Nombre��6A     5      $	 EsFallecidoMinimo��6   $
 	Es Valido��6<      View 5      (  "Xceed.Wpf.DataGrid.Views.TableView  5         ColumnStretchMode$
 Last=�6"   '  !Xceed.Wpf.DataGrid.Views.ViewBase   UseDefaultHeadersFooters .     Headers 5      �� 5       .R�5!      "  Xceed.Wpf.DataGrid.FilterRow  5"         FixedHeaders 5&      �� 5'      .R�5(      3	  -Xceed.Wpf.DataGrid.HierarchicalGroupByControl	   	  NoGroupContent$8 2Arrastre la(s) columna(s) que desea agrupar aquí.��6>      CanScrollHorizontally .  6�   5)      �� 5*      .R�5+      )
  #Xceed.Wpf.DataGrid.ColumnManagerRow
  5,         Theme 5/      3  -Xceed.Wpf.DataGrid.Views.AeroNormalColorTheme  50      53      56      � 57   
   $��31��6   $��	0,0,10,10q�6   $��Bottom=�6.   ���	#FFC3C3C3$��Right=�6`   $	��279��6|   .+�58      �� $
��Left=�6   $��5,6,0,0q�63   $
��Wrap=�6D   $	��Top=�6X   $��14(�6p   $
��Bold"�6~   �� 6�   $ es-do�6�   $�Total Docentes:��6�   6�   �� 59      $
��Left=�6   $��	111,6,0,0q�63   $
��Wrap=�6F   $	��Top=�6Z   $��14(�6�   $
��Bold"�6�   ��6r   �� *Items.Count+ �� ElementName$ 	datagrid1���� 6�   $ es-do�6�   6�   5:      �� 5;   
   -   5         ��Name$ 
But_Borrar��5;   ,   $
��Left=�6   $��
10,106,0,0q�6[   $	��102��6o   $��28��6{   $	��Top=�6�   .��5<      � $	��102��6   .+�5=      ��  �� Orientation$ 
Horizontal=�6   .+�5>      �� $��24��6   $��24��6'   $��5,0,2,0q�63   $
��Left=�6D   $3��-/SIC;component/Objs/Comun/imgs/ddelete_32.png��6_   �� 5?      $��5,5,10,0q�6    �� 63   $ es-do�67   $�Borrar��6H   6Y   5@      5A      5B      �� 5C   
   -   5        $ But_Recarga��5C      $��
0,106,10,0q�6B   $��28��6V   $	��Top=�6b   $��Right=�6z   $	��106��6�   .��5D      � $	��102��6   .+�5E      �� $ 
Horizontal=�6   .+�5F      �� $��24��6   $��24��6'   $��5,0,2,0q�63   $
��Left=�6D   $2��,/SIC;component/Objs/Comun/imgs/reload_48.png��6_   �� 5G      $��5,5,10,0q�6    �� 63   $ es-do�67   $�ReCarga��6H   6Z   5H      5I      5J      5L      5M      