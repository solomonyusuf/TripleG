using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Triapp.Server.Models
{
    public class Staffs
    {
        [Key]
        [Required]
        [JsonProperty("id")]
        public Guid id { get; set; }
        [StringLength(200)]
        [JsonProperty("imgPath")]
        public string ImgPath { get; set; }
        [StringLength(20)]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [StringLength(20)]
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [StringLength(20)]
        [JsonProperty("middleName")]
        public string MiddleName { get; set; }
        [DataType(DataType.EmailAddress)]
        [StringLength(20)]
        [JsonProperty("email")]
        public string Email { get; set; }
        [StringLength(30)]
        [JsonProperty("address")]
        public string Address { get; set; }
        [StringLength(30)]
        [JsonProperty("status")]
        public string Status { get; set; }
        [StringLength(30)]
        [JsonProperty("subject")]
        public string Subject { get; set; }
        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [StringLength(15)]
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
        [StringLength(15)]
        [JsonProperty("bank")]
        public string Bank { get; set; }
        [StringLength(40)]
        [JsonProperty("position")]
        public string Position { get; set; }
        [DataType(DataType.Date)]
        [StringLength(20)]
        [JsonProperty("dob")]
        public string DOB { get; set; }
        [StringLength(10)]
        [JsonProperty("originState")]
        public string OriginState { get; set; }
        [DataType(DataType.DateTime)]
        [JsonProperty("timeStamp")]
        public DateTime TimeStamp { get; set; }
        public Staffs()
        {
            TimeStamp = DateTime.Now;
        }

    }
}
