To run this project in Visual Studio 2019, open the LINQSample.sln
To run this project in Visual Studio Code, open the folder \LINQSamples

SampleViewModel Samples
--------------------------------------------------
WhereExpression() - Filter products using where. If the data is not found, an empty list is returned
WhereTwoFields() - Filter products using where with two fields. If the data is not found, an empty list is returned
WhereExtensionMethod() - Filter products using a custom extension method
Find() - Locate a specific product using the Find() method. NOTE: Find() only works on List<T> not IEnumerable<T>
First() - Locate a specific product using First(). First() searches forward in the collection. NOTE: First() throws an exception if the result does not produce any values
FirstOrDefault() - Locate a specific product using FirstOrDefault(). FirstOrDefault() searches forward in the list. NOTE: FirstOrDefault() returns a null if no value is found
Last() - Locate a specific product using Last(). Last() searches from the end of the list backwards. NOTE: Last returns the last value from a collection, or throws an exception if no value is found
LastOrDefault() - Locate a specific product using LastOrDefault(). LastOrDefault() searches from the end of the list backwards. NOTE: LastOrDefault returns the last value in a collection or a null if no values are found
Single() - Locate a specific product using Single(). NOTE: Single() expects only a single element to be found in the collection, otherwise an exception is thrown
SingleOrDefault() - Locate a specific product using SingleOrDefault(). NOTE: SingleOrDefault() returns a single element found in the collection, or a null value if none found in the collection, if multiple values are found an exception is thrown.
