using Nest;
using System;

namespace DataGenerator.Models
{
    public class Transaction
    {
        [Text(Name = "id")]
        public Guid Id { get; set; }

        [Text(Name = "element_id")]
        public string ElementId { get; set; }

        [Text(Name = "source_id")]
        public Guid SourceId { get; set; }

        [Text(Name = "target_id")]
        public Guid TargetId { get; set; }

        [Text(Name = "source_target_id")]
        public string SourceTargetId => $"{SourceId}_{TargetId}";

        [Text(Name = "date")]
        public string Date { get; set; }

        [Text(Name = "state")]
        public string State { get; set; }

        [Text(Name = "issue_tracking")]
        public int IssueTracking { get; set; }

        [Text(Name = "amount")]
        public int Amount { get; set; }

        public Transaction(
            Guid id,
            Guid sourceId,
            Guid targetId,
            string date,
            string time,
            string state,
            int issueTracking,
            int amount)
        {
            Id = id;
            ElementId = "2";
            SourceId = sourceId;
            TargetId = targetId;
            Date = date + " " + time;
            State = state;
            IssueTracking = issueTracking;
            Amount = amount;
        }
    }
}
