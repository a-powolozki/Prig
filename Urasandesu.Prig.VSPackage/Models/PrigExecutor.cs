﻿/* 
 * File: PrigExecutor.cs
 * 
 * Author: Akira Sugiura (urasandesu@gmail.com)
 * 
 * 
 * Copyright (c) 2015 Akira Sugiura
 *  
 *  This software is MIT License.
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in
 *  all copies or substantial portions of the Software.
 *  
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 *  THE SOFTWARE.
 */



using Microsoft.Practices.Unity;

namespace Urasandesu.Prig.VSPackage.Models
{
    class PrigExecutor : ProcessExecutor, IPrigExecutor
    {
        [Dependency]
        public IEnvironmentRepository EnvironmentRepository { private get; set; }

        public string StartInstalling(string name, string source)
        {
            var prig = EnvironmentRepository.GetPrigPath();
            var args = string.Format("install \"{0}\" -source \"{1}\"", name, source);
            return StartProcessWithoutShell(prig, args, p => p.StandardOutput.ReadToEnd());
        }

        public string StartUninstalling(string name)
        {
            var prig = EnvironmentRepository.GetPrigPath();
            var args = string.Format("uninstall \"{0}\"", name);
            return StartProcessWithoutShell(prig, args, p => p.StandardOutput.ReadToEnd());
        }

        public string StartUpdatingDelegate(string @delegate)
        {
            var prig = EnvironmentRepository.GetPrigPath();
            var args = string.Format("update All -delegate \"{0}\"", @delegate);
            return StartProcessWithoutShell(prig, args, p => p.StandardOutput.ReadToEnd());
        }
    }
}
