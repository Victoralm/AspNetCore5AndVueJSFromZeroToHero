using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppyHtmlHelper
{
    [HtmlTargetElement("shoppy-input")]
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

        [HtmlAttributeName("inputIcon")]
        public string inputIcon { get; set; }
        
        [HtmlAttributeName("spanIconId")]
        public string spanIconId { get; set; }
        
        [HtmlAttributeName("inputPlaceholder")]
        public string inputPlaceholder { get; set; }
        
        [HtmlAttributeName("inputAriaLabel")]
        public string inputAriaLabel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagOnly;
            value = value == null && For.Model != null ? For.Model.ToString() : value;
            inputAriaLabel = inputAriaLabel == null ? $"{For.Metadata.DisplayName}" : $"{inputAriaLabel}";
            var ariaDescribedBy = $"{spanIconId} {inputAriaLabel}-error";
            TagBuilder tagInput = new TagBuilder("input");
            tagInput.Attributes.Add("id", For.Name.Replace(".", "_"));
            tagInput.Attributes.Add("name", For.Name);
            tagInput.Attributes.Add("type", type);
            tagInput.Attributes.Add("value", value);
            tagInput.Attributes.Add("aria-describedby", ariaDescribedBy);
            tagInput.Attributes.Add("aria-label", inputAriaLabel);

            if (type == "hidden")
            {
                tagInput.AddCssClass(addClass == null ? "" : addClass);
                output.TagName = "";
                output.PostElement.AppendHtml(tagInput);
            }
            else
            {
                if (type == null)
                {
                    type = For.Metadata.DataTypeName != null ? For.Metadata.DataTypeName : "text";
                }

                tagInput.AddCssClass(addClass == null ? "form-control" : $"form-control {addClass}");
                //tagInput.Attributes.Add("placeholder", For.Metadata.DisplayName);
                tagInput.Attributes.Add("placeholder", inputAriaLabel);
                tagInput.TagRenderMode = TagRenderMode.SelfClosing;

                if (For.Metadata.IsRequired)
                {
                    //tagInput.Attributes.Add("required", "required"); // Commented so the validation messages works
                    tagInput.Attributes.Add("data-val", For.Metadata.ShowForDisplay.ToString().ToLower());

                    var validatorMetadata = For.Metadata.ValidatorMetadata;
                    if (validatorMetadata != null && validatorMetadata.Count > 0)
                    {
                        var metadata = For.Metadata;
                        var prop = metadata.ContainerType.GetProperty(metadata.PropertyName);
                        var attrs = prop.GetCustomAttributes(false);
                        var required = attrs.OfType<RequiredAttribute>().FirstOrDefault();

                        if(required != null)
                        {
                            tagInput.Attributes.Add("data-val-required", required.ErrorMessage);
                        }

                        var minLength = attrs.OfType<MinLengthAttribute>().FirstOrDefault();
                        if (minLength != null)
                        {
                            tagInput.Attributes.Add("data-val-minlength-min", minLength.Length.ToString());
                            tagInput.Attributes.Add("data-val-minlength", minLength.ErrorMessage);
                        }

                        var maxLength = attrs.OfType<MaxLengthAttribute>().FirstOrDefault();
                        if (maxLength != null)
                        {
                            tagInput.Attributes.Add("data-val-maxlength-max", maxLength.Length.ToString());
                            tagInput.Attributes.Add("data-val-maxlength", maxLength.ErrorMessage);
                            tagInput.Attributes.Add("maxLength", maxLength.Length.ToString());
                        }

                        var dataType = attrs.OfType<DataTypeAttribute>().FirstOrDefault();
                        if (dataType != null && type == null)
                        {
                            tagInput.Attributes.Add("type", dataType.DataType.ToString());
                        }
                    }
                    else
                    {
                        tagInput.Attributes.Add("data-val-required", $"{For.Metadata.DisplayName} is required");
                    }
                }

                var tagSpan = new TagBuilder("span");
                tagSpan.Attributes.Add("class", "text-danger filed-validation-valid");
                tagSpan.Attributes.Add("data-valmsg-for", For.Name);
                tagSpan.Attributes.Add("data-valmsg-replace", "true");

                var iconStr = "";
                if (inputIcon != null)
                {
                    iconStr = $"<span class='{thrirdClass}' id='{spanIconId}'><i class='ti-{inputIcon}'></i></span>";
                }

                output.PreElement.AppendHtml(@$"
                    <div class='form-group'>
                        <label for='{For.Name.Replace(".", "_")}'>{For.Metadata.DisplayName}</label>
                        <div class='{firstclass}'>
                            <div class='{secondClass}'>
                                {iconStr}
                            </div>
                    ");

                output.TagName = "";
                output.PostContent.AppendHtml(tagInput);
                output.PostContent.AppendHtml(@$"
                        <div class='{fifthClass}'>
                    ");
                output.PostContent.AppendHtml(tagSpan);
                output.PostContent.AppendHtml($@"
                            </div>
                        </div>
                    </div>
                    ");

            }

            base.Process(context, output);
        }

    }
}
