using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using RestfulLabSMSService.Models;

namespace RestfulLabSMSService.Controllers
{
    public class SMSServiceController : ApiController
    {
        private const int MaxSize = 140;
        private const String LOGFILENAME = "C:\\Student\\log.txt";


        // POST /api/SMSService
        public IHttpActionResult PostSendSMS(TextMessage message)
        {
            if (ModelState.IsValid)
            {
                log("Sent " + message.Content + " from " + message.SourceNumber + " to " + message.DestinationNumber);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [NonAction]
        private void log(String logInfo)
        {
            using (StreamWriter stream = File.AppendText(LOGFILENAME))
            {
                stream.Write(logInfo);
                stream.WriteLine(" " + DateTime.Now);
                stream.Close();
            }
        }



    }
}