using System;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    /// <summary>
    /// MD5������
    /// </summary>
    public class MD5
    {
        public static string GetMD5Hash(string str, bool base64 = true)
        {
            //���Ǳ�string����һֱ��Ҫ�õ��Ż�����
            StringBuilder sb = new StringBuilder();
            using MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //�������ַ���ת��Ϊ�ֽ����鲢�����ϣ��
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            if (base64) return Convert.ToBase64String(data);
            else
            {
                //XΪ     ʮ������ X���Ǵ�д x��ΪСд
                //2Ϊ ÿ�ζ�����λ��
                //������������10��26���������ʮ��������ʾ0xA��0x1A�����������������룬Ϊ�˺ÿ�������ָ��"X2"��������ʾ�������ǣ�0x0A��0x1A�� 
                //������ϣ���ݵ�ÿ���ֽ�
                //����ÿ���ַ�����ʽ��Ϊʮ�������ַ�����
                int length = data.Length;
                for (int i = 0; i < length; i++)
                    sb.Append(data[i].ToString("X2"));
                return sb.ToString();
            }
        }

        //��֤
        public static bool VerifyMD5Hash(string str, string hash, bool base64 = true)
        {
            string hashOfInput = GetMD5Hash(str, base64);
            return hashOfInput.CompareTo(hash) == 0;
        }
    }
}