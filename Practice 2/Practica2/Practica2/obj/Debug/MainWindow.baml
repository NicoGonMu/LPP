   M S B A M L   `   `   `  ����D  @Practica2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Practica2	Practica2  5   	       Practica2.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Practica2     5   	     � Title$  
MainWindow��5   	   $	��484��6   $	��655��6)   .��5	      � $��	0,0,0,-31q�6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5
      $
��Left=�6%   $��	10,67,0,0q�6@   $	��Top=�6S   $	��252��6�   $	��627��6�   5      �� 5   
   -   5         ��Name$ 
nameFilter��5      $
��Left=�6K   $��23��6f   $��
119,38,0,0q�6r    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ surnameFilter��5      $
��Left=�6Q   $��23��6l   $��
253,38,0,0q�6x   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ idFilter��5      $
��Left=�6G   $��23��6b   $��
387,38,0,0q�6n   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ degreeFilter��5      $
��Left=�6O   $��23��6j   $��
517,38,0,0q�6v   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ label��5      $J��DFilter by:	    		 Name		         Surname		     Identifier		Degree ID��6   $
��Left=�6�   $��	10,10,0,0q�6�   $	��Top=�6�   $	��627��6�   $��28��6�   �� 5   
   -   5        $ itemName��5      $
��Left=�6$   $��23��6?   $��119,352,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5   
   -   5        $ itemSurname��5      $
��Left=�6'   $��23��6B   $��253,352,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��120��6�   �� 5   
   -	   5        $ 
itemDegree��5      $
��Left=�6&   $��23��6A   $��517,352,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��120��6�   �� 5   
   -
   5        $ itemID��5      $
��Left=�6"   $��23��6=   $��387,352,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��120��6�   �� 5   
   -   5        $ 
label_Copy��5      $M��GSelected Item:		 Name		          Surname		       Identifier		 Degree ID��6$   $
��Left=�6�   $��
10,324,0,0q�6�   $	��Top=�6�   $	��617��6�   $��28��6�   �� 5   
   -   5         ��Name$ 
editButton��5      $��Edit selected item��6%   $
��Left=�6B   $��
10,352,0,0q�6]   $	��Top=�6q   $��99��6�    J� RenderTransformOrigin$ 
0.485,-4.1&�6�   �� 5   
   -   5        $ newName��5      $
��Left=�6#   $��23��6>   $��119,412,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��120��6�   �� 5   
   -   5        $ 
newSurname��5      $
��Left=�6&   $��23��6A   $��253,412,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��120��6�   �� 5   
   -   5        $ 	newDegree��5      $
��Left=�6%   $��23��6@   $��517,412,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��120��6�   �� 5   
   -   5        $ newID��5      $
��Left=�6!   $��23��6<   $��387,412,0,0q�6H   $
 Wrap=�6]   $	��Top=�6q   $	��120��6�   �� 5   
   -   5        $ label3��5      $H��BNew Item:		 Name		          Surname		       Identifier		 Degree ID��6    $
��Left=�6�   $��
10,384,0,0q�6�   $	��Top=�6�   $	��617��6�   $��28��6�   �� 5   
   -   5        $ insertButton��5      $��Insert new item��6'   $
��Left=�6A   $��
10,412,0,0q�6\   $	��Top=�6p   $��99��6�   $ 
0.485,-4.1&�6�   5      5      