using System;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Web;

public class CorsBehavior : Attribute, IServiceBehavior, IDispatchMessageInspector
{
    public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
    {
    }

    public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
        foreach (ChannelDispatcher cd in serviceHostBase.ChannelDispatchers)
        {
            foreach (EndpointDispatcher ed in cd.Endpoints)
            {
                ed.DispatchRuntime.MessageInspectors.Add(this);
            }
        }
    }

    public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
    }

    public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
    {
        HttpRequestMessageProperty httpRequest = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];

        if (httpRequest.Method == "OPTIONS")
        {
            HttpResponseMessageProperty response = new HttpResponseMessageProperty();
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Methods", "POST, GET, OPTIONS, PUT, DELETE");
            response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept");

            request.Properties[HttpResponseMessageProperty.Name] = response;
            return null;
        }
        return null;
    }

    public void BeforeSendReply(ref Message reply, object correlationState)
    {
        HttpResponseMessageProperty response = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];
        response.Headers.Add("Access-Control-Allow-Origin", "*");
    }
}
