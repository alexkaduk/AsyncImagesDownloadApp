   M S B A M L   `   `   `  ����Q  MAsyncImagesDownloadApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:AsyncImagesDownloadAppAsyncImagesDownloadApp  5   	   U/clr-namespace:AsyncImagesDownloadApp.Properties!AsyncImagesDownloadApp.Properties  5   	   (    "AsyncImagesDownloadApp.PopupWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:AsyncImagesDownloadApp     5   	   =p/clr-namespace:AsyncImagesDownloadApp.Properties     5   	   -   5          � Title$  PopupWindow��5	   	   $
��Auto��6   $
��Auto��6+    � WindowStartupLocation$ Manual=�68    � AllowsTransparency . 
������  � WindowStyle$
 None=�5   	    � SizeToContent$ WidthAndHeight=�6   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   .+�5   
   �� -   5         ��Name$ bdrProgress��5      $��0��5      $
��Auto��5      $
��Auto��6   $	��100��6,   $��Right=�5      $��Stretch=�6-   ���	#FFE0C99C �� CornerRadius$ 10��5      
��� d �$��2q�5   )   ._�5      � .+�5      �� -   5         ��Name$ 
popupLabel��5      1   +AsyncImagesDownloadApp.Properties.Resources	   Popup_Title#��Z	 5      $	��Top=�5      $��Center=�60   $
��Auto��5      $��30��6%   � 5      -   5        
 �Name$
 prgProgress��5      $	��450��5      $��20��6*   $	��5 0q�5       � Minimum$ 0Q�5       � Maximum$ 1Q�6*   �� 5       -   5         ��Name$ txtProgress��5       $��Center=�5!      $��Bottom=�69   $
��Auto��5"      $��20��6)   $��
10,0,10,10q�5#      �� 5$      -   5         ��Name$ cancelButton��5$      $��X��5%      $��20��5&      $��20��6$   $	��5 5q�5'      $��Right=�5)      $	��Top=�65   5*      5,      5-      5/      