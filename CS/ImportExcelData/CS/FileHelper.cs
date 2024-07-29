namespace ImportFromExcel;

public static class FileHelper {
    public static async Task<string> EnsureAssetInAppDataAsync(string fileName) {
        string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);
        if (!File.Exists(targetFile)) {
            await CopyAssetToAppDataAsync(fileName, targetFile);
        }
        return targetFile;

        static async Task CopyAssetToAppDataAsync(string fileName, string targetFile) {
            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(fileName);

            using MemoryStream buf = new();
            fileStream.CopyTo(buf);
            buf.Seek(0, SeekOrigin.Begin);

            using FileStream outputStream = File.OpenWrite(targetFile);
            buf.CopyTo(outputStream);
            outputStream.Flush();
        }
    }
}
