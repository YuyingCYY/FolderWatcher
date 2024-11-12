// 監聽的資料夾路徑
string folderPath = @"D:\Test";

using (var watcher = new FileSystemWatcher(folderPath))
{
    // 訂閱檔案變更事件
    watcher.Created += Watcher_Created;
    watcher.Changed += Watcher_Changed;
    watcher.Deleted += Watcher_Deleted;
    watcher.Renamed += Watcher_Renamed;

    // 設置監聽選項
    watcher.EnableRaisingEvents = true;
    watcher.IncludeSubdirectories = false;
    watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;

    // 持續監聽
    while (true)
    {
        Thread.Sleep(1000);
    }
}

void Watcher_Created(object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"New file created: {e.FullPath}");
}

void Watcher_Deleted(object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"File deleted: {e.FullPath}");
}

void Watcher_Changed(object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"File changed: {e.FullPath}");
}

void Watcher_Renamed(object sender, RenamedEventArgs e)
{
    Console.WriteLine($"File renamed: {e.OldFullPath} -> {e.FullPath}");
}
