   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      D @Messenger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Messenger.ViewsMessenger.Views 5          Messenger.Views.ClientView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      /localclr-namespace:Messenger.Views     5        � Title$  ВКОНТАКТЕ��5
      $	��350��6   $	��525��6&    � DataContext 5      ��    Locator �� Source# [   �� Path$ Friends�.��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� -   5        $��btnSend��5      $��1��6    $��88,283,85,10q�60   {�. ��6F   �� *SendMessage+.��6w   Отправить6�   �� 5   
   {�. $!��Messenger/Images/VkLogo.png��6!   |�. $��
0,10,0,201q�6W   �� 5   
   -   5        $��btnSave��5      $��0��6    $��86,283,85,10q�60   ��6F   �� *Save+.��6_   Сохранить6j   �� 5   
   -   5        $��
lbxFriends��5      $��0��6%   $	��200��65   $��29,132,29,41q�6B   ��6X   �� *	friends+ �� SelectedItem 6x   �� *SelectedFriend+�� 5   
   -   5        $��lbxChat��5      $��1��6"   $	��200��62   $��32,10,27,107q�6?   ��6U   �� *CurrentChat+�� 5   
   -   5        $��
tbxMessage��5      $��1��6$   $��32,223,27,60q�64   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$' !Введите сообщение��6J      ClearTextButton . ��6�   �� *	Message+ �� ValidatesOnDataErrors . 	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�6  5      5      