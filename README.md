#三步实现在ASP.NET Core Web API集成ChatGPT

  最近ChatGPT炒得比较厉害，它的AI功能是相当强大。以至于现在国内的大厂以及Google等公司已经开始模仿，推出类似的功能。先简介一下，ChatGPT是一种用深度学习技术建立的基于自然语言系统的对话机器人技术，可以使机器与用户对话，模拟他们的对话行为。它可以模仿真实的双向对话，通过在上下文，具体信息，术语和事实的混合来建立智能响应，从而使机器与用户之间的连接更加智能化，自动化和自然。

 

2、什么是文本完成

    文本完成是一项语言处理任务，涉及生成部分给定文本序列的缺失部分。这是一种文本生成任务，在该任务中，模型被迅速地给出不完整的文本，并被要求基于上下文生成缺失的文本。例如，如果提示“今天天气真的很好”，文本完成模型可以生成接下来的几句话，例如“我想我要去公园散步。阳光明媚，微风习习。”文本完成的目标是生成连贯、语法正确的文本，并延续原始提示的含义和上下文。文本完成模型使用机器学习算法来学习文本数据中的模式和关系，允许它们生成与给定提示一致的新文本。这些模型可以在大型文本语料库上进行训练，并针对特定任务进行微调，例如生成对话响应和完成句子、段落或文章。文本完成是各种应用程序的宝贵工具，包括聊天机器人、内容生成和具有自动完成功能的文本编辑器。

 

3、在ASP.NET Core Web API中集成文本完成

1）在ChatGPT官网申请API的key

当然在申请之前需要注册ChatGPT账号，注册免费，但是国内目前不能注册，网上有很多注册的方法，大家可以搜索一下。笔者是在网上花钱购买的。

注册成功后登录ChatGPT官网，在右上角点击"Personal"，然后打开下拉菜单中的"View API keys"，最后点击页面中的"Create new secret key"创建key，需要注意的是弹出窗口时复制一下，一旦创建将看不见key，只能删除重新创建。如下图1，图2。

 

 

 

图1 打开key页面



 

 

图2 创建key和删除key

2）ASP.NET Core Web API环境搭建

a、新建一个ASP.NET Core Web API空白站点，也可以是模板。

b、添加OpenAI的nuget包，方法可以使用nuget管理器，也可以用命令

c、新建一个空的控制器，并新建一个post方法，实例代码如下：


   [HttpPost]
        [Route("getanswer")]
        public IActionResult GetResult([FromBody] string prompt)
        {
            //这是你key
            string apiKey = "sk-WxARFnsINrnwf5vyRTHaT3BlbkFJxxxxxxxxxxxxxxxxxx03";
            string answer = string.Empty;
            var openai = new OpenAIAPI(apiKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = prompt;
            completion.Model = OpenAI_API.Models.Model.DavinciText;
            completion.MaxTokens = 4000;
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
                return BadRequest("请求失败");
            }
        }
复制代码
 

 
在上面的代码中，我们使用getanswer创建了一个端点。变量apikey保存您生成的API密钥。创建了CompletionRequest的对象。这里我们需要定义Model类型和MaxTokens。MaxToken将决定文本的长度，因此如果您想要文字比较长的答案，请把MaxToken值设置较大。这样API就写完了，很简单吧，如果需要更多功能可以查看官网的文档说明。

 

3）效果预览

老胡体文字自动完成。



 

 

问个C#的实现案例。

 

 

 

自动写出了c#这个组件的示例代码，很智能啊！

大家如果感兴趣可以自己写个界面，然后调用这个API，这样更加友好。

需要注意的是在高峰时期，网络可能会堵塞，接口会报错。

 

结语

    本文讲述了ASP.NET Core Web API集成ChatGPT 本文完成的API使用，并展示了使用案例，ChatGPT回答的很完美。值得注意的是OpenAI的接口是收费的，但是有18美元的免费的额度，使用完了可以重新申请一个。大家可以按照以上方法试一试。本文仅供参考，具体功能请查看官方API文档地址。欢迎留言和点赞。

 

源码地址：

https://pan.baidu.com/s/11n2NBJQ1Bgka-FVaZxYEfw?pwd=lo9i

本来想传到github上去，网络太差了。

API文档地址：https://platform.openai.com/docs/introduction
