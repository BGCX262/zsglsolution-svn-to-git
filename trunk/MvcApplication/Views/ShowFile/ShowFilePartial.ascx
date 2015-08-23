<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl"%>
    <script type="text/javascript" src="../../Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="../../flexpaper/js/swfobject/swfobject.js"></script>
    <script type="text/javascript" src="../../flexpaper/js/flexpaper_flash.js"></script>
    <script type="text/javascript">
        $(function() {
            var path = '<%=ViewData["path"] %>';
            var swfVersionStr = "10.0.0";
            var xiSwfUrlStr = "playerProductInstall.swf";
            var flashvars = {
                SwfFile: escape("../../UploadFiles/" + path),
                Scale: 0.6,
                ZoomTransition: "easeOut",
                ZoomTime: 0.5,
                ZoomInterval: 0.1,
                FitPageOnLoad: false,
                FitWidthOnLoad: true,
                PrintEnabled: true,
                FullScreenAsMaxWindow: false,
                ProgressiveLoading: true,

                PrintToolsVisible: true,
                ViewModeToolsVisible: true,
                ZoomToolsVisible: true,
                FullScreenVisible: true,
                NavToolsVisible: true,
                CursorToolsVisible: true,
                SearchToolsVisible: true,

                localeChain: "zh_CN"
            };

            var params = {}
            params.quality = "high";
            params.bgcolor = "#ffffff";
            params.allowscriptaccess = "sameDomain";
            params.allowfullscreen = "true";
            var attributes = {};
            attributes.id = "FlexPaperViewer";
            attributes.name = "FlexPaperViewer";
            swfobject.embedSWF(
                "../../flexpaper/FlexPaperViewer.swf", "flashContent",
                "650", "500",
                swfVersionStr, xiSwfUrlStr,
                flashvars, params, attributes);
            swfobject.createCSS("#flashContent", "display:block;text-align:left;");
        });

    </script>
      
    <div style="position:absolute;">
	    <div id="flashContent"> 
	        <p> 
		        To view this page ensure that Adobe Flash Player version 
				10.0.0 or greater is installed. 
			</p> 
	    </div>
	    <div id="errNoDocument" style="padding-top:10px;">
	        Can't see the document? Running FlexPaper from your local directory? Make sure you have added FlexPaper as trusted. You can do that at <a href="http://www.macromedia.com/support/documentation/en/flashplayer/help/settings_manager04a.html#119065">Adobe's website</a>.  
	    </div> 
    </div>