using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Janglin.RestApiSdk;
using System.Xml.Linq;

namespace RestApiSdkUnitTest
{
	[TestClass]
	public class ExtentionsUnitTest
	{
		[TestMethod]
		public void AppendSubRoutesTest()
		{
			try { Assert.AreEqual("http://bing.com/search", "".SubRoutes(null)); }
			catch (ArgumentNullException) { }
			Assert.AreEqual("/search", "".SubRoutes("search"));
			Assert.AreEqual("http://bing.com", "http://bing.com".SubRoutes());
			Assert.AreEqual("http://bing.com/search", "http://bing.com".SubRoutes("search"));
			Assert.AreEqual("http://bing.com/search/fart", "http://bing.com".SubRoutes("search", "fart"));
			Assert.AreEqual("http://bing.com/search/fart", "http://bing.com".SubRoutes(new string[] { "search", "fart" }));
		}

		[TestMethod]
		public void AppendParametersTest()
		{
			try { Assert.AreEqual("http://bing.com/?q=farts", "http://bing.com".Parameters(null)); }
			catch (ArgumentNullException) { }
			Assert.AreEqual("http://bing.com", "http://bing.com".Parameters(null, null));
			try { Assert.AreEqual("http://bing.com/?q=farts", "http://bing.com".Parameters("q")); }
			catch (ArgumentException) { }
			Assert.AreEqual("http://bing.com?q=farts", "http://bing.com".Parameters("q", "farts"));
			try { Assert.AreEqual("http://bing.com?q=farts", "http://bing.com".Parameters("q", "farts", "smell")); }
			catch (ArgumentException) { }
			Assert.AreEqual("http://bing.com?q=farts&smell=bad", "http://bing.com".Parameters("q", "farts", "smell", "bad"));
			Assert.AreEqual("http://bing.com?q=farts&smell=bad", "http://bing.com".Parameters("q", "farts", "smell", "bad"));
			Assert.AreEqual("http://bing.com?q=farts", "http://bing.com".Parameters("q", "farts", "", "bad"));
			Assert.AreEqual("http://bing.com?smell=bad", "http://bing.com".Parameters("q", null, "smell", "bad"));
			Assert.AreEqual("http://bing.com?q=farts&open=window", "http://bing.com".Parameters("q", "farts", "", "bad", "open", "window"));
			Assert.AreEqual("http://bing.com?smell=bad&open=window", "http://bing.com".Parameters("q", null, "smell", "bad", "open", "window"));
		}

		[TestMethod]
		public void XmlnsTest()
		{
			Assert.AreEqual(XName.Get("test", "http://www.docusign.com/restapi"), "test".Xmlns());
			Assert.AreEqual(XName.Get("test", "http://www.docusign.com/restapi"), "test".Xmlns("http://www.docusign.com/restapi"));
		}
	}
}
