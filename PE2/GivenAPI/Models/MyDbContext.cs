namespace GivenAPI.Models
{
    public class MyDbContext
    {
        public static List<Employee> Employees { get; set; } = new List<Employee>
            {
                new Employee {EmployeeId=1, Name="Employee 1", Gender="Male", Dob = new DateOnly(1994, 12, 23), Position="Developer", IsFulltime= true},
                new Employee {EmployeeId=2, Name="Employee 2", Gender="Female", Dob = new DateOnly(1987, 9, 2), Position="Tester", IsFulltime= true},
                new Employee {EmployeeId=3, Name="Employee 3", Gender="Female", Dob = new DateOnly(1984, 12, 10), Position="Developer", IsFulltime= false},
                new Employee {EmployeeId=4, Name="Employee 4", Gender="Male", Dob = new DateOnly(2000, 5, 27), Position="ProjectManager", IsFulltime= true},

            };
        public static List<Project> Projects { get; set; } = new List<Project>
            {
                new Project{ProjectId= 1, ProjectName = "Project Alpha", ProjectDescription="Description about Project Alpha", StartDate=new DateOnly(2021, 12, 1), EndDate=new DateOnly(2022, 5, 6), IsActive=false},
                new Project{ProjectId= 2, ProjectName = "Project Beta", ProjectDescription="Description about Project Beta", StartDate=new DateOnly(2022, 1, 1), EndDate=new DateOnly(2022, 8, 9), IsActive=false},
                new Project{ProjectId= 3, ProjectName = "Project Gamma", ProjectDescription="Description about Project Gamma", StartDate=new DateOnly(2023, 9, 18), EndDate=new DateOnly(2024, 1, 30), IsActive=false},
                new Project{ProjectId= 4, ProjectName = "Project Delta", ProjectDescription="Description about Project Delta", StartDate=new DateOnly(2024, 3, 1), EndDate=null, IsActive=true}
            };

    }
}
