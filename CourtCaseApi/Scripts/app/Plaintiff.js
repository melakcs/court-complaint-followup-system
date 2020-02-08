var app;
(function () {
    'use strict';
    app = angular.module('PlaintiffAdd', []);
    app.controller('PlaintiffAdd', ['$scope', '$http',
function ($scope, $http) {
    var baseUrl = 'http://localhost:1619/api/plaintiffs';
    $scope.btnText = "Save";

    //save and update function
    $scope.SaveUpdate = function () {
        $scope.SaveUpdate = true;
        var plaintif = {

            PlaintiffID: $scope.PlaintiffID,
            Fname: $scope.Fname,
            Mname: $scope.Mname,
            Lname: $scope.Lname,
            Gender: $scope.Gender,
            Age: $scope.Age,
            Phone: $scope.Phone,
            Email: $scope.Email,
            City: $scope.City,
            SubCity: $scope.SubCity,
            Kebele: $scope.Kebele,
            HouseNumber: $scope.HouseNumber
        }
        if ($scope.btnText == "Save") {
            // var apiRoute = baseUrl;
            $http.post(baseUrl, plaintif).then(function (response) {
                if (response.data != "") {
                    alert('Data Saved Successfully');
                    $scope.Clear();
                }
                else {
                    alert("Some error");
                }
            }

       ,
   function (error) {
       console.log("There is error " + error);
   });

        }
        else {
            var apiRoute = baseUrl + '/' + PlaintiffID;
            $http.put(apiRoute, plaintif).then(function (response) {
                if (response.data != "") {
                    alert("Data Updated Successfully");
                    $scope.GetPlaintiffs();
                    $scope.Clear();

                }
                else {
                    alert("Some error");
                }

            }, function (error) {
                console.log("Error: " + error);
            });
            //}

        }
    }

    $scope.Clear = function () {
        //$scope.PlaintiffID = 0;
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
        $scope.HouseNumber = "";

    }
    //Get all plaintiff
    $scope.GetPlaintiffs = function () {
        $http.get(baseUrl).then(function (response) {
            debugger
            $scope.Plaintiffs = response.data;

        },
         function (error) {
             console.log("Error: " + error);
         });


    }
    $scope.GetPlaintiffs();

    //get plaintiff by ID
    $scope.GetPlaintiff = function (Plaintiff) {
        debugger
        var apiRoute = baseUrl + '/' + Plaintiff.PlaintiffID;
        $http.get(apiRoute, Plaintiff.PlaintiffID).then(function (response) {
            $scope.PlaintiffID = response.data.PlaintiffID;
            $scope.Fname = response.data.Fname;
            $scope.Mname = response.data.Mname;
            $scope.Lname = response.data.Lname;
            $scope.Gender = response.data.Gender;
            $scope.Age = response.data.Age;
            $scope.Phone = response.data.Phone;
            $scope.Email = response.data.Email;
            $scope.City = response.data.City;
            $scope.SubCity = response.data.SubCity;
            $scope.Kebele = response.data.Kebele;
            $scope.HouseNumber = response.data.HouseNumber;
            $scope.btnText = "Update";

        },
        function (error) {
            console.log("Error: " + error);
        });
    }

    //delete function
    $scope.DeletePlaintiff = function (Plaintiff) {
        debugger
        var apiRoute = baseUrl + '/' + Plaintiff.PlaintiffID;
        $http.delete(apiRoute).then(function (response) {
            if (response.data != "") {
                alert("Data Delete Successfully");
                $scope.GetPlaintiffs();
                $scope.Clear();

            } else {
                alert("Some error");
            }

        }, function (error) {
            console.log("Error: " + error);
        });
    }

}]);
})();
