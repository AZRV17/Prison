   M S B A M L   `   `   `  ����A  =Prison, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PrisonPrison  5          Prison.Fines   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:Prison     5        N� Title$  Fines��5      $	��450��6   $	��800��6"   .��5	      �  � RowDefinitions 5
   
   �� 5      $��5* �6   6*   �� 5      $
��0.5* �6   6,   �� 5      $
��0.5* �6   6,   �� 5      $��2* �6   6*   �� 5      $
��Auto �6   6,    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid��5   4   $��0��6   $��6��6    6w   �� 5   
   $��1��6   $��0��6   $��Amount��6-   6@   �� 5   
   $��1��6   $��1��6   $
��Date��6-   6>   �� 5   
   $��1��6   $��2��6   $��Prisoner��6-   6B   �� 5   
   -   5         ��Name$ Amount��5      $��2��6"   $��0��6/   $��0 0 10 0q�6?   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
DateOfFine��5      $��2��6)   $��1��66   $��	0 20 10 0q�6F   6[   �� 5   
   -   5         ��Name$ PrisonerComboBox��5      $��2��6-   $��2��6:   $��	0 15 10 0q�6J   6_   �� 5    
   -   5         ��Name$ 
EditButton��5    .   $��0��6   $��4��6!   $
��Edit��6B   $��0 0 10 0q�6Q   6�   �� 5!   
   -   5        $ 	AddButton��5!   .   $��1��6   $��4��6!   $	��Add��6A   $��	0 0 10 0 q�6O   6~   5"      5#      