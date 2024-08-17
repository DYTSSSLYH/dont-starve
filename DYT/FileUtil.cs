using System;
using System.Collections.Generic;

namespace DYT
{
    public static class FileUtil
    {
        public static void CheckFiles(Action<Dictionary<string, bool>> cb, List<string> files)
        {
            if (files == null && cb != null) cb(null);

            Dictionary<string, bool> file_status = new Dictionary<string, bool>();

            for (int i = 0; i < files.Count; i++)
            {
                TheSim.CheckPersistentStringExists(files[i], exists =>
                {
                    file_status.Add(files[i], exists);

                    if (i == files.Count - 1 && cb != null) cb(file_status);
                });
            }
        }
    }
}