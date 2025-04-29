namespace UrlScanner;

public class SearchScansResponse
{
    public SearchScansResult[] Results { get; set; }
}

public class SearchScansResult
{
    public Guid _id { get; set; } // "9626f 773-9ffb-4cfb-89d 3-30b120fc8011",
    
    public SearchScansPage Page { get; set; }
    
    public string Result { get; set; } // "https://radar.clouflare.com/scan/9626f773-9ffb-4cfb-89d3-30b120fc8011",

    public SearchScansStats Stats { get; set; }
    public SearchScansTask Task { get; set; }
    public SearchScansVerdicts Verdicts { get; set; }

    public class SearchScansPage
    {
        public string Asn {get ;set; } // "AS15133",
        public string Country {get ;set; } // "US",
        public string Ip {get ;set; } // "93.184.215.14",
        public string Url {get ;set; } // "https://example.com"
    }

    public class SearchScansStats
    {
        public int DataLength { get; set; }
        public int Requests { get; set; }
        public int UniqCountries { get; set; }
        public int UniqIPs { get; set; }
    }

    public class SearchScansTask
    {
        public string Time {get; set; } // "2024-09-30T23:54:02.881000+00:00",
        public string Url {get; set; } // "https://example.com",
        public string Uuid {get; set; } // "9626f773-9ffb-4cfb-89d3-30b120fc8011",
        public string Visibility {get; set; } // "public"
    }

    public class SearchScansVerdicts
    {
        public bool Malicious { get; set; }
    }
}