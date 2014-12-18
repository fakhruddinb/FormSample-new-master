using System;
using SQLite.Net.Attributes;
using Newtonsoft.Json;


namespace FormSample
{
    public class Agent
    {
       [PrimaryKey, AutoIncrement]
		[JsonIgnore]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "Id")]
		public string Email { get; set; }
        //public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
		public string AgencyName { get; set; }
        
    }

}

