#include "thuvien.h"

Book dsSach[MAX];
int slSach = 0;

void nhapSach(Book& sach) {
    cout << "\n==================================" << endl;
    cout << "\nNhap ma sach: ";
    cin >> sach.masach;

    cout << "Nhap ten sach: ";
    cin.ignore();
    cin.getline(sach.tensach, 50);

    cout << "Nhap the loai: ";
    cin.getline(sach.theloai, 50);

    cout << "Nhap don gia: ";
    cin >> sach.dongia;

    dsSach[slSach] = sach;
    slSach++;

    cout << "\nThem sach thanh cong!" << endl;
    cout << "\n==================================" << endl;
}

void themSachVaoViTri(Book& sach, int viTri) {
    if (viTri < 0 || viTri > slSach || slSach >= MAX) {
        cout << "Vi tri them sach khong hop le hoac danh sach da day!" << endl;
        return;
    }

    for (int i = slSach; i > viTri; i--) {
        dsSach[i] = dsSach[i - 1];
    }
    cout << "\n==================================" << endl;
    cout << "Nhap ma sach: ";
    cin >> sach.masach;

    cout << "Nhap ten sach: ";
    cin.ignore();
    cin.getline(sach.tensach, 50);

    cout << "Nhap the loai: ";
    cin.getline(sach.theloai, 50);

    cout << "Nhap don gia: ";
    cin >> sach.dongia;

    dsSach[viTri] = sach;
    slSach++;

    cout << "\nThem sach thanh cong!" << endl;
    cout << "\n==================================" << endl;
}

void timKiemSach(int tieuChi, string giaTri) {
    bool timThay = false;

    for (int i = 0; i < slSach; i++) {
        if ((tieuChi == 1 && giaTri == dsSach[i].masach) ||
            (tieuChi == 2 && giaTri == dsSach[i].tensach) ||
            (tieuChi == 3 && giaTri == dsSach[i].theloai)) {
            cout << "Ma sach: " << dsSach[i].masach << endl;
            cout << "Ten sach: " << dsSach[i].tensach << endl;
            cout << "The loai: " << dsSach[i].theloai << endl;
            cout << "Don gia: " << dsSach[i].dongia << endl;
            timThay = true;
        }
    }

    if (!timThay) {
        if (tieuChi == 1) {
            cout << "Khong tim thay sach co ma sach la " << giaTri << endl;
        }
        else if (tieuChi == 2) {
            cout << "Khong tim thay sach co ten sach la " << giaTri << endl;
        }
        else if (tieuChi == 3) {
            cout << "Khong tim thay sach co the loai la " << giaTri << endl;
        }
    }
}

void xoaSach(int tieuChi, string giaTri) {
    bool daXoa = false;

    for (int i = 0; i < slSach; i++) {
        if ((tieuChi == 1 && giaTri == dsSach[i].masach) ||
            (tieuChi == 2 && giaTri == dsSach[i].tensach)) {
            for (int j = i; j < slSach - 1; j++) {
                dsSach[j] = dsSach[j + 1];
            }
            slSach--;
            cout << "Xoa sach thanh cong!" << endl;
            daXoa = true;
        }
    }

    if (!daXoa) {
        if (tieuChi == 1) {
            cout << "Khong tim thay sach co ma sach la " << giaTri << endl;
        }
        else if (tieuChi == 2) {
            cout << "Khong tim thay sach co ten sach la " << giaTri << endl;
        }
    }
}

void sapXepSach(int tieuChi) {
    for (int i = 0; i < slSach - 1; i++) {
        for (int j = 0; j < slSach - i - 1; j++) {
            if ((tieuChi == 1 && string(dsSach[j].masach) > string(dsSach[j + 1].masach)) ||
                (tieuChi == 2 && string(dsSach[j].tensach) > string(dsSach[j + 1].tensach)) ||
                (tieuChi == 3 && dsSach[j].dongia > dsSach[j + 1].dongia)) {
                swap(dsSach[j], dsSach[j + 1]);
            }
        }
    }
}

void hienThiDanhSach() {
    if (slSach == 0) {
        cout << "\nDanh sach sach rong!" << endl;
        return;
    }

    cout << "\nDanh sach sach: " << endl;
    for (int i = 0; i < slSach; i++) {
        cout << "Ma sach: " << dsSach[i].masach << endl;
        cout << "Ten sach: " << dsSach[i].tensach << endl;
        cout << "The loai: " << dsSach[i].theloai << endl;
        cout << "Don gia: " << dsSach[i].dongia << endl;
        cout << endl;
    }
}

