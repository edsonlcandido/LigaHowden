using System;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace LigaHowden.Extensions
{
    public static class HttpClientExtensions
    {
        private static readonly ConditionalWeakTable<HttpClient, HttpClientMetadata> Metadata = new();

        public static Guid GetInstanceId(this HttpClient client)
        {
            return Metadata.GetOrCreateValue(client).InstanceId;
        }
        private class HttpClientMetadata
        {
            public Guid InstanceId { get; } = Guid.NewGuid();
        }

    }



}
