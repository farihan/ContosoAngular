//'use strict';
(function () {
    var app = angular.module('ContosoRetailDW', ['ui.bootstrap', 'toastr', 'angular-loading-bar'])
        .config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
            cfpLoadingBarProvider.includeSpinner = false;
        }]);

    app.controller('CustomerController', function ($scope, $http, $modal, toastr) {
        $scope.pagingInfo = {
            pagingSize: 12,
            page: 1,
            pageSize: 10,
            sortBy: 'CustomerKey',
            isAsc: true,
            totalItems: 0
        };

        $scope.gridIndex = function (index) {
            return (index + 1) + (($scope.pagingInfo.page - 1) * $scope.pagingInfo.pageSize);
        };

        $scope.setPage = function (pageNo) {
            $scope.pagingInfo.page = pageNo;
        };

        $scope.pageChanged = function () {
            pageInit();
        };

        $scope.sort = function (sortBy) {
            if (sortBy === $scope.pagingInfo.sortBy) {
                $scope.pagingInfo.isAsc = !$scope.pagingInfo.isAsc;
            } else {
                $scope.pagingInfo.sortBy = sortBy;
                $scope.pagingInfo.isAsc = false;
            }
            pageInit();
        };

        $scope.openModal = function (id, html) {
            var modalInstance = $modal.open({
                templateUrl: html,
                controller: 'ModalController',
                size: '',
                resolve: {
                    selectedID: function () {
                        return id;
                    },
                    selectedPagingInfo: function () {
                        return $scope.pagingInfo;
                    }
                }
            });

            modalInstance.result.then(function (refreshCustomers) {
                $scope.customers = refreshCustomers;
            }, function () {
                //$log.info('Modal dismissed at: ' + new Date());
            });
        };

        function loadTotalItems() {
            $http.get('/api/customer/getsize')
            .success(function (data, status, headers, config) {
                $scope.pagingInfo.totalItems = data;
            })
            .error(function (data, status, headers, config) {
                $scope.error = 'Error has occured!';
                toastr.error($scope.error);
            });
        }

        function loadCustomers() {
            $http.get('/api/customer/getallby', { params: $scope.pagingInfo })
            .success(function (data, status, headers, config) {
                $scope.customers = data;
            })
            .error(function (data, status, headers, config) {
                $scope.error = 'Error has occured!';
                toastr.error($scope.error);
            });
        }

        function pageInit() {
            loadTotalItems();
            loadCustomers();
            toastr.info('Load page ' + $scope.pagingInfo.page + ' and sort by ' + $scope.pagingInfo.sortBy);
        }

        pageInit();
    });

    app.controller('ModalController', function ($scope, $modalInstance, $http, selectedID, selectedPagingInfo) {
        $scope.selectedID = selectedID;
        $scope.selectedPagingInfo = selectedPagingInfo;

        $scope.ok = function () {
            closeAndRefreshRepeater();
        };

        $scope.cancel = function () {
            closeAndRefreshRepeater();
        };

        $scope.create = function (customer) {
            if ($scope.createForm.$valid) {
                $scope.isProcessing = true;
                $http({
                    method: 'POST',
                    url: '/api/customer/create',
                    data: {
                        'CustomerLabel': customer.CustomerLabel,
                        'Title': customer.Title,
                        'FirstName': customer.FirstName,
                        'MiddleName': customer.MiddleName,
                        'LastName': customer.LastName,
                        'NameStyle': customer.NameStyle,
                        'BirthDate': customer.BirthDate,
                        'MaritalStatus': customer.MaritalStatus,
                        'Suffix': customer.Suffix,
                        'Gender': customer.Gender,
                        'EmailAddress': customer.EmailAddress,
                        'YearlyIncome': customer.YearlyIncome,
                        'TotalChildren': customer.TotalChildren,
                        'NumberChildrenAtHome': customer.NumberChildrenAtHome,
                        'Education': customer.Education,
                        'Occupation': customer.Occupation,
                        'HouseOwnerFlag': customer.HouseOwnerFlag,
                        'NumberCarsOwned': customer.NumberCarsOwned,
                        'AddressLine1': customer.AddressLine1,
                        'AddressLine2': customer.AddressLine2,
                        'Phone': customer.Phone,
                        'DateFirstPurchase': customer.DateFirstPurchase,
                        'CustomerType': customer.CustomerType,
                        'CompanyName': customer.CompanyName,
                        'ETLLoadID': customer.ETLLoadID,
                        'LoadDate': customer.LoadDate,
                        'UpdateDate': customer.UpdateDate,
                    },
                    headers: { 'Content-Type': 'application/json' }
                })
                .success(function (data, status, headers, config) {
                    $scope.isProcessing = false;
                    toastr.pop('success', 'Create successful...');
                    closeAndRefreshRepeater();
                })
                .error(function (data, status, headers, config) {
                    $scope.error = 'Error has occured!';
                    toastr.pop('error', $scope.error);
                });
            }
        };

        $scope.update = function (customer) {
            if ($scope.editForm.$valid) {
                $scope.isProcessing = true;
                $http({
                    method: 'PUT',
                    url: '/api/customer/edit/' + customer.CustomerKey,
                    data: {
                        'CustomerKey': customer.CustomerKey,
                        'GeographyKey': customer.GeographyKey,
                        'CustomerLabel': customer.CustomerLabel,
                        'Title': customer.Title,
                        'FirstName': customer.FirstName,
                        'MiddleName': customer.MiddleName,
                        'LastName': customer.LastName,
                        'NameStyle': customer.NameStyle,
                        'BirthDate': customer.BirthDate,
                        'MaritalStatus': customer.MaritalStatus,
                        'Suffix': customer.Suffix,
                        'Gender': customer.Gender,
                        'EmailAddress': customer.EmailAddress,
                        'YearlyIncome': customer.YearlyIncome,
                        'TotalChildren': customer.TotalChildren,
                        'NumberChildrenAtHome': customer.NumberChildrenAtHome,
                        'Education': customer.Education,
                        'Occupation': customer.Occupation,
                        'HouseOwnerFlag': customer.HouseOwnerFlag,
                        'NumberCarsOwned': customer.NumberCarsOwned,
                        'AddressLine1': customer.AddressLine1,
                        'AddressLine2': customer.AddressLine2,
                        'Phone': customer.Phone,
                        'DateFirstPurchase': customer.DateFirstPurchase,
                        'CustomerType': customer.CustomerType,
                        'CompanyName': customer.CompanyName,
                        'ETLLoadID': customer.ETLLoadID,
                        'LoadDate': customer.LoadDate,
                        'UpdateDate': customer.UpdateDate,
                    },
                    headers: { 'Content-Type': 'application/json' }
                })
                .success(function (data, status, headers, config) {
                    $scope.isProcessing = false;
                    toastr.pop('success', 'Update successful...');
                    closeAndRefreshRepeater();
                })
                .error(function (data, status, headers, config) {
                    $scope.error = 'Error has occured!';
                    toastr.pop('error', $scope.error);
                });
            }
        };

        $scope.delete = function (id) {
            $scope.isProcessing = true;
            $http.delete('/api/customer/delete', {
                params: { 'id': id }
            })
            .success(function (data, status, headers, config) {
                $scope.isProcessing = false;
                toastr.pop('success', 'Delete successful...');
                closeAndRefreshRepeater();
            })
            .error(function (data, status, headers, config) {
                $scope.error = 'Error has occured!';
                toastr.pop('error', $scope.error);
            });
        };

        function getAvailableGeographies() {
            $scope.availableDimGeography = [];
            $http.get('/api/geography/getall')
            .success(function (data, status, headers, config) {
                $.each(data, function (index, item) {
                    $scope.availableDimGeography.push({ ID: item.GeographyKey, Name: item.GeographyKey });
                });
            })
            .error(function (data, status, headers, config) {
                $scope.error = 'Error has occured!';
                toastr.pop('error', $scope.error);
            });
        }

        function loadCustomer() {
            $scope.customer = null;
            $http.get('/api/customer/get', { params: { id: $scope.selectedID } })
            .success(function (data, status, headers, config) {
                $scope.customer = data;
            })
            .error(function (data, status, headers, config) {
                $scope.error = 'Error has occured!';
                toastr.pop('error', $scope.error);
            });
        }

        function loadTotalItems() {
            $http.get('/api/customer/getsize')
            .success(function (data, status, headers, config) {
                $scope.selectedPagingInfo.totalItems = data;
            })
            .error(function (data, status, headers, config) {
                $scope.error = 'Error has occured!';
                toastr.pop('error', $scope.error);
            });
        }

        function loadCustomers() {
            $http.get('/api/customer/getallby', { params: $scope.selectedPagingInfo })
            .success(function (data, status, headers, config) {
                $scope.refreshCustomers = data;
                $modalInstance.close(data);
            })
            .error(function (data, status, headers, config) {
                $scope.error = 'Error has occured!';
                toastr.pop('error', $scope.error);
            });
        }

        function closeAndRefreshRepeater() {
            toastr.pop('info', 'Unload modal...');
            loadTotalItems();
            loadCustomers();
        }

        function pageInit() {
            toastr.pop('info', 'Load modal...');
            getAvailableGeographies();
            if ($scope.selectedID != '')
                loadCustomer();
        }

        pageInit();
    });

})();