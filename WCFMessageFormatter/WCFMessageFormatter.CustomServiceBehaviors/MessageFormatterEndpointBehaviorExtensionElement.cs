using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Configuration;

namespace WCFMessageFormatter.CustomServiceBehaviors
{
    public class MessageFormatterEndpointBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(MessageFormatterEndpointBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new MessageFormatterEndpointBehavior();
        }
    }
}
