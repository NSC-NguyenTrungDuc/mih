using System;
using System.Windows.Forms;
using System.IO;
using IWshRuntimeLibrary;

namespace IHIS
{
	/// <summary>
	/// Summary description for ShellLink.
	/// </summary>
	public class ShellLink
	{
		/// <summary>
		/// Check to see if a shortcut exists in a given directory with a specified file name
		/// </summary>
		/// <param name="DirectoryPath">The directory in which to look</param>
		/// <param name="FullPathName">The name of the shortcut (without the .lnk extension) or the full path to a file of the same name</param>
		/// <returns>Returns true if the link exists</returns>
		public static bool Exists(string DirectoryPath, string linkPathName)
		{
			// Get some file and directory information
			DirectoryInfo SpecialDir=new DirectoryInfo(DirectoryPath);
			// First get the filename for the original file and create a new file
			// name for a link in the Startup directory
			//
			FileInfo originalfile = new FileInfo(linkPathName);
			string NewFileName = SpecialDir.FullName+"\\"+originalfile.Name+".lnk";
			FileInfo linkfile = new FileInfo(NewFileName);
			return linkfile.Exists;
		}
		
		//Check to see if a shell link exists to the given path in the specified special folder
		// return true if it exists
		public static bool Exists(Environment.SpecialFolder folder, string linkPathName)
		{
			return Exists(Environment.GetFolderPath(folder), linkPathName);
		}
		
		/// <summary>
		/// Update the specified folder by creating or deleting a Shell Link if necessary
		/// </summary>
		/// <param name="folder">A SpecialFolder in which the link will reside</param>
		/// <param name="targetPathName">The path name of the target file for the link</param>
		/// <param name="linkPathName">The file name for the link itself or, if a path name the directory information will be ignored.</param>
		/// <param name="args"> link에 전달할 argument </param>
		/// <param name="description"> link의 Description입니다. </param>
		/// <param name="Create">If true, create the link, otherwise delete it</param>
		public static void Update(Environment.SpecialFolder folder, string targetPathName, string linkPathName, string args , string description, string iconFileName, bool create)
		{
			// Get some file and directory information
			Update(Environment.GetFolderPath(folder), targetPathName, linkPathName, args, description, iconFileName, create);
		}
			
		/// <summary>
		/// Update the specified folder by creating or deleting a Shell Link if necessary
		/// </summary>
		/// <param name="directoryPath">The full path of the directory in which the link will reside</param>
		/// <param name="targetPathName">The path name of the target file for the link</param>
		/// <param name="linkPathName">The file name for the link itself or, if a path name the directory information will be ignored.</param>
		/// <param name="args"> link에 전달할 argument </param>
		/// <param name="description"> link의 Description입니다. </param>
		/// <param name="create">If true, create the link, otherwise delete it</param>
		public static void Update(string DirectoryPath, string targetPathName, string linkPathName, string args, string description, string iconFileName, bool Create)
		{
			// Get some file and directory information
			DirectoryInfo SpecialDir=new DirectoryInfo(DirectoryPath);
			// First get the filename for the original file and create a new file
			// name for a link in the Startup directory
			//
			FileInfo OriginalFile = new FileInfo(linkPathName);
			string NewFileName = SpecialDir.FullName+"\\"+OriginalFile.Name+".lnk";
			FileInfo LinkFile = new FileInfo(NewFileName);

			if(Create) // If the link doesn't exist, create it
			{
				//if(LinkFile.Exists) return; // We're all done if it already exists
				//기존 LinkFile 제거
				if (LinkFile.Exists)
					LinkFile.Delete();
				//Place a shortcut to the file in the special folder 
				try 
				{ 
					// Create a shortcut in the special folder for the file
					// Making use of the Windows Scripting Host
					WshShell shell = new WshShell();
					IWshShortcut link = (IWshShortcut)shell.CreateShortcut(LinkFile.FullName);
					
					link.TargetPath=targetPathName;
					link.Arguments = args;
					link.Description = description;
					link.IconLocation = iconFileName;
					link.Save();
				}
				catch 
				{
					MessageBox.Show("Unable to create link in special directory: " + NewFileName,
						"Shell Link Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
			}
			else // otherwise delete it from the startup directory
			{
				if(!LinkFile.Exists)return; // It doesn't exist so we are done!
				try
				{
					LinkFile.Delete();
				}
				catch
				{
					MessageBox.Show("Error deleting link in special directory: "+NewFileName,
						"Shell Link Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
			}
		}

	}
}