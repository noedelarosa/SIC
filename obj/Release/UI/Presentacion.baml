   M S B A M L   `   `   `  ����   SIC    SIC.UI.Presentacion   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $��Stretch=�$��Stretch=�  � 	Resources   	  Intro �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value   EasingFunction-  'System.Windows.Media.Animation.BackEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode��%=  &	        �� .��U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$
 grid��.\�  $ 0:0:1.2��$ 71Q�   $ EaseOut=�U� $ (UIElement.Opacity)�$
 grid��.\�n� $ 0��$ 0Q�  $ 0:0:1.2��$ 1Q�   $ EaseOut=�U� $ (UIElement.Opacity)�$ 
But_Entrar��.\�  $ 0:0:0.4��$ 0Q�  $ 0:0:1.2��$ 1Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$ grid1��.\�  $ 0��$ 0Q�  $ 0:0:1.2��$ 62Q�   $ EaseOut=�����  �� ImageSource$7 1/SIC;component/Objs/Comun/imgs/bgapp_01_ext01.jpg�� � Triggers :� 	 :� RoutedEvent$	 FrameworkElement.Loaded��.[��� #��[  .��� -   
 �Name$
 
LayoutRoot��.+��� $��Center=�$��Center=�.+�� -   $

 grid��
�������$	��700��$	��300�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 0Q�   
BlurRadius$ 21Q�z�V� .~��� �� �� T� .+��� $��45��$��8,8,8,0q�$	��Top=�.+��� $��30��$1��+/SIC;component/Objs/Comun/imgs/logo_ina.png��$��30�� �� Left$ 6��
 �� Top$ 6���� $��17��$��INABIMA��$	��108��$
��Bold"����	#FF024900$ 39��$ 5��$��14.667(��� $��16��$1��+Instituto Nacional de Bienestar Magisterial��$	��257��$
��Bold"����	#FF024900$ 39��$ 20��� $��8,57,8,0q�$	��100��$	��Top=�.+��� $3��-/SIC;component/Objs/Comun/imgs/frente_ina.png��$
��Fill=�$��	8,0,576,0q��� $��	110,0,0,0q�.���� -    ��Name$ richTextBox��. �/� .T�J� .*�.*��� $
��Bold"�$�Misión��J�  �� TextAlignment$ Justify=�.*�.*��� $���Desarrollar un eficiente sistema de seguridad social en la Republica Dominicana, que norme, articule y ofrezca servicios de calidad, innovadores, rentables y sostenibles en el tiempo, orientados a satisfacer las aspiraciones del personal docente y sus familiares, en cuanto a pensiones, jubilaciones, salud, vivienda, recreación y mejoría de la calidad de vida.��� -   $
 grid1��$��0,20,0,0q� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� T� .+��� -    ��Name$ 
But_Entrar��$��_Entrar��$��Center=����	#FF64B261���	#FFF2FF04$��Center=�$��80��$��26�����	#FF818181 J� Opacity$ 0Q�