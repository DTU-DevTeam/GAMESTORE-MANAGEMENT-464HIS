# 🎮 GAMESTORE MANAGEMENT – HỆ THỐNG QUẢN LÝ QUÁN NET.

> Cung cấp các **lệnh SQL dành cho Admin** để quản lý tài khoản trong hệ thống GameStore, bao gồm: tạo bảng, thêm tài khoản với bảo mật SHA-256 + SALT, và kiểm tra đăng nhập.
> LƯU Ý: TẢI VÀ INSTALL CÁC FONT CHỮ CÓ TRONG THƯ MỤC /fonts TRONG DỰ ÁN.

> CÁCH THAY ĐỔI CẤU HÌNH ĐỂ CHẠY DỰ ÁN:

1. Tải font chữ đã được đính kèm trong thư mục /fonts.

2. Thay đổi chuỗi kết nối đến Database.

3. Vào dự án "GameStoreManagement_PROJECT_v1.0" -> CHUỘT PHẢI VÀO THƯ MỤC PROPERTIES -> ADD PROPERTIES -> PROJECT -> TÍCH CHỌN TẤT CẢ DỰ ÁN -> CHẠY DỰ ÁN "GameStoreManagement_PROJECT_v1.0".

---

## 📁 1. Tạo Bảng Tài Khoản `ACCOUNT_STORE`

```sql
CREATE TABLE ACCOUNT_STORE (
    MaTaiKhoan NVARCHAR(10) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau VARCHAR(256) NOT NULL, -- Mật khẩu đã mã hóa (SHA-256 + SALT)
    Salt VARCHAR(50) NOT NULL,     -- SALT ngẫu nhiên riêng cho từng tài khoản
    VaiTro NVARCHAR(20) NOT NULL,
    NgayTao DATETIME DEFAULT GETDATE()
);
```

## ➕ 2. Tạo Tài Khoản Mới (SHA-256 + SALT)

👤 Tạo tài khoản Admin:

```sql
DECLARE @Salt1 VARCHAR(50) = CONVERT(VARCHAR(50), NEWID());
DECLARE @Password1 NVARCHAR(50) = 'admin123';
DECLARE @Hashed1 VARCHAR(256) = CONVERT(VARCHAR(256), HASHBYTES('SHA2_256', @Password1 + @Salt1), 2);

INSERT INTO ACCOUNT_STORE (MaTaiKhoan, TenDangNhap, MatKhau, Salt, VaiTro)
VALUES ('AD01', 'admin', @Hashed1, @Salt1, N'Admin');
```

👨‍💼 Tạo tài khoản Nhân Viên:

```sql
DECLARE @Salt2 VARCHAR(50) = CONVERT(VARCHAR(50), NEWID());
DECLARE @Password2 NVARCHAR(50) = 'nv123';
DECLARE @Hashed2 VARCHAR(256) = CONVERT(VARCHAR(256), HASHBYTES('SHA2_256', @Password2 + @Salt2), 2);

INSERT INTO ACCOUNT_STORE (MaTaiKhoan, TenDangNhap, MatKhau, Salt, VaiTro)
VALUES ('NV01', 'nhanvien1', @Hashed2, @Salt2, N'Nhân Viên');
```

## 🔐 3. Kiểm Tra Trạng Thái Đăng Nhập:

```sql

DECLARE @TenDangNhap NVARCHAR(50) = 'admin';
DECLARE @MatKhauNhap NVARCHAR(50) = 'admin123';

DECLARE @Salt VARCHAR(50);
SELECT @Salt = Salt FROM ACCOUNT_STORE WHERE TenDangNhap = @TenDangNhap;

IF @Salt IS NOT NULL
BEGIN
    DECLARE @HashedNhap VARCHAR(256) =
        CONVERT(VARCHAR(256), HASHBYTES('SHA2_256', @MatKhauNhap + @Salt), 2);

    IF EXISTS (
        SELECT 1 FROM ACCOUNT_STORE
        WHERE TenDangNhap = @TenDangNhap AND MatKhau = @HashedNhap
    )
        PRINT N'Đăng nhập thành công';
    ELSE
        PRINT N'Sai tên đăng nhập hoặc mật khẩu';
END
ELSE
    PRINT N'Tài khoản không tồn tại';
```
