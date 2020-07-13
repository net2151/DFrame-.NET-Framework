﻿using System.Threading;
using System.Threading.Tasks;

namespace DFrame.KubernetesWorker
{
    public partial class KubernetesApi
    {
        #region namespace
        public async ValueTask<string> CreateNamespaceAsync(string name, string manifest, CancellationToken ct = default)
        {
            var res = await PostApiAsync($"/apis/apps/v1/namespaces/", manifest, "application/yaml", ct);
            return res;
        }
        public async ValueTask<string> GetNamespacesAsync()
        {
            var res = await GetApiAsync($"/apis/apps/v1/namespaces", "application/yaml");
            return res;
        }
        public async ValueTask<string> GetNamespaceAsync(string name)
        {
            var res = await GetApiAsync($"/apis/apps/v1/namespaces/{name}", "application/yaml");
            return res;
        }
        public async ValueTask<bool> ExistsNamespaceAsync(string name)
        {
            try
            {
                // 雑 of 雑
                var res = await GetApiAsync($"/apis/apps/v1/namespaces/{name}", "application/yaml");
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async ValueTask<string> DeleteNamespaceAsync(string @namespace, CancellationToken ct = default)
        {
            var res = await DeleteApiAsync($"/apis/apps/v1/namespaces/{@namespace}", ct);
            return res;
        }
        #endregion

        #region deployment
        public async ValueTask<string> CreateDeploymentAsync(string @namespace, string manifest, CancellationToken ct = default)
        {
            var res = await PostApiAsync($"/apis/apps/v1/namespaces/{@namespace}/deployments", manifest, "application/yaml", ct);
            return res;
        }
        public async ValueTask<string> GetDeploymentsAsync(string @namespace)
        {
            var res = await GetApiAsync($"/apis/apps/v1/namespaces/{@namespace}/deployments", "application/yaml");
            return res;
        }
        public async ValueTask<string> GetDeploymentAsync(string @namespace, string name)
        {
            var res = await GetApiAsync($"/apis/apps/v1/namespaces/{@namespace}/deployments/{name}", "application/yaml");
            return res;
        }
        public async ValueTask<bool> ExistsDeploymentAsync(string @namespace, string name)
        {
            try
            {
                // 雑 of 雑
                var res = await GetApiAsync($"/apis/apps/v1/namespaces/{@namespace}/deployments/{name}", "application/yaml");
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async ValueTask<string> DeleteDeploymentAsync(string @namespace, string name, CancellationToken ct = default)
        {
            var res = await DeleteApiAsync($"/apis/apps/v1/namespaces/{@namespace}/deployments/{name}", ct);
            return res;
        }
        #endregion
    }

    public class KubernetesDeploymentMetadata
    {
        public string apiVersion { get; set; }
        public string kind { get; set; }
        public Metadata metadata { get; set; }
        public object spec { get; set; }

        public class Metadata
        {
            public string name { get; set; }
            public string @namespace { get; set; }
        }
    }

    public class KubernetesNamespaceMetadata
    {
        public string apiVersion { get; set; }
        public string kind { get; set; }
        public Metadata metadata { get; set; }

        public class Metadata
        {
            public string name { get; set; }
            public string @namespace { get; set; }
        }
    }
}
