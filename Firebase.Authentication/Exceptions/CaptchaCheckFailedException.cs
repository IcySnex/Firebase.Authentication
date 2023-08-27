namespace Firebase.Authentication.Exceptions;

public class CaptchaCheckFailedException : IdentityPlatformException
{
    /// <summary>
    /// The Recaptcha verification failed. It may be invalid or expired.
    /// </summary>
    public CaptchaCheckFailedException() : base("The Recaptcha verification failed. It may be invalid or expired.", "CAPTCHA_CHECK_FAILED") { }
}