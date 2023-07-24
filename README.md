# Imagager

Webpage that allows users to create a virtual inventory of products which can have a location, name, description, and price; and each location product pair can have a quantity value associated with them. Built using the ASP.NET framework. 

# Usage

## Initiation 

To use, download the [build](https://github.com/mrmaxwellm9/IManager-Build) repository to run the webpage server from an executable, or download this repository if would like to run the webserver via the program cs file. Once the server is running open a web browser and visit the http address the server is listening on.
![IManager running server](https://github.com/mrmaxwellm9/IManager/assets/130167736/fc24d43d-cd59-4078-be4b-5b9f835a58a4)
In the example above the http address you would visit is http://localhost:5000

When the webpage loads you should see the screen below of something similar.
![IManager blank page](https://github.com/mrmaxwellm9/IManager/assets/130167736/b6abba40-14cf-4da1-80d2-42e8e3c3c9b6)

## Adding Locations

![Add Location](https://github.com/mrmaxwellm9/IManager/assets/130167736/1d82d6f5-1e21-4136-8875-2f09b4fa5138)
To add a location to associate products with, simply click the "Add Location" tab on the top navigation bar, enter the location name in the input popup and finally click "Add Location".

## Adding Products

![Add Product with Loc](https://github.com/mrmaxwellm9/IManager/assets/130167736/5bca0cd3-cb56-490e-a9cd-69fc8c956e32)
To add a product to the inventory click the "Add Product" tab on the top navigation bar to open the prompt. Then, enter the desired Product ID, Product Name, Product Description, Product Price, and Locations; for locations check the box for each location you which to add and enter the quantity of the product at that location in the input bar above the location name.

## Editing and Removing Products

###### Example inventory with one product (Apple) and one location (California)
![Inventory with one product](https://github.com/mrmaxwellm9/IManager/assets/130167736/30b549e6-6030-48d6-b947-6771152f815d)

### Editing

![Edit menu](https://github.com/mrmaxwellm9/IManager/assets/130167736/5270715b-6e0e-41d1-bb53-58402f88b1f6)                                                          
To edit a product in the inventory click the "Edit" button on the right side of the product in the inventory to open an edit prompt, change or add the desired information, and then click "Save Changes"

### Removing

To remove a product in the inventory click the "Remove" button on the right side of the product you wish to remove. This will bring up a confirmation prompt, click "Remove" to confirm and remove the product.

## Additional Features and Program Information

### Features
You can click "Item ID", "Name", "Description", or "Price" to sort the list numerically or alphanumerically based on the row you are sorting.

### Inner Workings
All the data that is accepted or removed by the user is stored or removed from a SQLite database with the .NET entity framework. The SQLite database stores products and locations separately and links them together with a junction table. In the program, the processing of products and locations is done similarly; the location and product (InvItem) classes process their proper information and are linked together with an association class (LocationInvItem).

Most of the backend page processing can be found in the _Layout.cshtml, Inventory.cshtml.cs, and Inventory.cs files in the [pages](https://github.com/mrmaxwellm9/IManager/tree/master/IManager/Pages) folder.

Sorting of the table is done with the [Stupid-table-plugin](https://joequery.github.io/Stupid-Table-Plugin/) by Joseph "joequery" McCullough.

