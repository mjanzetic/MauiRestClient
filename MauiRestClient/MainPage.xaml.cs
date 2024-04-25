namespace MauiRestClient
{
    public partial class MainPage : ContentPage
    {
        HttpClient client;

        public MainPage()
        {
            InitializeComponent();
            this.client = new HttpClient();
            url.Text = "http://";

#if IOS
            // trigger local network permission
            try
            {
                this.client.GetAsync("http://foo.bar.local/something");
            }
            catch (Exception)
            {
            }
#endif
        }

        private void OnBtnClicked(object sender, EventArgs e)
        {
            HttpMethod httpMethod;
            switch ((string)requestType.SelectedItem)
            {
                case "GET":
                    httpMethod = HttpMethod.Get;
                    break;
                case "PUT":
                    httpMethod = HttpMethod.Put;
                    break;
                case "POST":
                    httpMethod = HttpMethod.Post;
                    break;
                case "HEAD":
                    httpMethod = HttpMethod.Head;
                    break;
                case "DELETE":
                    httpMethod = HttpMethod.Delete;
                    break;
                default:
                    httpMethod = HttpMethod.Get;
                    break;
            }

            try
            {
                responseEditor.Text = string.Empty;
                var response = this.client.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri(url.Text))).Result;
                responseEditor.Text = $"Response Code: {response.StatusCode}";
            }
            catch (Exception ex)
            {
                responseEditor.Text = $"Ex Msg: {ex.Message}";
                if (ex.InnerException != null)
                {
                    responseEditor.Text += $"{Environment.NewLine}Inner Ex Msg: {ex.InnerException.Message}";
                    if (ex.InnerException.InnerException != null)
                    {
                        responseEditor.Text += $"{Environment.NewLine}Inner Inner Ex Msg: {ex.InnerException.InnerException.Message}";
                    }
                }
            }
        }
    }
}
