   M S B A M L   `   `   `  ����M  IwpfhwWorkerListBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:wpfhwWorkerListBoxwpfhwWorkerListBox  5   	   #    wpfhwWorkerListBox.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:wpfhwWorkerListBox     5   	     � Title$  ListBox��5   	   $	��500��6   $	��800��6&   .��5	      �  � RowDefinitions 5
      �� 5      $��* �6   �� 5      $��50 �6   .+�5      �� -   5        $��listBox1��5      $��0��6   ��5      �� 5      .R�5      � $��mainGrid��6    � ColumnDefinitions 5      �� 5   	   $	��125 �6   �� 5   	    5      �� 5   	   $	��100 �6   .+�5       �� $��0��6   $��0��6   $��75��6H   ��6+   ��  �� Path$
 Icon�6H   � 5!      $��0��6   $��1��6    5"   	   �� 5#   
   �� 5$   
    5&   	   �� 5'   
   �� 5(   
   .+�5*   	   �� 
����  �$	��200��6%   $��0��6R   $��0��6_   $��Right=�6o   $��Center=�6�   ��61   �� $ Surname�6�   �� 5+   	   
����  �$	��100��6%   $��0��6O   $��1��6\   $
��Left=�6l   $��Center=�6�   ��61   �� $
 Name�6�   �� 5,   	   
���   �$	��200��6"   $��Age : ��6.   $��1��6?   $��0��6L   �� 5-   	   
���  ��$	��200��6    $��1��6I   $��1��6V   ��6,   �� $	 Age�6V   5.   	   5/      50      52      � 53       � Orientation$ 
Horizontal=�6   $��Center=�6'   $��Center=�6D   $��1��6_   .+�54      �� -   5        $��btnDel��54      $��75��6   $��Delete��6%   66   �� 55      -   5        $��btnAdd��55      $��75��6   $	��Add��6%   63   �� 56      -   5        $��btnEdt��56      $��75��6   $
��Edit��6%   64   57      58      59      