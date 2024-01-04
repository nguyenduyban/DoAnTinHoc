using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSPhan3
{
    public class Book
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string TheLoai { get; set; }
        public double DonGia { get; set; }
    }

    public class Node
    {
        public Book Data { get; set; }
        public Bookstore Data1 { get; set; }
        public Node Next { get; set; }
    }

    public class Bookstore
    {
        public string TenNhaSach { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public Node DanhSachSach { get; set; }
    }

    public class Program
    {
        static Node head;
        static int slNhaSach = 0;

        static void Main()
        {
            int luaChon;
            Bookstore nhaSach;
            int tieuChi;
            string giaTri;

            Console.WriteLine("==========QUAN LY SACH============");

            do
            {
                Console.WriteLine("\n==================================");
                Console.WriteLine("\nChon tinh nang: ");
                Console.WriteLine("1. Them nha sach");
                Console.WriteLine("2. Them mot nha sach vao vi tri bat ky");
                Console.WriteLine("3. Them sach vao nha sach");
                Console.WriteLine("4. Tim kiem nha sach");
                Console.WriteLine("5. Xoa nha sach");
                Console.WriteLine("6. Hien thi danh sach nha sach");
                Console.WriteLine("7. Hien thi danh sach sach co trong nha sach");
                Console.WriteLine("0. Thoat");
                Console.WriteLine("\n==================================");
                Console.Write("\nChon mot lua chon: ");

                if (!int.TryParse(Console.ReadLine(), out luaChon))
                {
                    Console.WriteLine("Lua chon khong hop le. Vui long chon lai!");
                    continue;
                }

                switch (luaChon)
                {
                    case 1:
                        nhaSach = NhapNhaSach();
                        ThemNhaSach(nhaSach);
                        break;
                    case 2:
                        Console.Write("Nhap vi tri muon them nha sach: ");
                        int viTriThemNhaSach = int.Parse(Console.ReadLine());
                        Bookstore nhaSachMoi = NhapNhaSach();
                        ThemNhaSachTaiViTriBatKy(nhaSachMoi, viTriThemNhaSach);
                        break;
                    case 3:
                        Console.Write("Nhap ten nha sach muon them sach: ");
                        string tenNhaSachNhap = Console.ReadLine();
                        nhaSach = TimNhaSachTheoTen(tenNhaSachNhap);
                        if (nhaSach != null)
                        {
                            Book sach = NhapSach();
                            ThemSachVaoNhaSach(nhaSach, sach);
                        }
                        else
                        {
                            Console.WriteLine($"Khong tim thay nha sach co ten {tenNhaSachNhap}");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Chon tieu chi tim kiem nha sach: ");
                        Console.WriteLine("1. Ten nha sach");
                        Console.WriteLine("2. So dien thoai");
                        if (!int.TryParse(Console.ReadLine(), out tieuChi))
                        {
                            Console.WriteLine("Lua chon khong hop le. Vui long chon lai!");
                            continue;
                        }

                        Console.Write("Nhap gia tri can tim: ");
                        giaTri = Console.ReadLine();
                        TimKiemNhaSach(tieuChi, giaTri);
                        break;
                    case 5:
                        Console.WriteLine("Chon tieu chi xoa nha sach: ");
                        Console.WriteLine("1. Ten nha sach");
                        Console.WriteLine("2. Dia chi");
                        Console.WriteLine("3. So dien thoai");
                        if (!int.TryParse(Console.ReadLine(), out tieuChi))
                        {
                            Console.WriteLine("Lua chon khong hop le. Vui long chon lai!");
                            continue;
                        }

                        Console.Write("Nhap gia tri can xoa: ");
                        giaTri = Console.ReadLine();
                        XoaNhaSach(tieuChi, giaTri);
                        break;
                    case 6:
                        HienThiDanhSachNhaSach();
                        break;
                    case 7:
                        Console.Write("Nhap ten nha sach muon hien thi danh sach sach: ");
                        string tenNhaSachHienThi = Console.ReadLine();
                        nhaSach = TimNhaSachTheoTen(tenNhaSachHienThi);
                        if (nhaSach != null)
                        {
                            HienThiDanhSachSach(nhaSach.DanhSachSach);
                        }
                        else
                        {
                            Console.WriteLine("Khong tim thay nha sach co ten {tenNhaSachHienThi}");
                        }
                        break;    
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long chon lai!");
                        break;
                }
            } while (luaChon != 0);
        }

        static Book NhapSach()
        {
            Book sach = new Book();
            Console.WriteLine("\n==================================");
            Console.Write("\nNhap ma sach: ");
            sach.MaSach = Console.ReadLine();

            Console.Write("Nhap ten sach: ");
            sach.TenSach = Console.ReadLine();

            Console.Write("Nhap the loai: ");
            sach.TheLoai = Console.ReadLine();

            Console.Write("Nhap don gia: ");
             sach.DonGia = double.Parse(Console.ReadLine());
            return sach;
        }

        static Bookstore NhapNhaSach()
        {
            Bookstore nhaSach = new Bookstore();
            Console.WriteLine("\n==================================");
            Console.Write("\nNhap ten nha sach: ");
            nhaSach.TenNhaSach = Console.ReadLine();

            Console.Write("Nhap dia chi: ");
            nhaSach.DiaChi = Console.ReadLine();

            Console.Write("Nhap so dien thoai: ");
            nhaSach.SoDienThoai = Console.ReadLine();

            return nhaSach;
        }

        static void ThemNhaSach(Bookstore nhaSach)
        {
            Node newNode = new Node
            {
                Data1 = nhaSach,
                Next = null
            };

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }

                temp.Next = newNode;
            }

            slNhaSach++;
            Console.WriteLine("\nThem nha sach thanh cong!");
            Console.WriteLine("\n==================================");
        }

        static void ThemSachVaoNhaSach(Bookstore nhaSach, Book sach)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.Data1 == nhaSach)
                {
                    Node newNode = new Node
                    {
                        Data1 = new Bookstore(),
                        Data = sach,
                        Next = null
                    };
                    newNode.Data1 = new Bookstore
                    {
                        TenNhaSach = sach.MaSach,
                        DiaChi = sach.TenSach,
                        SoDienThoai = sach.TheLoai,
                        DanhSachSach = null
                    };

                    if (temp.Data1.DanhSachSach == null)
                    {
                        temp.Data1.DanhSachSach = newNode;
                    }
                    else
                    {
                        Node tempSach = temp.Data1.DanhSachSach;
                        while (tempSach.Next != null)
                        {
                            tempSach = tempSach.Next;
                        }

                        tempSach.Next = newNode;
                    }

                    Console.WriteLine("\nThem sach vao nha sach thanh cong!");
                    Console.WriteLine("\n==================================");
                    return;
                }

                temp = temp.Next;
            }

            Console.WriteLine("Khong tim thay nha sach!");
        }

        static void TimKiemNhaSach(int tieuChi, string giaTri)
        {
            bool timThay = false;
            Node temp = head;

            while (temp != null)
            {
                bool timNode ;
                switch (tieuChi)
                {
                    case 1:
                        timNode = giaTri.Equals(temp.Data1.TenNhaSach);
                        break;
                    case 2:
                        timNode = giaTri.Equals(temp.Data1.SoDienThoai);
                        break;
                    default:
                        Console.WriteLine("Tieu chi tim kiem nha sach khong hop le.");
                        return;
                }

                if (timNode)
                {
                    Console.WriteLine("Ten nha sach: " + temp.Data1.TenNhaSach);
                    Console.WriteLine("Dia chi: " + temp.Data1.DiaChi);
                    Console.WriteLine("So dien thoai: " + temp.Data1.SoDienThoai);
                    HienThiDanhSachSach(temp.Data1.DanhSachSach);

                    timThay = true;
                }

                temp = temp.Next;
            }

            if (!timThay)
            {
                if (tieuChi == 1)
                {
                    Console.WriteLine("Khong tim thay nha sach co ten nha sach la " + giaTri);
                }
                else if (tieuChi == 2)
                {
                    Console.WriteLine("Khong tim thay nha sach co so dien thoai la " + giaTri);
                }
            }
        }

        static void XoaNhaSach(int tieuChi, string giaTri)
        {
            bool daXoa = false;
            Node temp = head;
            Node prev = null;

            while (temp != null)
            {
                bool timNode;
                switch (tieuChi)
                {
                    case 1:
                        timNode = giaTri.Equals(temp.Data1.TenNhaSach);
                        break;
                    case 2:
                        timNode = giaTri.Equals(temp.Data1.DiaChi);
                        break;
                    case 3:
                        timNode = giaTri.Equals(temp.Data1.SoDienThoai);
                        break;
                    default:
                        Console.WriteLine("Tieu chi xoa nha sach khong hop le.");
                        return;
                }

                if (timNode)
                {
                    if (prev == null)
                    {
                        head = temp.Next;
                    }
                    else
                    {
                        prev.Next = temp.Next;
                    }

                    slNhaSach--;
                    Console.WriteLine("Xoa nha sach thanh cong!");
                    daXoa = true;
                    break;
                }

                prev = temp;
                temp = temp.Next;
            }

            if (!daXoa)
            {
                if (tieuChi == 1)
                {
                    Console.WriteLine("Khong tim thay nha sach co ten nha sach la " + giaTri);
                }
                else if (tieuChi == 2)
                {
                    Console.WriteLine("Khong tim thay nha sach co dia chi la " + giaTri);
                }
                else if (tieuChi == 3)
                {
                    Console.WriteLine("Khong tim thay nha sach co so dien thoai la " + giaTri);
                }
            }
        }

        static void HienThiDanhSachNhaSach()
        {
            if (slNhaSach == 0)
            {
                Console.WriteLine("\nDanh sach nha sach rong!");
                return;
            }

            Console.WriteLine("\nDanh sach nha sach: ");
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Ten nha sach: " + temp.Data1.TenNhaSach);
                Console.WriteLine("Dia chi: " + temp.Data1.DiaChi);
                Console.WriteLine("So dien thoai: " + temp.Data1.SoDienThoai);

                //HienThiDanhSachSach(temp.Data.DanhSachSach);

                temp = temp.Next;
            }
            Console.WriteLine("\n==================================");
        }

        static void HienThiDanhSachSach(Node danhSachSach)
        {
            if (danhSachSach == null)
            {
                Console.WriteLine("Danh sach sach trong nha sach rong!");
                return;
            }
            Node temp = danhSachSach;
            Console.WriteLine("Danh sach sach trong nha sach: "+ temp.Data1.TenNhaSach);
            
            while (temp != null)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Ma sach: " + temp.Data.MaSach);
                Console.WriteLine("Ten sach: " + temp.Data.TenSach);
                Console.WriteLine("The loai: " + temp.Data.TheLoai);
                Console.WriteLine("Don gia: " + temp.Data.DonGia);

                temp = temp.Next;
            }
        }

        static void ThemNhaSachTaiViTriBatKy(Bookstore nhaSach, int viTri)
        {
            Node newNode = new Node
            {
                Data1 = nhaSach,
                Next = null
            };

            if (viTri <= 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node temp = head;
                Node prev = null;
                int count = 0;

                while (temp != null && count < viTri)
                {
                    prev = temp;
                    temp = temp.Next;
                    count++;
                }

                prev.Next = newNode;
                newNode.Next = temp;
            }

            slNhaSach++;
            Console.WriteLine("\nThem nha sach thanh cong!");
            Console.WriteLine("\n==================================");
        }
        static Bookstore TimNhaSachTheoTen(string tenNhaSach)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.Data1.TenNhaSach.Equals(tenNhaSach))
                {
                    return temp.Data1;
                }
                temp = temp.Next;
            }
            return null;
        }
    }
}