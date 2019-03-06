# library-manager

Feature: Properties

@mytag
Scenario Outline: Add property
	Given I create a new property (<Address>,<Price>,<Name>,<PropertyDescription>,<Id>)
    	And ModelState is correct
	Then the system should return <StatusCode>

Examples: 
	| Address             | Price   | Name        | PropertyDescription | StatusCode | Id  |
	| London, Essex       | 250.000 | Court House | New Development     | 201        |  1  |
	| Essex, Romford      | 200.000 | New House   | House               | 201        |  2  |
	| London, Soho        | 300.000 | Court House | New Development     | 201        |  3  |
	| London, Wanstead    | 350.000 | New House   | House               | 201        |  4  |
	| London, Stratford   | 370.000 | Court House | New Development     | 201        |  5  |
	| Essex, Liverpool St | 500.000 | New House   | House               | 201        |  6  |
  
  
[Binding]
    public class PropertiesSteps 
    {
        private IRestResponse _restResponse;
        private Property _property;
        private HttpStatusCode _statusCode;
        private List<Property> _properties;
      
         [Given(@"I create a new property \((.*),(.*),(.*),(.*),(.*)\)")]
        public void GivenICreateANewProperty(string Address, decimal Price, string Name, string PropertyDescription, int Id)
        {
            _property = new Property()
            {
                Address = Address,
                Name = Name,
                Price = Price,
                PropertyDescription = PropertyDescription,
                Id = Id
            };

            var request = new HttpRequestWrapper()
                            .SetMethod(Method.POST)
                            .SetResourse("/api/properties/")
                            .AddJsonContent(_property);

            _restResponse = new RestResponse();
            _restResponse = request.Execute();
            _statusCode = _restResponse.StatusCode;

            ScenarioContext.Current.Add("Pro", _property);
        }

        [Given(@"ModelState is correct")]
        public void GivenModelStateIsCorrect()
        {
            Assert.That(() => !string.IsNullOrEmpty(_property.Address));
            Assert.That(() => !string.IsNullOrEmpty(_property.Name));
            Assert.That(() => !string.IsNullOrEmpty(_property.PropertyDescription));
            Assert.That(() => _property.Price.HasValue);
        }

        [Then(@"the system should return properties that match my criteria")]
        public void ThenTheSystemShouldReturn()
        {
            Assert.AreEqual(_statusCode, HttpStatusCode.Created);
        }
}
