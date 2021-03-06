﻿# T4 Azure Arm Template Generator
This library contains T4 templates for auto-generating Azure ARM template parameter files for environments that are custom defined. Example of environments: "dev", "qa", "prod"

## Requirements:
1. The shape of the json input used by the .tt template **must** match the shape of the C# classes defined in the Input folders or viceversa
2. Depends on .NET 4.6.1
3. VS 2017

## How to run the T4 templates?
1. Download the VS solution locally and build it
2. Modify the **{resourceName].parameters.input.json** file accordingly
3. Open the **{resourceName}.parameters.tt** file and save the file. This will execute the T4 template and generate the parameters per environment output files
4. Click the arrow to the left of the  **{resourceName}.parameters.tt** file name. You should now see **{resourceName}.parameters-{environment}.json** files depending on the environments that were defined in the input .json file
5. In order to use these generated parameters files, you'll need the **{resourceName}.template.json** file which contains the Azure ARM template definition for creating multiple instances of that same namespace based on the autogenerated **{resourceName}.parameters-{environment}.json** file

## Why would you need this?
* Existing definition of Azure ARM templates allows the deployment of multiple instances of Azure resources. This definition, however, supports only the ability to iterate through an array of top-level Azure resources. 
This means that if you have an array of children with grandchildren resources that you need to iterate through as part of a parent resource defined in another array, your only option at the moment is to move that child/grandchildren resources array to the top level and duplicate parent resource information. **In summary, ARM templates do not currently support defining "loops within loops" using json.** 
* This duplication of data becomes tedious to maintain and could lead to engineers making mistakes when copying/pasting information
* To cut down the amount of time a developer or devops engineer would spend creating json ARM template parameter files
* To ensure that there is consistency with naming conventions of Azure resources defined in ARM .json templates

## How it works?
For every top-level Azure resource, you'll find a folder that corresponds to the name of that resource. Under this folder you'll find Input and Output folders:

- The **Input** folder contains the C# Root class and inner classes which **must** map 1-1 to the json object defined in the **
{resourceName}.parameters.input.json** file. 

- The **Output** folder contains the C# Root class and inner classes which **must** map 1-1 to the expected shape of the **{resourceName}.parameters-{environment}.json** file which **must** follow Azure ARM template conventions. 

Once the C# logic gets an instance of this root input class, it'll convert the root input instance object to a Dictionary<string, ResourceParametersRootOutput> dictionary where each key in the dictionary represents the environment that the resource would be created under. 

## Todo
- Add validation logic to insure that the input Root object data is correct
- Add additional T4 templates and c# code to support ALL ARM template resources

## What ARM template resources are currently supported?
Namespaces > Queues

## References: 
[MSDN documentation about creating multiple ARM resources](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-multiple)

[What are Azure ARM templates?](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-overview)
