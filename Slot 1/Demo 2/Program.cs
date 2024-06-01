
using Demo_2;
using System.Collections;
using System.Runtime.CompilerServices;

internal class Program
{
    public static List<Course> courseList = new List<Course>();
    private static void Main(string[] args)
    {
        Console.WriteLine("Choose options:");
        Console.WriteLine("1. Input a courses list");
        Console.WriteLine("2. Print available courses:");
        Console.WriteLine("3. Input StartDate and EndDate to search for courses that start between:");
        Console.WriteLine("4. Sort courses by title");
        Console.WriteLine("0. Exit");
        try
        {
            int choice = Int32.Parse(Console.ReadLine());
            while (choice != 0)
            {
                Redirect(choice);
                Console.WriteLine("Choose options:");
                Console.WriteLine("1. Input a courses list");
                Console.WriteLine("2. Print available courses:");
                Console.WriteLine("3. Input StartDate and EndDate to search for courses that start between:");
                Console.WriteLine("4. Sort courses by title");
                Console.WriteLine("0. Exit");
                choice = Int32.Parse(Console.ReadLine());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Input must be 1 - 4");
        }
    }

    private static void Redirect(int choice)
    {
        if (choice == 1)
        {
            InputCourseList();
        }
        else if (choice == 2)
        {
            Display(courseList);
        }
        else if (choice == 3)
        {
            SearchDate();
        }
        else if (choice == 4)
        {
            courseList.Sort((x, y) => string.Compare(x.title, y.title));

            //courseList = courseList.OrderBy(c => c.title).ToList();
            
        }
    }

    private static void InputCourseList()
    {
        Console.WriteLine("Input number of courses you want to input:");
        try
        {
            int num = Int32.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                InputCourse(i);
            }
        }
        catch
        {
            Console.WriteLine("Input must be an integer");
        }
    }

    private static void InputCourse(int courseSTT)
    {
        Console.WriteLine($"Input course number {courseSTT}:");
        Console.WriteLine("Input course title:");
        string? title = Console.ReadLine();
        DateTime startdate = DateTime.Now;
        while (title == null)
        {
            Console.WriteLine("Title cannot be null:");
            title = Console.ReadLine();
        }

        Console.WriteLine("Input course start date:");
        try
        {
            startdate = DateTime.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Wrong format");
        }

        int id;
        if (courseList == null) { id = 1; }
        else id = courseList.Count() + 1;

        courseList.Add(new Course(id, title, startdate));
    }

    public static void Display(List<Course> courses)
    {
        foreach (Course course in courses)
        {
            Console.WriteLine(course.ID + " " + course.title + " " + course.startdate);
        }
    }
    public static void SearchDate()
    {
        DateTime startDate;
        DateTime endDate;

        Console.WriteLine("Input start date:");
        if (DateTime.TryParse(Console.ReadLine(), out startDate))
        {
            Console.WriteLine("Input end date:");
            if (DateTime.TryParse(Console.ReadLine(), out endDate))
            {
                var coursesInRange = courseList.Where(course => course.startdate >= startDate && course.startdate <= endDate).ToList();
                Display(coursesInRange);
            }
            else
            {
                Console.WriteLine("Wrong format for end date.");
            }
        }
        else
        {
            Console.WriteLine("Wrong format for start date.");
        }
    }

}
