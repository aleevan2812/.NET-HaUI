   M S B A M L   `   `   `  ����B  >DemoNET, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DemoNETDemoNET  5   	       DemoNET.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:DemoNET     5   	   -   5          � Title$  
MainWindow��5   	   $	��691��6   $
��1032��6)   $��Time New Roman)�66   $��20(�6R   .��5	      � .+�5
   
   �� $��Mã sản phẩm:��6   $
��Left=�6'   $��
129,36,0,0q�6B    J� RenderTransformOrigin$ 0.438,-0.73&�6V   $��37��6z   $	��129��6�   $	��Top=�6�   �� 5   
   $��Tên sản phẩm:��6   $
��Left=�6(   $��
129,78,0,0q�6C   $	��Top=�6W   �� 5   
   $��Loại sản phẩm:��6   $
��Left=�6)   $��129,117,0,0q�6D   $	��Top=�6Y   $ 0.562,-0.681&�6q   �� 5   
   $��Đơn giá:��6   $
��Left=�6#   $��129,156,0,0q�6>   $	��Top=�6S   �� 5   
   $��Số lượng:��6   $
��Left=�6$   $��129,195,0,0q�6?   $	��Top=�6T   �� 5   
   -   5         ��Name$ txtMa��5      $
��Left=�6!   $��
322,36,0,0q�6<    �� TextWrapping$
 Wrap=�6P   $��TextBox��6d   $	��Top=�6s   $	��314��6�   �� 5   
   -   5        $ txtTen��5      $
��Left=�6"   $��
322,86,0,0q�6=   $
 Wrap=�6Q   $��TextBox��6e   $	��Top=�6t   $	��314��6�   �� 5   
   -   5        $ 	txtDonGia��5      $
��Left=�6%   $��322,156,0,0q�6@   $
 Wrap=�6U   $��TextBox��6i   $	��Top=�6x   $	��314��6�   �� 5   
   -   5        $ txtSL��5      $
��Left=�6!   $��322,195,0,0q�6<   $
 Wrap=�6Q   $��TextBox��6e   $	��Top=�6t   $	��314��6�   �� 5   
   -   5         ��Name$ cboLoai��5      $
��Left=�6$   $��322,119,0,0q�6?   $	��Top=�6T   $	��314��6l   $ 0.188,-0.532&�6x   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgvSanPham��5   J      AutoGenerateColumns$ False��6^      AlternatingRowBackground
 �����   CanUserAddRows$ False��6�   $
��Left=�6�   $	��288��6�   $��129,270,0,0q�6�   $	��Top=�6�   $	��767��6  	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Mã SP��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *MaSp+  5      $
 Tên SP��6%    65   �� *TenSp+  5      $
 Mã loại SP��6%    69   �� *MaLoai+  5      $
 Số lượng��6%    67   �� *	SoLuong+  5      $
 
Đơn giá��6%    66   �� *DonGia+  5      $
 Thành tiền��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6W    69   �� *	ThanhTien+6W   5      �� 5   
   -   5        $��Thêm��5      $
��Left=�6    $��159,588,0,0q�6;   $	��Top=�6P   $��42��6h   $��99��6t   6   �� 5    
   -	   5        $��Sửa��5       $
��Left=�6   $��306,588,0,0q�6:   $	��Top=�6O   $��42��6g   $��83��6s   6~   �� 5!   
   -
   5        $
��Xoá��5!      $
��Left=�6   $��445,588,0,0q�6:   $	��Top=�6O   $��42��6g   $��93��6s   6~   �� 5"   
   -   5        $
��Tìm��5"      $
��Left=�6   $��586,588,0,0q�6:   $	��Top=�6O   $ 0.204,-0.213&�6g   $��42��6�   $	��109��6�   6�   �� 5#   
   -   5        $��Thống kê��5#      $
��Left=�6$   $��737,588,0,0q�6?   $	��Top=�6T   $��42��6l   $	��128��6x   6�   5'      5)      