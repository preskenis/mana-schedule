using System.Runtime.Serialization;

namespace ManaSchedule.DataModels
{
    [DataContract]
    public class ImportItem
    {
        [DataMember]
        public string Number { get; set; }
        [DataMember]public Team Team { get; set; }
        [DataMember]public bool IsPastWinner { get; set; }
        [DataMember]public double? PastWinnerPlace { get; set; }

    }
}