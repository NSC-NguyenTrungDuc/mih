$(document).ready(function() {
	var ul = $("div.steps-container");
	$(ul).find("li.active").prevAll().find("a").removeAttr("href");
});