namespace Pokemon.Middle
{
    public class Util
    {

        public static int GetIdfromUrl(string url)
        {
            var len = url.Length;
            var u_url = url.Remove(len - 1);

            var id = u_url.Substring(u_url.LastIndexOf("/") + 1);
            var id_len = id.Length;

            return Convert.ToInt16(id);

        }
    }
}
