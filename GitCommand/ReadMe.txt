Append to text
https://stackoverflow.com/questions/8854984/append-text-using-streamwriter

Load Assembly from file or from Reference
------------------------------------------
var assembly = Assembly.LoadFile(assemblyFilePath);
or
var assembly = typeof(AssemblyExample.ReflectionUtils).Assembly;


Get list of classes & methods
https://stackoverflow.com/questions/11360372/get-all-the-method-names-in-all-of-the-classes


Get list of methods
https://stackoverflow.com/questions/1198417/generate-list-of-methods-of-a-class-with-method-types


Get all Classes & Class Methods from an Assembly
http://venkateswarlu.net/DotNet/Get_all_methods_from_a_class.aspx

C# How to get the assembly's name
-----------------------------------
typeof(Program).Assembly.GetName().Name;
or
System.Reflection.Assembly.GetExecutingAssembly().GetName().Name
or
System.Reflection.Assembly.GetAssembly(typeof(CP.Proj.ILogger)).GetName().Name
or
System.Reflection.Assembly.GetCallingAssembly().GetName().Name;


Get class methods using reflection
-----------------------------------
MethodInfo[] methodInfos = Type.GetType(selectedObjcClass) 
                           .GetMethods(BindingFlags.Public | BindingFlags.Instance);

Git Tutorial
https://www.deployhq.com/git

LibGit2Sharp
-------------
LibGit2Sharp brings all the might and speed of libgit2, a native Git implementation, to the managed world of .Net and Mono.

Install-Package LibGit2Sharp

Getting Information About Your Git Repository With C#
https://blog.somewhatabstract.com/2015/06/22/getting-information-about-your-git-repository-with-c/

Parse git log output in C#
http://chrisparnin.github.io/articles/2013/09/parse-git-log-output-in-c/

GIT HASH
-----------
The git hash is made up of the following:

The commit message
The file changes
The commit author (and committer- they can be different)
The date
The parent commit hash


git log --abbrev-commit --pretty=oneline