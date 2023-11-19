using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DemoNET.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DemoNET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        QLBanHangContext db = new QLBanHangContext();

        private void HienThiDL()
        {
            var query = db.SanPhams.Select(s => new
            {
                s.MaSp, s.TenSp, s.MaLoai, s.DonGia, s.SoLuong, ThanhTien = s.DonGia * s.SoLuong
            });

            dgvSanPham.ItemsSource = query.ToList();
        }

        private void HienThiCB()
        {
            var query = db.LoaiSanPhams.Select(l => l);
            cboLoai.ItemsSource = query.ToList();
            cboLoai.DisplayMemberPath = "TenLoai";
            cboLoai.SelectedValuePath = "MaLoai";
            cboLoai.SelectedIndex = 0;
        }
        private void dgvSanPham_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(dgvSanPham.SelectedItem != null)
            {
                try
                {
                    txtMaSp.Text = dgvSanPham.SelectedItem.GetType().GetProperties()[0].GetValue(dgvSanPham.SelectedValue).ToString();
                    txtTenSp.Text = dgvSanPham.SelectedItem.GetType().GetProperties()[1].GetValue(dgvSanPham.SelectedValue).ToString();
                    
                    txtDonGia.Text = dgvSanPham.SelectedItem.GetType().GetProperties()[3].GetValue(dgvSanPham.SelectedValue).ToString();
                    txtSL.Text = dgvSanPham.SelectedItem.GetType().GetProperties()[4].GetValue(dgvSanPham.SelectedValue).ToString();
                    cboLoai.SelectedValue = dgvSanPham.SelectedItem.GetType().GetProperties()[2].GetValue(dgvSanPham.SelectedValue).ToString();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDL();
            HienThiCB();
        }

        private void btnMaSp(object sender, RoutedEventArgs e)
        {
            var query = db.SanPhams.SingleOrDefault(s => s.MaSp.Equals(txtMaSp.Text));
            if (query != null)
            {
                MessageBox.Show("Mã sản phẫm đã tồn tại", "Thong bao");
                HienThiDL();
            }
            else
            {

                SanPham s = new();
                s.MaSp = txtMaSp.Text;
                s.TenSp = txtTenSp.Text;
                s.DonGia = Convert.ToDouble(txtDonGia.Text);
                s.SoLuong = Convert.ToInt32(txtSL.Text);
                LoaiSanPham l = (LoaiSanPham)cboLoai.SelectedItem;
                s.MaLoai = l.MaLoai;
                db.SanPhams.Add(s);
                db.SaveChanges();
                MessageBox.Show("Them thanh cong", "Thong bao");
                HienThiDL();
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            var s = db.SanPhams.SingleOrDefault(s => s.MaSp.Equals(txtMaSp.Text));
            if(s != null)
            {
               
             
                s.TenSp= txtTenSp.Text;
                s.DonGia = Convert.ToDouble(txtDonGia.Text) ;
                s.SoLuong= Convert.ToInt32(txtSL.Text);
                LoaiSanPham itemSelected = (LoaiSanPham)cboLoai.SelectedItem;
                s.MaLoai = itemSelected.MaLoai;
                
                db.SaveChanges();
                MessageBox.Show("Sua thanh cong!", "Thong bao");
                HienThiDL() ;
            }
            else
            {
                MessageBox.Show("Khong ton tai san pham can sua", "Thong bao");
            }
        }
    }
}
