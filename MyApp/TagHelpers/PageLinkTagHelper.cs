using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.TagHelpers
{
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PageViewModel PageModel { get; set; }
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "div";

            int countTags = 14; // Переменная отвечающая за количество тэг-хелперов на странице просмотра, можно изменять как удобно

                                // По сути следовало бы сделать параметр, который бы отвечал за отображение ровно 28 элементов, как в левую
                                // так и в правую сторону, и сделать ограничения и условия для страниц выше 100, но тогда нужно ставить и ограничения
                                // для страниц выше тысячи, и более простым и правильным решением будет привязать размер и количество страниц к размеру
                                // таблицы, но этого делать я пока не умею. Да и в целом этой мой первый ASP.NET проект.. HelloWorld, как говорится

            // набор ссылок будет представлять список ul
            TagBuilder tag = new TagBuilder("ul");
            tag.AddCssClass("pagination");

            // формируем ссылку на текущую страницу
            TagBuilder currentItem = CreateTag(PageModel.PageNumber, urlHelper);

            // создаем ссылки на предыдущие страницы, если они есть
            if (PageModel.PageNumber < countTags + 1)
            {
                for (int i = 1; i < PageModel.PageNumber && i < countTags; i++)
                {
                    TagBuilder prevItem = CreateTag(i, urlHelper);
                    tag.InnerHtml.AppendHtml(prevItem);
                }
            }
            else
            {
                for (int i = PageModel.PageNumber - countTags; i < PageModel.PageNumber; i++)
                {
                    TagBuilder prevItem = CreateTag(i, urlHelper);
                    tag.InnerHtml.AppendHtml(prevItem);
                }
            }
            tag.InnerHtml.AppendHtml(currentItem);
            // создаем ссылки на следующие страницы, если они есть
            for (int i = PageModel.PageNumber + 1; i <= PageModel.TotalPages && i - PageModel.PageNumber < countTags; i++)
            {
                TagBuilder nextItem = CreateTag(i, urlHelper);
                tag.InnerHtml.AppendHtml(nextItem);
            }

            output.Content.AppendHtml(tag);
        }

        TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
        {
            TagBuilder item = new TagBuilder("li");
            TagBuilder link = new TagBuilder("a");
            if (pageNumber == this.PageModel.PageNumber)
            {
                item.AddCssClass("active");
            }
            else
            {
                PageUrlValues["page"] = pageNumber;
                link.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
            }
            item.AddCssClass("page-item");
            link.AddCssClass("page-link");
            link.InnerHtml.Append(pageNumber.ToString());
            item.InnerHtml.AppendHtml(link);
            return item;
        }
    }
}
