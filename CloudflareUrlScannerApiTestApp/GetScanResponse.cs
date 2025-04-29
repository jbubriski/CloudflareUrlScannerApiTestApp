namespace UrlScanner;

public class GetScanResponse
{
    public DataSection Data { get; set; }
    public ListsSection Lists { get; set; }
    public MetaSection Meta { get; set; }
    public PageSection Page { get; set; }
    // public ScannerSection Scanner { get; set; }
    // public StatsSection Stats { get; set; }
    // public TaskSection Task { get; set; }
    public VerdictsSection Verdicts { get; set; }
}

public class DataSection
{
    public List<ConsoleEntry> Console { get; set; }
    public List<Cookie> Cookies { get; set; }
    public List<GlobalVar> Globals { get; set; }
    public List<Link> Links { get; set; }
    public List<PerformanceEntry> Performance { get; set; }
    public List<RequestBlock> Requests { get; set; }
}

public class ConsoleEntry
{
    public ConsoleMessage Message { get; set; }
}

public class ConsoleMessage
{
    public string Level { get; set; }
    public string Source { get; set; }
    public string Text { get; set; }
    public string Url { get; set; }
}

public class Cookie
{
    public string Domain { get; set; }
    public long Expires { get; set; }
    public bool HttpOnly { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Priority { get; set; }
    public bool SameParty { get; set; }
    public bool Secure { get; set; }
    public bool Session { get; set; }
    public int Size { get; set; }
    public int SourcePort { get; set; }
    public string SourceScheme { get; set; }
    public string Value { get; set; }
}

public class GlobalVar
{
    public string Prop { get; set; }
    public string Type { get; set; }
}

public class Link
{
    public string Href { get; set; }
    public string Text { get; set; }
}

public class PerformanceEntry
{
    public double Duration { get; set; }
    public string EntryType { get; set; }
    public string Name { get; set; }
    public double StartTime { get; set; }
}

public class RequestBlock
{
    public RequestData Request { get; set; }
    public ResponseData Response { get; set; }
    public List<SubRequest> Requests { get; set; }
}

public class RequestData
{
    public string DocumentURL { get; set; }
    public bool HasUserGesture { get; set; }
    public Initiator Initiator { get; set; }
    public bool RedirectHasExtraInfo { get; set; }
    public RequestDetail Request { get; set; }
    public string RequestId { get; set; }
    public string Type { get; set; }
    public double WallTime { get; set; }
    public string FrameId { get; set; }
    public string LoaderId { get; set; }
    public bool PrimaryRequest { get; set; }
    public RedirectResponse RedirectResponse { get; set; }
}

public class Initiator
{
    public string Host { get; set; }
    public string Type { get; set; }
    public string Url { get; set; }
}

public class RequestDetail
{
    public string InitialPriority { get; set; }
    public bool IsSameSite { get; set; }
    public string Method { get; set; }
    public string MixedContentType { get; set; }
    public string ReferrerPolicy { get; set; }
    public string Url { get; set; }
    public Dictionary<string, string> Headers { get; set; }
}

public class RedirectResponse
{
    public string Charset { get; set; }
    public string MimeType { get; set; }
    public string Protocol { get; set; }
    public string RemoteIPAddress { get; set; }
    public int RemotePort { get; set; }
    public List<SecurityHeader> SecurityHeaders { get; set; }
    public string SecurityState { get; set; }
    public int Status { get; set; }
    public string StatusText { get; set; }
    public string Url { get; set; }
    public Dictionary<string, string> Headers { get; set; }
}

public class SecurityHeader
{
    public string Name { get; set; }
    public string Value { get; set; }
}

public class ResponseData
{
    public AsnInfo Asn { get; set; }
    public int DataLength { get; set; }
    public int EncodedDataLength { get; set; }
    public GeoIpInfo Geoip { get; set; }
    public bool HasExtraInfo { get; set; }
    public string RequestId { get; set; }
    public ResponseDetail Response { get; set; }
    public int Size { get; set; }
    public string Type { get; set; }
    public bool ContentAvailable { get; set; }
    public string Hash { get; set; }
}

public class AsnInfo
{
    public string Asn { get; set; }
    public string Country { get; set; }
    public string Description { get; set; }
    public string Ip { get; set; }
    public string Name { get; set; }
    public string Org { get; set; }
}

public class GeoIpInfo
{
    public string City { get; set; }
    public string Country { get; set; }
    public string CountryName { get; set; }
    public string GeonameId { get; set; }
    public List<object> Ll { get; set; }
    public string Region { get; set; }
}

public class ResponseDetail
{
    public string Charset { get; set; }
    public string MimeType { get; set; }
    public string Protocol { get; set; }
    public string RemoteIPAddress { get; set; }
    public int RemotePort { get; set; }
    public SecurityDetails SecurityDetails { get; set; }
    public List<SecurityHeader> SecurityHeaders { get; set; }
    public string SecurityState { get; set; }
    public int Status { get; set; }
    public string StatusText { get; set; }
    public string Url { get; set; }
    public Dictionary<string, string> Headers { get; set; }
}

public class SecurityDetails
{
    public int CertificateId { get; set; }
    public string CertificateTransparencyCompliance { get; set; }
    public string Cipher { get; set; }
    public bool EncryptedClientHello { get; set; }
    public string Issuer { get; set; }
    public string KeyExchange { get; set; }
    public string KeyExchangeGroup { get; set; }
    public string Protocol { get; set; }
    public List<string> SanList { get; set; }
    public int ServerSignatureAlgorithm { get; set; }
    public string SubjectName { get; set; }
    public long ValidFrom { get; set; }
    public long ValidTo { get; set; }
}

public class SubRequest
{
    public string DocumentURL { get; set; }
    public string FrameId { get; set; }
    public bool HasUserGesture { get; set; }
    public Initiator Initiator { get; set; }
    public string LoaderId { get; set; }
    public bool RedirectHasExtraInfo { get; set; }
    public RequestDetail Request { get; set; }
    public string RequestId { get; set; }
    public string Type { get; set; }
    public double WallTime { get; set; }
}

public class ListsSection
{
    public List<string> Asns { get; set; }
    public List<Certificate> Certificates { get; set; }
    public List<string> Continents { get; set; }
    public List<string> Countries { get; set; }
    public List<string> Domains { get; set; }
    public List<string> Hashes { get; set; }
    public List<string> Ips { get; set; }
    public List<string> LinkDomains { get; set; }
    public List<string> Servers { get; set; }
    public List<string> Urls { get; set; }
}

public class Certificate
{
    public string Issuer { get; set; }
    public string SubjectName { get; set; }
    public long ValidFrom { get; set; }
    public long ValidTo { get; set; }
}

public class MetaSection
{
    public ProcessorData Processors { get; set; }
}

public class ProcessorData
{
    public AsnProcessor Asn { get; set; }
    public DnsProcessor Dns { get; set; }
    public DomainCategoryProcessor DomainCategories { get; set; }
    public GeoIpProcessor Geoip { get; set; }
    public PhishingProcessor Phishing { get; set; }
    public RadarRankProcessor RadarRank { get; set; }
    public WappaProcessor Wappa { get; set; }
    public UrlCategoryProcessor UrlCategories { get; set; }
}

public class AsnProcessor
{
    public List<AsnInfo> Data { get; set; }
}

public class DnsProcessor
{
    public List<DnsData> Data { get; set; }
}

public class DnsData
{
    public string Address { get; set; }
    public bool DnssecValid { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
}

public class DomainCategoryProcessor
{
    public List<DomainCategoryData> Data { get; set; }
}

public class DomainCategoryData
{
    public object Inherited { get; set; }
    public bool IsPrimary { get; set; }
    public string Name { get; set; }
}

public class GeoIpProcessor
{
    public List<GeoIpData> Data { get; set; }
}

public class GeoIpData
{
    public GeoIpInfo Geoip { get; set; }
    public string Ip { get; set; }
}

public class PhishingProcessor
{
    public List<string> Data { get; set; }
}

public class RadarRankProcessor
{
    public List<RadarRankData> Data { get; set; }
}

public class RadarRankData
{
    public string Bucket { get; set; }
    public string Hostname { get; set; }
    public int Rank { get; set; }
}

public class WappaProcessor
{
    public List<WappaData> Data { get; set; }
}

public class WappaData
{
    public string App { get; set; }
    public List<Category> Categories { get; set; }
    public List<ConfidenceData> Confidence { get; set; }
    public int ConfidenceTotal { get; set; }
    public string Icon { get; set; }
    public string Website { get; set; }
}

public class Category
{
    public string Name { get; set; }
    public int Priority { get; set; }
}

public class ConfidenceData
{
    public int Confidence { get; set; }
    public string Name { get; set; }
    public string Pattern { get; set; }
    public string PatternType { get; set; }
}

public class UrlCategoryProcessor
{
    public List<UrlCategoryData> Data { get; set; }
}

public class UrlCategoryData
{
    public List<CategoryData> Content { get; set; }
    public InheritedCategory Inherited { get; set; }
    public string Name { get; set; }
    public List<CategoryData> Risks { get; set; }
}

public class InheritedCategory
{
    public List<CategoryData> Content { get; set; }
    public string From { get; set; }
    public List<CategoryData> Risks { get; set; }
}

public class CategoryData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SuperCategoryId { get; set; }
}

public class PageSection
{
    public string ApexDomain { get; set; }
    public string Asn { get; set; }
    public string Asnname { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Domain { get; set; }
    public string Ip { get; set; }
    public string MimeType { get; set; }
    public string Server { get; set; }
    public string Status { get; set; }
    public string Title { get; set; }
    public int TlsAgeDays { get; set; }
    public string TlsIssuer { get; set; }
    public int TlsValidDays { get; set; }
    public string TlsValidFrom { get; set; }
    public string Url { get; set; }
    public Screenshot Screenshot { get; set; }
}

public class Screenshot
{
    public string Dhash { get; set; }
    public int Mm3Hash { get; set; }
    public string Name { get; set; }
    public string Phash { get; set; }
}

public class VerdictsSection
{
    public VeridictsSectionOverall Overall { get; set; }
}

public class VeridictsSectionOverall
{
    public string[] Categories { get; set; }
    public bool HasVerdicts { get; set; }
    public bool Malicious { get; set; }
    public string[] Tags { get; set; }
}
