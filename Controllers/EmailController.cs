using Microsoft.AspNetCore.Mvc;
using SendEmails.Models;
using SendEmails.Services;


namespace SendEmails.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(MailRequest mailRequest)
        {
            try
            {
                if (mailRequest == null)
                {
                    return BadRequest("MailRequest object is null.");
                }
                
                await _emailService.SendEmailAsync(mailRequest);
                return Ok(mailRequest);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
