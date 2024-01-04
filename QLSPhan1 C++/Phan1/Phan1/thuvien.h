#include <iostream>
#include <string>


using namespace std;

struct Book {
    char masach[20];
    char tensach[50];
    char theloai[50];
    double dongia;
};

const int MAX = 100;
extern Book dsSach[MAX];
extern int slSach;
void nhapSach(Book& sach);
void themSachVaoViTri(Book& sach, int viTri);
void timKiemSach(int tieuChi, string giaTri);
void xoaSach(int tieuChi, string giaTri);
void sapXepSach(int tieuChi);
void hienThiDanhSach();

