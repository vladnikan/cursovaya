   M S B A M L   `   `   `  ����B  >another, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AudioPlayerAudioPlayer  5   	       AudioPlayer.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:AudioPlayer     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ AudioPlayer��5	   	   $	��550��6   $	��600��6*   .��5
      � ��5   
   �� 5       �� ImageSource$6 0/5d9e62d6f20658e7baa09ddc989409e3 копия.jpg��6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5        $��
PlayButton��5      $	��▶��6#   $��284,420,273,29q�6H   ���	#FFFE7C28���	#FF4F4D4D���	#FFFE7C28$��1��6�   �� 5   
   -   5        $��
EditButton��5      $��
Edit Track��6#   $��494,420,15,29q�6Q   ���	#FFFE7C28���	#FF4F4D4D���	#FFFE7C28$��1��6�   �� 5   
   -   5        $��PauseButton��5      $��⏸️��6$   $��228,420,332,29q�6K   ���	#FFFE7C28���	#FF4F4D4D���	#FFFE7C28$��1��6�   �� 5   
   -   5        $��
StopButton��5      $
��Stop��6#   $��345,420,210,29q�6K   ���	#FFFE7C28���	#FF4F4D4D���	#FFFE7C28$��1��6�   �� 5   
   -   5        $��RemoveButton��5      $��Remove Track��6%   $��10,420,499,29q�6W   ���	#FFFE7C28���	#FF4F4D4D���	#FFFE7C28$��1��6�   �� 5   
   -   5        $��PlaylistListBox��5      $��1��6)   $��10,33,10,110q�66   ���	#FFFF7700$��Bahnschrift)�6�   
���������5      �� 5       �� Color$ 	#FFA53C41��6"    �� Opacity$	 0.7Q�64   ��5      �� 5       .R�5!      �� ��6    ��  � ToolTip 61   �� 5"      5$      �� 5%   
   -   5        $��LoadFilesButton��5%      $��
Load Files��6(   $��
89,6,393,7q�6[   ���	#FFFE7C28���	#FF4F4D4D���	#FFFE7C286�   �� 5&   
   -   5        $��SavePlaylistButton��5&      $��Save Playlist��6+   $��241,7,241,7q�6d   ���	#FFFE7C28���	#FFFE7C28���	#FF4F4D4D6�   �� 5'   
   -	   5        $��OpenPlaylistButton��5'      $��Open Playlist��6+   $��
395,6,87,7q�6d   ���	#FFFE7C28���	#FFFE7C28���	#FF4F4D4D J� RenderTransformOrigin$ 0.502,-0.122&�6�   z�5(      V� 5)      .~�5*      ��  �� ScaleY$ 1Q�6%   �� 5+      �� 5,      T� 5-      5.      50      �� 51   
   -
   5        $��TimelineSlider��51      $��1��6'   	 � Minimum$	 0Q�64   
 � Maximum$	
 100Q�6@   $��10,384,10,61q�6y   ���	#FFB700FF
��� ���52   #   �� 53   
   -   5        $��searchTextBox��53      $��Center=�6'   $	��Top=�6D   $	��200��6\   $��0,10,0,0q�6h   $��1��6�   54      55      