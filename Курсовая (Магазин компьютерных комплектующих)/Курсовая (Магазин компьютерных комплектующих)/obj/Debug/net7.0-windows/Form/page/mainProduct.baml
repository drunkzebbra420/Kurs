   M S B A M L   `   `   `  �����  �Курсовая (Магазин компьютерных комплектующих), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�mclr-namespace:Курсовая__Магазин_компьютерных_комплектующих_.Form.page_Курсовая__Магазин_компьютерных_комплектующих_.Form.page  5      q    kКурсовая__Магазин_компьютерных_комплектующих_.Form.page.mainProduct   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      ylocalmclr-namespace:Курсовая__Магазин_компьютерных_комплектующих_.Form.page  5      -   5          N� Title$  mainProduct��5
      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $��40 �6   .+�5   
   �� $��\image\Logo\logo.jpg��6   $	��Top=�6.   $��2��6F   �� 5   
   $��0��6   $��1��6%   $��3��62   $��Center=�6C   $��0 0 0 0q�6^   .+�5      (  "Xceed.Wpf.Toolkit.WatermarkTextBox  -   5          Name$ 	SearchBox��5   C      	Watermark$' !Поиск по названию ��6$   $��30��6V   $	��200��6b   
���   �$��1q�6�   6�   )  #Xceed.Wpf.Toolkit.WatermarkComboBox  5       -   5          Name$ 	Sortcombo��5    %      	Watermark$( "Сортировка по цене��68   $	��200��6W   $��30��6c   $��0 10 0 0q�6o   6�     5!      -   5        $ 
Filtrcombo��5!   %   $? 9Фильтрация по категории товара��69   $	��200��6d   $��30��6p   $��0 10 0 0q�6|   6�   5$      �� 5&   
   $��5��6   $��6��6"   .+�5'      �� -   5         ��Name$ 
addProduct��5'      $�� ��6)   $��60��64   $��60��6?   $y�	Collapsed=�6K   
�������$��24 0 0 0q�6�   $
��Left=�6�    � Cursor$
 Hand��6�   	 � ToolTip$%	 Добавить продукт��6�      cdButton#��[  6�   ��5(      �� 5)      
 �� ImageSource$"
 /Form/page/addProductIMG.png��6!   5+      �� 5,       �� Orientation$ 
Horizontal=�6   $��0 15 0 0q�62   .+�5-      �� -   5        $ ExitBtn��5-      $��60��6*   $��60��65   $&	  Выйти из аккаунта��6A   
�������$��24 0 0 0q�6q   #��[  6�   $
 Hand��6�   ��5.      �� 5/      $
 /Form/page/exitAcc.png��6%   51      �� 52      -   5        $ 	seeBasket��52      $��60��6,   $��60��67   $>	 8Посмотреть содержимое корзины��6C   
�������$��80 0 0 0q�6   #��[  6�   $
 Hand��6�   ��53      �� 54      $
 /Form/page/Bascet.png��6%   57      58      �� 59      -   5         ��Name$ RoleUser��59      $��Менеджер��6.   $��Center=�6>   $��Center=�6Y   $y�	Collapsed=�6v   $	��20 (�6�   5:      �� 5<   
   -	   5        $ 	ListEmpty��5<      $)��#Записей не найдено ��6'   $��1��6B   $��0��6R   $��6��6_   $y�	Collapsed=�6p   $��50(�6�   $��Center=�6�   $��Center=�6�   �� 5>   
   -
   5         ��Name$
 List��5>      $��1��6!   $��0��61   $��6��6>   $��Disabled=�6O   $��Center=�6�    � ContextMenu 5?      �� 5@      -   5         ��Name$ ComtextMenu��5@      $y�	Collapsed=�63   .@�5A      m� -   5        $��Удалить��5A       m� Icon 5B      �� 5C      $��\image\Logo\krestik.png��6$   5E      5G      ��5R      �� 5S      .R�5T      �  � Orientation$ 
Horizontal=�6    $
��Left=�69   5U      ��5W      �� 5X      .R�5Y      �� 
���   �$��2q�61   ._�5Z      � $	��300��6   $	��345��6+   {�68   �� *BtnOff+ 5\      �� 5]   "   $	��170 �60   �� 5^   "   �� 5_   "   .+�5c      �� $��0��6$   $��10q�61   ��6=   �� *Image+  Plug �� TargetNullValue# [ �� 5d      $��1��6(   $��Center=�6R   $��14(�6o   $
��Bold"�6}   ��65   �� *NameProduct+6}   �� 5e      $��1��6)   $��	10 20 0 0q�66   .+�5f   "   �� �� 5g   &   $�Категория  : ��6*   $
��Bold"�6?    �� 5h   &   �6*   �� * TypeProductNavigation.NameType+5i   #   �� 5k   "   �� 5l   &   $#�Производитель : ��6*   $
��Bold"�6B    �� 5m   &   �6*   �� *.,ManufactureProductNavigation.NameManufacture+5n   #   �� 5o   "   $��15(�6,   �� 5p   &   $�Цена : ��6*   $
��Bold"�69    �� 5q   &   �6*   �� *CostProduct+ �� 5r   &   $	�₽��6*   5s   #   �� 5t   "   �� 5u   &   $/�)Количество на складе : ��6*   $
��Bold"�6I    �� 5v   &   �6*   �� *CountInStockProduct+5w   #   5x      �� 5z      $ trashBTN��6%   -   5        $��2��5z   7   $��0 0 20 0q�6D   $��60��6V   $��60��6a   $��Right=�6m   
�������$3	 -Добавить товар в корзину��6�   #��[  6�   $
 Hand��6�   ��5{   "   �� 5|   &   $
 /Form/Trash.png��61   5~      �� 5�      $ infoBTN��6%   -   5        $��2��5�   6   $��10 0 0 0q�6C   $��60��6U   $��60��6`   $
��Left=�6l   
�������$=	 7Подробная информация о товаре��6�   #��[  6�   $
 Hand��6�   ��5�   "   �� 5�   &   $
 /Form/info.png��61   5�      5�      5�      5�      5�      5�      5�      