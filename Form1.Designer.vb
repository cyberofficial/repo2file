<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        OpenFolderBtn = New Button()
        FileInputFolder = New TextBox()
        SaveFileLocationBtn = New Button()
        SaveFileName = New TextBox()
        ScanFolderBtn = New Button()
        Label1 = New Label()
        FileExtList = New CheckedListBox()
        FolderSelector = New FolderBrowserDialog()
        SaveBtn = New Button()
        FileListBox = New CheckedListBox()
        Label2 = New Label()
        GroupBox1 = New GroupBox()
        SkipBinaryFileTypes = New CheckBox()
        FilterFiles_EXT = New Button()
        Label3 = New Label()
        InfoText = New Label()
        FolderListBox = New CheckedListBox()
        Label4 = New Label()
        FilePreview = New RichTextBox()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' OpenFolderBtn
        ' 
        OpenFolderBtn.Location = New Point(12, 12)
        OpenFolderBtn.Name = "OpenFolderBtn"
        OpenFolderBtn.Size = New Size(98, 23)
        OpenFolderBtn.TabIndex = 0
        OpenFolderBtn.Text = "Folder"
        OpenFolderBtn.UseVisualStyleBackColor = True
        ' 
        ' FileInputFolder
        ' 
        FileInputFolder.Location = New Point(116, 12)
        FileInputFolder.Name = "FileInputFolder"
        FileInputFolder.Size = New Size(516, 23)
        FileInputFolder.TabIndex = 1
        ' 
        ' SaveFileLocationBtn
        ' 
        SaveFileLocationBtn.Location = New Point(12, 41)
        SaveFileLocationBtn.Name = "SaveFileLocationBtn"
        SaveFileLocationBtn.Size = New Size(98, 23)
        SaveFileLocationBtn.TabIndex = 2
        SaveFileLocationBtn.Text = "Save Location"
        SaveFileLocationBtn.UseVisualStyleBackColor = True
        ' 
        ' SaveFileName
        ' 
        SaveFileName.Location = New Point(116, 41)
        SaveFileName.Name = "SaveFileName"
        SaveFileName.Size = New Size(516, 23)
        SaveFileName.TabIndex = 1
        ' 
        ' ScanFolderBtn
        ' 
        ScanFolderBtn.Location = New Point(638, 11)
        ScanFolderBtn.Name = "ScanFolderBtn"
        ScanFolderBtn.Size = New Size(75, 23)
        ScanFolderBtn.TabIndex = 3
        ScanFolderBtn.Text = "Scan"
        ScanFolderBtn.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 156)
        Label1.Name = "Label1"
        Label1.Size = New Size(270, 15)
        Label1.TabIndex = 5
        Label1.Text = "Detected File Extensions | Click Each Ext You Want"
        ' 
        ' FileExtList
        ' 
        FileExtList.FormattingEnabled = True
        FileExtList.Location = New Point(13, 174)
        FileExtList.MultiColumn = True
        FileExtList.Name = "FileExtList"
        FileExtList.Size = New Size(420, 220)
        FileExtList.Sorted = True
        FileExtList.TabIndex = 7
        ' 
        ' SaveBtn
        ' 
        SaveBtn.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        SaveBtn.Location = New Point(1096, 867)
        SaveBtn.Name = "SaveBtn"
        SaveBtn.Size = New Size(75, 23)
        SaveBtn.TabIndex = 8
        SaveBtn.Text = "Save to File"
        SaveBtn.UseVisualStyleBackColor = True
        ' 
        ' FileListBox
        ' 
        FileListBox.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        FileListBox.FormattingEnabled = True
        FileListBox.HorizontalScrollbar = True
        FileListBox.Location = New Point(13, 469)
        FileListBox.Name = "FileListBox"
        FileListBox.Size = New Size(700, 382)
        FileListBox.TabIndex = 9
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(13, 451)
        Label2.Name = "Label2"
        Label2.Size = New Size(251, 15)
        Label2.TabIndex = 10
        Label2.Text = "File List | Check each file you want to skip over"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(SkipBinaryFileTypes)
        GroupBox1.Location = New Point(439, 71)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(270, 100)
        GroupBox1.TabIndex = 11
        GroupBox1.TabStop = False
        GroupBox1.Text = "Search Params"
        ' 
        ' SkipBinaryFileTypes
        ' 
        SkipBinaryFileTypes.AutoSize = True
        SkipBinaryFileTypes.Location = New Point(6, 22)
        SkipBinaryFileTypes.Name = "SkipBinaryFileTypes"
        SkipBinaryFileTypes.Size = New Size(110, 19)
        SkipBinaryFileTypes.TabIndex = 0
        SkipBinaryFileTypes.Text = "Skip Binary Files"
        SkipBinaryFileTypes.UseVisualStyleBackColor = True
        ' 
        ' FilterFiles_EXT
        ' 
        FilterFiles_EXT.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        FilterFiles_EXT.Location = New Point(13, 861)
        FilterFiles_EXT.Name = "FilterFiles_EXT"
        FilterFiles_EXT.Size = New Size(161, 23)
        FilterFiles_EXT.TabIndex = 12
        FilterFiles_EXT.Text = "Filter out not checked exts"
        FilterFiles_EXT.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(13, 397)
        Label3.Name = "Label3"
        Label3.Size = New Size(34, 15)
        Label3.TabIndex = 14
        Label3.Text = "Info: "
        ' 
        ' InfoText
        ' 
        InfoText.AutoSize = True
        InfoText.Location = New Point(53, 397)
        InfoText.Name = "InfoText"
        InfoText.Size = New Size(22, 15)
        InfoText.TabIndex = 14
        InfoText.Text = "---"
        ' 
        ' FolderListBox
        ' 
        FolderListBox.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        FolderListBox.FormattingEnabled = True
        FolderListBox.HorizontalScrollbar = True
        FolderListBox.Location = New Point(439, 192)
        FolderListBox.Name = "FolderListBox"
        FolderListBox.Size = New Size(733, 274)
        FolderListBox.Sorted = True
        FolderListBox.TabIndex = 15
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(439, 174)
        Label4.Name = "Label4"
        Label4.Size = New Size(188, 15)
        Label4.TabIndex = 16
        Label4.Text = "Check folders you want to remove"
        ' 
        ' FilePreview
        ' 
        FilePreview.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        FilePreview.Location = New Point(719, 469)
        FilePreview.Name = "FilePreview"
        FilePreview.ReadOnly = True
        FilePreview.Size = New Size(447, 386)
        FilePreview.TabIndex = 19
        FilePreview.Text = ""
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1178, 902)
        Controls.Add(FilePreview)
        Controls.Add(Label4)
        Controls.Add(FolderListBox)
        Controls.Add(FilterFiles_EXT)
        Controls.Add(InfoText)
        Controls.Add(Label3)
        Controls.Add(GroupBox1)
        Controls.Add(Label2)
        Controls.Add(FileListBox)
        Controls.Add(SaveBtn)
        Controls.Add(FileExtList)
        Controls.Add(Label1)
        Controls.Add(ScanFolderBtn)
        Controls.Add(SaveFileLocationBtn)
        Controls.Add(SaveFileName)
        Controls.Add(FileInputFolder)
        Controls.Add(OpenFolderBtn)
        MinimumSize = New Size(1194, 941)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents OpenFolderBtn As Button
    Friend WithEvents FileInputFolder As TextBox
    Friend WithEvents SaveFileLocationBtn As Button
    Friend WithEvents SaveFileName As TextBox
    Friend WithEvents ScanFolderBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents FileExtList As CheckedListBox
    Friend WithEvents FolderSelector As FolderBrowserDialog
    Friend WithEvents SaveBtn As Button
    Friend WithEvents FileListBox As CheckedListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents SkipBinaryFileTypes As CheckBox
    Friend WithEvents FilterFiles_EXT As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents InfoText As Label
    Friend WithEvents FolderListBox As CheckedListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents FilePreview As RichTextBox

End Class
