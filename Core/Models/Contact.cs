namespace Core.Models
{
    public class Contact
    {
        public string Photo { get; set; }
        public string PhotoClear { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryAccountId { get; set; }
        public string PrimaryAccount { get; set; }
        public string Title { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string EmailStatus { get; set; }
        public DateTime EmailOptInDate { get; set; }
        public bool InvalidEmail { get; set; }
        public string PhoneWork { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneOther { get; set; }
        public bool DoNotCall { get; set; }
        public string Website { get; set; }
        public string SkypeId { get; set; }
        public int AssignedUserId { get; set; }
        public string AssignedUser { get; set; }
        public string Teams { get; set; }
        public string PartnerId { get; set; }
        public string Partner { get; set; }
        public List<string> Categories { get; set; }
        public bool NewAccount { get; set; }
        public string AccountName { get; set; }
        public bool AccountIsSupplier { get; set; }
        public string AccountPhoneOffice { get; set; }
        public string AccountWebsite { get; set; }
        public string AccountDescription { get; set; }
        public bool NewOpportunity { get; set; }
        public string OpportunityName { get; set; }
        public DateTime OpportunityDateClosed { get; set; }
        public string OpportunitySalesStage { get; set; }
        public decimal OpportunityAmount { get; set; }
        public string OpportunityDescription { get; set; }
        public bool NewAppointment { get; set; }
        public string Appointment { get; set; }
        public string AppointmentName { get; set; }
        public DateTime AppointmentDateStart { get; set; }
        public string AppointmentDescription { get; set; }
        public string Department { get; set; }
        public string LeadSource { get; set; }
        public BusinessRole BusinessRole { get; set; }
        public string CampaignId { get; set; }
        public string Campaign { get; set; }
        public string ReportsToId { get; set; }
        public string ReportsTo { get; set; }
        public DateTime Birthdate { get; set; }
        public string Assistant { get; set; }
        public int EmailAccounts { get; set; }
        public string AssistantPhone { get; set; }
        public string PhoneFax { get; set; }
        public string PrimaryAddressStreet { get; set; }
        public string PrimaryAddressCity { get; set; }
        public string PrimaryAddressStateCode { get; set; }
        public string PrimaryAddressState { get; set; }
        public string PrimaryAddressCountryCode { get; set; }
        public string PrimaryAddressCountry { get; set; }
        public string PrimaryAddressPostalCode { get; set; }
        public string AltAddressStreet { get; set; }
        public string AltAddressCity { get; set; }
        public string AltAddressStateCode { get; set; }
        public string AltAddressState { get; set; }
        public string AltAddressCountryCode { get; set; }
        public string AltAddressCountry { get; set; }
        public string AltAddressPostalCode { get; set; }
        public string Description { get; set; }
        public List<string> SocialAccounts { get; set; }
    }

    public enum BusinessRole
    {
        CEO,
        MIS,
        CFO,
        Sales,
        Admin
    }
}
