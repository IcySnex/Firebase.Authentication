namespace Firebase.Authentication.Exceptions;

public class CaptchaCheckFailedException : IdentityPlatformException
{
    /// <summary>
    /// The Recaptcha verification failed. It may be invalid or expired.
    /// </summary>
    public CaptchaCheckFailedException() : base("CAPTCHA_CHECK_FAILED", "The Recaptcha verification failed. It may be invalid or expired.") { }
}