var debug = true;

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

	$("body").on("click", "#analytics-refresh", function () {
		var $button = $(this);

		$button.addClass("analytics-refresh-active");

		updateData().then(
			function () {			
				$button.removeClass("analytics-refresh-active");
			},
			function () { 
				$button.removeClass("analytics-refresh-active");		
			}
		);
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
	if (websiteFilter != null) {
		websiteFilter.onchange = function (e) {
			updateData();
		};
	}

	var viewFilter = document.getElementById("analytics-filter-view-value");
	var viewOptions = viewFilter.getElementsByTagName("input");

	for (var i = 0; i < viewOptions.length; i++) {
		viewOptions[i].onclick = function () {
			updateData();
		};
	}

	var dateFilter = document.getElementById("analytics-filter-dates");
	var dateOptions = dateFilter.getElementsByTagName("input");

	for (var i = 0; i < dateOptions.length; i++) {
		dateOptions[i].onblur = function () {
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

		//console.log(availableWidth);
		//console.log(itemCount);
		//console.log(itemWidth);

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

		setRightLabel(container);
	}
}

function setRightLabel(container) {
	var lastCount = 0;
	var maxCount = 0;

	var cells = getElementsByClassName(container.getElementsByTagName("table")[0], "analytics-count");
	for (var j = 0; j < cells.length; j++) {
		var value = parseInt(cells[j].getElementsByTagName("div")[0].getElementsByTagName("span")[0].innerHTML);

		lastCount = value;
		if (value > maxCount) maxCount = value;
	}

	var labelRight = document.getElementById("analytics-aggregates-y-label-right");
	if (typeof labelRight != "undefined" && labelRight != null) {
		//console.log("label");
		//console.log(lastCount);
		//console.log(maxCount);

		//var mTop = 298 - (298 * lastCount / maxCount);
		//console.log(mTop);
		//labelRight.style.marginTop = mTop + "px";
	}
}

function updateData() {
	var deferred = new $.Deferred();

	var website = document.getElementById("analytics-filter-website-value").value;
	if (typeof website == "undefined") {
		website = document.getElementById("analytics-filter-website-value").innerHTML;
	}

	var view = document.querySelector('input[name=view]:checked').value
	var location = document.getElementById("analytics-filter-location-value").value;
	var startDate = document.getElementById("analytics-filter-date-start").value;
	var endDate = document.getElementById("analytics-filter-date-end").value;

	console.log("update: " + website + ", " + view + ", " + location)

	var url = document.getElementById("analytics-base-url").innerHTML;
	url += view + "?Website=" + website + "&Location=" + location;
	if ("" != startDate) url += "&startDate=" + startDate;
	if ("" != endDate) url += "&endDate=" + endDate;

	document.getElementById("analytics-filter-location").style.display = ((location != "") ? "inline-block" : "none");

	var request = new XMLHttpRequest();

	request.onreadystatechange = function () {
		if (request.readyState == XMLHttpRequest.DONE) {
			if (request.status == 200) {
				var target = document.getElementById("analytics-data");
				target.innerHTML = request.responseText;
				SizeDays();
				deferred.resolve();
			}
			else if (request.status == 400) {
				alert('There was an error 400');
				deferred.reject();
			}
			else {
				alert('something else other than 200 was returned');
				deferred.reject();
			}
		}
	};

	request.open("GET", url, true);
	request.send();

	return deferred.promise();
}
