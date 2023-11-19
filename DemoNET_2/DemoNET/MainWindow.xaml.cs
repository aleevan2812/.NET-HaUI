using DemoNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        QLBanHangContext db = new();
        private void HienThiDL()
        {
            var query = db.SanPhams.Select(s => new
            {
                s.MaSp,s.TenSp, s.MaLoai, s.DonGia,s.SoLuong, ThanhTien = s.DonGia * s.SoLuong
            }).OrderBy(s => s.ThanhTien);

            dgvSP.ItemsSource = query.ToList();
        }

        private void HienThiCB()
        {
            var query = db.LoaiSanPhams.Select(s => s);
            cboLoai.ItemsSource = query.ToList();
            cboLoai.DisplayMemberPath = "TenLoai";
            cboLoai.SelectedValuePath = "MaLoai";
            cboLoai.SelectedIndex = 0;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDL();
            HienThiCB();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            
            var query = db.SanPhams.SingleOrDefault(s => s.MaSp.Equals(txtMaSp.Text));
            if (query != null)
            {
                MessageBox.Show("Ma SP da ton tai!", "ThongBao");
            }
            else
            {
                var list = db.SanPhams.Select(s => new
                {
                    s.MaSp,
                    s.TenSp,
                    s.MaLoai,
                    s.DonGia,
                    s.SoLuong,
                    ThanhTien = s.DonGia * s.SoLuong
                }).OrderBy(s => s.ThanhTien).ToList();
                if (checkDL() == true)
                {
                    
                    SanPham sp = new();
                    sp.MaSp = txtMaSp.Text;
                    sp.TenSp = txtTenSp.Text;
                    sp.DonGia = Convert.ToDouble(txtDonGia.Text);
                    sp.SoLuong = Convert.ToInt32(txtSL.Text);
                    LoaiSanPham selectedLoai = (LoaiSanPham)cboLoai.SelectedItem;
                    sp.MaLoai = selectedLoai.MaLoai;
                    list.Add(new {
                        sp.MaSp,
                        sp.TenSp,
                        sp.MaLoai,
                        sp.DonGia,
                        sp.SoLuong,
                        ThanhTien = sp.DonGia * sp.SoLuong
                    });
                    dgvSP.ItemsSource = list;
                    /*db.SanPhams.Add(sp);
                    db.SaveChanges();
                    HienThiDL();*/
                    
                }
                else
                {
                    MessageBox.Show("Co loi khi them.", "Thong bao");
                }
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            var sp = db.SanPhams.SingleOrDefault(s => s.MaSp.Equals(txtMaSp.Text));
            if(sp != null)
            {
                sp.TenSp = txtTenSp.Text;
                sp.DonGia = Convert.ToDouble(txtDonGia.Text);
                sp.SoLuong = Convert.ToInt32(txtSL.Text);
                LoaiSanPham selectedLoai = (LoaiSanPham)cboLoai.SelectedItem;
                sp.MaLoai = selectedLoai.MaLoai;
                db.SaveChanges() ;
                HienThiDL();
            }
            else
            {
                MessageBox.Show("Ma SP khong ton tai!", "ThongBao");
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var sp = db.SanPhams.SingleOrDefault(s => s.MaSp.Equals(txtMaSp.Text));
            if(sp != null)
            {
                db.SanPhams.Remove(sp);
                db.SaveChanges();
                MessageBox.Show("Xoa thanh cong", "Thong bao");
                HienThiDL() ;
            }
            else
            {
                MessageBox.Show("Ma SP khong ton tai!", "ThongBao");
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            var sp = db.SanPhams.Where(s => s.DonGia == Convert.ToDouble(txtDonGia.Text)).Select(s => new
            {
                s.MaSp,
                s.TenSp,
                s.MaLoai,
                s.DonGia,
                s.SoLuong,
                ThanhTien = s.DonGia * s.SoLuong
            }).OrderBy(s => s.ThanhTien); ;
            dgvSP.ItemsSource = sp.ToList();
        }

        private void dgvSP_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(dgvSP.SelectedItem != null)
            {
                var t = dgvSP.SelectedItem.GetType().GetProperties();
                txtMaSp.Text = t[0].GetValue(dgvSP.SelectedValue).ToString();
                txtTenSp.Text = t[1].GetValue(dgvSP.SelectedValue).ToString();
                txtDonGia.Text = t[3].GetValue(dgvSP.SelectedValue).ToString();
                txtSL.Text = t[4].GetValue(dgvSP.SelectedValue).ToString();
                cboLoai.SelectedValue = t[2].GetValue(dgvSP.SelectedValue).ToString();
            }
            
        }

        private bool checkDL()
        {
            string tb = "";
            if (txtMaSp.Text == "" || txtTenSp.Text == "" || txtDonGia.Text == "" || txtSL.Text == "")
            {
                tb += "Can dien day du du lieu\n"; 
            }
            if (!Regex.IsMatch(txtDonGia.Text, @"\d+"))
            {
                tb += "Don gia nhap vao phai la 1 so\n";
            }
            else
            {
                if(Convert.ToDouble(txtDonGia.Text) < 0)
                {
                    tb += "Don gia nhap vao phai la 1 so duong";
                }
            }
            if (!Regex.IsMatch(txtSL.Text, @"\d+"))
            {
                tb += "So Luong nhap vao phai la 1 so\n";
            }
            else
            {
                if (Convert.ToInt32(txtDonGia.Text) < 0)
                {
                    tb += "So luong nhap vao phai la 1 so duong";
                }
            }
            if(tb != "")
            {
                MessageBox.Show(tb, "Thong bao");
                return false;
            }
            return true;
        }

        private void txtMaSp_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void btnLuu_click(object sender, RoutedEventArgs e)
        {
            SanPham sp = new();
            sp.MaSp = txtMaSp.Text;
            sp.TenSp = txtTenSp.Text;
            sp.DonGia = Convert.ToDouble(txtDonGia.Text);
            sp.SoLuong = Convert.ToInt32(txtSL.Text);
            LoaiSanPham selectedLoai = (LoaiSanPham)cboLoai.SelectedItem;
            sp.MaLoai = selectedLoai.MaLoai;
            db.SanPhams.Add(sp);
            db.SaveChanges();
            HienThiDL();
        }
    }
}
