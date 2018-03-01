using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CreateBISoaSolutionStructure
{
	internal class Program
	{
		private const string
			API_SECTION = "Api.",
			CORE_SECTION = "Core.",
			DTO_SECTION = "Dto.",
			MANAGER_SECTION = "Manager.",
			NUGET_SECTION = "nuget.",
			QUEUE_SECTION = "QueueConsumer.",
			QUEUE_INSTALLER_SECTION = "QueueConsumerInstaller.",
			REPOSITORY_SECTION = "Repository.",
			REPOSITORY_MANAGER_SECTION = "RepositoryManager.",
			SOLUTION_SECTION = "Solution.",
			UNIT_TEST_SECTION = "UnitTest.",
			VIEWMODELS_SECTION = "ViewModels.";

		private const string
			TEMPLATE = "Template",
			LIBLOGFOLDER = "LibLog.4.2",
			LIBLOGFOLDERRESOURCE = "LibLog._4._2",
			LIBLOGREPLACEFOLDER = "LibLog_4_2",
			SERVICEBUS_NAMESPACE = "BI.ServiceBus.";

		private static Assembly _assembly = Assembly.GetExecutingAssembly();

		private static string _domainName;
		private static string _friendlyDomainName;
		private static IEnumerable<ResourceInfo> _resources;

		private static string[] _sections;

		public static string AssemblyDirectory
		{
			get
			{
				string codeBase = Assembly.GetExecutingAssembly().CodeBase;
				UriBuilder uri = new UriBuilder(codeBase);
				string path = Uri.UnescapeDataString(uri.Path);
				return Path.GetDirectoryName(path);
			}
		}

		private static void Main(string[] args)
		{
			try
			{
#if DEBUG
				args = new[] { "/c", "EntityAddress", "Entity Address" };
				//args = new[] { "/d", "EntityAddress" };
#endif
				if ((args?.Length ?? 0) < 2)
				{
					DisplayHelp();
					return;
				}
				var cmd = (args[0] ?? string.Empty).ToLower();
				if (cmd != "/c" && cmd != "/d")
				{
					DisplayHelp();
					return;
				}
				_domainName = args[1];
				if (_domainName.IndexOf(' ') >= 0)
				{
					Console.WriteLine("The domain name should not have any spaces.");
					return;
				}
				_friendlyDomainName = _domainName;
				if (args.Length > 2)
					_friendlyDomainName = args[2];

				_resources = _assembly.GetManifestResourceNames().Select(x => new ResourceInfo
				{
					FullResource = x,
					Resource = x.Replace("CreateBISoaSolutionStructure.ContentFiles.", "")
				});
				_sections = new[] {
					API_SECTION,
					CORE_SECTION,
					DTO_SECTION,
					MANAGER_SECTION,
					QUEUE_SECTION,
					QUEUE_INSTALLER_SECTION,
					REPOSITORY_SECTION,
					REPOSITORY_MANAGER_SECTION,
					UNIT_TEST_SECTION,
					VIEWMODELS_SECTION
				};
				if (cmd == "/c")
					CreateSoaStructure();
				else
					DeleteSoaStructure();
			}
			catch (Exception ex)
			{
				Console.Write(ex.Message);
			}
#if DEBUG
			finally
			{
				Console.ReadLine();
			}
#endif
		}

		#region Private Methods

		private static bool IsStructureInUse()
		{
			var domainPath = $@"{AssemblyDirectory}\{_domainName}\Main_{_domainName}";
			if (Directory.Exists(domainPath))
			{
				Console.WriteLine();
				Console.WriteLine($"WARNING: The domain \"{_domainName}\" already exists!!!");
				Console.WriteLine("Please clear the existing domain or create a new one with a different name.");
				return true;
			}
			return false;
		}

		private static void ClearDirectory(DirectoryInfo dInfo)
		{
			foreach (var f in dInfo.GetFiles())
				f.Delete();
			var di = dInfo.GetDirectories();
			if (di.Length > 0)
				foreach (var d in di)
					ClearDirectory(d);
			dInfo.Delete();
		}

		private static void CreateSoaStructure()
		{
			if (IsStructureInUse())
				return;
			WriteSolution();
			WriteNuget();
			foreach (var sec in _sections)
			{
				var sectionAndProj = GetInitialSectionAndProjectName(sec);
				var initialSection = sectionAndProj.Item1;
				var projectName = sectionAndProj.Item2;

				WriteProject(projectName, initialSection);
			}
			Console.WriteLine("	SOA domain structure successfully created.");
		}

		private static void DeleteSoaStructure()
		{
			var domainFolder = $@"{AssemblyDirectory}\{_domainName}";
			if (!Directory.Exists(domainFolder))
			{
				Console.WriteLine("The specified SOA domain doesn't exists in the current folder.");
				return;
			}
			var di = new DirectoryInfo(domainFolder);
			ClearDirectory(di);
			Console.WriteLine("	SOA domain structure successfully deleted.");
		}

		private static void DisplayHelp()
		{
			Console.WriteLine("-	To create a new solution structure.");
			Console.WriteLine("	/c DomainName \"Friendly Domain Name\"[optional]");
			Console.WriteLine();
			Console.WriteLine("-	To delete a solution structure");
			Console.WriteLine("	/d DomainName");
			Console.WriteLine();
			Console.WriteLine("	WARNING: These two commands are final. If you delete");
			Console.WriteLine("	a solution structure that has not been backed-up");
			Console.WriteLine("	you will not be able to recover it.");
		}

		private static Tuple<string, string> GetInitialSectionAndProjectName(string section)
		{
			var initialSection = string.Empty;
			var projectName = string.Empty;
			switch (section)
			{
				case API_SECTION:
					initialSection = API_SECTION;
					projectName = $"BI.WebApi.{_domainName}";
					break;
				case CORE_SECTION:
					initialSection = CORE_SECTION;
					projectName = $"{SERVICEBUS_NAMESPACE}Core.{_domainName}";
					break;
				case DTO_SECTION:
					initialSection = DTO_SECTION;
					projectName = $"BI.Enterprise.Dto.{_domainName}";
					break;
				case MANAGER_SECTION:
					initialSection = MANAGER_SECTION;
					projectName = $"{SERVICEBUS_NAMESPACE}Manager.{_domainName}";
					break;
				case QUEUE_SECTION:
					initialSection = QUEUE_SECTION;
					projectName = $"BI.QueueConsumer.{_domainName}";
					break;
				case QUEUE_INSTALLER_SECTION:
					initialSection = QUEUE_INSTALLER_SECTION;
					projectName = $"BI.QueueConsumer.{_domainName}.Wix";
					break;
				case REPOSITORY_SECTION:
					initialSection = REPOSITORY_SECTION;
					projectName = $"BI.Repository.{_domainName}";
					break;
				case REPOSITORY_MANAGER_SECTION:
					initialSection = REPOSITORY_MANAGER_SECTION;
					projectName = $"{SERVICEBUS_NAMESPACE}Repository.{_domainName}";
					break;
				case UNIT_TEST_SECTION:
					initialSection = UNIT_TEST_SECTION;
					projectName = $"BI.ServiceBus.Core.{_domainName}.Test";
					break;
				case VIEWMODELS_SECTION:
					initialSection = VIEWMODELS_SECTION;
					projectName = $"BI.Enterprise.ViewModels.{_domainName}";
					break;
			}
			return new Tuple<string, string>(initialSection, projectName);
		}

		//private static bool ProjectExists(string section)
		//{
		//	var sectionAndProj = GetInitialSectionAndProjectName(section);
		//	var projectName = sectionAndProj.Item2;
		//	var projectDirectoryName = $@"{AssemblyDirectory}\{_domainName}\Main_{_domainName}\{projectName}";
		//	return Directory.Exists(projectDirectoryName);
		//}

		private static void WriteProject(string projectName, string initialSection)
		{
			var files = _resources.Where(x => x.Resource.StartsWith(initialSection)).ToArray();
			var domainPath = $@"{AssemblyDirectory}\{_domainName}\Main_{_domainName}";
			var projectDirectoryName = $@"{domainPath}\{projectName}";
			Directory.CreateDirectory(projectDirectoryName);
			foreach (var f in files)
				f.Resource = f.Resource.Substring(initialSection.Length);
			string fullFileName;
			string content;
			var specialFiles = files.Where(x =>
				x.Resource.Contains("csproj") || x.Resource.Contains("asax.cs") || x.Resource.Contains("fakes") ||
				x.Resource.Contains("designer.cs") || x.Resource.Contains("wixproj") || x.Resource.Contains("Debug.config") ||
				x.Resource.Contains("Release.config"));
			foreach (var f in specialFiles)
			{
				if (f.Resource.Contains("fakes"))
				{
					Directory.CreateDirectory($@"{projectDirectoryName}\Fakes");
					fullFileName = $@"{projectDirectoryName}\Fakes\{f.Resource.Remove(0, 6).Replace(TEMPLATE, _domainName)}";
				}
				else
					fullFileName = $@"{projectDirectoryName}\{f.Resource.Replace(TEMPLATE, _domainName)}";
				File.Create(fullFileName).Close();
				using (var sr = new StreamReader(_assembly.GetManifestResourceStream(f.FullResource)))
				{
					content = sr.ReadToEnd().Replace(TEMPLATE, _domainName);
					File.WriteAllText(fullFileName, content);
				}
			}
			var regularFiles = files.Where(x =>
				!x.Resource.Contains("csproj") && !x.Resource.Contains("asax.cs") && !x.Resource.Contains("fakes") &&
				!x.Resource.Contains("designer.cs") && !x.Resource.Contains("wixproj") && !x.Resource.Contains("Debug.config") &&
				!x.Resource.Contains("Release.config"));
			foreach (var f in regularFiles)
			{
				var resource = f.Resource.Replace(LIBLOGFOLDERRESOURCE, LIBLOGREPLACEFOLDER);
				var folders = resource.Split('.');
				var tmpDirectory = projectDirectoryName;
				if (folders.Length > 2)
					for (var i = 0; i < folders.Length - 2; i++)
					{
						tmpDirectory += $@"\{folders[i].Replace(LIBLOGREPLACEFOLDER, LIBLOGFOLDER)}";
						Directory.CreateDirectory(tmpDirectory);
					}
				var fileName = folders[folders.Length - 2];
				if (fileName == "Skip")
					continue;
				var extension = folders[folders.Length - 1];
				if (extension == "resx1")
					extension = "resx";
				if (extension == "resources")
					extension = "resx";
				fullFileName = $@"{tmpDirectory}\{fileName}.{extension}".Replace(TEMPLATE, _domainName);
				File.Create(fullFileName).Close();
				using (var sr = new StreamReader(_assembly.GetManifestResourceStream(f.FullResource)))
				{
					if (extension == "html")
						content = sr.ReadToEnd().Replace(TEMPLATE, _friendlyDomainName);
					else
						content = sr.ReadToEnd().Replace(TEMPLATE, _domainName);
					File.WriteAllText(fullFileName, content);
				}
			}
		}

		private static void WriteSolution()
		{
			var solution = _resources.FirstOrDefault(x => x.Resource.StartsWith(SOLUTION_SECTION));
			var solutionName = solution.Resource.Replace(SOLUTION_SECTION, "").Replace(TEMPLATE, _domainName);
			var domainPath = $@"{AssemblyDirectory}\{_domainName}\Main_{_domainName}";
			Directory.CreateDirectory(domainPath);
			var solPath = $@"{domainPath}\{solutionName}";
			File.Create(solPath).Close();
			using (var sr = new StreamReader(_assembly.GetManifestResourceStream(solution.FullResource)))
			{
				var content = sr.ReadToEnd().Replace(TEMPLATE, _domainName);
				File.WriteAllText(solPath, content);
			}
		}

		private static void WriteNuget()
		{
			var nugetPath = $@"{AssemblyDirectory}\{_domainName}\Main_{_domainName}\.nuget";
			Directory.CreateDirectory(nugetPath);
			foreach (var r in _resources.Where(x => x.Resource.StartsWith(NUGET_SECTION)))
			{
				var fileName = $@"{nugetPath}\{r.Resource.Replace(NUGET_SECTION, "")}";
				File.Create(fileName).Close();
				using (var sr = new StreamReader(_assembly.GetManifestResourceStream(r.FullResource)))
				{
					var content = sr.ReadToEnd();
					File.WriteAllText(fileName, content);
				}
			}
		}

		#endregion

		#region Support Classes

		public class ResourceInfo
		{
			public string FullResource { get; set; }
			public string Resource { get; set; }
		}

		#endregion
	}
}