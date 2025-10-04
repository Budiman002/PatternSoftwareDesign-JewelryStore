# JAwels & Diamonds

**Proyek:** Toko Perhiasan Online — ASP.NET Web Forms (.NET Framework)

**Deskripsi singkat**
Aplikasi e‑commerce sederhana untuk penjualan perhiasan (JAwels & Diamonds). Dibangun menggunakan ASP.NET Web Forms (.NET Framework) dan SQL Server. Proyek ini dibuat sebagai portofolio untuk menunjukkan kemampuan pengembangan web full‑stack berbasis .NET termasuk arsitektur berbasis repository, refactor code‑behind, pengelolaan transaksi, dan fitur dasar toko online.

---

## 🚀 Fitur Utama

* 🔐 Autentikasi: Login & Register pengguna.
* 👥 Role dasar: User & Admin.
* 💍 Halaman produk: List, detail, filter kategori.
* 🛒 Cart & Checkout: Tambah ke keranjang, proses transaksi.
* 📦 Manajemen Pesanan: Pengguna dapat melihat pesanan; Admin dapat mengelola pesanan.
* 💳 Transaksi & Riwayat: Simulasi pembayaran dan riwayat transaksi.
* 🏗️ Refactor: Penerapan pattern Repository untuk memisahkan akses data dari presentation layer.

---

## 🛠️ Teknologi

* **Backend:** ASP.NET Web Forms (.NET Framework)
* **Bahasa:** C#
* **Database:** SQL Server (LocalDB / SQL Server Express)
* **Frontend:** HTML, CSS, (Bootstrap optional)
* **Tools:** Visual Studio 2022

---

## 📂 Struktur Repository (ringkasan)

```
/ (root)
│  README.md
│  /JAwelsAndDiamonds.sln
│  /JAwelsAndDiamonds.Web (WebForms project)
│     /Pages (aspx + aspx.cs)
│     /Repositories
│     /Models
│     /DataAccess
│     /Assets (css, js, images)
│  /Database (scripts)
```

---

## ⚡ Persiapan & Prasyarat

1. Visual Studio 2022 (ASP.NET dan web development workload).
2. .NET Framework (target: 4.7.2 atau 4.8).
3. SQL Server / LocalDB.
4. Git.

---

## ▶️ Cara Jalankan Secara Lokal

1. Clone repository:

```bash
git clone https://github.com/<username>/<repo>.git
cd <repo>
```

2. Buka solusi di Visual Studio: `JAwelsAndDiamonds.sln`.
3. Sesuaikan connection string di `Web.config`.
4. Jalankan script SQL di folder `Database`.
5. Run project (F5).

---

## 🏗️ Arsitektur & Catatan Teknis

* **Repository Pattern:** Akses data dipisah agar lebih clean dan maintainable.
* **Refactor code‑behind:** Logic bisnis dipindahkan dari code‑behind ke repository/service.
* **Unit utama:** `JewelRepository`, `OrderRepository`.

---

## 📌 Highlight Portofolio

* Refactor penuh untuk seluruh code‑behind halaman utama.
* Implementasi Repository pattern.
* Penyusunan dataset dummy untuk demo transaksi.
* Clean architecture dan maintainable structure.

---

## 🔮 Roadmap

* Migrasi ke **ASP.NET Core**.
* Penambahan **unit & integration tests**.
* Integrasi dengan **real payment gateway** (Midtrans/Stripe).
* CI/CD pipeline untuk otomatisasi build & deployment.

---

## 👤 Kontak

BudiMan — Budiman002
