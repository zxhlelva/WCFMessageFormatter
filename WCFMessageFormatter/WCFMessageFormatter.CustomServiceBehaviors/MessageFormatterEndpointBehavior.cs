using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace WCFMessageFormatter.CustomServiceBehaviors
{
    public class MessageFormatterEndpointBehavior : IEndpointBehavior
    {
        #region IEndpointBehavior Members
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            foreach (OperationDescription operation in endpoint.Contract.Operations)
            {
                if (operation.Behaviors.Contains(typeof(MessageFormatterOperationBehavior)))
                {
                    continue;
                }
                operation.Behaviors.Add(new MessageFormatterOperationBehavior());
            }
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
        #endregion
    }
}
