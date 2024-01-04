using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSPhan2
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
        public Node Next { get; set; }
    }

    public class Program
    {
        static Node head;
        static int slSach = 0;

        static void Main()
        {
            int luaChon;
            Book sach;
            int tieuChi;
            string giaTri;
            Console.WriteLine("==========QUAN LY SACH============");

            do
            {
                Console.WriteLine("\n==================================");
                Console.WriteLine("\nChon tinh nang: ");
                Console.WriteLine("1. Them sach");
                Console.WriteLine("2. Them sach vao vi tri bat ky");
                Console.WriteLine("3. Tim kiem sach");
                Console.WriteLine("4. Xoa sach");
                Console.WriteLine("5. Sap xep sach");
                Console.WriteLine("6. Hien thi danh sach sach");
                Console.WriteLine("0. Thoat");
                Console.WriteLine("\n==================================");
                Console.Write("\nChon mot lua chon: ");

                luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        sach = NhapSach();
                        ThemSach(sach);
                        break;
                    case 2:
                        int viTri;
                        Console.Write("Nhap vi tri muon them: ");
                        viTri = int.Parse(Console.ReadLine());
                        sach = NhapSach();
                        ThemSachVaoViTri(sach, viTri);
                        break;
                    case 3:
                        Console.WriteLine("Chon tieu chi tim kiem: ");
                        Console.WriteLine("1. Ma sach");
                        Console.WriteLine("2. Ten sach");
                        Console.WriteLine("3. The loai");
                        tieuChi = int.Parse(Console.ReadLine());

                        Console.Write("Nhap gia tri can tim: ");
                        giaTri = Console.ReadLine();
                        TimKiemSach(tieuChi, giaTri);
                        break;
                    case 4:
                        Console.WriteLine("Chon tieu chi xoa sach: ");
                        Console.WriteLine("1. Ma sach");
                        Console.WriteLine("2. Ten sach");
                        tieuChi = int.Parse(Console.ReadLine());

                        Console.Write("Nhap gia tri can xoa: ");
                        giaTri = Console.ReadLine();
                        XoaSach(tieuChi, giaTri);
                        break;
                    case 5:
                        Console.WriteLine("Chon tieu chi sap xep: ");
                        Console.WriteLine("1. Ma sach");
                        Console.WriteLine("2. Ten sach");
                        Console.WriteLine("3. Don gia");
                        tieuChi = int.Parse(Console.ReadLine());

                        SapXepSach(tieuChi);
                        Console.WriteLine("Danh sach da duoc sap xep!");
                        break;
                    case 6:
                        HienThiDanhSach();
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

        static void ThemSach(Book sach)
        {
            Node newNode = new Node
            {
                Data = sach,
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

            slSach++;
            Console.WriteLine("\nThem sach thanh cong!");
            Console.WriteLine("\n==================================");
        }

        static void ThemSachVaoViTri(Book sach, int viTri)
        {
            if (viTri < 0 || viTri > slSach)
            {
                Console.WriteLine("Vi tri them sach khong hop le!");
                return;
            }

            Node newNode = new Node
            {
                Data = sach,
                Next = null
            };

            if (viTri == 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node temp = head;
                for (int i = 0; i < viTri - 1; i++)
                {
                    temp = temp.Next;
                }

                newNode.Next = temp.Next;
                temp.Next = newNode;
            }

            slSach++;
            Console.WriteLine("\nThem sach thanh cong!");
            Console.WriteLine("\n==================================");
        }

        static void TimKiemSach(int tieuChi, string giaTri)
        {
            bool timThay = false;
            Node temp = head;

            while (temp != null)
            {
                if ((tieuChi == 1 && giaTri == temp.Data.MaSach) ||
                    (tieuChi == 2 && giaTri == temp.Data.TenSach) ||
                    (tieuChi == 3 && giaTri == temp.Data.TheLoai))
                {
                    Console.WriteLine("Ma sach: " + temp.Data.MaSach);
                    Console.WriteLine("Ten sach: " + temp.Data.TenSach);
                    Console.WriteLine("The loai: " + temp.Data.TheLoai);
                    Console.WriteLine("Don gia: " + temp.Data.DonGia);
                    timThay = true;
                }

                temp = temp.Next;
            }

            if (!timThay)
            {
                if (tieuChi == 1)
                {
                    Console.WriteLine("Khong tim thay sach co ma sach la " + giaTri);
                }
                else if (tieuChi == 2)
                {
                    Console.WriteLine("Khong tim thay sach co ten sach la " + giaTri);
                }
                else if (tieuChi == 3)
                {
                    Console.WriteLine("Khong tim thay sach co the loai la " + giaTri);
                }
            }
        }

        static void XoaSach(int tieuChi, string giaTri)
        {
            bool daXoa = false;
            Node temp = head;
            Node prev = null;

            while (temp != null)
            {
                if ((tieuChi == 1 && giaTri == temp.Data.MaSach) ||
                    (tieuChi == 2 && giaTri == temp.Data.TenSach))
                {
                    if (prev == null)
                    {
                        head = temp.Next;
                    }
                    else
                    {
                        prev.Next = temp.Next;
                    }

                    slSach--;
                    Console.WriteLine("Xoa sach thanh cong!");
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
                    Console.WriteLine("Khong tim thay sach co ma sach la " + giaTri);
                }
                else if (tieuChi == 2)
                {
                    Console.WriteLine("Khong tim thay sach co ten sach la " + giaTri);
                }
            }
        }

        static void SapXepSach(int tieuChi)
        {
            Node temp1, temp2;
            Book tempData;

            for (temp1 = head; temp1 != null; temp1 = temp1.Next)
            {
                for (temp2 = temp1.Next; temp2 != null; temp2 = temp2.Next)
                {
                    switch (tieuChi)
                    {
                        case 1:
                            if (string.Compare(temp1.Data.MaSach, temp2.Data.MaSach) > 0)
                            {
                                tempData = temp1.Data;
                                temp1.Data = temp2.Data;
                                temp2.Data = tempData;
                            }
                            break;
                        case 2:
                            if (string.Compare(temp1.Data.TenSach, temp2.Data.TenSach) > 0)
                            {
                                tempData = temp1.Data;
                                temp1.Data = temp2.Data;
                                temp2.Data = tempData;
                            }
                            break;
                        case 3:
                            if (temp1.Data.DonGia > temp2.Data.DonGia)
                            {
                                tempData = temp1.Data;
                                temp1.Data = temp2.Data;
                                temp2.Data = tempData;
                            }
                            break;
                        default:
                            Console.WriteLine("Tieu chi sap xep khong hop le.");
                            break;
                    }
                }
            }
        }

        static void HienThiDanhSach()
        {
            if (slSach == 0)
            {
                Console.WriteLine("\nDanh sach sach rong!");
                return;
            }

            Console.WriteLine("\nDanh sach sach: ");
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine("Ma sach: " + temp.Data.MaSach);
                Console.WriteLine("Ten sach: " + temp.Data.TenSach);
                Console.WriteLine("The loai: " + temp.Data.TheLoai);
                Console.WriteLine("Don gia: " + temp.Data.DonGia);
                Console.WriteLine();
                temp = temp.Next;
            }
        }
    }
}
