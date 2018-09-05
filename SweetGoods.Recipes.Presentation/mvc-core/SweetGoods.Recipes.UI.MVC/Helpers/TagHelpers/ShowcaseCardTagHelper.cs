using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.UI.MVC.Helpers.TagHelpers
{
    [HtmlTargetElement("showcase-card")]
    public class ShowcaseCardTagHelper : TagHelper
    {
        //<div class="card bg-dark text-white" style="width: 18rem;">
        //    <img class="card-img-top" src="~/images/1.jpg" alt="Card image cap">
        //    <div class="card-img-overlay">
        //        <h5 class="card-title">Título 1</h5>
        //    </div>
        //</div>
        [HtmlAttributeName("img-src")]
        public string ImageSource { get; set; }

        [HtmlAttributeName("img-alt")]
        public string ImageAlt { get; set; }

        [HtmlAttributeName("title")]
        public string Title { get; set; }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.SetAttribute("class", "card bg-dark text-white");

            var contentSb = new StringBuilder()
                .Append("<img class='card-img-top' src='").Append(ImageSource).Append("' alt='").Append(ImageAlt).AppendLine("' />")
                .AppendLine("<div class='card-img-overlay'>")
                .Append("<h5 class='card-title'>").Append(Title).AppendLine("</h5>")
                .AppendLine("</div>");

            output.Content.SetHtmlContent(contentSb.ToString());

            return base.ProcessAsync(context, output);
        }
    }
}