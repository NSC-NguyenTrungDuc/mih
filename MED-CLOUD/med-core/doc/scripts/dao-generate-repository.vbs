Const ForReading = 1
Const ForWriting = 2


Set objFSO = CreateObject("Scripting.FileSystemObject")
objStartFolder = "D:\nextop-projects\med-cloud\med-core\src\main\java\nta\med\core\domain"
objEndFolder = "D:\nextop-projects\med-cloud\med-data\src\main\java\nta\med\data\dao\medi"

Set objTemplateFile = objFSO.OpenTextFile("D:\nextop-projects\med-cloud\med-core\doc\templates\JpaRepository.txt", ForReading)
strText = objTemplateFile.ReadAll
objTemplateFile.Close

Set objFolder = objFSO.GetFolder(objStartFolder)
Set fc = objFolder.SubFolders
For Each f1 in fc
	call processFolder(f1.name, strText)    
Next   

msgbox "Success!"

sub processFolder(folder, strTempateText)
	Set objSubFolder = objFSO.GetFolder(objStartFolder & "\" & folder)
	Set colFiles = objSubFolder.Files
	For Each objFile in colFiles
	    call saveFile(objFile.Name, folder, strTempateText)
	Next
end sub

Sub saveFile(destFileName, folder, strTempateText)
	strClassName = left(destFileName, len(destFileName) - 5)
	strFinalName = strClassName & "Repository.java"
	strNewText = Replace(strTempateText, "{folder}", folder)	
	strNewText = Replace(strNewText, "{entity}", strClassName)	
	'Set objFile = objFSO.OpenTextFile(objEndFolder & "\" & folder & "\" & strFinalName, ForWriting)
	'msgbox objEndFolder & "\" & folder & "\" & strFinalName
	Set objFile = objFSO.CreateTextFile(objEndFolder & "\" & folder & "\" & strFinalName, true)	
	objFile.WriteLine strNewText
	objFile.Close
end sub	