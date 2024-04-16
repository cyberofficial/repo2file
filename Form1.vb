Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.IO.Compression

Public Class Form1

    ' Define constants for the IsTextUnicode function
    Private Const IS_TEXT_UNICODE_STATISTICS As Integer = &H2
    Private Const IS_TEXT_UNICODE_CONTROLS As Integer = &H4
    Private Const IS_TEXT_UNICODE_SIGNATURE As Integer = &H8
    Private Const IS_TEXT_UNICODE_REVERSE_SIGNATURE As Integer = &H10
    Private Const IS_TEXT_UNICODE_REVERSE_STATISTICS As Integer = &H20
    Private Const IS_TEXT_UNICODE_REVERSE_CONTROLS As Integer = &H40
    Private Const IS_TEXT_UNICODE_ILLEGAL_CHARS As Integer = &H10000
    Private Const IS_TEXT_UNICODE_ODD_LENGTH As Integer = &H20000
    Private Const IS_TEXT_UNICODE_NULL_BYTES As Integer = &H40000
    Private Const IS_TEXT_UNICODE_UNICODE_MASK As Integer = &HF
    Private Const IS_TEXT_UNICODE_REVERSE_MASK As Integer = &H70
    Private Const IS_TEXT_UNICODE_NOT_UNICODE_MASK As Integer = &HF0000

    ' Import the IsTextUnicode function from kernel32.dll
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function IsTextUnicode(
        <[In], MarshalAs(UnmanagedType.LPArray)> ByVal lpBuffer As Byte(),
        ByVal cb As Integer,
        ByRef lpi As Integer
    ) As Boolean
    End Function

    Private Sub OpenFolderBtn_Click(sender As Object, e As EventArgs) Handles OpenFolderBtn.Click
        FolderSelector.ShowDialog()
        Try
            FileInputFolder.Text = FolderSelector.SelectedPath
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ScanFolderBtn_Click(sender As Object, e As EventArgs) Handles ScanFolderBtn.Click
        ' Check if folder path is provided
        Dim Counter As Integer = 0
        If Not String.IsNullOrEmpty(FileInputFolder.Text) Then
            Dim dirInfo As New DirectoryInfo(FileInputFolder.Text)

            ' Clear existing items from FolderListBox and FileListBox
            FileExtList.Items.Clear()
            FolderListBox.Items.Clear()
            FileListBox.Items.Clear()

            ' Add the root folder to the FolderListBox
            FolderListBox.Items.Add(dirInfo.FullName)

            ' Get all directories in the directory and its subdirectories
            Dim allDirectories As IEnumerable(Of DirectoryInfo) = dirInfo.EnumerateDirectories("*", SearchOption.AllDirectories)

            ' Add all subfolders to the FolderListBox
            For Each directoryEntry As DirectoryInfo In allDirectories
                FolderListBox.Items.Add(directoryEntry.FullName)
            Next

            ' Get all files in the directory and its subdirectories
            Dim fileEntries As FileInfo() = dirInfo.GetFiles("*.*", SearchOption.AllDirectories)

            ' Determine if SkipBinaryFileTypes checkbox is checked
            Dim skipBinaryFileTypesChecked As Boolean = SkipBinaryFileTypes.Checked

            For Each fileEntry As FileInfo In fileEntries
                ' Check if the file is binary
                If IsBinaryFile(fileEntry.FullName, skipBinaryFileTypesChecked) Then
                    Continue For ' Skip binary files
                End If

                ' Get the extension of each file (including the '.') and add it to the list if not already present
                Dim ext = fileEntry.Extension.ToLowerInvariant()
                If Not FileExtList.Items.Contains(ext) Then
                    FileExtList.Items.Add(ext)
                End If

                ' Add the file to the FileListBox
                FileListBox.Items.Add(fileEntry.FullName)
            Next
            InfoText.Text = $"Found {FolderListBox.Items.Count} folders and {FileListBox.Items.Count} files."
        Else
            MessageBox.Show("Please select a folder first.")
        End If
    End Sub


    Private Function IsBinaryFile(filePath As String, skipBinaryFileTypesChecked As Boolean) As Boolean
        If skipBinaryFileTypesChecked Then
            Try
                ' Read the first few bytes of the file to determine if it's binary
                Dim bufferSize As Integer = 1024
                Dim buffer(bufferSize - 1) As Byte

                Using fileStream As New FileStream(filePath, FileMode.Open, FileAccess.Read)
                    Dim bytesRead As Integer = fileStream.Read(buffer, 0, bufferSize)

                    ' Check for non-printable characters
                    For i As Integer = 0 To bytesRead - 1
                        If buffer(i) < 32 AndAlso buffer(i) <> 9 AndAlso buffer(i) <> 10 AndAlso buffer(i) <> 13 Then
                            Return True ' Contains non-printable characters, likely binary
                        End If
                    Next
                End Using

                ' If no non-printable characters are found, assume it's text
                Return False
            Catch ex As IOException
                ' If the file is in use, skip it and treat it as binary
                Return True
            End Try
        Else
            ' If SkipBinaryFileTypes is not checked, assume all files are text
            Return False
        End If
    End Function


    Private Sub FileExtList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FileExtList.SelectedIndexChanged

    End Sub
    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        Dim Counter As Integer = 0
        ' Check if folder path and save file location are provided
        If Not String.IsNullOrEmpty(FileInputFolder.Text) AndAlso Not String.IsNullOrEmpty(SaveFileName.Text) Then
            ' Create a list to store file paths
            Dim fileList As New List(Of String)

            ' Build the list of files based on the selected items in FileListBox that are not checked
            For Each filePath As String In FileListBox.Items
                If Not FileListBox.CheckedItems.Contains(filePath) Then
                    fileList.Add(filePath)
                End If
            Next

            ' Get the count of selected files
            Dim writtenFileCount As Integer = fileList.Count

            ' Open the output file in write mode
            Using writer As StreamWriter = File.CreateText(SaveFileName.Text)
                For Each filePath As String In fileList
                    Try
                        ' Attempt to read the file's contents
                        Using reader As New StreamReader(filePath)
                            ' Write the file path to the output file
                            writer.WriteLine($"Exact file location: {filePath}")
                            writer.WriteLine("```") ' Start of code block
                            ' Read the contents of the file and write them to the output file
                            writer.WriteLine(reader.ReadToEnd())
                            writer.WriteLine("```") ' End of code block
                            writer.WriteLine() ' Add an empty line to separate file contents
                        End Using
                        Counter = Counter + 1
                        InfoText.Text = $"Wrote {Counter} of {FileListBox.Items.Count} files."
                    Catch ex As Exception
                        ' If the file is in use or inaccessible, skip it and continue with the next file
                        Continue For
                    End Try
                Next
            End Using
            InfoText.Text = $"Wrote {Counter} of {FileListBox.Items.Count} files."
        Else
            MessageBox.Show("Please select a folder and provide a save location first.")
        End If
    End Sub

    Private Sub SaveFileLocationBtn_Click(sender As Object, e As EventArgs) Handles SaveFileLocationBtn.Click
        FolderSelector.ShowDialog()
        SaveFileName.Text = FolderSelector.SelectedPath + "\changeme.txt"
    End Sub
    Private Sub FilterFiles_EXT_Click(sender As Object, e As EventArgs) Handles FilterFiles_EXT.Click
        ' Create a list to store selected file extensions
        Dim selectedExtensions As New List(Of String)

        ' Add selected file extensions from FileExtList to the list
        For Each selectedItem As String In FileExtList.CheckedItems
            selectedExtensions.Add(selectedItem)
        Next

        ' Create a list to store selected folders
        Dim selectedFolders As New List(Of String)

        ' Add selected folders from FolderListBox to the list
        For Each selectedItemIndex As Integer In FolderListBox.CheckedIndices
            selectedFolders.Add(FolderListBox.Items(selectedItemIndex).ToString())
        Next

        ' Create a list to store file paths to be removed
        Dim filesToRemove As New List(Of String)

        ' Create a list to store folders to be removed
        Dim foldersToRemove As New List(Of String)

        ' Iterate through the items in FileListBox
        For Each filePath As String In FileListBox.Items
            ' Get the file extension of the current file
            Dim fileExtension As String = Path.GetExtension(filePath).ToLowerInvariant()

            ' Check if the file extension is not selected in FileExtList
            If Not selectedExtensions.Contains(fileExtension) Then
                ' Add the file to the list to be removed
                filesToRemove.Add(filePath)
            Else
                ' Get the parent directory of the file
                Dim fileParentDirectory As String = Path.GetDirectoryName(filePath)

                ' Check if any selected folder is a parent directory of the file
                For Each selectedFolder As String In selectedFolders
                    If fileParentDirectory.Equals(selectedFolder, StringComparison.OrdinalIgnoreCase) OrElse
   fileParentDirectory.StartsWith(selectedFolder & Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase) Then
                        ' If the file's parent directory matches or starts with the selected folder, remove the file
                        filesToRemove.Add(filePath)
                        Exit For
                    End If
                Next
            End If
        Next

        ' Remove the files from FileListBox
        For Each fileName As String In filesToRemove
            FileListBox.Items.Remove(fileName)
        Next

        ' Iterate through the items in FolderListBox
        For Each folderPath As String In FolderListBox.Items.Cast(Of String)().ToList() ' Convert to List to avoid modifying collection while iterating
            ' Check if the folder is still present in FileListBox
            If Not FileListBox.Items.Cast(Of String)().Any(Function(filePath) filePath.StartsWith(folderPath & Path.DirectorySeparatorChar)) Then
                ' If the folder is not present in FileListBox, remove it
                foldersToRemove.Add(folderPath)
            End If
        Next

        ' Remove selected folders from FolderListBox
        For Each folderName As String In foldersToRemove
            FolderListBox.Items.Remove(folderName)
        Next

        InfoText.Text = $"Reduced to {FileListBox.Items.Count} files."
    End Sub

    Private Sub DL_GH_REPO_Click(sender As Object, e As EventArgs) Handles DL_GH_REPO.Click
        ' Check if URL_txtbox is not empty
        If Not String.IsNullOrEmpty(URL_txtbox.Text) Then
            ' Get the URL from the textbox
            Dim url As String = URL_txtbox.Text.Trim()

            ' Check if the URL is a GitHub repository
            If url.StartsWith("https://github.com/") Then
                ' Extract the repository name
                Dim repoName As String = url.Split("/"c).Last()

                ' Check if the URL ends with "tree/"
                If url.EndsWith("tree/") Then
                    ' Append "master" to the URL
                    url &= "master"
                End If

                ' Convert the URL to the archive URL
                Dim archiveUrl As String = url.Replace("/tree/", "/archive/refs/heads/") & ".zip"

                ' Get the directory path where the zip file will be saved
                Dim zipDirectory As String = Path.Combine(Application.StartupPath, "repos")

                ' Create the directory if it doesn't exist
                If Not Directory.Exists(zipDirectory) Then
                    Directory.CreateDirectory(zipDirectory)
                End If

                ' Specify the path for saving the zip file
                Dim zipFileName As String = Path.Combine(zipDirectory, $"{repoName}.zip")

                ' Download the zip file
                Try
                    Dim client As New WebClient()
                    client.DownloadFile(archiveUrl, zipFileName)

                    ' Extract the zip file
                    Dim extractPath As String = Path.Combine(Application.StartupPath, "repos", repoName & "-master")
                    ZipFile.ExtractToDirectory(zipFileName, extractPath)

                    ' Set the FileInputFolder to the extracted folder
                    FileInputFolder.Text = extractPath
                    SaveFileName.Text = extractPath & "\repo.txt"

                    ' Inform the user about the successful download and extraction
                    MessageBox.Show("GitHub repository downloaded and extracted successfully.")
                Catch ex As Exception
                    MessageBox.Show($"An error occurred while downloading or extracting the GitHub repository: {ex.Message}")
                End Try
            Else
                MessageBox.Show("Invalid GitHub repository URL.")
            End If
        Else
            MessageBox.Show("Please enter a GitHub repository URL.")
        End If
    End Sub

    Private Sub FileListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FileListBox.SelectedIndexChanged
        ' Check if any item is selected in the FileListBox
        If FileListBox.SelectedIndex <> -1 Then
            Try
                ' Get the path of the selected file
                Dim filePath As String = FileListBox.SelectedItem.ToString()

                ' Read the contents of the file
                Dim fileContents As String = File.ReadAllText(filePath)

                ' Display the contents in the FilePreview RichTextBox
                FilePreview.Text = fileContents
            Catch ex As Exception
                ' Handle any errors that may occur while reading the file
                MessageBox.Show($"Error loading file: {ex.Message}")
            End Try
        End If
    End Sub

End Class
