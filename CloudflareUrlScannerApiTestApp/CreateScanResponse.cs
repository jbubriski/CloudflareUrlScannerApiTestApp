namespace UrlScanner;

public class CreateScanResponse
{
    public string Api { get; set; } // "api"
    public string Message { get; set; } // "Submission successful"
    public string Result { get; set; } // "result"
    public string Url { get; set; } // "url"
    public string Uuid { get; set; } // "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
    public string Visibility { get; set; } // "Public"
    public ScanOptions Options { get; set; }

    public class ScanOptions
    {
        public string Useragent { get; set; }// "useragent"
    }
}