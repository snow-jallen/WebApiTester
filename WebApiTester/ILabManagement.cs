using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTester
{
    public class ReportItem
    {
        public int Id { get; set; }
        public string HostName { get; set; }
        public string SerialNumber { get; set; }
        public string MacNumber { get; set; }
        public string ImageVersionContent { get; set; }
        public DateTime ReportTime { get; set; }
    }

    public interface ILabManagement
    {
        [Get("/api/ReportItems")]
        Task<IEnumerable<ReportItem>> GetReportItemsAsync();

        [Post("/api/ReportItems")]
        Task<ReportItem> AddReportItemAsync(ReportItem reportItem);

        [Get("/api/ReportItems/{id}")]
        Task<ReportItem> GetReportItemAsync(int id);

        [Put("/api/ReportItems/{id}")]
        Task<bool> UpdateReportItemAsync(int id, ReportItem reportItem);
    }
}
