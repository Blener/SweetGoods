using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.UI.MVC
{
    [HtmlTargetElement("form-default")]
    public class FormTagHelper : TagHelper
    {
        [ViewContext, HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.SetAttribute("class", "card");

            output.PreContent.AppendHtml(
                $"<div class='card-body'>");

            output.PostContent.AppendHtml(
                $"<div class='row'>" +
                            $"<input type = 'submit' class='btn btn-primary' value='Salvar' />" +
                        $"</div>" +
                    $"</form>" +
                $"</div>");

            base.Process(context, output);
        }
    }
}