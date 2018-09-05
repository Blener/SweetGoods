using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.UI.MVC.Helpers.TagHelpers
{
    [HtmlTargetElement("autocomplete")]
    public class AutocompleteTagHelper : TagHelper
    {
        [HtmlAttributeName("url")]
        public string URL { get; set; }

        [HtmlAttributeName("placeholder")]
        public string Placeholder { get; set; }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";
            output.TagMode = TagMode.SelfClosing;

            output.Attributes.SetAttribute("class", "autocomplete form-control");
            output.Attributes.Add("data-url", URL);
            output.Attributes.Add("placeholder", Placeholder);

            return base.ProcessAsync(context, output);
        }
    }
}