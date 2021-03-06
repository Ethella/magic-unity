using System;
using link.magic.unity.sdk.Utility;
using UnityEngine;

namespace link.magic.unity.sdk.Relayer
{
    public class UrlBuilder
    {
        internal static UrlBuilder Instance;

        public static readonly string Host = "https://box.magic.link";

        // public static readonly string Host = "http://192.168.1.18:3016";
        internal readonly string EncodedParams;
        public string apikey;

        public UrlBuilder(string apikey, CustomNodeConfiguration customNode, string locale = "en-US")
        {
            var options = new CustomNodeOptions();
            options.ETH_NETWORK = customNode;
            options.locale = locale;
            options.API_KEY = apikey;

            var optionsJsonString = JsonUtility.ToJson(options);
            EncodedParams = MagicUtility.BtoA(optionsJsonString);
        }

        public UrlBuilder(string apikey, EthNetworkConfiguration ethNetwork, string locale = "en-US")
        {
            var options = new EthNetworkOptions();
            options.ETH_NETWORK = ethNetwork;
            options.locale = locale;
            options.API_KEY = apikey;

            var optionsJsonString = JsonUtility.ToJson(options);
            EncodedParams = MagicUtility.BtoA(optionsJsonString);
        }
    }

    [Serializable]
    internal class EthNetworkOptions : BaseOptions
    {
        public EthNetworkConfiguration ETH_NETWORK;
    }

    [Serializable]
    internal class CustomNodeOptions : BaseOptions
    {
        public CustomNodeConfiguration ETH_NETWORK;
    }

    [Serializable]
    public class CustomNodeConfiguration
    {
        private int chainId;
        private string rpcUrl;

        public CustomNodeConfiguration(string rpcUrl, int chainId)
        {
            this.rpcUrl = rpcUrl;
            this.chainId = chainId;
        }
    }

    [Serializable]
    public class EthNetworkConfiguration
    {
        private string network;

        public EthNetworkConfiguration(EthNetwork network)
        {
            this.network = nameof(network);
        }
    }

    [Serializable]
    public class BaseOptions
    {
        public string host = UrlBuilder.Host;
        public string sdk = "magic-sdk-unity";
        public string API_KEY;
        public string locale;
    }
}