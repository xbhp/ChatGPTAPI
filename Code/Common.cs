using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace webapitest.Code
{
    public static class Common
    {
        enum WXBizMsgCryptErrorCode
        {
            WXBizMsgCrypt_OK = 0,
            WXBizMsgCrypt_ValidateSignature_Error = -40001,
            WXBizMsgCrypt_ParseXml_Error = -40002,
            WXBizMsgCrypt_ComputeSignature_Error = -40003,
            WXBizMsgCrypt_IllegalAesKey = -40004,
            WXBizMsgCrypt_ValidateAppid_Error = -40005,
            WXBizMsgCrypt_EncryptAES_Error = -40006,
            WXBizMsgCrypt_DecryptAES_Error = -40007,
            WXBizMsgCrypt_IllegalBuffer = -40008,
            WXBizMsgCrypt_EncodeBase64_Error = -40009,
            WXBizMsgCrypt_DecodeBase64_Error = -40010
        };
        /// <summary>
        /// HMAC-SHA1加密算法
        /// </summary>
        /// <param name="str">加密字符串</param>
        /// <returns></returns>
        public static string HmacSha1Sign(string str)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var hash = sha1.ComputeHash(Encoding.Default.GetBytes(str));
            string byte2String = null;
            for (int i = 0; i < hash.Length; i++)
            {
                byte2String += hash[i].ToString("x2");
            }
            return byte2String;
        }

        public static bool Check(string signature, string timestamp, string nonce,string token)
        {

            string[] value = new string[3]
            {
               token,
                timestamp,
                nonce
            }.OrderBy(o => o).ToArray();
            string s = string.Join("", value);
            byte[] array = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(s));
            StringBuilder stringBuilder = new StringBuilder();
            byte[] array2 = array;
            foreach (byte b in array2)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }

            return signature == stringBuilder.ToString();
        }
        public static int GenarateSinature(string sToken, string sTimeStamp, string sNonce, string sMsgEncrypt, ref string sMsgSignature)
        {
            ArrayList AL = new ArrayList();
            AL.Add(sToken);
            AL.Add(sTimeStamp);
            AL.Add(sNonce);
            AL.Add(sMsgEncrypt);
            AL.Sort(new DictionarySort());
            string raw = "";
            for (int i = 0; i < AL.Count; ++i)
            {
                raw += AL[i];
            }

            SHA1 sha;
            ASCIIEncoding enc;
            string hash = "";
            try
            {
                sha = new SHA1CryptoServiceProvider();
                enc = new ASCIIEncoding();
                byte[] dataToHash = enc.GetBytes(raw);
                byte[] dataHashed = sha.ComputeHash(dataToHash);
                hash = BitConverter.ToString(dataHashed).Replace("-", "");
                hash = hash.ToLower();
            }
            catch (Exception)
            {
                return (int)WXBizMsgCryptErrorCode.WXBizMsgCrypt_ComputeSignature_Error;
            }
            sMsgSignature = hash;
            return 0;
        }
        public class DictionarySort : System.Collections.IComparer
        {
            public int Compare(object oLeft, object oRight)
            {
                string sLeft = oLeft as string;
                string sRight = oRight as string;
                int iLeftLength = sLeft.Length;
                int iRightLength = sRight.Length;
                int index = 0;
                while (index < iLeftLength && index < iRightLength)
                {
                    if (sLeft[index] < sRight[index])
                        return -1;
                    else if (sLeft[index] > sRight[index])
                        return 1;
                    else
                        index++;
                }
                return iLeftLength - iRightLength;

            }
        }
    }
}
