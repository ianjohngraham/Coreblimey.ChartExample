
define(["sitecore"], function (sc) {

// Extend the page object..
var extendedPage = sc.Definitions.App.extend({
initialized: function () {
var app = this;

// Log pice chart errors, handy for debugging..
app.PieChart1.on("error", function (error) {
console.log(error);
});

// Create RequestOptions object..
var requestOptions = {
url: "/sitecore/api/visitdata"
, parameters: ""
, onSuccess: function (data) {
// We’ve successfully retrieved data from the server!
console.log("this is the data" +data);
}
};
// Make the ChartDataProvider get the data from the server..
app.ChartDataProvider1.viewModel.getData(requestOptions);
}
});

return extendedPage;
});


