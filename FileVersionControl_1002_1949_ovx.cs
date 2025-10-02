// 代码生成时间: 2025-10-02 19:49:51
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FileVersionControlSystem
{
    public class FileVersionControl
    {
        // Dictionary to store file versions, where the key is the file identifier and the value is a list of versions.
        private Dictionary<string, List<string>> fileVersions = new Dictionary<string, List<string>>();

        // Adds a new version of a file to the system.
        // If the file does not exist, it will be created with this version as the initial version.
        public void AddFileVersion(string fileId, string versionContent)
        {
            if (string.IsNullOrEmpty(fileId))
            {
                Debug.LogError("File identifier cannot be null or empty.");
                return;
            }

            if (fileVersions.ContainsKey(fileId))
            {
                fileVersions[fileId].Add(versionContent);
            }
            else
            {
                fileVersions.Add(fileId, new List<string> { versionContent });
            }
        }

        // Retrieves a specific version of a file.
        // If the file or version does not exist, it returns null.
        public string GetFileVersion(string fileId, int versionNumber)
        {
            if (!fileVersions.ContainsKey(fileId) || fileVersions[fileId].Count <= versionNumber)
            {
                Debug.LogError("File or version not found.");
                return null;
            }

            return fileVersions[fileId][versionNumber];
        }

        // Gets the list of all versions for a specific file.
        // If the file does not exist, it returns an empty list.
        public List<string> GetAllFileVersions(string fileId)
        {
            if (fileVersions.ContainsKey(fileId))
            {
                return new List<string>(fileVersions[fileId]);
            }
            else
            {
                Debug.LogError("File not found.");
                return new List<string>();
            }
        }

        // Displays the contents of the file version system for debugging purposes.
        public void DebugDisplayFileVersions()
        {
            foreach (var file in fileVersions)
            {
                Debug.Log($"File: {file.Key}, Versions: {string.Join("=>", file.Value)}");
            }
        }
    }
}
