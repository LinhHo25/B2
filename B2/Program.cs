using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        
        public override string ToString()
        {
            return $"ID: {Id}, Ten: {Name}, Tuoi: {Age}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
            

            List<Student> studentList = new List<Student>()
            {
                new Student() { Id = 1, Name = "Nguyen Van An", Age = 16 },
                new Student() { Id = 2, Name = "Tran Thi Binh", Age = 18 },
                new Student() { Id = 3, Name = "Le Van Cuong", Age = 15 },
                new Student() { Id = 4, Name = "Pham Thi Dung", Age = 19 },
                new Student() { Id = 5, Name = "Hoang Van Anh", Age = 17 },
                new Student() { Id = 6, Name = "Vu Thi Giang", Age = 15 }
            };

            while (true)
            {
               
                Console.Clear();
                Console.WriteLine("--- QUAN LY DANH SACH SINH VIEN ---");
                Console.WriteLine("1. Hien thi toan bo danh sach sinh vien.");
                Console.WriteLine("2. Tim sinh vien co tuoi tu 15 den 18.");
                Console.WriteLine("3. Tim sinh vien co ten bat dau bang chu 'A'.");
                Console.WriteLine("4. Tinh tong so tuoi cua tat ca sinh vien.");
                Console.WriteLine("5. Tim sinh vien co tuoi lon nhat.");
                Console.WriteLine("6. Sap xep danh sach sinh vien theo tuoi tang dan.");
                Console.WriteLine("0. Thoat chuong trinh.");
                Console.Write("\nMoi ban chon chuc nang: ");

                string choice = Console.ReadLine();

                Console.WriteLine(); 

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("--- a. Danh sach sinh vien ---");
                        studentList.ForEach(Console.WriteLine);
                        break;

                    case "2":
                        Console.WriteLine("--- b. Danh sach sinh vien co tuoi tu 15 den 18 ---");
                        var studentsByAge = studentList.Where(s => s.Age >= 15 && s.Age <= 18);
                        foreach (var student in studentsByAge)
                        {
                            Console.WriteLine(student);
                        }
                        break;

                    case "3":
                        Console.WriteLine("--- c. Sinh vien co ten bat dau bang chu 'A' ---");
                        
                        var studentsByName = studentList.Where(s => s.Name.Split(' ').Last().StartsWith("A", StringComparison.OrdinalIgnoreCase));
                        if (!studentsByName.Any())
                        {
                            Console.WriteLine("Khong tim thay sinh vien nao co ten bat dau bang chu 'A'.");
                        }
                        else
                        {
                            foreach (var student in studentsByName)
                            {
                                Console.WriteLine(student);
                            }
                        }
                        break;

                    case "4":
                        Console.WriteLine("--- d. Tong so tuoi cua tat ca sinh vien ---");
                        int totalAge = studentList.Sum(s => s.Age);
                        Console.WriteLine($"Tong so tuoi la: {totalAge}");
                        break;

                    case "5":
                        Console.WriteLine("--- e. Sinh vien co tuoi lon nhat ---");
                        var oldestStudent = studentList.OrderByDescending(s => s.Age).FirstOrDefault();
                        if (oldestStudent != null)
                        {
                            Console.WriteLine(oldestStudent);
                        }
                        break;

                    case "6":
                        Console.WriteLine("--- f. Danh sach sinh vien sap xep theo tuoi tang dan ---");
                        var sortedList = studentList.OrderBy(s => s.Age);
                        foreach (var student in sortedList)
                        {
                            Console.WriteLine(student);
                        }
                        break;

                    case "0":
                        Console.WriteLine("Da thoat chuong trinh. Hen gap lai!");
                        return; 

                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                        break;
                }

                
                Console.Write("\nNhan phim bat ky de quay lai menu...");
                Console.ReadKey();
            }
        }
    }
}