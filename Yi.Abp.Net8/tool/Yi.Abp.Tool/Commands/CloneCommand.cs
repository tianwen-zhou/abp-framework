﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.CommandLineUtils;

namespace Yi.Abp.Tool.Commands
{
    public class CloneCommand : ICommand
    {
        private const string CloneAddress= "https://gitee.com/ccnetcore/Yi";

        
        public string Command => "clone";
        public string? Description => "克隆最新YiFramework源代码，需依赖git";

        public void CommandLineApplication(CommandLineApplication application)
        {
            application.OnExecute(() =>
            {
                StartCmd($"git clone {CloneAddress}");
                return 0;
            });
        }
        
        
        /// <summary>
        /// 执行cmd命令
        /// </summary>
        /// <param name="cmdCommands"></param>
        private void StartCmd(params string[] cmdCommands)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c chcp 65001&{string.Join("&", cmdCommands)}",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            Process proc = new Process
            {
                StartInfo = psi
            };

            proc.Start();
            string output = proc.StandardOutput.ReadToEnd();
            Console.WriteLine(output);

            proc.WaitForExit();
        }
    }
}
