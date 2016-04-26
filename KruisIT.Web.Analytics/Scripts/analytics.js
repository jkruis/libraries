if (window.attachEvent) {
	window.attachEvent('onload', SizeDays);
	window.attachEvent('onresize', SizeDays);
} else {
	if (window.onload) {
		var curronload = window.onload;
		var curronresize = window.onresize;

		var newonload = function (evt) {
			curronload(evt);
			SizeDays(evt);
		};
		window.onload = newonload;

		var newonresize = function (evt) {
			curronresize(evt);
			SizeDays(evt);
		};
		window.onresize = newonresize;
	} else {
		window.onload = SizeDays;
		window.onresize = SizeDays;
	}
}

function getStyle(el, styleProp) {
	if (el.currentStyle)
		var y = el.currentStyle[styleProp];
	else if (window.getComputedStyle)
		var y = document.defaultView.getComputedStyle(el, null).getPropertyValue(styleProp);
	return y;
}

function getElementsByClassName(el, name) {

	if (document.getElementsByClassName) {
		return el.getElementsByClassName(name);
	} else {
		return el.querySelectorAll(name);
	}
}

function SizeDays() {
	var containers = getElementsByClassName(document, "analytics-aggregates-rotated");
	

	for (var i = 0; i < containers.length; i++) {
		var container = containers[i];
		var table = container.getElementsByTagName("table")[0];
		
		var paddingLeft = getStyle(container, "padding-left").replace("px", "");
		var paddingRight = getStyle(container, "padding-right").replace("px", "");

		var availableWidth = container.offsetWidth - paddingLeft - paddingRight;
		var itemCount = getElementsByClassName(table, "analytics-count").length;
		var itemWidth = availableWidth / itemCount;

		//console.log(availableWidth);
		//console.log(itemCount);
		//console.log(itemWidth);

		var cells = getElementsByClassName(table, "analytics-count");

		for (var j = 0; j < cells.length; j++) {
			var div = cells[j].getElementsByTagName("div")[0];
			div.style.height = itemWidth + "px";
		}
	}

}