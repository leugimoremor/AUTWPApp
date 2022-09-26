﻿using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Diagnostics;
using Assert = NUnit.Framework.Assert;

namespace FlaUI.Core.UITests
{
    [TestClass]
    public class NotepadTests
    {
        [TestMethod]
        public void NotepadLaunchTest()
        {
            using (var app = Application.Launch("notepad.exe"))
            {
                using (var automation = new UIA3Automation())
                {
                    var window = app.GetMainWindow(automation);
                    Assert.That(window, Is.Not.Null);
                    Assert.That(window.Title, Is.Not.Null);
                }
            }
        }

        [TestMethod]
        public void NotepadAttachByNameTest()
        {
            Application.Launch("notepad.exe");
            using (var app = Application.Attach("notepad.exe"))
            {
                using (var automation = new UIA3Automation())
                {
                    var window = app.GetMainWindow(automation);
                    Assert.That(window, Is.Not.Null);
                    Assert.That(window.Title, Is.Not.Null);
                }
            }
        }

        [TestMethod]
        public void NotepadAttachByProcessIdTest()
        {
            using (var launchedApp = Application.Launch("notepad.exe"))
            {
                using (var app = Application.Attach(launchedApp.ProcessId))
                {
                    using (var automation = new UIA3Automation())
                    {
                        var window = app.GetMainWindow(automation);
                        Assert.That(window, Is.Not.Null);
                        Assert.That(window.Title, Is.Not.Null);
                    }
                }
            }
        }

        [TestCase(@"C:\WINDOWS\system32\notepad.exe")]
        [TestCase("notepad.exe")]
        public void NotepadAttachOrLauchIdTest(string name)
        {
            using (Application.Launch("notepad.exe"))
            {
                using (var app = Application.AttachOrLaunch(new ProcessStartInfo(name)))
                {
                    using (var automation = new UIA3Automation())
                    {
                        var window = app.GetMainWindow(automation);
                        Assert.That(window, Is.Not.Null);
                        Assert.That(window.Title, Is.Not.Null);
                    }
                }
            }
        }

        [TestMethod]
        public void NotepadAttachWithAbsoluteExePath()
        {
            using (Application.Launch("notepad.exe"))
            {
                using (var app = Application.Attach(@"C:\WINDOWS\system32\notepad.exe"))
                {
                    using (var automation = new UIA3Automation())
                    {
                        var window = app.GetMainWindow(automation);
                        Assert.That(window, Is.Not.Null);
                        Assert.That(window.Title, Is.Not.Null);
                    }
                }
            }
        }
    }
}
