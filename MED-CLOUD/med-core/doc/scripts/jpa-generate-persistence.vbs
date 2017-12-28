Const ForReading = 1
Const ForWriting = 2


Set objFSO = CreateObject("Scripting.FileSystemObject")
objStartFolder = "D:\nextop-projects\med-cloud\med-core\src\main\java\nta\med\core\domain"
objOutputFile = "D:\persistence.txt"

Set objTemplateFile = objFSO.OpenTextFile("D:\nextop-projects\med-cloud\med-core\doc\templates\JpaRepository.txt", ForReading)
strText = objTemplateFile.ReadAll
objTemplateFile.Close

Set objFolder = objFSO.GetFolder(objStartFolder)
Set fc = objFolder.SubFolders
Set objOutFile = objFSO.CreateTextFile(objOutputFile, true)
For Each f1 in fc	
	call processFolder(objOutFile, f1.name, strText)    	
Next   
objOutFile.Close

msgbox "Success!"

sub processFolder(objOutFile, folder, strTempateText)
	Set objSubFolder = objFSO.GetFolder(objStartFolder & "\" & folder)
	Set colFiles = objSubFolder.Files
	For Each objFile in colFiles
			objOutFile.WriteLine "<class>nta.med.core.domain." & folder & "." & left(objFile.Name, len(objFile.Name) - 5) & "</class>"
	Next
end sub
