   M S B A M L   `   `   `  ����K  GWpf-Task-Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:TeamNorthStar_TaskTrackerApp.Models#TeamNorthStar_TaskTrackerApp.Models  5   	   -    'TeamNorthStar_TaskTrackerApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Clocal1clr-namespace:TeamNorthStar_TaskTrackerApp.Models     5   	     � Title$  Task Tracker��5   	   $	��700��6   $	��500��6+   
�������.��5      �� $��10q�6   .+�5	   
   �� $��Task Tracker��6   $��28(�6(   $
��Bold"�66   
����  �$��Center=�6^   $��10q�6{   �� 5   
   
����  �$��2q�6(    �� CornerRadius$ 5��6<   
������� �� Padding$ 10q�6`   $��10q�6m   ._�5      �� .+�5      �� $��Add New Task��6   $��20(�60   $
��Bold"�6>   
����  �$��0,0,0,10q�6f   �� 5      -   5        $��
TitleInput��5      $	��400��6,   $��5q�68   $��Center=�5      
�������$��Enter task title...��5      �� 5      -   5        $��DescriptionInput��5      $	��400��62   $��5q�6>   $��Center=�5      
�������$��Enter task description...��5      (  "System.Windows.Controls.DatePicker  5      -   5        $��DueDatePicker��5      $	��400��62   $��5q�6>   �� 5      -   5        $��StatusDropdown��5      $	��400��61   $��5q�6=   .@�5      �� $��
NotStarted��6#    �� 
IsSelected . 68   �� 5      $��
InProgress��6#   �� 5      $��	Completed��6#   5      �� 5      -   5        $��Add Task��5      $	��150��6,   $��5,10,5,5q�68   
����  �
�������$��Center=�6s   6�   5      5      �� 5"   
   
����  �$��2q�6(   $ 5��6<   
�������$ 10q�6`   $��10q�6m   ._�5#      �� .+�5$      �� $��	Task List��6   $��20(�6-   $
��Bold"�6;   
����  �$��0,0,0,10q�6c   �� 5%      $��0q�69   ��6   �� *Tasks+ �� View 5&      �� 5'      .P�5(      �� $��Title��6-    �� Width$	 150��6c    �� DisplayMemberBinding 6<   �� *Title+6c   �� 5)      $��Description��6-   $	 150��6o    6B   �� *Description+6o   �� 5*      $��Due Date��6-   $	 150��6h    6?   �� *	DueDate+6h   �� 5+      $��Status��6-   $	 100��6=    �� CellTemplate 5,   "   �� 5-   &   .R�5.   *   �� :   4TeamNorthStar_TaskTrackerApp.Models.TaskStatusHelper   Values#��Z 5/   3   $	��100��6j   $��5q�6v   	 �� SelectedItem	 5.   3   �� *Status+
 �� Mode$
 TwoWay=�5/   v   50   '   52      53      55      56      57      �� 5:   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��10q�6K   .+�5;      �� -   5        $��Export Tasks��5;      $	��150��6,   $��5q�68   
����  �
�������6l   �� 5<      -   5        $��Import Tasks��5<      $	��150��6,   $��5q�68   
����  �
�������6l   5=      5?      5@      