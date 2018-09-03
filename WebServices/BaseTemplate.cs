using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;

using System.Runtime.Serialization; // DataContractSerializer (XML)
using System.Runtime.Serialization.Json;  // DataContractJsonSerializer


namespace LastMessage.WebServices
{
    public class BaseTemplate<TInput, TOutput> : System.Web.UI.Page
    {
        
        public TInput DeserializePostInput()
        {
            byte[] postData = Request.BinaryRead(Request.ContentLength);
            MemoryStream postStream = new MemoryStream(postData);
            TInput input = default(TInput);

            DataContractJsonSerializer jsonSerializerPostData = new DataContractJsonSerializer(typeof(TInput));
            try
            {
                input = (TInput)jsonSerializerPostData.ReadObject(postStream);
            }
            catch
            {
                input = default(TInput);
            }

            return input;
        }


        public void SerializeOutput(TOutput output)
        {
            if (Request.QueryString["OutputFormat"] == "XML")
            {
                DataContractSerializer xmlSerializer = new DataContractSerializer(typeof(TOutput));
                Response.ContentType = "text/xml";
                xmlSerializer.WriteObject(Response.OutputStream, output);
            }
            // JSON by default
            else
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(TOutput));
                Response.ContentType = "application/json";
                jsonSerializer.WriteObject(Response.OutputStream, output);
            }

        }
    }
}