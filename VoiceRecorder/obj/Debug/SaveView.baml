   M S B A M L   `   `   `  ����M  IVoiceRecorder.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:VoiceRecorder.Core;assembly=VoiceRecorder.CoreVoiceRecorder.Core  5       VoiceRecorder   VoiceRecorder.SaveView   5      R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      Imy<clr-namespace:VoiceRecorder.Core;assembly=VoiceRecorder.Core    5      $	��360��5      .��5      �� $	��540��6   ��5   
   �� 5        �� EndPoint$  0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5	      �  � Color$ White��6   � 5
      $ 	#FF8C9ACB��6    � Offset$ 1Q�61   � 5      $ White��6   $ 0.479Q�6-   5      .+�5   
   �� $
��Left=�6   $	��360��60   $��99.266��6<   ��5      �� 5       �� ImageSource$ pic/stethoscope1.jpg��6   .+�5      �� $��27,5,147.017,5q�6   $��Center=�6,   $
��Bold"�6I   $��20(�6[   $��Smart Health��6i   $��56.976��6�   $��185.983��6�   �� 5      $��231.633,5,10,5q�6   $��Center=�6,   $
��Bold"�6I   $��13(�6[   $��Heartbeats Sound ��6i   $��118.367��6�    J� RenderTransformOrigin$ 0.517,-0.181&�6�   $��25.29��6�   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��19,0,0,0q�6.   $��51��6@   .+�5      �� $��Username : ��6   $��83��6*   $��0,10,0,0q�65   �� 5      -   5         ��Name$ username��5      $��23��6(    �� TextWrapping$
 Wrap=�64   $��0,14,197,14q�6H   $	��233��6�   ���	#FFCAF4FB6�   5      �� 5   
   $��5q�6   $��Select audio to be saved:��6   /   )VoiceRecorder.Core.WaveFileTrimmerControl  5   
   $��5q�6$   	   SampleAggregator	 5      �� *SampleAggregator+
   TotalWaveFormSamples
 5      �� *TotalWaveFormSamples+   LeftSelection 5      �� *LeftPosition+ �� Mode$ TwoWay=�   RightSelection 5      �� *RightPosition+$ TwoWay=��� 5    
   $ 
Horizontal=�6   $��30,0,0,0q�6.   $��62��6@   .+�5!      �� $��5q�6   $
��10,0q�6     � ToolTip$
 Play��6O   $��45��6^   $��40��6i   ��6/   �� *PlayCommand+.��5"      �� $��pic/play1.png��6   $
��Fill=�60   $��20��6?   $��20��6K   5#      �� 5$      $��5q�6   $
��10,0q�6    $
 Stop��6P   $��45��6_   $��40��6j   ��60   �� *StopCommand+.��5%      �� $��pic/stop2.png��6   $
��Fill=�60   $��22��6?   $��22��6K   5&      �� 5'      $��5q�6   $��40��6    $	��100��6,   $��
Select All��6]   ��68   �� *SelectAllCommand+6]   �� 5(      $
��5,10q�6   $��40��6#   $��74��6/   ��6;   Z� ��6Q   �� *SaveCommand+.��5)      �� $��pic/save1.png��6   $
��Fill=�60   $��30��6?   $��50��6K    � Cursor$ No��6V   {�.  6b   5*      5+      �� 5,   
   $ 
Horizontal=�6   $��118.746,0,45.821,0q�6.   .+�5-      �� 
���   �$��2q�6)    �� CornerRadius$ 3��6=   $��2q�6N   ._�5.      �� $ Vertical=�6   $��77.814��64   $��99��6D   .+�5/      �� $��pic/hb8.jpg��6   $	��100��61   $��45��6=   $
��Fill=�6I   �� 50      -   5         ��Name$ hasilHR��50   l   $	��3,1q�6    $
��Bold"�6L   $��16(�6^   $��31.28��6}   ��6-   �� *RecordedTime3+6}   51      52      54      �� 55   
   $��21��6   $��0,0,45.821,0q�6   $ -0.544,0.141&�63   .+�56      �� $��
Heart Rate��6   $
��Bold"�6*   $��14(�6<   $��120.254��6J    �� Left$ 137.746��6[   $��21��6q   57      �� 58   
   .��59      �� $��Label21��6   5:      5<      5=      