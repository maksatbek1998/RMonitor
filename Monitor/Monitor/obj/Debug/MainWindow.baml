   M S B A M L   `   `   `  ����B  >Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MonitorMonitor  5   	   5clr-namespace:Monitor.ViewModelMonitor.ViewModel  5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466J6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPFFontAwesome.WPF 5   	       Monitor.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Monitor     5   	   .vmclr-namespace:Monitor.ViewModel     5   	   EFA6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPF     5   	   U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5	   	   -   5          � Title$  
MainWindow��5   	   $	��700��63   $
��1200��6@    � WindowStyle$
 None=�5   
    � AllowsTransparency .  � DataContext 5      %  Monitor.ViewModel.MainViewModel  5   
    � 	Resources 5         Storyboard1 g� AutoReverse g� RepeatBehavior g� FillBehavior �� TargetProperty	 �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame
 �� KeyTime �� Value  Animation_For_Video��%5  &	        &	     �� 5   
    . $ 0:0:4��6<   $
 Stop=�6S   .��5      �� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $	 
NumberText��6x   .g�5        $
 0��6&   $ #01B3A4��62     5      $
 0:0:0.7��6&   $ White��68   5      5      �� 5   
   6   5       � Triggers 5      :� 5   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5      �� #��[ 6   5      .��5      � .+�5   
   �  � RowDefinitions 5       �� 5!      $
��Auto �6    �� 5"      $��* �6    �� 5#      $��60 �6    .+�5%      � $��0��6    5&      �� 5'      $
��Auto �6$   �� 5(      $��10 �6$   .+�5+      � -   5         �Name$ Title��5+      $��0��6&   ���#0A6E9E$	��162��6H    � ColumnDefinitions 5,      �� 5-      $	��55* �6+   �� 5.      $	��45* �6+   .+�51      ��  �� Orientation$ 
Horizontal=�6!   $��
25,25,0,10q�6:   $��0��6N   .+�52      �� -   5         ��Name$ buttonClickMain��52   !   $y�Hidden=�6:   6N   �� 53      $��Image/Icon/RSK icon.png��6    $��0��6A   $
��Left=�6Q   $��Center=�6l   �� 54      .+�55      �� -   5         ��Name$ MainText��55   (   
�������$��40(�6M   $
��Bold"�6[   $	��550��6m   $	��120��6y   $
��Wrap=�6�   $	��5,0q�6�   �� 56      -   5         ��Name$ IDText��56   :   $y�Hidden=�6&   6J   57      58      � 5:      $��1��6   .+�5;      �  5<      �� 5=   "   $��* �63   �� 5>   "   $	��110 �63   �� 5?   "   $��* �63   .+�5A      �� -   5        $ 	NumberTxt��5A   8   {�.  $��65(�6K   
�������$��Center=�6l   $��0q�6�   $��Center=�6�   $
��Bold"�6�   $��20,0,0,0q�6�   ��6�   Z�  �� SelectionBrush 6�   Z� �� 5B      -   5         ��Name$ imageAwesome��5B   $   $��1��6:   $��Stretch=�6J   $��Stretch=�6f   $	��153��6�   5C      �� 5D      -   5        $	 Lan��5D   <   $y�Hidden=�6(   6<   �� 5E      -	   5        $ OperTxt��5E   8   {�.  $��65(�6J   
�������$��Center=�6k   $��Center=�6�   $
��Bold"�6�   $��2��6�   $��0q�6�   $��10,0,0,0q�6	  ��6�   Z�  6�   Z� 6	  5F      5G      5H      � 5I      ���	#FF005F8D$��1��6.   $��7��6;   $	��Top=�6F    J� Effect 5J      3  -System.Windows.Media.Effects.DropShadowEffect  5K         
BlurRadius$ 6Q�6+      	Direction$	 250Q�6:      Color$ 	#FF009AE4��6J      ShadowDepth$ 2Q�6\   5M      5N      � 5O      -
   5        $
 grid��5O      $��1��6!    5P      �� 5Q      $	��55* �6'   �� 5R      $
��Auto �6'   .+�5U      � $��0��6   
���   �.+�5V      r� -   5         r�Name$ mediaReclam��5V   �    r� Volume$ 0Q�6#    r� LoadedBehavior$ Manual=�6R    r� UnloadedBehavior$ Manual=�6j   $��Stretch=�6�   $��Stretch=�6�     r� Stretch$
  Fill=�6�   5W      � 5Y      -   5        $ 	GridWidth��5Y      $��1��6*   $	��600��6:    5Z      �� 5[      $��65 �6(   �� 5\      $��* �6(   .+�5^      �  5_      �� 5`      $��* �6/   �� 5a      $��* �6/   .+�5c      �� $��55(�6$   ���	#FF0A6E9E$��0,0,0,0q�6I   $��Center=�6Z   $��Center=�6u   $
��Bold"�6�   $��КЛИЕНТ��6�   �� 5d      $��55(�6$   ���	#FF0A6E9E$��0,0,0,0q�6I   $��Center=�6Z   $��Center=�6u   $
��Bold"�6�   $��ОКНО��6�   $��1��6�   5e      �� 5f      -   5        ! ��Name$
! List��5f   �   " �� SelectedIndex$" 0��6   $��Stretch=�6�   $��Stretch=�6�   $��1��6	    styleListBox#���  6  # �� SelectedItem# 60   �� *SelectedNum+$ �� UpdateSourceTrigger$$ PropertyChanged=���6z   �� *
ListColl+$$ PropertyChanged=���5g      �� 5h      .R�5i   "   �  5j   &   �� 5k   *   $��2* �6;   �� 5l   *   $��* �6;   �� 5m   *   $��2* �6;   .+�5o   &   �� $��55(�60   ���	#FF646464$��Center=�6U   $��Center=�6p   $
��Bold"�6�   $��20,0,0,0q�6�   ��6�   �� *number+$$ PropertyChanged=�6�   "  FontAwesome.WPF.ImageAwesome  5p   &   $��1��66   %   Icon$% LongArrowRight=�6F   $��90��6\   &   
Foreground& �	#FF0A6E9E6g   �� 5q   &   $��55(�60   ���	#FF646464$��Center=�6U   $��Center=�6p   $
��Bold"�6�   $��2��6�   ��6�   �� *oper+$$ PropertyChanged=�6�   5r   #   5s      5u      5v      5w      � 5x      $��2��6   ���#0A6E9E$��60��65   $��Bottom=�6A   .+�5�      �� -   5        $��canMain��5�   -   }�. .+�5�      �� -   5        $ marquee��5�       $��45(�61   
�������CAHello This is a Sample Marquee in Wpf. Please check the animation5�      5�      5�      5�      5�      5�      