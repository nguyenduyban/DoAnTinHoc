#include "thuvien.h"

int main() {
    int luaChon;
    Book sach;
    int tieuChi;
    string giaTri;
    cout << "==========QUAN LY SACH============";
    do {
        cout << "\n==================================" << endl;
        cout << "\nChon tinh nang: " << endl;
        cout << "1. Them sach" << endl;
        cout << "2. Them sach vao vi tri bat ky" << endl;
        cout << "3. Tim kiem sach" << endl;
        cout << "4. Xoa sach" << endl;
        cout << "5. Sap xep sach" << endl;
        cout << "6. Hien thi danh sach sach" << endl;
        cout << "0. Thoat" << endl;
        cout << "\n==================================" << endl;
        cout << "\nChon mot lua chon :";

        cin >> luaChon;
        
        switch (luaChon) {
        case 1:
            nhapSach(sach);
            break;
        case 2:
            int viTri;
            cout << "Nhap vi tri muon them: ";
            cin >> viTri;
            themSachVaoViTri(sach, viTri);
            break;
        case 3:
            cout << "Chon tieu chi tim kiem: " << endl;
            cout << "1. Ma sach" << endl;
            cout << "2. Ten sach" << endl;
            cout << "3. The loai" << endl;
            cin >> tieuChi;

            cout << "Nhap gia tri can tim: ";
            cin.ignore();
            getline(cin, giaTri);
            timKiemSach(tieuChi, giaTri);
            break;
        case 4:
            cout << "Chon tieu chi xoa sach: " << endl;
            cout << "1. Ma sach" << endl;
            cout << "2. Ten sach" << endl;
            cin >> tieuChi;

            cout << "Nhap gia tri can xoa: ";
            cin.ignore();
            getline(cin, giaTri);
            xoaSach(tieuChi, giaTri);
            break;
        case 5:
            cout << "Chon tieu chi sap xep: " << endl;
            cout << "1. Ma sach" << endl;
            cout << "2. Ten sach" << endl;
            cout << "3. Don gia" << endl;
            cin >> tieuChi;

            sapXepSach(tieuChi);
            cout << "Danh sach da duoc sap xep!" << endl;
            break;
        case 6:
            hienThiDanhSach();
            break;
        case 0:
            break;
        default:
            cout << "Lua chon khong hop le. Vui long chon lai!" << endl;
        }
    } while (luaChon != 0);
    return 0;
}
