using System;
using System.Collections.Generic;
using ProjectManagementApp.DAL.Entities;

namespace ProjectManagementApp.BL.Models
{
    public class CommentDetailModel : BaseModel
    {
        public DateTime Timestamp { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public ThreadDetailModel Thread { get; set; }
        public UserDetailModel Author { get; set; }
    }
}