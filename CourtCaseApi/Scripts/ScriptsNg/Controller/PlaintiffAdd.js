/*app.controller('PlaintiffAdd', ['$scope', 'Service',
    function ($scope, Service) {
        var baseUrl = '/api/Plaintiffs';
        var btnText = "Save";
    $scope.PlaintiffID = 0;
    $scope.SaveUpdate = function () {
        var plaintif = {
            PlaintiffID: $scope.PlaintiffID,
            Fname: $scope.Fname,
            Mname: $scope.Mname,
            Lname: $scope.Lname,
            Gender: $scope.Gender,
            Age : $scope.Age,
            Phone : $scope.Phone,
            Email : $scope.Email,
            City : $scope.City,
            SubCity : $scope.SubCity,
            Kebele : $scope.Kebele,
            HouseNumber: $scope.HouseNumber
        }
        if ($scope.btnText == "Save") {
            var apiRoute = baseUrl + 'SavePlaintiffs';
            var savePlaintiffs = Service.post(apiRoute, plaintif);
            savePlaintiffs.then(function (response) {
                if (response.data != "") {
                    alert('Product Added Successfully');
                    $scope.Clear();
                }
                else {
                    alert("Some error");
                }
            },
        function (error) {
            console.log("hummm !There is error " + error);
        });
        }
    }
    $scope.Clear = function () {
        $scope.PlaintiffID = 0;
        $scope.Fname = "";
        $scope.Lname = "";
        $scope.Mname = "";
        $scope.Gender = "";
        $scope.Age = "";
        $scope.Phone = "";
        $scope.Email = "";
        $scope.City = "";
        $scope.SubCity = "";
        $scope.Kebele = "";
        $scope = HouseNumber = "";

    }

}]);*/