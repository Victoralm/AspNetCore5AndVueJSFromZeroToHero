using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppyHtmlHelper
{
    public class ShoppyInputTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        [HtmlAttributeName("type")]
        public string type { get; set; }

        [HtmlAttributeName("addClass")]
        public string addClass { get; set; }

        [HtmlAttributeName("asp-value")]
        public string value { get; set; }

        [HtmlAttributeName("firstClass")]
        public string firstclass { get; set; } = "input-group mb-3";

        [HtmlAttributeName("secondClass")]
        public string secondClass { get; set; } = "input-group-prepend";

        [HtmlAttributeName("thrirdClass")]
        public string thrirdClass { get; set; } = "input-group-text";

        [HtmlAttributeName("fourthClass")]
        public string fourthClass { get; set; } = "form-control";

        [HtmlAttributeName("fifthClass")]
        public string fifthClass { get; set; } = "col-12 row";

        [HtmlAttributeName("sixthClass")]
        public string sixthClass { get; set; } = "text-danger";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagOnly;
            TagBuilder tagInput = new TagBuilder("input");
            tagInput.Attributes.Add("id", For.Name.Replace(".", "_"));
            tagInput.Attributes.Add("name", For.Name);
            tagInput.Attributes.Add("type", type);

            if (type == "hidden")
            {
                tagInput.AddCssClass(addClass == null ? "" : addClass);
                output.TagName = "";
                output.PostElement.AppendHtml(tagInput);
            }

            base.Process(context, output);
        }

    }
}
