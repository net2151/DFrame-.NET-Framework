﻿using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DFrame.Core;
using YamlDotNet.Serialization;

namespace DFrame.KubernetesWorker
{
    public class KubernetesScalingProvider : IScalingProvider
    {
        private readonly string _ns = "dframe-worker";
        private readonly KubernetesApi _kubeapi;
        private readonly IDeserializer _yamlDeserializer;

        private string _namespaceManifest;
        private string _deploymentManifest;

        public KubernetesScalingProvider()
        {
            _kubeapi = new KubernetesApi(new KubernetesApiConfig
            {
                AccesptHeaderType = HeaderContentType.Yaml,
                SkipCertificateValidation = true,
            });
            _yamlDeserializer = new DeserializerBuilder().Build();
        }

        public async Task StartWorkerAsync(DFrameOptions options, int nodeCount, CancellationToken cancellationToken)
        {
            // master が kubernetes で起動している、worker をここで作る。
            // todo: service account / role / rolebindings が必要

            // create kuberentes deployments. replicacount = nodeCount
            // create namespace
            _namespaceManifest = KubernetesManifest.GetNamespace(_ns);
            _ = await _kubeapi.CreateNamespaceAsync(_ns, _namespaceManifest, cancellationToken);

            // create deployment
            _deploymentManifest = KubernetesManifest.GetDeployment("dframe", "guitarrapc/dframe-worker", "0.1.0", 12345, nodeCount);
            _ = await _kubeapi.CreateDeploymentAsync(_ns, _deploymentManifest, cancellationToken);

            // wait kubernetes deployments done.
            var deployresult = await _kubeapi.GetDeploymentAsync(_ns, "dframe");
            var deploy = _yamlDeserializer.Deserialize<KubernetesDeploymentMetadata>(deployresult);
            Console.WriteLine($"deployment create. {deploy.metadata.@namespace}/{deploy.metadata.name}");
        }

        public async ValueTask DisposeAsync()
        {
            // delete kubernetes deployments. namespace は master を含むので残す。
            var namespaces = await _kubeapi.GetNamespacesAsync();
            var deploy = await _kubeapi.GetDeploymentAsync(_ns, "dframe");
        }
    }
}
