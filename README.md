# Imagager

Webpage that allows users to create a virtual inventory of products which can have a location, name, description, and price; and each location product pair can have a quantity value associated with them. Built using the ASP.NET framework. 

# Usage

## Initiation 

To use, download the [build](https://github.com/mrmaxwellm9/IManager-Build) repository to run the webpage server from an executable, or download this repository if would like to run the webserver via the program cs file. Once the server is running open a web browser and visit the http address the server is listening on.
![alt text](https://raw.githubusercontent.com/mrmaxwellm9/images/main/IManager%20running%20server.png?token=GHSAT0AAAAAACEFFZBSX5N46CT63KRXA3GGZFYFBGA "Server Running Picture")
In the example above the http address you would visit is http://localhost:5000

When the webpage loads you should see the screen below of something similar.
![alt text](https://raw.githubusercontent.com/mrmaxwellm9/images/main/IManager%20blank%20page.png?token=GHSAT0AAAAAACEFFZBTYGXDPCP7REPCFOUYZFYFBSA "Empty Inventory Image")

## Adding Locations

![alt text](https://raw.githubusercontent.com/mrmaxwellm9/images/main/Add%20Location.png?token=GHSAT0AAAAAACEFFZBSCH5VVNVBRUDGWYB6ZFZPRNQ "Add Location Prompt")
To add a location to associate products with, simply click the "Add Location" tab on the top navigation bar, enter the location name in the input popup and finally click "Add Location".

## Adding Products

![alt text](https://raw.githubusercontent.com/mrmaxwellm9/images/main/Add%20Product%20with%20Loc.png?token=GHSAT0AAAAAACEFFZBSLUREDYD52QB2LEL2ZFZPTXQ "Add Product Prompt")
To add a product to the inventory click the "Add Product" tab on the top navigation bar to open the prompt. Then, enter the desired Product ID, Product Name, Product Description, Product Price, and Locations; for locations check the box for each location you which to add and enter the quantity of the product at that location in the input bar above the location name.

## Editing and Removing Products

###### Example inventory with one product (Apple) and one location (California)
![alt text](https://raw.githubusercontent.com/mrmaxwellm9/images/main/Inventory%20with%20one%20product.png?token=GHSAT0AAAAAACEFFZBT5H2DW6M2OPOF52QIZFZP4BQ "Example Inventory")

### Editing

![alt text](https://raw.githubusercontent.com/mrmaxwellm9/images/main/Edit%20menu.png?token=GHSAT0AAAAAACEFFZBTW4DPDDSUCUCZILG4ZFZP4CQ "Edit Prompt")
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

