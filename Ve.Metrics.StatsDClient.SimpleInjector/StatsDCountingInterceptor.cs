﻿using Ve.Metrics.StatsDClient.Abstract;
using Ve.Metrics.StatsDClient.Attributes;

namespace Ve.Metrics.StatsDClient.SimpleInjector
{
    public class StatsDCountingInterceptor : BaseInterceptor<StatsDCounting>, IInterceptor
    {
        public StatsDCountingInterceptor(IVeStatsDClient client) : base(client)
        {
        }
        
        protected override void Invoke(IInvocation invocation, StatsDCounting attr)
        {
            invocation.Proceed();
            Client.LogCount(attr.Name, attr.Count, attr.Tags);
        }
    }
}
