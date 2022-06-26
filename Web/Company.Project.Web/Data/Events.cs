﻿using Company.Project.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Data
{
    
    public class Events
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = " Please Enter title of the book")]
        [Display(Name = "Title of the Book")]
        public string title { get; set; }

        [Required(ErrorMessage = "Please Enter the Event Date")]
        [Display(Name = "Event Date")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "Please Enter the start time")]
        [DataType(DataType.Time)]
        public DateTime startTime { get; set; }

        [Required(ErrorMessage = "Please Enter the venue")]
        [Display(Name = "Venue")]
        public string location { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Range(1, 4, ErrorMessage = " Duration should be 1-4 hours only")]
        public int? duration { get; set; }

        [Display(Name = "Organiser")]
        [Required(ErrorMessage = "Please Enter your name")]
        public string organiser { get; set; }


        [Display(Name = "Type of Event")]
        public string eventType { get; set; }


        [Display(Name = "Invite People")]
        public string invitees { get; set; }

        [ForeignKey("EventId")]
        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
