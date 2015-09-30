﻿<!DOCTYPE html>
<html>
<head>
    <title>@ViewData("Title")</title>
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
    
    <script src="@Url.Content("~/Scripts/jquery-1.9.1.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jquery.signalR-1.0.1.js")" type="text/javascript"></script> 
    <script src="@Url.Content("~/signalr/hubs")" type="text/javascript"></script>
</head>

<body>
    <div class="page">

        <div id="header">
            <div id="title">
                <h1>My MVC Chat</h1>
            </div>           

            <div id="menucontainer">

                <ul id="menu">
                    <li>@Html.ActionLink("Home", "Index", "Home")</li>
                    <li>@Html.ActionLink("About", "About", "Home")</li>
                </ul>

            </div>
        </div>

        <div id="main">
            @RenderBody()
            <div id="footer">
            </div>
        </div>
    </div>
</body>
</html>