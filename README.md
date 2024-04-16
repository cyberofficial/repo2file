# Repo 2 File
This document provides a brief overview of the File Content Extraction Tool and its functionalities.

# Purpose
The File Content Extraction Tool allows you to extract the contents of multiple text files within a chosen directory and its subdirectories. It then compiles the extracted content into a single output file. Allowing use for easier usage for LLMs sauce as Google's AI, Claud, GPT-4, or Self Hosted, so on.

# Features
- Folder Selection: Choose the root folder containing the text files you want to process.
- File Type Filtering: Filter files by their extensions using the provided list. You can select or deselect specific file extensions to include or exclude them from the extraction process.
- Binary File Detection: Optionally skip binary files to avoid including their contents in the output file.
- Folder Structure Display: View the hierarchy of folders and subfolders within the selected directory.
- File List Preview: See a list of all files within the chosen directory and its subfolders, with the ability to select/deselect files for inclusion in the final output.
- File Content Preview: View the content of any selected file within the tool.
- Output File Generation: Create a single text file containing the contents of all selected files, along with their original file paths.

# Usage
1. Select Folder: Click the "Open Folder" button and choose the directory containing the repo file or folder you wish to compact into a files.
2. Scan Files: Click the "Scan" button to populate the lists of folders, files, and file extensions.
3. Filter Files (Optional): Use the checkboxes in the "File Extensions" list to select or deselect file types. Additionally, use the checkboxes next to folders and files to exclude specific items. Click the "Filter Files" button to apply the filters.
4. Choose Save Location: Click the "Save File Location" button and select the desired path and filename for the output file.
5. Save Extracted Content: Click the "Save" button to generate the output file containing the extracted content.

# Additional Notes
- The tool assumes text files are encoded in UTF-8 format.
- Error handling is implemented to skip files that are inaccessible or in use.
- The tool's interface allows for easy selection and deselection of files and folders.

# Disclaimer
This tool is provided as-is and without any warranty. Use it at your own risk.
