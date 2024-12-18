﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProProjekt.Models
{
	public class OurPicUploads
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[DisplayName("The heckin' title of yo pic (May not contain < > . or new line)")]
		//[RegularExpression("([^(<>\n.)])*")]
		public string? PicTitle { get; set; }

		[Required]
		[DisplayName("Describe your pic !!!(May not contain < > . or new line)")]
		[RegularExpression("([^(<>\n.)])*")]
		public string? PicDescription { get; set; }
		
		public string? PicPath { get; set; }

		public required string ProfileId { get; set; }

		[Required]
		[DisplayName("Pic u have to upload")]
		[NotMapped]
        public IFormFile PicFile { get; set; }

		
	}
}
