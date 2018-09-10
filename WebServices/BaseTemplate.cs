using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;

using System.Runtime.Serialization; // DataContractSerializer (XML)
using System.Runtime.Serialization.Json;  // DataContractJsonSerializer


namespace LastMessage.WebServices
{

    public abstract class BaseTemplate<TInput, TOutput> : System.Web.UI.Page where TOutput : BaseOutput, new()
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TInput input = DeserializePostInput();
            
            TOutput output = new TOutput();

            // if(input==default(TInput)) // Operator '==' cannot be applied to operands of type 'TInput' and 'TInput'	// https://stackoverflow.com/questions/8982645/how-to-solve-operator-cannot-be-applied-to-operands-of-type-t-and-t
            if(EqualityComparer<TInput>.Default.Equals(input, default(TInput)))
            {
                output.Status = "Invalid arguments";
            }
            else
            {
                output = GetData(input);
            }

            SerializeOutput(output);
        }

        public abstract TOutput GetData(TInput input);
        
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

    public abstract class BaseOutput
    {
        public string Status {get;set;}

        public BaseOutput()
        {
            Status = "OK";
        }
    }

}
