   M S B A M L   `   `   `  ����A  =Prison, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PrisonPrison  5          Prison.ShopPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:Prison     5        N� Title$  ShopPage��5      $	��450��6   $	��800��6%   .��5	      �  � RowDefinitions 5
   
   �� 5      $��0.12* �6   6-   �� 5      $��* �6   6)   �� 5      $
��0.5* �6   6,    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ GoodsDataGrid��5   !   $��1��6   $��3��68   6N   �� 5   
   $��3��6   $��5��6%   
�������.+�5      �� -   5         ��Name$ ToBill��5      $��>��6%   $��	0 150 0 0q�61   6]   �� 5      -   5        $ FromBill��5      $��<��6'   $��0 30 0 0q�66   6c   5        5   
   -   5        $ BillDataGrid��5       $��1��6   $��4��66   $��3��6F   6\   �� 5   
   $��Внесено:��6   6%   �� 5   
   -   5         ��Name$ MoneyTextBox��5      $��1��6(   $��0��68   6C   �� 5    
   -   5         ��Name$ PrisonerSelect��5    #   $��2��6   6=   �� 5!   
   $��4��6   $��
Сумма��6    $��20(�60   6@   �� 5"   
   -   5         ��Name$ TotalSum��5"      $��5��6&   $��0��66   $��20(�6?    �� TextAlignment$
 Left=�6M   6d   �� 5#   
   -   5        $ SaveBill��5#      $��2��6#   $��5��60   $
��Save��6@   6j   5$      5%      