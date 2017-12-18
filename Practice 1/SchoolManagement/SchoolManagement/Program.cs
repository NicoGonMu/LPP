using System;
using SchoolLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            School s = new School();
            List<Degree> degrees = new List<Degree>();
            List<Mark> marks = new List<Mark>();
            initData(ref s, ref degrees, ref marks);

            ///Who is the student(or students) that has passed more subjects
            morePassedSubjects(marks);


            ///Who is the student(or students) with more degrees ? (must has passed all degree subjects )
            moreDegrees(degrees, marks);


            ///For each degree who has the best mean qualification? (must have finished the degree)
            bestMeanPerDegree(degrees, marks);


            ///For each degree compare mean qualifications by sex.            
            meanBySex(degrees, marks);


            ///What is the best degree qualification? Student that has got the best mean qualification in a degree.
            bestMean(degrees, marks);


            ///Display the 10% best students for each degree.            
            bestTen(degrees, marks);


            ///Display the best mark for each subject (if nobody has passed the subject then shows it empty)             
            bestMark(degrees, marks);

        }


        private static void initData(ref School s, ref List<Degree> degrees, ref List<Mark> marks)
        {
            Random rnd = new Random();
            s = new School() { Name = Common.randomStr(10, rnd), Town = Common.randomStr(5, rnd) };

            //i degrees
            //n subjects            
            //j students
            //k marks
            //Where i < n < j <= k
            for (int i = 0; i < 10; i++)
            {
                Degree d = new Degree(Common.randomStr(15, rnd));
                d.Subjects = new List<Subject>();

                //n subjects
                for (int n = 0; n < 10; n++)
                {
                    Subject sb = new Subject(Common.randomStr(5, rnd), Common.randomYear(rnd));
                    d.Subjects.Add(sb);
                }
                degrees.Add(d);
            }
            //j students
            for (int j = 0; j < 2000; j++)
            {
                Student st = new Student(Common.randomStr(5, rnd), Common.randomStr(5, rnd), DateTime.Now, Common.randomStr(6, rnd), Common.randomSex(rnd));
                //Randomly decide how many started degrees will the student have
                int degs = (Common.random(rnd) % 3) + 1;
                for (int it = 0; it < degs; it++)
                {
                    Degree deg = degrees.ElementAt(Common.random(rnd) % degrees.Count);
                    //Randomly decide how many subjects the student has (supposing a maximum of 1 fail per subject)
                    int subjs = Common.random(rnd) % 20;
                    for (int k = 0; k < subjs; k++)
                    {
                        Subject sb = deg.Subject(Common.random(rnd) % deg.Subjects.Count);
                        Mark mk = new Mark(sb, st, (Common.random(rnd) % 11));
                        marks.Add(mk);
                    }
                }
            }

            foreach (Degree d in degrees)
            {
                Console.WriteLine(d.ToString());
                Console.WriteLine();
            }

            foreach (Mark m in marks)
            {
                Console.WriteLine(m.ToString());
                Console.WriteLine();
            }
        }


        private static void addMeans(ref Dictionary<string, decimal> studentMeans, IEnumerable<IGrouping<string, Mark>> p)
        {
            foreach (IGrouping<string, Mark> student in p)
            {
                decimal mean = student.Average(x => x.Value);
                if (!studentMeans.ContainsKey(student.Key)) studentMeans.Add(student.Key, mean);
                studentMeans[student.Key] = mean;

            }
        }

        private static void addCounts(ref Dictionary<string, int> studentMeans, IEnumerable<IGrouping<string, Mark>> p)
        {
            foreach (IGrouping<string, Mark> student in p)
            {
                if (!studentMeans.ContainsKey(student.Key)) studentMeans.Add(student.Key, 0);
                studentMeans[student.Key]++;
            }
        }

        private static void morePassedSubjects(List<Mark> marks)
        {
            //Get all studens with a >= 5 mark
            var students = from mark in marks where mark.Value >= 5 select mark.getStudent;
            //Get student marks count orderered
            var count = (from student in students group student by student.ToString() into c select new { studentName = c.Key, studentCount = c.Count() }).OrderByDescending(x => x.studentCount);
            int maxSubjects = count.First().studentCount;
            var result = from student in count where student.studentCount == maxSubjects select student.studentName;

            Console.WriteLine("Students with maximum subjects passed:");
            foreach (string sName in result) Console.WriteLine(sName);
        }

        private static void moreDegrees(List<Degree> degrees, List<Mark> marks)
        {
            Dictionary<string, int> studentDegs = new Dictionary<string, int>();
            //Get all subjects from every degree
            var subjsPerDegree = from degree in degrees select degree.Subjects;
            //Get all passed marks
            var mks = from mark in marks where mark.Value >= 5 select mark;
            //Get all students that finished a degree
            foreach (List<Subject> subjs in subjsPerDegree)
            {
                //Get all students with all subjects of the degree passed
                var p = from mark in mks join subj in subjs on mark.getSubject.Code equals subj.Code let st = $"{mark.getStudent.Name} {mark.getStudent.Surname}" group mark by st into c where c.Count() == subjs.Count() select c;
                addCounts(ref studentDegs, p);
            }
            var result = from degs in studentDegs where degs.Value == studentDegs.Values.Max() select degs;
            Console.WriteLine($"{result.First().Key} has passed {result.First().Value} degrees.");
        }

        private static void bestMeanPerDegree(List<Degree> degrees, List<Mark> marks)
        {
            Dictionary<string, string> studentPerDegree = new Dictionary<string, string>();
            //Get all subjects from every degree
            var subjsPerDegree = from degree in degrees select new { name = degree.Name, subjects = degree.Subjects };
            //Get all passed marks            
            var mks = from mark in marks where mark.Value >= 5 select mark;
            //For each degree, obtain the best mean qualification
            foreach (var deg in subjsPerDegree)
            {
                //Get all students with all subjects of the degree passed
                var p = from mark in mks join subj in deg.subjects on mark.getSubject.Code equals subj.Code let st = $"{mark.getStudent.Name} {mark.getStudent.Surname}" group mark by st into c where c.Count() == deg.subjects.Count() select new { name = c.Key, value = c.Average(x => x.Value) };
                if (p == null || p.Count() == 0) continue;
                Console.WriteLine($"Best student in {deg.name}: {p.OrderByDescending(x => x.value).First().name}");
            }
        }

        private static void meanBySex(List<Degree> degrees, List<Mark> marks)
        {
            Dictionary<string, string> studentPerDegree = new Dictionary<string, string>();            

            foreach (Degree deg in degrees)
            {
                //Get all degree marks grouped by sex
                var p = from mark in marks join subj in deg.Subjects on mark.getSubject.Code equals subj.Code group mark by mark.getStudent.Sex into c select new { sex = c.First().getStudent.Sex, value = c.Average(x => x.Value) };
                Console.WriteLine($"Qualifications on degree {deg.Name} by sex:");
                foreach(var mean in p)
                {
                    Console.WriteLine($"{Convert.ToChar(mean.sex)}: {mean.value}");
                }
            }
        }

        private static void bestMean(List<Degree> degrees, List<Mark> marks)
        {
            string studentName = "";
            decimal bestMean = 0;

            //Get all subjects from every degree
            var subjsPerDegree = from degree in degrees select new { name = degree.Name, subjects = degree.Subjects };
            //Get all passed marks            
            var mks = from mark in marks where mark.Value >= 5 select mark;
            //For each degree, obtain the best mean qualification
            foreach (var deg in subjsPerDegree)
            {
                //Get all students with all subjects of the degree passed
                var p = from mark in mks join subj in deg.subjects on mark.getSubject.Code equals subj.Code let st = $"{mark.getStudent.Name} {mark.getStudent.Surname}" group mark by st into c where c.Count() == deg.subjects.Count() select new { name = c.Key, value = c.Average(x => x.Value) };
                p = p.OrderByDescending(x => x.value);
                decimal bestDegreeMean = p.First().value;
                if (bestDegreeMean > bestMean)
                {
                    bestMean = bestDegreeMean;
                    studentName = p.First().name;
                }
            }

            Console.WriteLine($"Best student degree mean qualification: {bestMean} by {studentName}");
        }

        private static void bestTen(List<Degree> degrees, List<Mark> marks)
        {
            Dictionary<string, string> studentPerDegree = new Dictionary<string, string>();
            //Get all subjects from every degree
            var subjsPerDegree = from degree in degrees select new { name = degree.Name, subjects = degree.Subjects };
            //For each degree, obtain the best mean qualification
            foreach (var deg in subjsPerDegree)
            {
                //Get all students with all subjects of the degree passed
                var p = (from mark in marks join subj in deg.subjects on mark.getSubject.Code equals subj.Code let st = $"{mark.getStudent.Name} {mark.getStudent.Surname}" group mark by st into c where c.Count() == deg.subjects.Count() select new { name = c.Key, value = c.Average(x => x.Value) }).OrderByDescending(x => x.value);
                Console.WriteLine($"Best 10% students in {deg.name}: ");
                int tenPercent = (int)(p.Count() * 0.1);
                for (int i = 0; i < tenPercent; i++)
                {
                    var student = p.ElementAt(i);
                    Console.WriteLine($"{student.name} with mean of {student.value}");
                }
            }
        }

        private static void bestMark(List<Degree> degrees, List<Mark> marks)
        {
            Dictionary<int, decimal?> bestMarkBySubject = new Dictionary<int, decimal?>();
            //Get all marks sorted by value, and grouped by subject
            var p = from mark in marks group mark.Value by mark.getSubject.Code into m select m;
            foreach (var subject in p)
            {
                decimal val = subject.Max();
                if (!bestMarkBySubject.ContainsKey(subject.Key)) bestMarkBySubject.Add(subject.Key, null);
                if (val >= 5 && (bestMarkBySubject[subject.Key] == null || bestMarkBySubject[subject.Key] < val))
                    bestMarkBySubject[subject.Key] = val;
            }

            Console.WriteLine($"Best marks for each subject:");
            foreach (KeyValuePair<int, decimal?> kvp in bestMarkBySubject) Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}
