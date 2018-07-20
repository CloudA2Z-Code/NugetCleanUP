using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetCleanupTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allfileslist;
            string strRootpath = @"E:\1ES.SCOMCPY\SystemCenter\Migration\SCOM\src";

            string[] Outlines;
            List<string> allRootfilesItemList = new List<string>();
            if (args.Length != 0)
            {
                strRootpath = args[0];
            }

            if (Directory.Exists(strRootpath))
            {
                int i = 0;
                allfileslist = Directory.GetFiles(strRootpath, "*.csproj", SearchOption.AllDirectories);
                foreach (string line1 in allfileslist)
                {

                    string[] lines = System.IO.File.ReadAllLines(line1);
                    string str1, str2;
                    // Display the file contents by using a foreach loop.


                    /*foreach (string line in lines)
                    {
                        // Use a tab to indent each line of the file.
                        if (line.Contains(@"<AssemblyName>") && line.Contains(@"</AssemblyName>"))
                        {
                            str1 = line.Replace(@"<AssemblyName>", "").Replace(@"</AssemblyName>", "");
                            i++;
                            str2 = i.ToString() + "," + str1.Trim() + "," + line1.Trim();
                            System.Console.WriteLine(str2);
                            allRootfilesItemList.Add(str2);

                        }

                    }*/

                    string strAssembly = string.Empty, strGu = string.Empty;
                    string strAssemblyline = lines.Where(x => x.Contains(@"<AssemblyName>")).FirstOrDefault();
                    if (!string.IsNullOrEmpty(strAssemblyline))
                    {
                        strAssembly = strAssemblyline.Replace(@"<AssemblyName>", "").Replace(@"</AssemblyName>", "").Trim();

                        string strGuideline = lines.Where(x => x.Contains(@"<ProjectGuid>")).FirstOrDefault();
                        if (!string.IsNullOrEmpty(strGuideline))
                        {
                            strGu = (strGuideline.Replace(@"<ProjectGuid>", "").Replace(@"</ProjectGuid>", "").Replace("{", "").Replace("}", "")).ToString().Trim();
                        }
                        i++;
                        str2 = i.ToString() + "," + strAssembly.Trim() + "," + line1.Trim() + "," + strGu;

                        System.Console.WriteLine(str2);
                        allRootfilesItemList.Add(str2);

                    }
                }

                //File.WriteAllLines(@"\\sccxe-scratch\scratch\v-satvin\IES\InternalBinaryList.txt", allRootfilesItemList.ToList());
                File.WriteAllLines(@"C:\Users\v-gikala\source\repos\NugetCleanupTest\NugetCleanupTest\InternalBinaryList.txt", allRootfilesItemList.ToList());
                Console.ReadLine();
            }

        }
    }
}
