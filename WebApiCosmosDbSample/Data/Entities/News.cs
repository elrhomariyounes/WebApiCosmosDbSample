using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCosmosDbSample.Data.Entities
{
    public class News
    {
        [Column("id")]
        public Guid Id { get; set; }
        public string Body { get; set; }
        public string PhotoUrl { get; set; }
    }
}
