using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace webapitest.Controllers
{
    public class OpenaiController : ControllerBase
    {
        [HttpPost]
        [Route("getanswer")]
        public IActionResult GetResult([FromBody] string prompt)
        {
            //your OpenAI API key
            string apiKey = "sk-rn4dYobxtxXilCD0BIgXT3BlbkFJjMLMpMvzxxxasdadf";
            string answer = string.Empty;
            var openai = new OpenAIAPI(apiKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = prompt;
            completion.Model = OpenAI_API.Models.Model.DavinciText;
            completion.MaxTokens = 400000;
            var result = openai.Completions.CreateCompletionAsync(completion);
            if (result != null)
            {
                foreach (var item in result.Result.Completions)
                {
                    answer = item.Text;
                }
                return Ok(answer);
            }
            else
            {
                return BadRequest("Not found");
            }
        }
    }
}
