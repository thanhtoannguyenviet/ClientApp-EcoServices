using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models.DTO
{
    public class FeedBackDTO
    {
        FeedbackEntity feedBack { get;set;}
        ClientEntity client { get;set;}
    }
}