using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace codefirst1.Models
{
	public class studentcontext:DbContext
	{
		public DbSet<student> students { get; set; }
	}
}