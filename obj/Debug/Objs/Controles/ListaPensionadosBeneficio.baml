   M S B A M L   `   `   `  ����  SIC2    ,SIC.Objs.Controles.ListaPensionadosBeneficio   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      f bXceed.Wpf.DataGrid.v4.3, Version=4.3.12074.17240, Culture=neutral, PublicKeyToken=ba83ff368b7563c6f bXceed.Wpf.Controls.v4.3, Version=4.3.12074.17240, Culture=neutral, PublicKeyToken=ba83ff368b7563c67xcdg*http://schemas.xceed.com/wpf/xaml/datagrid   5      -   5          >�Name$'  !ListaPensionadosBeneficio_control��5        � 	Resources 5	      5  /Xceed.Wpf.DataGrid.DataGridCollectionViewSource   source_data9  3Xceed.Wpf.DataGrid.DataGridCollectionViewSourceBase   Source��%&   &	          5
   
    6@   �� 5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Open��5      6�    J� InputBindings 5      �� 5   
    �� Command$ ApplicationCommands.Open��6   
 �� Key$ S��68    �� 	Modifiers$	 Altf�6@   6R   .��5      � .+�5   
   (  "Xceed.Wpf.DataGrid.DataGridControl  -   5        	  Name$	 	datagrid1��5      
   ItemsSourceName$
 Listados Beneficiarios��63      AutoCreateColumns .  $��Stretch=�6v   $��10,122,10,43q�6�      ItemScrollingBehavior$ 	Immediate=�6�   ��6�   ��  �� Source# [     Columns 5        Xceed.Wpf.DataGrid.Column  5      #  Xceed.Wpf.DataGrid.ColumnBase   	FieldName$ CedulaF��6      Title$ Cedula��62     5      $ Nombres��6   $ Nombres��62     5      $ 	Apellidos��6   $ 	Apellidos��64     5      $ FechaConcrecion��6   $ Fecha Concreción��6:     5      $ 
FechaCorte��6   $ Fecha Corte��65     5      $ ScalaPension��6   $ 	Porciento��67     5      $ MontoPagosRectroactivo��6   $ Monto��6A      View 5!      (  "Xceed.Wpf.DataGrid.Views.TableView  5"         ColumnStretchMode$
 Last=�6"   '  !Xceed.Wpf.DataGrid.Views.ViewBase   UseDefaultHeadersFooters .     Headers 5#      �� 5$      .R�5%      "	  Xceed.Wpf.DataGrid.FilterRow	  5&         FixedHeaders 5)      �� 5*      .R�5+      3
  -Xceed.Wpf.DataGrid.HierarchicalGroupByControl
   
  NoGroupContent$8 2Arrastre la(s) columna(s) que desea agrupar aquí.��6>      CanScrollHorizontally .  6�   5,      �� 5-      .R�5.      )  #Xceed.Wpf.DataGrid.ColumnManagerRow  5/         Theme 52      3  -Xceed.Wpf.DataGrid.Views.AeroNormalColorTheme  53      55      58      � 59   
   ���	#FFDEDEDE$��
10,10,10,0q�6&   $��74��6:   $	��Top=�6F   .+�5:      �� $
��Left=�6   $��	81,33,0,0q�63   $
��Wrap=�6F   $	��Top=�6Z   $	��322��6r   $��16��6~   �� 6�   $ �Aplique el filtro en funci��6�   �� 6�    � Language$ es-do�6�   $�ó��6�   �� 6�   $%�n a los parametros seleccionado��6�   �� 6   $ es-do�6  $�s.��6  6"  �� 5;      $
��Left=�6   $��	81,10,0,0q�63   $
��Wrap=�6F   $	��Top=�6Z   $	��304��6r   $
��Bold"�6~   $��14(�6�   �� 6�   $ es-do�6�   $ �Beneficios de Pensionados.��6�   6�   �� 5<      $
��Left=�6   $��48��6/   $��	10,10,0,0q�6;   $	��Top=�6N   $��48��6f   $=��7/SIC;component/Objs/Comun/imgs/clients_search_48_02.png��6q   5=      �� 5>   
   -   5         ��Name$ But_Agregar��5>   ,   $
��Left=�6   $��	10,89,0,0q�6\   $	��102��6o   $��28��6{   $	��Top=�6�   .��5?      � $	��102��6   .+�5@      ��  �� Orientation$ 
Horizontal=�6   .+�5A      �� $��24��6   $��24��6'   $��5,0,2,0q�63   $
��Left=�6D   $0��*/SIC;component/Objs/Comun/imgs/aadd_32.png��6_   �� 5B      $��5,5,10,0q�6    �� 63   $ es-do�67   $�Agregar��6H   6Z   5C      5D      5E      �� 5F   
   -   5        $ 
But_Borrar��5F   ,   $
��Left=�6   $��
117,89,0,0q�6B   $	��102��6V   $��28��6b   $	��Top=�6n   .��5G      � $	��102��6   .+�5H      �� $ 
Horizontal=�6   .+�5I      �� $��24��6   $��24��6'   $��5,0,2,0q�63   $
��Left=�6D   $3��-/SIC;component/Objs/Comun/imgs/ddelete_32.png��6_   �� 5J      $��5,5,10,0q�6    �� 63   $ es-do�67   $�Borrar��6H   6Y   5K      5L      5M      � 5N   
   $��31��6   $��0,0,10,7q�6   $��Bottom=�6-   ���	#FFC3C3C3$��Right=�6_   $	��186��6{   .+�5O      �� $
��Left=�6   $��5,6,0,0q�63   $
��Wrap=�6D   $	��Top=�6X   $��14(�6p   $
��Bold"�6~   �� 6�   $ es-do�6�   $�Total Docentes:��6�   6�   �� 5P      $
��Left=�6   $��	111,6,0,0q�63   $
��Wrap=�6F   $	��Top=�6Z   $��14(�6�   $
��Bold"�6�   ��6r   �� *Items.Count+ �� ElementName$ 	datagrid1���� 6�   $ es-do�6�   6�   5Q      5S      5T      