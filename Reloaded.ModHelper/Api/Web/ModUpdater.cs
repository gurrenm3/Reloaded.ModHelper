using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// An Update checker for mods
    /// </summary>
    public class ModUpdater
    {
        private static HttpClient client = null;

        /// <summary>
        /// The URL to Github Release Api
        /// </summary>
        public string ReleaseURL { get; set; }

        /// <summary>
        /// An Update checker for mods
        /// </summary>
        public ModUpdater()
        {
            if (client is null)
                client = CreateHttpClient();
        }

        /// <summary>
        /// An Update checker for mods
        /// </summary>
        /// <param name="url">The URL to Github Release Api</param>
        public ModUpdater(string url) : this()
        {
            ReleaseURL = url;
        }

        /// <summary>
        /// Get's the all ReleaseInfo from the ReleaseURL
        /// </summary>
        /// <returns></returns>
        public async Task<List<GithubReleaseInfo>> GetReleaseInfoAsync()
        {
            return await GetReleaseInfoAsync(ReleaseURL);
        }

        /// <summary>
        /// Get's the all ReleaseInfo from the ReleaseURL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<List<GithubReleaseInfo>> GetReleaseInfoAsync(string url)
        {
            var releaseJson = await client.GetStringAsync(url);
            return GithubReleaseInfo.FromJson(releaseJson);
        }

        /// <summary>
        /// Get's the latest ReleaseInfo from the ReleaseURL
        /// </summary>
        /// <returns></returns>
        public async Task<GithubReleaseInfo> GetLatestReleaseAsync()
        {
            return await GetLatestReleaseAsync(ReleaseURL);
        }

        /// <summary>
        /// Get's the latest ReleaseInfo from the ReleaseURL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<GithubReleaseInfo> GetLatestReleaseAsync(string url)
        {
            var releases = await GetReleaseInfoAsync(url);
            return releases[0];
        }

        /// <summary>
        /// Compares 2 version numbers and returns whether or not tue current one is outdated
        /// </summary>
        /// <param name="currentVersion"></param>
        /// <param name="latestReleaseInfo"></param>
        /// <returns></returns>
        public bool IsUpdate(string currentVersion, GithubReleaseInfo latestReleaseInfo)
        {
            return IsUpdate(currentVersion, latestReleaseInfo?.TagName);
        }

        /// <summary>
        /// Compares 2 version numbers and returns whether or not tue current one is outdated
        /// </summary>
        /// <param name="currentVersion"></param>
        /// <param name="latestVersion"></param>
        /// <returns></returns>
        public bool IsUpdate(string currentVersion, string latestVersion)
        {
            if (string.IsNullOrEmpty(currentVersion) || string.IsNullOrEmpty(latestVersion))
                throw new ArgumentNullException();

            CleanVersionStrings(ref currentVersion, ref latestVersion);

            Int32.TryParse(currentVersion, out int currentVersionNum);
            Int32.TryParse(latestVersion, out int latestVersionNum);

            return latestVersionNum > currentVersionNum;
        }

        private HttpClient CreateHttpClient()
        {
            client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            client.DefaultRequestHeaders.Add("user-agent", " Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0");
            return client;
        }

        private void CleanVersionStrings(ref string string1, ref string string2)
        {
            RemoveAllNonNumeric(ref string1);
            RemoveAllNonNumeric(ref string2);
            MakeLengthEven(ref string1, ref string2);
        }

        private void RemoveAllNonNumeric(ref string str)
        {
            string cleanedStr = "";
            for (int i = 0; i < str.Length; i++)
            {
                var currentLetter = str[i].ToString();
                bool isNumber = Int32.TryParse(currentLetter, out int num);
                if (isNumber)
                    cleanedStr += currentLetter;
            }

            str = cleanedStr;
        }

        private void MakeLengthEven(ref string string1, ref string string2)
        {
            while (string1.Length != string2.Length)
            {
                bool isString1Bigger = string1.Length > string2.Length;

                string1 += isString1Bigger ? "" : "0";
                string2 += isString1Bigger ? "0" : "";
            }
        }
    }
}
