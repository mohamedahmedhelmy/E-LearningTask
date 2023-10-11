// See https://aka.ms/new-console-template for more information
using E_LearningTask.Data;
using E_LearningTask.Enums;
using E_LearningTask.Models;
using E_LearningTask.Operations;
using E_LearningTask.Payment;

public class Program
{
  
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
      
        Console.WriteLine("--------------------Welcome To Giza E-Learning Site --------------------");

        var option = "";
        while (option != "ex")
        {
            ApplicationDbContext db = new ApplicationDbContext();
            IGenericOperation<Course> courseOperation = new CourseOperation(db);
            IGenericOperation<Instructor> instructorOperation = new InstructorOperation(db);
            IGenericOperation<Student> studentOperation = new StudentOperation(db);
            IGenericOperation<FeedBackCourse> FeedBackOperation = new FeedBackCourseOperation(db);
            Console.WriteLine("Press 1 To Add New Course Or Show Courses List ");
            Console.WriteLine("Press 2 To Add New Instructor Or Show Instructor List ");
            Console.WriteLine("Press 3 To Add New Student Or Show Student List ");
            Console.WriteLine("Press 4 To Add FeedBack To Course ");
            Console.WriteLine("Press ex To Leave ");
            option = Console.ReadLine();
            if (option == "1")
            {
                Console.WriteLine("Press 1 To Add New Course . Press 2 To Show The Courses List");
                var Operation = Console.ReadLine();


                if (Operation == "1")
                {
                    Console.WriteLine("Please Enter The Course Name");
                    var courseName = Console.ReadLine();
                    Console.WriteLine("Please Enter The Course Duration");
                    var courseDuration = Console.ReadLine();
                    Console.WriteLine("Please Enter The Course Price");
                    var coursePrice = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Please Enter The Instructor ID");
                    var instructorId = int.Parse(Console.ReadLine());

                    var course = new Course();
                    var isCourseName = courseOperation.GetAll().FirstOrDefault(c => c.CourseName.ToLower() == courseName.ToLower());
                    if (isCourseName != null)
                    {
                        Console.WriteLine($"This Course already exist {courseName}");
                        Console.WriteLine("---------------------------------");
                    }
                    else
                    {
                        course.CourseName = courseName;
                        course.Duration = courseDuration;
                        course.InstructorId = instructorId;
                        course.Price = coursePrice;
                        courseOperation.Add(course);
                    }

                }

                else if (Operation == "2")
                {
                    var coursesList = courseOperation.GetAll();
                    foreach (var item in coursesList)
                    {
                       
                        var instructorName = instructorOperation.GetAll().FirstOrDefault(i => i.InstructorId == item.InstructorId);
                        Console.WriteLine($"Course ID: {item.CourseId}\n" +
                            $"Course Name : {item.CourseName}" +
                            $"\nInstructor Name :{instructorName?.InstructorName}");
                        item.FeedBackCourse = FeedBackOperation.GetAll();
                        var FeedList = item.FeedBackCourse.Where(f => f.CourseId == item.CourseId).ToList();
                        Console.WriteLine("---------Course FeedBack-----------");
                        if (FeedList.Count > 0)
                        {

                            Double CalcRate = 0;
                            foreach (var feedback in FeedList)
                            {
                                CalcRate = CalcRate + feedback.Rate;
                                Console.WriteLine($"Student Id : {feedback.StudentId}\nFeedback Comment : {feedback.Comment}\n" +
                                    $"He Rating This Course {feedback.Rate} *");
                                Console.WriteLine("------------------------------");
                            }
                            var TotalRate = (CalcRate / (FeedList.Count * 5)) * 5;
                            Console.WriteLine($"The Total Rate Is {TotalRate} *");
                        }
                        else
                        {
                            Console.WriteLine($"The Total Rate Is Zero ");
                        }
                        Console.WriteLine("------------------------------");
                    };


                }
            }
            else if (option == "2")
            {
                Console.WriteLine("enter 1 to add new Instructor . 2 to show iInstructors list");
                var operation = Console.ReadLine();
                if (operation == "1")
                {
                    Console.WriteLine("Please Enter The instructor Name");
                    var Name = Console.ReadLine();
                    Console.WriteLine("Please Enter The instructor Job type(1- To PerCourse, 2- FullTime)");
                    var type = Console.ReadLine();
                    Instructor instructor = new Instructor();
                    var isInstructorName = instructorOperation.GetAll().FirstOrDefault(c => c.InstructorName.ToLower() == Name.ToLower());
                    if (isInstructorName != null)
                    {
                        Console.WriteLine($"This Course already exist {Name}");
                        Console.WriteLine("---------------------------------");
                    }
                    instructor.InstructorName = Name;
                    switch (type)
                    {
                        case "1":
                            instructor.employeeType = EmployeeType.PerCourse;
                            break;
                        case "2":
                            instructor.employeeType = EmployeeType.FullTime;
                            break;
                        default:
                            Console.WriteLine("Please Choose From The Employee Type List");
                            break;
                    }
                    instructorOperation.Add(instructor);
                }
                else
                {

                    foreach (var item in instructorOperation.GetAll())
                    {
                        Console.WriteLine($"Instructor ID: {item.InstructorId}\n" +
                            $"Instructor Name: {item.InstructorName}" +
                            $"\nInstructorType: {item.employeeType}");
                        Console.WriteLine("---------------------------------");
                    };
                }
            }
            else if (option == "3")
            {
                Console.WriteLine("enter 1 to add new student . 2 to show student list");
                var operation = Console.ReadLine();
                if (operation == "1")
                {
                    Console.WriteLine("Please Enter The student Name");
                    var Name = Console.ReadLine();
                    Student student = new Student();
                    student.StudentName = Name;
                    student.Courses = new List<StudentCourse>();
                    var addLoop = "";
                    while (addLoop != "no")
                    {
                        Console.WriteLine("Please Enter Id of the Selected Course");
                        var courseId = int.Parse(Console.ReadLine());
                        student.Courses.Add(new StudentCourse { CourseId = courseId,StudentId= student.StudentId});
                        Console.WriteLine("Do You Want Add Another Course (yes) TO Add No To ");
                        addLoop = Console.ReadLine();
                    }


                    Console.WriteLine("Choose Your Pereferd Payment To Enroll In This Course");
                    Console.WriteLine(" 1- paypal\n 2- X Bank Transfer\n 3- Cridet Card ");
                    var paymentWay = Console.ReadLine();
                    IPayment payment;
                    switch (paymentWay)
                    {
                        case "1":
                            payment = new PaymentWithPaypal();
                            student.IsEnrolled = payment.PaymentManageWay();
                            break;
                        case "2":
                            payment = new PaymentWithBankTransfer();
                            student.IsEnrolled = payment.PaymentManageWay();
                            break;
                        case "3":
                            payment = new PaymentWithCridetCard();
                            student.IsEnrolled = payment.PaymentManageWay();
                            break;
                        default:
                            Console.WriteLine("Please Choose From The List ");
                            break;
                    }
                    if (student.IsEnrolled)
                        studentOperation.Add(student);

                }
                else
                {

                    foreach (var item in studentOperation.GetAll())
                    {
                        Console.WriteLine($"student ID: {item.StudentId}\n" +
                            $"student Name : {item.StudentName}");
                        var courseFromStudent = item.Courses.Select(c => c.CourseId);
                        var studentCourses = courseOperation.GetAll();

                        foreach (var Id in courseFromStudent)
                        {
                            foreach (var course in studentCourses.Where(c => c.CourseId == Id).Select(c => c.CourseName))
                                Console.WriteLine($" + course Id : {Id}\t Course Name : {course}");
                        }
                        Console.WriteLine("---------------------------------");
                    };
                }
            }
            else if (option == "4")
            {
                Console.WriteLine("Please Enter The Course Id ");
                var courseId = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Please Enter Your Id ");
                var studentId = int.Parse(Console.ReadLine()!);
                var Student = studentOperation.GetAll().FirstOrDefault(s => s.StudentId == studentId);
                var studentCourse = Student.Courses.Select(c => c.CourseId);
                foreach (var course in studentCourse)
                {
                    if (course == courseId)
                    {
                        Console.WriteLine("Please enter your rate from 1 To 5");
                        var rate = double.Parse(Console.ReadLine()!);
                        Console.WriteLine("Please enter Your Feedback Comment");
                        var comment = Console.ReadLine();
                        var feedback = new FeedBackCourse() { StudentId = studentId, CourseId = courseId, Rate = rate, Comment = comment };
                        FeedBackOperation.Add(feedback);
                    }
                    else
                    {
                        Console.WriteLine("You Can not add feedback because You are not enroll in this course");
                    }
                }

            }
            else if (option == "ex")
            {
                break;
            }
            else
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Please Choose Number From The List Or Exit (ex)");
                Console.WriteLine("---------------------------------------------------");
            }
            
        }
    }
}