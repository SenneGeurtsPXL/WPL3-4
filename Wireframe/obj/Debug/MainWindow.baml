   M S B A M L   `   `   `  ����D  @Wireframe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Wireframe	Wireframe  5   	       Wireframe.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Wireframe     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��10q�6"   .+�5      �� $��Select Application:��6   $
��Bold"�63   �� 5      -   5         ��Name$ txtApplications��5      $	��200��6/   $	��0,5q�6;   5      �� 5   
   $��1��6   $��10q�6"   .+�5      �� $��Select Page:��6   $
��Bold"�6,   �� 5      -   5         ��Name$ cmbPages��5      $	��200��6)   $	��0,5q�65   5       �� 5#   
   $��2��6   $��10q�6"   .+�5$      �� $��Select Element:��6   $
��Bold"�6/   �� 5&      -   5        $ cmbElements��5&      $	��200��6,   $	��0,5q�68   5'      �� 5*   
   $��3��6   $��10q�6"   .+�5+      �� $��Select Action:��6   $
��Bold"�6.   �� 5,      -   5        $ 
cmbActions��5,      $	��200��6+   $	��0,5q�67   5-      �� 50   
   $��4��6   $��10q�6"   .+�51      �� $��Add Parameters:��6   $
��Bold"�6/   �� 53      -   5        $ txtParameters��53      $	��200��6-   $	��0,5q�69   54      �� 57   
   $��6��6   $��10q�6"    �� Orientation$ 
Horizontal=�6.   .+�58      �� $��Generate C# Code��6   $	��150��60   $��0,0,10,0q�6<   �� 59      $��Generate TypeScript Code��6   $	��150��68   5:      �� 5=   
   $��7��6   $��10q�6"   .+�5>      �� $��Copy to Clipboard��6   $	��150��61   5?      �� 5B   
   $��8��6   $��10q�6"   $ 
Horizontal=�6.   .+�5C      �� $��Reset��6   $	��100��6%   $��0,0,10,0q�61   �� 5D      $��Close��6   $	��100��6%   5E      5F      5G      