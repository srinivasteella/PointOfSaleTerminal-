# PointOfSaleTerminal-NetCore ![GitHub release](https://img.shields.io/github/release/srinivasteella/PointOfSaleTerminal.svg?style=for-the-badge) ![Maintenance](https://img.shields.io/maintenance/yes/2019.svg?style=for-the-badge)


#### PointOfSaleTerminal- Console App in .netCore2.1 

| ![GitHub Release Date](https://img.shields.io/github/release-date/srinivasteella/PointOfSaleTerminal-.svg?style=plastic) | [![.Net Framework](https://img.shields.io/badge/DotNet-2.1_Framework-blue.svg?style=plastic)](https://www.microsoft.com/net/download/dotnet-core/2.1) | ![GitHub top language](https://img.shields.io/github/languages/top/srinivasteella/PointOfSaleTerminal-.svg) |![GitHub repo size in bytes](https://img.shields.io/badge/repo%20size-18kB-blue.svg) 
| ---          | ---        | ---       | ---      | 

---------------------------------------


## Repository CodeBase
 
The complete app has divided into 2 folders.

The repository consists of projects as below:


| # |Project Name | Project detail | Environment |
| ---| ---  | ---           | --- |
| 1 | drawboardPOS | Asp.Net Core2.1 Console App   | [![.Net Framework](https://img.shields.io/badge/DotNet-2.1_Framework-blue.svg?style=plastic)](https://www.microsoft.com/net/download/dotnet-core/2.1)|
| 2 | drawboardPOS.Test | Unit and Integration Test for drawboardPOS | [![.Net Framework](https://img.shields.io/badge/DotNet-2.1_Framework-blue.svg?style=plastic)](https://www.microsoft.com/net/download/dotnet-core/2.1)| 



### Summary

The main aim of the application is to accept an arbitrary ordering of products (similar to what would happen when actually at a checkout line) then returns the correct total price for an entire shopping cart based on the per unit prices or the volume prices as applicable.

Consider a grocery market where items have prices per unit but also volume prices. For example, doughnuts may be $1.25 each or 3 for $3 dollars. There could only be a single volume discount per product.

Products listed by code and the prices used:


    Product Code Price

    --------------- ---------------

    A         $1.25 each or 3 for $3.00

    B         $4.25

    C         $1.00 or $5 for a six pack

    D         $0.75


## List of Services
Here are the list of services created to calculate total price:

| # |Service Name | Description
| ---| ---  | --- 
| 1 | TerminalService | Delegates task to respective service
| 2 | PriceService | Gets available products and individual price and volume offers of each product
| 3 | ScanService | Scans selected products and group by each product type
| 4 | TotalCalculatorService | Calculates total price of the selected products
| 5 | CalculationService | Helper service to calculate volume|individual product price
| 6 | GroupByItems |Extension method to group selected products

## Test Project

The solution has **Integration** and **Unit Tests** to test all the above services



### Setup Detail

##### Environment Setup Detail

> Download/install   	

>   1. [![VS2017](https://img.shields.io/badge/VS-2017-blue.svg)](https://git-scm.com/downloads) 
>	2. [![.Net Framework](https://img.shields.io/badge/.Net%20Core-2.1-blue.svg)](https://www.microsoft.com/net/download/dotnet-core/2.1) to run the project


##### Project Setup Detail

>   1. Please clone or download the repository from [![github](https://img.shields.io/badge/git-hub-blue.svg?style=plastic)](https://github.com/srinivasteella/PointOfSaleTerminal-) 

>   
##### (a) To Run the drawboardPOS Project
   
>   1. Open solution in **Visual Studio 2017**     
>   2. Build the solution
>   3. Press F5 to run


##### (b) To Run the drawboardPOS.Test Project

>   1. Open solution in **Visual Studio 2017**   
>   2. Goto Test -> Windows -> Test Explorer   
>   3. Click on **Run All**
>



[![HitCount](http://hits.dwyl.io/srinivasteella/PointOfSaleTerminal-/projects/1.svg)](http://hits.dwyl.io/srinivasteella/PointOfSaleTerminal-/projects/1) | ![GitHub contributors](https://img.shields.io/github/contributors/srinivasteella/PointOfSaleTerminal-.svg?style=plastic)|![license](https://img.shields.io/github/license/srinivasteella/PointOfSaleTerminal-.svg?style=plastic)|
 | --- | --- | ---|
