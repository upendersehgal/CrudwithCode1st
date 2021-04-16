using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
 

namespace codefirst1.Models
{
	public class student
	{
		[Key]
		public int id { get; set; }
		public string Name { get; set; }
		public string Gender { get; set; }
		public int Age { get; set; }
	}
}