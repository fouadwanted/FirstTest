using FirstTest.APP;

var operation = new Operations();
var families = operation.GeneratePassengersAndFamilies();
operation.OptimizeFlightSeating(families);