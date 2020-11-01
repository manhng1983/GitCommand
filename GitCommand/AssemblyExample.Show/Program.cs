using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ListAllClassesInAssembly
{
    internal partial class Program
    {
        // Add Reference to                  ..\AssemblyExample\bin\Debug\AssemblyExample.dll
        // Declare string assemblyFilePath = ..\AssemblyExample.Show\bin\Debug\AssemblyExample.dll
        private static string assemblyFilePath = @"C:\Users\Nguyen Viet Manh\source\repos\AssemblyExample.Show\AssemblyExample.Show\bin\Debug\AssemblyExample.dll";

        private static string ctorString = @"+<>c";

        private static List<string> baseMethods = new List<string>
        {
"System.Boolean Equals (System.Object obj)",
"System.Int32 GetHashCode ()",
"System.Type GetType ()",
"System.String ToString ()"
        };

        private static List<string> baseObjectMethods = new List<string>
        {
"Equals",
"GetHashCode",
"GetType",
"ToString"
        };

        private static string baseAutoGetProperty = "get_";
        private static string baseAutoSetProperty = "set_";

        private static HashSet<string> allMethods = new HashSet<string>();
        private static HashSet<string> allClasses = new HashSet<string>();
        private static SortedDictionary<string, string> Methods = new SortedDictionary<string, string>();
        private static SortedDictionary<string, string> Classes = new SortedDictionary<string, string>();

        /// <summary>
        ///
        /// </summary>
        /// <param name="pathDllName">Path of DLL file</param>
        /// <returns></returns>
        public static List<string> ShowClasses(string pathDllName)
        {
            Assembly assembly = Assembly.LoadFile(pathDllName);

            string assemblyName = assembly.GetName().Name;

            var listClassName = assembly.GetTypes().OrderBy(b => b.FullName).Select(a => a.FullName.ToString()).ToList();
            foreach (var className in listClassName)
            {
                AppendLineClass(className);
                Type type = Type.GetType($"{className},{assemblyName}");
                if (type != null)
                {
                    ShowMethods(type);
                }
            }

            // C# 4 and above offers the following syntax, which some find more readable:
            // new StreamWriter("C:\\methods.txt", append: true);
            using (StreamWriter sw = new StreamWriter(@"C:\methods.txt", true))
            {
                foreach (var s in allMethods)
                {
                    if (!baseObjectMethods.Contains(s) && !s.StartsWith(baseAutoGetProperty) && !s.StartsWith(baseAutoSetProperty))
                    {
                        sw.WriteLine(s);
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(@"C:\classes.txt", true))
            {
                foreach (var s in allClasses)
                {
                    if (!s.Contains("+"))
                    {
                        sw.WriteLine(s);
                    }
                }
            }

            return listClassName;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="line"></param>
        public static void AppendLineClass(string line)
        {
            allClasses.Add(line);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="line"></param>
        public static void AppendLineMethod(string line)
        {
            allMethods.Add(line);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        public static void ShowMethods(Type type)
        {
            foreach (var method in type.GetMethods())
            {
                var parameters = method.GetParameters();
                var parameterDescriptions = string.Join
                    (", ", method.GetParameters()
                                 .Select(x => x.ParameterType + " " + x.Name)
                                 .ToArray());

                string methodName = method.Name;

                if (baseMethods.Contains(methodName))
                {
                    continue;
                }

                if (methodName.Contains(ctorString))
                {
                    continue;
                }

                string s = string.Format("{0} {1} ({2})",
                                  method.ReturnType,
                                  methodName,
                                  parameterDescriptions);

                AppendLineMethod(methodName);
            }
        }

        //private static void BindMethods()
        //{
        //    var assembly = Assembly.LoadFile(assemblyFilePath);
        //    var publicClasses = assembly.GetExportedTypes().Where(p => p.IsClass);

        //    foreach (var classItem in publicClasses)
        //    {
        //        BindMethodNames(classItem);
        //    }
        //}

        //private static void BindMethodNames(Type type)
        //{
        //    MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.Static);

        //    Array.Sort(methodInfos,
        //        delegate (MethodInfo methodInfo1, MethodInfo methodInfo2)
        //        {
        //            return methodInfo1.Name.CompareTo(methodInfo2.Name)

        //        });

        //    foreach (var methodInfo in methodInfos)
        //    {
        //        this.comboMethods.Items.Add(methodInfo.Name);
        //    }
        //}

        private static void Main(string[] args)
        {
            // Run git commands from a C# function
            // https://stackoverflow.com/questions/26167387/run-git-commands-from-a-c-sharp-function
            //string gitCommand = "git";
            //string gitInitArgument = @" init";
            //string gitRemoteAddOriginArgument = @" remote add origin https://github.com/manhng1983/CSharpTest.git";
            //string gitPullOriginMasterArgument = @" pull origin master";
            //string gitRemoteShowOriginArgument = @" remote show origin https://github.com/manhng1983/CSharpTest.git";
            //string gitAddArgument = @"add -A";
            //string gitCommitArgument = @"commit ""explanations_of_changes""";
            //string gitPushArgument = @"push our_remote";

            //Process.Start(gitCommand, gitInitArgument);
            //Process.Start(gitCommand, gitRemoteAddOriginArgument);
            //Process.Start(gitCommand, gitPullOriginMasterArgument);
            //Process.Start(gitCommand, gitRemoteShowOriginArgument);

            //Process.Start(gitCommand, gitAddArgument);
            //Process.Start(gitCommand, gitCommitArgument);
            //Process.Start(gitCommand, gitPushArgument);

            string output = string.Empty;

            //----------------------------------------------------------------------------------------------------
            //output = ParseGitLog.RunProcess(" log");
            //output = ParseGitLog.RunProcess(" log -2"); // Hiển thị log của 2 commit cuối
            //output = ParseGitLog.RunProcess(" log -p -2"); // Hiển thị chi tiết các thay đổi của từng commit
            //output = ParseGitLog.RunProcess(" log --stat -5"); // Hiển thị thống kế gọn hơn về sự thay đổi
            //output = ParseGitLog.RunProcess(" log --shortstat -5"); // Hiển thị thống kế gọn hơn về sự thay đổi
            //output = ParseGitLog.RunProcess(" log --oneline"); // Định dạng thông tin chung về commit (mã hash, dòng thông tin) trên một dòng
            //output = ParseGitLog.RunProcess(" log --stat -10 --oneline"); // Định dạng thông tin chung về commit (mã hash, dòng thông tin) trên một dòng
            //output = ParseGitLog.RunProcess(" log --shortstat -10 --oneline"); // Định dạng thông tin chung về commit (mã hash, dòng thông tin) trên một dòng

            //----------------------------------------------------------------------------------------------------
            //output = ParseGitLog.RunProcess(" log --after=\"2019-01-01\" --before=\"2019-12-31\""); // Lọc theo ngày
            //output = ParseGitLog.RunProcess(" log --oneline --author=\"manhng83vn\""); // Lọc theo người commit
            //output = ParseGitLog.RunProcess(" log --oneline --grep=\"init\""); // Lọc theo thông tin ghi chú về commit

            //----------------------------------------------------------------------------------------------------
            //Lọc các commit liên quan đến file cụ thể
            //output = ParseGitLog.RunProcess(" log --oneline -- Matches/SearchCondition.cs");

            //----------------------------------------------------------------------------------------------------
            //Lọc và định dang thông tin chung về các commit liên quan đến file cụ thể và theo người commit
            //output = ParseGitLog.RunProcess(" log --oneline --author=\"manhng83vn\" -- Matches/SearchCondition.cs");

            //output = ParseGitLog.RunProcess(" log --author=\"manhng83vn\" -- Matches/SearchCondition.cs"); // Lọc các commit liên quan đến file cụ thể và theo người commit

            //----------------------------------------------------------------------------------------------------
            //git log -p
            //git show e9fc251aaa72a0eb421e507c287cd6d887a0f20e
            //git show e9fc25
            //----------------------------------------------------------------------------------------------------

            //Git can figure out a short, unique abbreviation for your SHA-1 values. If you pass --abbrev-commit to the git log command, the output will use shorter values but keep them unique; it defaults to using seven characters but makes them longer if necessary to keep the SHA-1 unambiguous
            //----------------------------------------------------------------------------------------------------
            //git log --abbrev-commit --pretty=oneline

            //Shows the changes made in the most recent commit
            //----------------------------------------------------------------------------------------------------
            //git show HEAD
            //git show HEAD~1 takes you back 1 commit
            //git show HEAD~2 takes you back 2 commit
            //git show HEAD~3 takes you back 3 commit
            //git show HEAD~4 takes you back 4 commit
            //git show HEAD~5 takes you back 5 commit

            //using (StreamWriter sw = new StreamWriter(@"C:\output.txt", true))
            //{
            //    sw.WriteLine(output);
            //}

            //var assembly = Assembly.LoadFile(assemblyFilePath);
            //var assembly = typeof(AssemblyExample.ReflectionUtils).Assembly;

            // You have to Add Reference to AssemblyExample.dll
            // Type type = Type.GetType("AssemblyExample.ReflectionUtils, AssemblyExample");

            // ShowClasses(assemblyFilePath);

            //ShowMethods(typeof(DateTime));

            //Assembly mscorlib = typeof(string).Assembly;
            //foreach (Type type in mscorlib.GetTypes())
            //{
            //    Console.WriteLine(type.FullName);
            //}

            //foreach (var entity in ReflectionUtils.GetClassNames(assemblyFilePath))
            //{
            //    Console.WriteLine(entity);
            //}

            //System.Reflection.Assembly objAssembly = System.Reflection.Assembly.LoadFrom(assemblyFilePath);
            //Type[] arOfTypes = objAssembly.GetTypes();

            // Reflection in .NET
            // https://www.c-sharpcorner.com/article/reflection-in-net/

            System.Reflection.Assembly objAssembly;
            System.Type[] arOfTypes;
            objAssembly = System.Reflection.Assembly.LoadFrom(assemblyFilePath);
            arOfTypes = objAssembly.GetTypes();

            System.Type t;
            //t = Type.GetType("AssemblyExample.Student,AssemblyExample");

            for (int i = 0; i < arOfTypes.Length; i++)
            {
                t = arOfTypes[0];

                // Extracting Constructor Information
                // It is an object of type System.Type. This method returns an array of objects of type ConstructorInfo. This calss is part of System.Reflection Name space.
                ConstructorInfo[] ctrInfo = t.GetConstructors();

                // Extracting Properties Information
                // It is an object of type System.Type. This method returns an array of objects of type PropertyInfo. This calss is part of System.Reflection Name space.
                PropertyInfo[] pInfo = t.GetProperties();

                // Extracting Method Information
                MethodInfo[] mInfo = t.GetMethods();

                // Extracting Event Information
                EventInfo[] eInfo = t.GetEvents();
            }
        }
    }
}