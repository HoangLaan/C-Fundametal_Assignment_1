public class Member{
    public string FirstName { get; set;}
    public string LastName {get; set;}
    public string Gender {get; set;}
    public DateTime DoB {get; set;}
    public string BirthPlace {get; set;}
    public string PhoneNo {get; set;}
    public int Age{get => DateTime.Now.Year -  DoB.Year;}
    public bool IsGraduated{get;set;}

    public Member(string firstName, string lastName, string gender, DateTime dOb,string birthPlace, string phoneNo, bool isGraduated ){
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Gender = gender;
        this.BirthPlace = birthPlace;
        this.DoB = dOb ;
        this.PhoneNo = phoneNo;
        this.IsGraduated = isGraduated;
    }
    public Member(){
    }
}
class Assignment{
    static void Main(string[] args)
    {
        Member mem1 = new Member("Lan", "Hoang", "Male", new DateTime(2001, 01, 17), "Hanoi", "0398903001", true);
        Member mem2 = new Member("Truong", "Nguyen", "Male", new DateTime(1992, 03, 16), "HCMC", "0912345678", false);
        Member mem3 = new Member("Huyen", "Luu", "Female", new DateTime(2005, 02, 24), "SG", "0945394242", false);
        Member mem4 = new Member("Hang", "Minh", "Female", new DateTime(1997, 07, 05), "Hanoi", "0945394242", true);
        Member mem5 = new Member("Phuong", "Lan", "Female", new DateTime(2003, 08, 03), "Haiphong", "0945394242", true);
        Member mem6 = new Member("Son", "Cao", "Female", new DateTime(2000, 09, 02), "Hue", "0945394242", false);
        List<Member> members = new List<Member>{mem1, mem2, mem3, mem4, mem5, mem6};
        Console.WriteLine("a. Return list of members who is Male ");
        FindMemberByGender(members);
        Console.WriteLine("-----");
        Console.WriteLine("b. Return the oldest member");
        OldestMember(members);
        Console.WriteLine("-----");
        Console.WriteLine("c. Return full name of members");
        MemberFullname(members);
        Console.WriteLine("-----");
        Console.WriteLine("d. Return list of birthday year ");
        DivideBaseOnDoB(members);
        Console.WriteLine("-----");
        Console.WriteLine("e. Return the first member who was born in Hanoi ");
        BirthPlaceMember(members);
    }

    public static void FindMemberByGender(List<Member> list){
        List<Member> newMem = new List<Member>();
            foreach (var member in list){
                if (member.Gender == "Male")
                newMem.Add(member);
            }
        PrintListMember(newMem);
    }

    public static void OldestMember(List<Member> list){
        Member oldestMember = new Member
        {
            DoB = DateTime.Now
        };
        foreach (var member in list){
            if(member.DoB.Year < oldestMember.DoB.Year){
                oldestMember = member;
            }
        }
        PrintMember(oldestMember);
    }

    public static void MemberFullname(List<Member> list){
        List<string> fullNameMembers = new List<string>();
        foreach (var member in list){
            string fullName = member.LastName + " " + member.FirstName;
            fullNameMembers.Add(fullName);
        }
        int j = 1;
        foreach (string name in fullNameMembers){
            Console.WriteLine($"{j}. {name}");
            j++;
        }
    }

    public static void DivideBaseOnDoB(List<Member> list){
        List<Member> birthYear2000 = new List<Member>();
        List<Member> birthYeargreater2000 = new List<Member>();
        List<Member> birthYearless2000 = new List<Member>();

        foreach (var member in list){
            switch (member.DoB.Year) {
                case 2000:
                    birthYear2000.Add(member);
                    break;
                case >2000:
                    birthYeargreater2000.Add(member);
                    break;
                case <2000:
                    birthYearless2000.Add(member);
                    break;
            }
        }
        Console.WriteLine("List of members who has birth year is 2000");
        PrintListMember(birthYear2000);
        Console.WriteLine();
        Console.WriteLine("List of members who has birth year is greater than 2000");
        PrintListMember(birthYeargreater2000);
        Console.WriteLine();
        Console.WriteLine("List of members who has birth year is less than 2000");
        PrintListMember(birthYearless2000);
    }

    public static void BirthPlaceMember(List<Member> list){
        foreach (var mem in list){
            if (mem.BirthPlace == "Hanoi"){
                PrintMember(mem);
                break;
            }
        }
    }

    public static void PrintListMember(List<Member> list){
        int i = 1;
        foreach (var mem in list){
            //Em cách ra chỉ để format lúc chạy trông đẹp hơn thui ạ T.T
            Console.WriteLine($" {i}. First Name: {mem.FirstName} | Last Name: {mem.LastName} | Gender: {mem.Gender} | DoB: {mem.DoB.ToString("dd/MM/yyyy")} | Age: {mem.Age} | Phone Number: {mem.PhoneNo} | Birthplace: {mem.BirthPlace} | Graduated: {mem.IsGraduated} ");
            i++;
        }
    }
    public static void PrintMember(Member mem){
            //Đây cũng thế anh nhá ^^
            Console.WriteLine($"    First Name: {mem.FirstName} | Last Name: {mem.LastName} | Gender: {mem.Gender} | DoB: {mem.DoB.ToString("dd/MM/yyyy")} | Age: {mem.Age} | Phone Number: {mem.PhoneNo} | Birthplace: {mem.BirthPlace} | Graduated: {mem.IsGraduated} ");
    }
}
