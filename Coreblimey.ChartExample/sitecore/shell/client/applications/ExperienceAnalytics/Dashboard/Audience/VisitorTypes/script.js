
define(["sitecore"], function (sc) {

// Extend the page object..
var extendedPage = sc.Definitions.App.extend({
initialized: function () {
var app = this;

app.PieChart1.on("error", function (error) {
console.log(error);
});


var requestOptions = {
url: "/sitecore/api/visitdata"
, parameters: ""
, onSuccess: function (data) {

console.log("this is the data" +data);
}
};

app.ChartDataProvider1.viewModel.getData(requestOptions);
}
});

return extendedPage;
});


