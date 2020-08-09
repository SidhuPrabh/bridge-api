namespace bridge_api.Models.Leads
{
    public class Lead
    {
        public uint id;
        public uint cId;
        public uint bId;
        public uint catId;
        public string dateTimeCreated;
        public string status;
        public uint city;
        public string dateTimeDelivery;
        public string workDetails;
        public bool isHired;
        public bool quoteRequested;
        public bool quoteSent;
        public string quoteRequestedDateTime;
        public string quoteSentDateTime;

        public string QuoteSentDateTime { get => quoteSentDateTime; set => quoteSentDateTime = value; }
    }
}