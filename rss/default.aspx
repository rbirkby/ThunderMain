<%@ Page Language="c#" ContentType="text/xml" ResponseEncoding="utf-8" Debug="false" %>

<%@ OutputCache Duration="3600" VaryByParam="none" %>
<%@ Import Namespace="Sgml" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="System.Xml" %>

<script runat="server">
    void Page_Load(object sender, EventArgs e)
    {
        var output = new XmlDocument();

        XmlDeclaration xmlDeclaration = output.CreateXmlDeclaration("1.0", null, null);
        output.InsertBefore(xmlDeclaration, output.DocumentElement);

        XmlComment poweredByComment = output.CreateComment("\n\n **** Powered by ASP.Net on Azure **** \n\n");
        output.InsertBefore(poweredByComment, output.DocumentElement);

        XmlElement rssElement = output.CreateElement("rss");

        XmlAttribute rssVersionAttribute = output.CreateAttribute("version");
        rssVersionAttribute.InnerText = "2.0";
        rssElement.Attributes.Append(rssVersionAttribute);

        output.AppendChild(rssElement);

        XmlElement channelElement = output.CreateElement("channel");
        rssElement.AppendChild(channelElement);

        XmlElement channelTitleElement = output.CreateElement("title");
        channelTitleElement.InnerText = "Microsoft Download Center";
        channelElement.AppendChild(channelTitleElement);

        XmlElement channelLinkElement = output.CreateElement("link");
        channelLinkElement.InnerText = "http://www.microsoft.com/downloads/";
        channelElement.AppendChild(channelLinkElement);

        XmlElement channelDescriptionElement = output.CreateElement("description");
        channelDescriptionElement.InnerText = "The twenty latest downloads from the Microsoft Download Center. (For personal and non-commercial use only.)";
        channelElement.AppendChild(channelDescriptionElement);

        XmlElement channelLastBuildDateElement = output.CreateElement("lastBuildDate");
        channelLastBuildDateElement.InnerText = DateTime.Now.ToUniversalTime().ToString(new DateTimeFormatInfo().RFC1123Pattern);
        channelElement.AppendChild(channelLastBuildDateElement);

        var sgmlReader = new SgmlReader();
        sgmlReader.DocType = "HTML";
        sgmlReader.CaseFolding = Sgml.CaseFolding.ToLower;
        sgmlReader.Href = "http://www.microsoft.com/download/en/search.aspx?q=t%2a&p=0&r=50&t=&s=availabledate~Descending";

        var downloads = new XmlDocument();
        downloads.Load(new XmlReaderDecorator(sgmlReader));

        XmlNodeList items = downloads.SelectNodes("//*[local-name()='td'][@class='descTD']");

        foreach (XmlElement item in items)
        {
            XmlElement itemElement = output.CreateElement("item");

            XmlElement itemTitleElement = output.CreateElement("title");
            itemTitleElement.InnerText = item.SelectSingleNode("*[local-name()='div'][@class='link']").FirstChild.InnerText;
            itemElement.AppendChild(itemTitleElement);

            XmlElement itemLinkElement = output.CreateElement("link");

            string linkUrl = item.SelectSingleNode("*[local-name()='div'][@class='link']").FirstChild.Attributes["href"].InnerText;
            itemLinkElement.InnerText = "http://www.microsoft.com/en-us/download/" + linkUrl + "#tm";
            itemElement.AppendChild(itemLinkElement);

            XmlElement itemDescriptionElement = output.CreateElement("description");
            itemDescriptionElement.InnerText = item.SelectSingleNode("*[local-name()='div'][@class='description']").InnerText;
            itemElement.AppendChild(itemDescriptionElement);

            if (!linkUrl.StartsWith("http"))
            {
                channelElement.AppendChild(itemElement);
            }
        }

        Response.Write(output.OuterXml);
    }

</script>
