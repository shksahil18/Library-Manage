# 📚 Library Management System

A web-based Library Management System built using ASP.NET Core MVC and Entity Framework Core. This application helps manage books, authors, customers, and book borrowing/return operations efficiently.

## 🚀 Features

- User-friendly dashboard
- Manage Books (Add, Edit, Delete, View)
- Manage Authors
- Manage Customers
- Borrow and Return Books
- Membership Management
- Search and Filter Records
- Responsive User Interface
- Database Integration with Entity Framework Core

## 🛠️ Technologies Used

- ASP.NET Core MVC
- C#
- Entity Framework Core
- MySQL
- Bootstrap 5
- HTML, CSS, JavaScript
- Visual Studio Code

## 📂 Project Structure

```
Controllers/
Models/
Views/
wwwroot/
Data/
Program.cs
appsettings.json
```

## ⚙️ Installation

1. Clone the repository

```bash
git clone https://github.com/your-username/Library-Management-System.git
```

2. Open the project

```bash
cd Library-Management-System
```

3. Update the database connection string in:

```bash
appsettings.json
```

4. Apply migrations

```bash
dotnet ef database update
```

5. Run the application

```bash
dotnet run
```

## 📸 Screenshots

Add project screenshots : -----

1.Resigter :
<img width="1177" height="651" alt="Register" src="https://github.com/user-attachments/assets/b08e8b26-96fa-4e3d-93e0-48200de8f53b" />

2.Login :
<img width="1177" height="651" alt="Login" src="https://github.com/user-attachments/assets/7eb85542-8627-445b-827b-946938911c81" />

3.Welcome_Login DashBoard :
<img width="1152" height="590" alt="Welcome_Login_Dashboard" src="https://github.com/user-attachments/assets/f68091bd-dae8-4518-9ad8-b4046f2fb8d2" />

4.├── Books :
    ├──Create
    <img width="1130" height="550" alt="Create_Book" src="https://github.com/user-attachments/assets/1c8e956c-dd80-45bc-ac08-9d0ace0a8a59" />
    ├──Edit
    <img width="1126" height="501" alt="Edit_Book" src="https://github.com/user-attachments/assets/6170c166-c487-4e4a-be38-de6446dd3cea" />
    ├──Delete
    <img width="1127" height="432" alt="Delete_Book" src="https://github.com/user-attachments/assets/c9f95d98-f7bb-4ee8-b4d7-5480ddf5d6e9" />
    ├──Details 
    <img width="1142" height="521" alt="Details_Book" src="https://github.com/user-attachments/assets/b5ce1a7d-94d2-4d4d-90be-05d21e2467a9" />
    ├──Available_Books / Views
    <img width="1158" height="662" alt="View_Books" src="https://github.com/user-attachments/assets/5e1d559f-040d-4006-b050-316a9a2fcbc2" />

5.├── Authors :
    ├──Create
    <img width="1135" height="506" alt="Create_Author" src="https://github.com/user-attachments/assets/13735cc3-28a0-4547-83ba-d61fc4cf8f89" />
    ├──Edit
    <img width="1123" height="537" alt="Edit_Author" src="https://github.com/user-attachments/assets/b12250ca-1d8e-4e00-9066-9a9ee884f71f" />
    ├──Delete
    <img width="1127" height="571" alt="Delete_Author" src="https://github.com/user-attachments/assets/f79b4fbf-c54f-42f6-b7a0-6899908c9f48" />
    ├──Details 
    <img width="1132" height="632" alt="Details_Author" src="https://github.com/user-attachments/assets/29a9670a-4adc-4a0e-bed7-65a3c6091162" />
    ├──Author_List / Views 
    <img width="1127" height="712" alt="View_Author" src="https://github.com/user-attachments/assets/4e7fbd11-8202-49e7-84eb-aa26fe444915" />

6.├── Customer :
     ├──Create
     <img width="1125" height="466" alt="Create_Customer" src="https://github.com/user-attachments/assets/c8f56bcd-4f00-4118-8f59-b24d7e0afddc" />
     ├──Edit
     <img width="1126" height="562" alt="Edit_Customer" src="https://github.com/user-attachments/assets/bc974550-87ec-47c8-b597-9984b501d4a6" />
     ├──Delete
     <img width="1130" height="551" alt="Delete_Customer" src="https://github.com/user-attachments/assets/aa2669bb-f8cc-440c-9751-5a3437016679" />
     ├──Details 
     <img width="1125" height="635" alt="Details_Customer" src="https://github.com/user-attachments/assets/a44b7f3f-faf8-467f-aa63-5793dc3da0cd" />
     ├──Available_Customers / Views
     <img width="1141" height="695" alt="View_Customer" src="https://github.com/user-attachments/assets/d96eab5f-97a3-424b-bc72-03a307dc445b" />

7.├── Borrow Books / Records :
    ├──Borrow Book
    <img width="1127" height="643" alt="Borrow_Book" src="https://github.com/user-attachments/assets/ecc3abf8-801d-4291-a193-0f62290bbe77" />
    ├──View Borrow Records
    <img width="1125" height="370" alt="View_BorrowRecords" src="https://github.com/user-attachments/assets/3ab96274-5fd5-4863-97eb-7e801f1d8dac" />
    ├──Edit Borrow Record
    <img width="1127" height="617" alt="Edit_BorrowRecord" src="https://github.com/user-attachments/assets/d6915f38-5875-4a0a-b0c3-4cf2d92b2a2d" />
    ├──Delete Borrow Record
    <img width="1131" height="520" alt="Delete_BorrowRecord" src="https://github.com/user-attachments/assets/6d022703-329d-4572-96c8-06dfcd87980c" />
    ├──Return Borrow
      ├──ReturnBorrow_NotYetReturn
      <img width="1127" height="572" alt="Return_Borrow_NotYetReturn" src="https://github.com/user-attachments/assets/25a6f93a-57ed-4091-807f-2f4578d7a0ca" />
      ├──ReturnBorrow_Return
      <img width="1133" height="567" alt="Return_Borrow_Return" src="https://github.com/user-attachments/assets/afc30fbd-6beb-4641-a3e6-bdb36c3af90d" />
    ├──Detail Borrow
    <img width="1126" height="600" alt="Borrow_Detail" src="https://github.com/user-attachments/assets/97dc8ace-b739-45db-8e9b-8b50c312f03e" />
    ├──BorrowBookRecords / Views
    <img width="1127" height="663" alt="Veiw_BorrowBookRecords" src="https://github.com/user-attachments/assets/2b39c196-4a3c-4cfd-9083-5ee419c91119" />

  8.├──LibraryBranch :  
      ├──Add Library
      <img width="1127" height="487" alt="Add_Library" src="https://github.com/user-attachments/assets/01300ea3-dccf-4d60-9e9f-421e69e79064" />
      ├──Edit
      <img width="1130" height="516" alt="Edit_Library" src="https://github.com/user-attachments/assets/e4e46b0d-2d87-490d-845e-f7195c924ed3" />
      ├──Delete
      <img width="1126" height="542" alt="Delete_Library" src="https://github.com/user-attachments/assets/df2ad733-a664-4895-86d9-25c033ea6bff" />
      ├──Detail
      <img width="1127" height="615" alt="Detail_Library" src="https://github.com/user-attachments/assets/e39f113f-53d1-46a4-9d24-85ca1282ad7a" />
      ├───Available_LibraryBranches / Views
      <img width="1128" height="667" alt="Veiw_Library" src="https://github.com/user-attachments/assets/c8762b0f-4fe2-4419-82c2-6d4e4f750031" />






## 🎯 Future Improvements

- Authentication & Authorization
- Role-Based Access Control (Admin/User)
- Fine Calculation for Late Returns
- Email Notifications
- Book Reservation System

## 👨‍💻 Author :---------------------------------------------------------------------------------------------------------------

**Sahil Shaikh**

- MCA Student
- .NET Developer

## 📄 License

This project is for learning and educational purposes.
