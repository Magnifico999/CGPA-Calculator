try
{
    Console.WriteLine("Enter the number of courses");
    int noOfCourses = int.Parse(Console.ReadLine());

    string[] courseCode = new string[noOfCourses];
    int[] courseUnit = new int[noOfCourses];
    int[] score = new int[noOfCourses];
    char[] grade = new char[noOfCourses];
    double[] weightPoint = new double[noOfCourses];
    string[] remark = new string[noOfCourses];
    double totalCourseUnitReg = 0;
    double totalCourseUnitPass = 0;
    double totalweightPoint = 0;
    double GPA = 0;

    for (int i = 0; i < noOfCourses; i++)
    {
        Console.WriteLine($"Enter course code for course No {i + 1}:");
        courseCode[i] = Console.ReadLine();
        Console.WriteLine($"Enter course unit for {courseCode[i]}:");
        courseUnit[i] = int.Parse(Console.ReadLine());
        Console.WriteLine($"Enter score for {courseCode[i]}:");
        score[i] = int.Parse(Console.ReadLine());

        int gradeUnit = GetGradeUnit(score[i], courseUnit[i], out grade[i], out weightPoint[i], out remark[i]);

        totalCourseUnitReg += courseUnit[i];
        totalCourseUnitPass += gradeUnit;
        totalweightPoint += weightPoint[i];
        GPA = totalweightPoint / totalCourseUnitPass;
    }

    Console.Clear();
    Console.WriteLine("|-------------------------" + "-------GPA CALCULATOR---" +
                      "------------------------|");
    Console.WriteLine("| {0,-9} | {1,-9}| {2,-9} | {3,-9} | {4,-9} |{5,-9}  |", "COURSE CODE", "COURSE UNIT",
        "GRADE", "GRADE PT", "WEIGHT PT", "REMARK");
    Console.WriteLine("|-------------------------" + "-------------------------" +
                      "-----------------------|");

    for (int i = 0; i < noOfCourses; i++)
    {
        Console.WriteLine("| {0,-11} | {1,-9} | {2,-9} | {3,-9} | {4,-9} |{5,-9}  |", courseCode[i], courseUnit[i],
            grade[i], GetGradeUnit(score[i], courseUnit[i], out _, out double w, out _), w, remark[i]);
    }

    Console.WriteLine("|-------------------------" + "-------------------------" +
                      "-----------------------|");

    Console.WriteLine($"Total Course Unit Registered is {totalCourseUnitReg}");
    Console.WriteLine($"Total Course Unit Passed is {totalCourseUnitPass}");
    Console.WriteLine($"Total Weight Point is {totalweightPoint}");
    Console.WriteLine($"Your GPA is {GPA:F2}");


    static int GetGradeUnit(int score, int courseUnit, out char grade, out double weightPoint, out string remark)
    {
        switch (score / 10)
        {
            case 10:
            case 9:
                grade = 'A';
                weightPoint = 5 * courseUnit;
                remark = "Excellent";
                return 5;
            case 8:
                grade = 'B';
                weightPoint = 4 * courseUnit;
                remark = "Very Good";
                return 4;
            case 7:
                grade = 'C';
                weightPoint = 3 * courseUnit;
                remark = "Good";
                return 3;
            case 6:
                grade = 'D';
                weightPoint = 2 * courseUnit;
                remark = "Fair";
                return 2;
            case 5:
            case 4:
                grade = 'E';
                weightPoint = courseUnit;
                remark = "Pass";
                return 1;
            default:
                grade = 'F';
                weightPoint = 0;
                remark = "Fail";
                return 0;
        }
    }
}
catch
{
    Console.WriteLine("Invalid input");
}
