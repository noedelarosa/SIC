   M S B A M L   `   `   `  ����>  :SIC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Empresa.ComunEmpresa.Comun  5      '    !SIC.Objs.Controles.us_direcciones   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -Comunclr-namespace:Empresa.Comun     5      -   5          >�Name$  us_direccion_control��5       � 	Resources 5	      *   $Empresa.Comun.ConvertFiltroMunicipio   ConvertFiltroMunicipio��%   &	          5
   
   6'   5      .��5      � -   5         �Name$ 
LayoutRoot��5      .+�5   
   � $��10,10,10,10q�6   .+�5      �� -   5         ��Name$ label1��5   O   $��	Provincia��6   $��26��6(   $
��Left=�64   $	��Top=�6_   �� 5      -   5         ��Name$ Com_Provincia��5       �� DisplayMemberPath$ Nombre��5       �� SelectedValuePath$ Id��5      $��23��5      $
��Left=�6   $��78,0,0,0q�6,   $	��Top=�5      $	��271��5       ��5      ��  �� ElementName$ us_direccion_control�� �� Path$ 
Provincias�	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� SelectedItem
 5      �� *&$Direccion.Sector.Municipio.Provincia+$ us_direccion_control��$	 PropertyChanged=� �� SelectedValue 5      �� *)'Direccion.Sector.Municipio.Provincia.Id+$ us_direccion_control��$	 PropertyChanged=�5       �� 5"      -   5        $ Com_Municipio��5-      $ Nombre��5%      $ Id��5&      $ �� IsSynchronizedWithCurrentItem$
 TrueY�5)      $��23��5+      $
��Left=�6   $��	78,31,0,0q�5,      $	��Top=�5.      $	��271��6   
 5'      �� *Direccion.Sector.Municipio+$ us_direccion_control��$	 PropertyChanged=� 5(      �� *Direccion.Sector.Municipio.Id+$ us_direccion_control��$	 PropertyChanged=�5.      �� 53      -   5        $ label2��53   a   $��	Municipio��6   $��28��6(   $
��Left=�64   $��0,31,0,0q�6O   $	��Top=�6q   �� 54      -   5        $ label3��54   ^   $��Sector��6   $��29��6%   $
��Left=�61   $��0,59,0,0q�6L   $	��Top=�6n   �� 55      -   5        $ label4��55   a   $��
Dirección��6   $��30��6(   $
��Left=�64   $��0,88,0,0q�6O   $	��Top=�6q   �� 56      -	   5         ��Name$ Txt_Direccion��56   �   $��97��6   $
��Left=�6�   $��	78,93,0,0q�6�   $	��Top=�6�   $	��281��6�   ��6"   �� *Direccion.Referencia+$	 PropertyChanged=�$ us_direccion_control��6�   �� 57      -
   5        $ 
Com_Sector��57   Q   $��23��6   $ Nombre��6#   $��	78,59,0,0q�6>   $	��Top=�6e    �� 
IsEditable . $
��Left=�6�   $	��271��6�   58      59      5;      