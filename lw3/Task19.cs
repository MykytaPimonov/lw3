using System.Xml;

namespace lw3;

public class Task19
{
    public void run()
    {
        Company company = Parser.parse();

        foreach (Staff s in company.getStaves())
        {
            Console.WriteLine(s);
        }
    }
    
    static class Parser
    {
        private static String path = "task19.xml";
        internal static Company parse() {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            XmlElement xmlElement = xmlDocument.DocumentElement;
            Company company = new Company();

            foreach (XmlElement elem in xmlElement)
            {
                Staff staff = new Staff();
                int? id = Convert.ToInt32(elem.Attributes.GetNamedItem("id")?.Value);
                staff.Id = id;
                
                foreach (XmlNode node in elem.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "firstname":
                            staff.Firstname = node.InnerText;
                            break;
                        case "lastname":
                            staff.Lastname = node.InnerText;
                            break;
                        case "nickname":
                            staff.Nickname = node.InnerText;
                            break;
                        case "salary":
                            staff.Salary = Convert.ToDouble(node.InnerText);
                            break;
                    }
                }
                
                company.add(staff);
            }

            return company;
        }
    }

    class Company
    {
        private List<Staff> staves;

        internal Company()
        {
            staves = new List<Staff>();
        }

        public void add(Staff element)
        {
            staves.Add(element);
        }

        public List<Staff> getStaves()
        {
            return staves;
        }
    }

    class Staff
    {
        private int? id; 
        private string? firstname; 
        private string? lastname; 
        private string? nickname; 
        private double? salary;

        public Staff()
        {
        }

        public Staff(int id, string? firstname, string? lastname, string? nickname, double? salary)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.nickname = nickname;
            this.salary = salary;
        }

        public int? Id
        {
            get => id;
            set => id = value;
        }

        public string? Firstname
        {
            get => firstname;
            set => firstname = value;
        }

        public string? Lastname
        {
            get => lastname;
            set => lastname = value;
        }

        public string? Nickname
        {
            get => nickname;
            set => nickname = value;
        }

        public double? Salary
        {
            get => salary;
            set => salary = value;
        }

        public override string ToString()
        {
            String s = "Staff {";
            if (id != null) s += "\n\tId: " + id;
            if (firstname != null) s += "\n\tFirstname: " + firstname;
            if (lastname != null) s += "\n\tLastname: " + lastname;
            if (nickname != null) s += "\n\tNickname: " + nickname;
            if (salary != null) s += "\n\tSalary: " + salary;
            return s + "\n}";
        }
    }
}