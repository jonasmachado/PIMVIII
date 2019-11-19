using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;

namespace HomeworkBuddy.Web
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString EnumDisplayNameFor(this HtmlHelper html, Enum item)
        {
            var type = item.GetType();
            var member = type.GetMember(item.ToString());
            DisplayAttribute displayname = (DisplayAttribute)member[0].GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault();

            if (displayname != null)
            {
                return new MvcHtmlString(displayname.Name);
            }

            return new MvcHtmlString(item.ToString());
        }
    }

    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString LabelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Func<object, HelperResult> template, object htmlAttributes)
        {
            var label = new TagBuilder("label");

            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string propertyName = metaData.DisplayName ?? (metaData.PropertyName ?? ExpressionHelper.GetExpressionText(expression));

            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);            
            
            label.Attributes["for"] = TagBuilder.CreateSanitizedId(htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName));
            label.InnerHtml = string.Format("{0} {1}", propertyName, template(null).ToHtmlString());
            label.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return MvcHtmlString.Create(label.ToString(TagRenderMode.Normal));
        }


        private static Type GetNonNullableModelType(ModelMetadata modelMetadata)
        {
            Type realModelType = modelMetadata.ModelType;

            Type underlyingType = Nullable.GetUnderlyingType(realModelType);
            if (underlyingType != null)
            {
                realModelType = underlyingType;
            }
            return realModelType;
        }

        private static readonly SelectListItem[] SingleEmptyItem = new[] { new SelectListItem { Text = "", Value = "" } };

        public static string GetEnumDescription<TEnum>(TEnum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if ((attributes != null) && (attributes.Length > 0))
                return attributes[0].Description;
            else
                return value.ToString();
        }

        //public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
        //{
        //    return EnumDropDownListFor(htmlHelper, expression, null);
        //}

        //public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
        //{
        //    ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
        //    Type enumType = GetNonNullableModelType(metadata);
        //    IEnumerable<TEnum> values = Enum.GetValues(enumType).Cast<TEnum>();

        //    IEnumerable<SelectListItem> items = from value in values
        //                                        select new SelectListItem
        //                                        {
        //                                            Text = GetEnumDescription(value),
        //                                            Value = value.ToString(),
        //                                            Selected = value.Equals(metadata.Model)
        //                                        };

        //    // If the enum is nullable, add an 'empty' item to the collection
        //    if (metadata.IsNullableValueType)
        //        items = SingleEmptyItem.Concat(items);

        //    return htmlHelper.DropDownListFor(expression, items, htmlAttributes);
        //}

    }
}