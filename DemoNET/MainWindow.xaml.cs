using DemoNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

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
                s.MaSp,
                s.TenSp,
                s.MaLoai,
                s.SoLuong,
                s.DonGia,
                ThanhTien = s.SoLuong * s.DonGia
            });

            /*var query = from s in db.SanPhams
                    orderby s.DonGia
                    select new {
                        s.MaSp,
                        s.TenSp,
                        s.MaLoai,
                        s.SoLuong,
                        s.DonGia,
                        ThanhTien = s.SoLuong * s.DonGia
                    };*/


            dgvSanPham.ItemsSource = query.ToList();
        }

        private void HienThiCB()
        {
            /*var query = db.LoaiSanPhams.Select(s => s.TenLoai);*/
            var query = from l in db.LoaiSanPhams select l;
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

        private void dgvSanPham_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dgvSanPham.SelectedItem != null)
            {
                try
                {
                    Type t = dgvSanPham.SelectedItem.GetType();
                    PropertyInfo[] p = t.GetProperties();
                    txtMa.Text = p[0].GetValue(dgvSanPham.SelectedValue).ToString();
                    txtTen.Text = p[1].GetValue(dgvSanPham.SelectedValue).ToString();
                    cboLoai.SelectedValue = p[2].GetValue(dgvSanPham.SelectedValue).ToString();
                    txtDonGia.Text = p[3].GetValue(dgvSanPham.SelectedValue).ToString();
                    txtSL.Text = p[4].GetValue(dgvSanPham.SelectedValue).ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Co loi khi chon hang" + ex.Message, "Thong bao");
                }
            }
        }

        private void btnThem(object sender, RoutedEventArgs e)
        {
            var query = db.SanPhams.SingleOrDefault(t => t.MaSp.Equals(txtMa.Text));
            // kiem tra khong trung 
            if (query != null)
            {
                MessageBox.Show("Ma sp da ton tai", "Thong bao");
                HienThiDL();
            }
            else
            {
                SanPham sp = new();
                sp.MaSp = txtMa.Text;
                sp.TenSp = txtTen.Text;
                sp.DonGia = Convert.ToDouble(txtDonGia.Text);
                sp.SoLuong = Convert.ToInt32(txtSL.Text);
                LoaiSanPham itemSelected = (LoaiSanPham)cboLoai.SelectedItem;
                sp.MaLoai = itemSelected.MaLoai;
                db.SanPhams.Add(sp);
                db.SaveChanges();
                MessageBox.Show("Them thanh cong", "Thong bao");
                HienThiDL();
            }

        }

        private void btnSua(object sender, RoutedEventArgs e)
        {
            var sp = db.SanPhams.SingleOrDefault(t => t.MaSp.Equals(txtMa.Text));
            if (sp != null)
            {
                sp.TenSp = txtTen.Text;
                LoaiSanPham itemSelected = (LoaiSanPham)cboLoai.SelectedItem;
                sp.MaLoai = itemSelected.MaLoai;
                sp.DonGia = double.Parse(txtDonGia.Text);
                sp.SoLuong = int.Parse(txtSL.Text);
                db.SaveChanges();
                MessageBox.Show("Sua thanh cong", "Thong bao");
                HienThiDL();
            }
            else
            {
                MessageBox.Show("Khong tim thay san pham can sua", "Thong bao");
            }

        }

        private void btnXoa(object sender, RoutedEventArgs e)
        {
            var sp = db.SanPhams.SingleOrDefault(t => t.MaSp.Equals(txtMa.Text));
            if (sp != null)
            {
                MessageBoxResult rs = MessageBox.Show("Bạn có chắc muốn xoá?", "Thông báo", MessageBoxButton.YesNo);
                if (rs == MessageBoxResult.Yes)
                {
                    db.SanPhams.Remove(sp);
                    db.SaveChanges();
                    HienThiDL();
                }
            }
            else
            {
                MessageBox.Show("Khong co san pham nay de xoa", "Thong bao");
            }
        }

        private void btnThongKe(object sender, RoutedEventArgs e)
        {
            Window2 myWin = new Window2();
            myWin.Show();
        }

        private bool CheckDL()
        {
            string tb = "";
            if (txtMa.Text == "" || txtSL.Text == "" || txtDonGia.Text == "")
            {
                tb += "\nCan nhap day du du lieu";
            }
            if (!Regex.IsMatch(txtDonGia.Text, @"\d+"))
            {
                tb += "\nDon gia phai nhap vao phai la so!";
            }
            else
            {
                int dg = Convert.ToInt32(txtDonGia.Text);
                if (dg < 0)
                    tb += "\nSo luong nhap vao phai la so duong";
            }
            if (tb != "")
            {
                MessageBox.Show(tb, "Thong bao", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            var sp = db.SanPhams.SingleOrDefault(s => s.MaSp.Equals(txtMa.Text));
            if (sp != null)
            {
                dgvSanPham.ItemsSource = db.SanPhams.Where(s => s.MaSp.Equals(txtMa.Text)).ToList();


                txtMa.Text = sp.MaSp;
                txtTen.Text = sp.TenSp;
                txtDonGia.Text = sp.DonGia.ToString();
                txtSL.Text = sp.SoLuong.ToString();
                var loai = db.LoaiSanPhams.Join(db.SanPhams, l => l.MaLoai, s => s.MaLoai, (l, s) => l).Take(1);
                cboLoai.ItemsSource = loai.ToList();
                cboLoai.DisplayMemberPath = "TenLoai";
                cboLoai.SelectedValuePath = "MaLoai";
                cboLoai.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Khong tim thay san pham co ma can tim!", "Thong bao");
            }
        }
    }
}
