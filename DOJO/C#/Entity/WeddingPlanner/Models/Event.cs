using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Event
    {
        [Key]
        public int EventId {get;set;}


        [Required(ErrorMessage="Wedder 1 is required!")]
        [MinLength(2, ErrorMessage="Wedder name must be 2 characters or longer!")]
        [Display(Name="Wedder 1 Name:")]
        public string Wedder1 {get;set;}



        [Required(ErrorMessage="Wedder 2 is required!")]
        [MinLength(2, ErrorMessage="Wedder name must be 2 characters or longer!")]
        [Display(Name="Wedder 2 name:")]
        public string Wedder2 {get;set;}


        //figure out how to make date a future date only.
        [Required(ErrorMessage="Future date is required!")]
        [ValidDate]
        [Display(Name="Date:")]
        public DateTime Date {get;set;}


        [Required]
        [Display(Name="Address:")]
        public string Address {get;set;}
        public List<Attending> allUsersAttending { get; set; }

        //OwnerId gets set based on UserId stored in session during creation of event.
        public int OwnerId {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public Event()
        {
            allUsersAttending = new List<Attending>();
        }
        public string SetDate()
        {
            string SetDate = this.Date.ToString("MM/dd/yyyy");
            return SetDate;
        }
    }
}