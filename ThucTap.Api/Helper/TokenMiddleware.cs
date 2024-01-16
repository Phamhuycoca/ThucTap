namespace ThucTap.Api.Helper
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                string token = context.Request.Headers["Authorization"].ToString();

                if (string.IsNullOrEmpty(token))
                {
                    context.Items["TaiKhoanId"] = "";
                }
                else
                {
                    string id = token.Substring(7);
                    string userID = JWT.GetUserId(id);

                    context.Items["TaiKhoanId"] = userID;
                }
                await _next(context);

            }
            catch
            {
                context.Items["TaiKhoanId"] = "";
                await _next(context);

            }
        }
    }
}
