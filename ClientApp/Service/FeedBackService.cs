using ClientApp.Common;
using ClientApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace ClientApp.Service
{
    public class FeedBackService
    {
        public FeedbackEntity Post(FeedbackEntity feedbackEntity)
        {
            var fbEntity = GRestfulApi<FeedbackEntity>.Post(PropertiesFile.HOST + "Feedback/Post/", feedbackEntity);
            return fbEntity;
            }
        public FeedbackEntity Put(FeedbackEntity feedbackEntity)
        {
            var fbEntity = GRestfulApi<FeedbackEntity>.Put(PropertiesFile.HOST + "Feedback/Put/", feedbackEntity);
            return fbEntity;
        }
        public string Delete(int id)
        {
            var fbEntity = GRestfulApi<FeedbackEntity>.Delete(PropertiesFile.HOST + "Feedback/Delete/" + id);
            return fbEntity;
           
        }
        public FeedbackEntity GetDetail(int id)
        {
            var fbEntity = GRestfulApi<FeedbackEntity>.Get(PropertiesFile.HOST + "Feedback/GetDetail/" + id);
            return fbEntity;
        }
       
    }
}