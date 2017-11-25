﻿var debug = true;

if (window.attachEvent) {
	window.attachEvent('onload', Analytics_OnLoad);
	window.attachEvent('onresize', Analytics_OnResize);
} else {
	if (window.onload) {
		var curronload = window.onload;
		var curronresize = window.onresize;

		var newonload = function (evt) {
			curronload(evt);
			Analytics_OnLoad(evt);
		};
		window.onload = newonload;

		var newonresize = function (evt) {
			curronresize(evt);
			Analytics_OnResize(evt);
		};
		window.onresize = newonresize;
	} else {
		window.onload = Analytics_OnLoad;
		window.onresize = Analytics_OnResize;
	}
}

function Analytics_OnLoad(evt) {
	if (debug) { console.log("onLoad"); }

	SizeDays(evt);
	ActivateMenu(evt);

	$("body").on("click", ".analytics-select-location a", function () {
		$("#analytics-filter-location-value").val($(this).html());
		document.getElementById("vwVisits").checked = true;
		updateData();
		return false;
	});

	$("body").on("click", "#analytics-filter-location .clear", function () {
		$("#analytics-filter-location-value").val("");
		updateData();
	});

}

function Analytics_OnResize(evt) {
	if (debug) { console.log("onResize"); }

	SizeDays(evt);
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

function ActivateMenu() {
	var websiteFilter = document.getElementById("analytics-filter-website-value");
	websiteFilter.onchange = function (e) {
		updateData();
	};

	var viewFilter = document.getElementById("analytics-filter-view-value");
	var viewOptions = viewFilter.getElementsByTagName("input");

	for (var i = 0; i < viewOptions.length; i++) {
		viewOptions[i].onclick = function () {
			updateData();
		};
	}

	//var locationFilter = document.getElementById("analytics-filter-location-value");
	//locationFilter.oninput = function (e) {
	//	updateData();
	//};

	updateData();
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

		console.log(availableWidth);
		console.log(itemCount);
		console.log(itemWidth);

		var cells = getElementsByClassName(table, "analytics-count");

		for (var j = 0; j < cells.length; j++) {
			var div = cells[j].getElementsByTagName("div")[0];
			div.style.height = itemWidth + "px";
		}

		var cells2 = getElementsByClassName(table, "analytics-date");

		for (var j = 0; j < cells2.length; j++) {
			var div = cells2[j].getElementsByTagName("div")[0];
			div.style.height = itemWidth + "px";
		}
	}

}

function updateData() {

	var website = document.getElementById("analytics-filter-website-value").value;
	var view = document.querySelector('input[name=view]:checked').value
	var location = document.getElementById("analytics-filter-location-value").value;

	console.log("update: " + website + ", " + view + ", " + location)

	var url = document.getElementById("analytics-base-url").innerHTML;
	url += view + "?Website=" + website + "&Location=" + location;


	document.getElementById("analytics-filter-location").style.display = ((location != "") ? "block" : "none");

	var request = new XMLHttpRequest();

	request.onreadystatechange = function () {
		if (request.readyState == XMLHttpRequest.DONE) {
			if (request.status == 200) {
				var target = document.getElementById("analytics-data");
				target.innerHTML = request.responseText;
				SizeDays();
			}
			else if (request.status == 400) {
				alert('There was an error 400');
			}
			else {
				alert('something else other than 200 was returned');
			}
		}
	};

	request.open("GET", url, true);
	request.send();
}