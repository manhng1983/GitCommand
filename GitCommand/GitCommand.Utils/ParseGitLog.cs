using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitCommand.Utils
{
    public class ParseGitLog
    {
        public static string ListShaWithFiles(string path)
        {
            var output = RunProcess(string.Format(" --git-dir={0}/.git --work-tree={1} log --name-status", path.Replace("\\", "/"), path.Replace("\\", "/")));
            return output;
        }

        public static string RunProcess(string command)
        {
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = Config.GitExectuable;
            p.StartInfo.Arguments = command;
            p.Start();
            // Read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output;
        }

        private bool StartsWithHeader(string line)
        {
            if (line.Length > 0 && char.IsLetter(line[0]))
            {
                var seq = line.SkipWhile(ch => char.IsLetter(ch) && ch != ':');
                return seq.FirstOrDefault() == ':';
            }
            return false;
        }
    }
}
